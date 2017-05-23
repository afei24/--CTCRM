using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;
using System.Web;
using System.Web.Caching;
using System.Net;
using System.Net.Sockets;
using System.Timers;
using System.Threading;
using MeesageAtuoSendService.TOPCRM;
using Top.Api.Response;
using Top.Api.Domain;
using CTCRM.Common;
using System.Data;
using CTCRM.Entity;
using CHENGTUAN.Components;
using CHENGTUAN.Entity;
using System.Collections;
using Top.Api.Util;
using CTCRM.Components.TopCRM;
using Top.Api;
using Top.Api.Request;
using System.IO;


namespace MeesageAtuoSendService
{
    public class ThreadManager
    {
        /// <summary>
        /// 客户端列表
        /// </summary>
        public class ClientItem
        {
            public string ShopId { get; set; }
            public Socket Sockets { get; set; }
            public bool Sending { get; set; }
            public int Step { get; set; }
        }

        public class ClientList
        {
            public List<ClientItem> Items { get; set; }
        }
        public static readonly string CONNECT_CACHE = "CONNECT_LIST";
        public static readonly string SOCKET_CACHE = "SOCKET_LIST";
        private static readonly string PORT = ConfigurationManager.AppSettings["Port"];
        private static readonly string BACK_LOG = ConfigurationManager.AppSettings["BackLog"];
        //自动短信提醒定时器
        private static readonly string SEND_MESSAGE_DO_INTERVAL = ConfigurationManager.AppSettings["SendMessageTimeSpan"];

        private IPEndPoint ServerInfo; //存放服务器IP和端口信息
        private Socket ServerSocket;   //服务端运行的SOCKET
        private Thread ServerThread;   //服务端运行的线程
        private byte[] MsgBuffer; //存放消息数据
        private System.Timers.Timer sendMessageDoTimer;

        private ClientList getClientsCache()
        {
            var obj = HttpRuntime.Cache[SOCKET_CACHE] as ClientList;
            if (obj == null)
            {
                obj = new ClientList();
                obj.Items = new List<ClientItem>();
                HttpRuntime.Cache.Add(SOCKET_CACHE, obj, null, DateTime.Now.AddDays(1d), Cache.NoSlidingExpiration, CacheItemPriority.High, null);
            }
            return obj;
        }

        private void AddClientToCache(ClientItem item)
        {
            var list = getClientsCache();
            if (list != null)
            {
                list.Items.Add(item);
            }
        }

        private void RemoveClientFromCache(string shopId)
        {
            var list = getClientsCache();
            foreach (ClientItem q in list.Items)
            {
                if (q.ShopId == shopId)
                {
                    list.Items.Remove(q);
                    break;
                }
            }
        }

        private ClientItem findClientItem(string shopId)
        {
            var list = getClientsCache();

            foreach (ClientItem item in list.Items)
            {
                if (item.ShopId.ToLower() == shopId.ToLower())
                {
                    return item;
                }
            }
            return null;
        }

        private ClientItem findClientItemByEndPoint(IPEndPoint ep)
        {
            var list = getClientsCache();

            for (var i = list.Items.Count - 1; i >= 0; i--)
            {
                ClientItem item = list.Items[i];
                IPEndPoint iep = (IPEndPoint)item.Sockets.RemoteEndPoint;
                if (iep.Address.Equals(ep.Address) && iep.Port == ep.Port)
                {
                    if (!item.Sockets.Connected)
                    {
                        list.Items.Remove(item);
                        continue;
                    }
                    return item;
                }
            }
            return null;
        }

        /// <summary>
        /// 启动监听线程 
        /// </summary>
        public void StartCTCRMListenThread()
        {
            //测试
            //MobileMsg.SendMsgHubeiYDPost("15800930232", "【急钻风】老板，您已经开启物流提醒服！");
            //定时处理 -------用于定时刷新令牌防止令牌过期不能读取API数据
            sendMessageDoTimer = new System.Timers.Timer();
            sendMessageDoTimer.Enabled = true;
            sendMessageDoTimer.Interval = int.Parse(SEND_MESSAGE_DO_INTERVAL);
            sendMessageDoTimer.Elapsed += new ElapsedEventHandler(SendMessageDoTimer_Elapsed);
            ////创建监听SOCKET
            ServerSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            ////设置SOCKET允许多个SOCKET访问同一个本地IP地址和端口号
            ServerSocket.SetSocketOption(SocketOptionLevel.Socket, SocketOptionName.ReuseAddress, true);
            ServerInfo = new IPEndPoint(IPAddress.Any, int.Parse(PORT));
            ServerSocket.Bind(ServerInfo);
            Console.WriteLine("店铺管家物流提醒NewV—短信自动发送中.....");
            ServerSocket.Listen(int.Parse(BACK_LOG));
            MsgBuffer = new byte[2048];
            ServerThread = new Thread(onListen);
            ServerThread.Start();
        }

        public class StateObject
        {
            // Client  socket.
            public Socket workSocket = null;
            // Size of receive buffer.
            public const int BufferSize = 1024;
            // Receive buffer.
            public byte[] buffer = new byte[BufferSize];
            // Received data string.
            public StringBuilder sb = new StringBuilder();
        }

        /// <summary>
        /// 开始监听 [当前采用异步接收策略]
        /// </summary>
        private void onListen()
        {
            while (true)
            {
                Socket appSocket = ServerSocket.Accept();
                IPEndPoint clientip = (IPEndPoint)appSocket.RemoteEndPoint;
                Console.WriteLine("Connect With Client:" + clientip.Address + " At Port:" + clientip.Port);
                StateObject state = new StateObject();
                state.workSocket = appSocket;
                appSocket.BeginReceive(state.buffer, 0, StateObject.BufferSize, 0, new AsyncCallback(RecieveCallBack), state);
            }
        }

        /// <summary>
        /// 接收客户端信息回调函数
        /// </summary>
        /// <param name="AR"></param>
        private void RecieveCallBack(IAsyncResult AR)
        {

        }

        private bool GetArrived(string strCity, LogisticsTraceSearchResponse lt, out DateTime dtTime)
        {
            dtTime = new DateTime();
            int index;

            try
            {
                strCity = strCity.Trim();
                if (strCity.Length > 0)
                {
                    if (strCity[strCity.Length - 1] == '市' || strCity[strCity.Length - 1] == '州')
                        strCity = strCity.Substring(0, strCity.Length - 1);
                }
                if (strCity.Length > 0)
                {
                    for (int i = 0; i < lt.TraceList.Count; i++)
                    {
                        if (string.IsNullOrEmpty(lt.TraceList[i].StatusDesc))
                        {
                            continue;
                        }
                        index = lt.TraceList[i].StatusDesc.IndexOf(strCity);
                        if (index >= 0)
                        {
                            if (lt.TraceList[i].StatusDesc.LastIndexOf("发往", index) < 0 && lt.TraceList[i].StatusDesc.LastIndexOf("发出", index) < 0)
                            {
                                DateTime.TryParse(lt.TraceList[i].StatusTime, out dtTime);
                                return true;
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                ExceptionReporter.WriteLog(ex, ExceptionPostion.TBApply_Data);
            }
            return false;
        }


        private void SendMsgForCommon(string sellerNick, string transNumber, string cellphone, string content)
        {
            //if (AutoMsgDB.IsAutoMsgWhiteList(sellerNick))
            //{
                //string sendStatus = "0";
            
            
                string phoneType = "";
                //IDictionary resultDic = null;

                string sendStatus = SendMsg(transNumber, sellerNick, content);
                if (!Utility.IsYiDongCellPhoneNo(cellphone))//电信联通通道
                {
                    try
                    {
                        phoneType = "电信联通";
                        //sendStatus = MobileMsg.PostDataToMyServer(cellphone, content, "");
                        //resultDic = TopUtils.ParseJson(sendStatus);
                        AutoMsgDB.UpdateMsgSendHisStatus(transNumber, sendStatus, phoneType);
                    }
                    catch (Exception ex)
                    {
                        ExceptionReporter.WriteLog(ex, ExceptionPostion.TBApply_Data);
                    }
                }
                else
                {
                    try
                    {
                        //移动通道
                        phoneType = "移动";
                        //sendStatus = MobileMsg.PostDataToMyServerTX(cellphone, content, "");
                        //sendStatus = sendStatus.Replace("\r", "").Replace("\n", "");
                        if (sendStatus.Equals("0")) { sendStatus = "100"; }
                        AutoMsgDB.UpdateMsgSendHisStatus(transNumber, sendStatus, phoneType);
                    }
                    catch (Exception ex)
                    {
                        ExceptionReporter.WriteLog(ex, ExceptionPostion.TBApply_Data);
                    }
                }
            //}
        }

        //检查告警类型 2016-10-16 yao c
        int checkWarnTypeExist(DataTable dt, string type)
        {
            if (dt != null && dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    if (string.IsNullOrEmpty(Convert.ToString(dt.Rows[i]["warnType"])) == false)
                    {
                        if (Convert.ToString(dt.Rows[i]["warnType"]).Equals(type) == true)
                        {
                            if (Convert.ToInt16(dt.Rows[i]["unPayType"]) == 1)
                            {
                                return i;
                            }
                            return -1;
                        }
                    }
                }
            }
            return -1;
        }

        /// <summary>
        /// 检查买家的地区是否在Listarea里面
        /// </summary>
        /// <param name="arelist"></param>
        /// <param name="buyerArea"></param>
        /// <returns></returns>
        bool IsInAreaList(string arelist, string buyerArea)
        {
            if (string.IsNullOrEmpty(arelist) == false)
            {
                string[] list = arelist.Split(',');
                foreach (string area in list)
                {
                    if (area.Equals(buyerArea) == true)
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        //是否3天内发送过短信
        bool isSendMsgInThreeDay()
        {

            return true;
        }      

        /// <summary>
        /// 卖家短信自动分发
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        bool busySend = false;
        private void SendMessageDoTimer_Elapsed(object sender, ElapsedEventArgs e)
        //void  test()
        {
            //疲劳度控制
            if (!Utility.CheckCanSendEmail())
            { return; }
            Console.WriteLine(DateTime.Now.ToShortDateString() + "自动分发starting.........！");
            try
            {
                //查询同步过来的消息MESSAGE

                DataTable tbTrade = AutoMsgDB.GetTradeData("");
                //如果该卖家有消息推送
                if (!busySend && tbTrade != null && tbTrade.Rows.Count > 0)
                {
                    //Console.WriteLine("获取到订单！");
                    busySend = true;
                    foreach (DataRow row in tbTrade.Rows)//轮训通知消息
                    {
                        string sellerNick = row["seller_nick"].ToString();
                        string status = row["status"].ToString();
                        string createDate = row["createDate"].ToString();
                        string modifyDate = row["modified"].ToString();
                        string payment = row["payment"].ToString();
                        string buyer_nick = row["buyer_nick"].ToString();
                        string tid = row["tid"].ToString();
                        string ret = LogisticsBLL.getLogisticsStatusByTid(tid);
                        Trade trade = null;
                        //检查卖家短信数量
                        DataTable tbSellerMsgAcount = AutoMsgDB.GetSellerMsgAcount(sellerNick);
                        if (tbSellerMsgAcount != null && tbSellerMsgAcount.Rows.Count > 0
                            && Convert.ToInt32(tbSellerMsgAcount.Rows[0]["msgCanUseCount"].ToString()) > 0)
                        {
                            string msgCount = tbSellerMsgAcount.Rows[0]["msgCanUseCount"].ToString();
                            //get session key
                            DataTable tbSeller = AutoMsgDB.GetSellerInfo(sellerNick);
                            string sessionKey = "";
                            string signShopeName = "";
                            if (tbSeller != null && tbSeller.Rows.Count == 1)
                            {
                                sessionKey = tbSeller.Rows[0]["SESSKEY"].ToString();
                                signShopeName = tbSeller.Rows[0]["SignShopName"].ToString();
                            }
                            if (signShopeName.Trim().Equals("undefined"))
                            {
                                signShopeName = "";
                            }
                            //get the rule which belongs to seller
                            DataTable trRule = AutoMsgDB.GetAutoMsgRuleData(sellerNick);
                            if (trRule != null)
                            {
                                //发送之前检查是否今天该买家已经收到了消息
                                try
                                {
                                    if (!AutoMsgDB.CheckHisSend(sellerNick, buyer_nick, "催款提醒"))
                                    {
                                        #region 催款提醒
                                        DateTime enter;
                                        if (DateTime.TryParse(createDate, out enter))
                                        {
                                            TimeSpan totalSpan = DateTime.Now - Convert.ToDateTime(createDate);
                                            if (status.Equals("taobao_trade_TradeCreate") && totalSpan.Hours > 2)//创建订单后2小时还未付款则催款
                                            {
                                                //检查卖家是否开启了催款提醒
                                                int num = checkWarnTypeExist(trRule, "notplay");
                                                if (num != -1)
                                                {
                                                    var amount = trRule.Rows[num]["amount"].ToString();
                                                    var amountMax = trRule.Rows[num]["amountMax"].ToString();
                                                    //过滤金额
                                                    if (Double.Parse(payment) >= Double.Parse(amount) && Double.Parse(payment) < Double.Parse(amountMax))
                                                    {
                                                        //查看卖家短信是否足够
                                                        if (Convert.ToInt32(tbSellerMsgAcount.Rows[0]["msgCanUseCount"].ToString()) > 0)
                                                        {
                                                            MsgSendHis objHis = null;
                                                            trade = MeesageAtuoSendService.TOPCRM.TBTrade.GetTradeContact(Convert.ToInt64(tid), sessionKey);
                                                            bool Isok = true;
                                                            //黑名单过滤
                                                            if (Convert.ToInt16(trRule.Rows[num]["unPayType"]) == 1)
                                                            {
                                                                if (AutoMsgDB.IsBlackListName(sellerNick, buyer_nick, "催付提醒") == true)
                                                                {
                                                                    Isok = false;
                                                                }
                                                            }
                                                            //过滤地区
                                                            if (Convert.ToInt16(trRule.Rows[num]["areaType"]) == 1)
                                                            {
                                                                if (IsInAreaList(Convert.ToString(trRule.Rows[num]["areaList"]), trade.ReceiverCity) == true)
                                                                {
                                                                    Isok = false;
                                                                }
                                                            }
                                                            //过滤后满足所有条件
                                                            if (Isok == true)
                                                            {
                                                                //get the cellphone no
                                                                string cellPhone = trade == null ? "" : trade.ReceiverMobile;
                                                                if (!String.IsNullOrEmpty(cellPhone) && Utility.IsCellPhone(cellPhone))
                                                                {
                                                                    #region send msg
                                                                    objHis = new MsgSendHis();
                                                                    objHis.TransNumber = tid + "unpay";
                                                                    objHis.SellerNick = sellerNick;
                                                                    objHis.Buyer_nick = buyer_nick;
                                                                    objHis.CellPhone = cellPhone;
                                                                    objHis.SendDate = DateTime.Now;
                                                                    objHis.SendType = "催款提醒";
                                                                    objHis.SendStatus = "0";
                                                                    //if(true)test
                                                                    if (AutoMsgDB.AddMsgSendHis(objHis))
                                                                    {
                                                                        var msgContent = Convert.ToString(trRule.Rows[num]["unpayMsg"]);
                                                                        msgContent = msgContent.Replace("**下单时间**", Convert.ToDateTime(createDate).ToShortDateString())
                                                                            .Replace("**收货人**", trade.ReceiverName);

                                                                        string sigNames = CTCRM.Components.SellersBLL.GetSignName(sellerNick);
                                                                        if (String.IsNullOrEmpty(sigNames))
                                                                        {
                                                                            sigNames = sellerNick;
                                                                        }
                                                                        SendMsgForCommon(sigNames, objHis.TransNumber, objHis.CellPhone, msgContent);
                                                                        msgContent = "【" + sigNames + "】" + msgContent;
                                                                        AutoMsgDB.UpdateMsgSendHis(objHis.TransNumber, msgContent);
                                                                        Console.WriteLine("当前卖家：" + sellerNick + "到货提醒内容：" + msgContent);
                                                                        if (msgContent.Length <= 65)
                                                                        {
                                                                            if (AutoMsgDB.UpdateMsgTransUseCount(objHis.SellerNick, 1))
                                                                            {
                                                                                AutoMsgDB.DeleteNotifyByTid(tid);
                                                                            }
                                                                        }
                                                                        else if (msgContent.Length > 65 && msgContent.Length <= 130)
                                                                        {
                                                                            if (AutoMsgDB.UpdateMsgTransUseCount(objHis.SellerNick, 2))
                                                                            {
                                                                                AutoMsgDB.DeleteNotifyByTid(tid);
                                                                            }
                                                                        }
                                                                        else if (msgContent.Length > 130 && msgContent.Length <= 195)
                                                                        {
                                                                            if (AutoMsgDB.UpdateMsgTransUseCount(objHis.SellerNick, 3))
                                                                            {
                                                                                AutoMsgDB.DeleteNotifyByTid(tid);
                                                                            }
                                                                        }
                                                                    }
                                                                    else
                                                                    {
                                                                        Console.WriteLine("催款提醒短信未能发送，原因为短信信息写入数据库失败，交易Id为" + objHis.TransNumber);
                                                                    }
                                                                    #endregion
                                                                }
                                                            }

                                                        }
                                                        //发送完成后删除消息该条交易信息
                                                        AutoMsgDB.DeleteValidTid(tid);
                                                    }
                                                }
                                            }
                                        }

                                        #endregion
                                    }

                                    if (!AutoMsgDB.CheckHisSend(sellerNick, buyer_nick, "付款提醒"))
                                    {
                                        #region 付款提醒
                                        if (status.Equals("taobao_trade_TradeBuyerPay"))
                                        {
                                            //检查卖家是否设置了下单付款自动发信提醒
                                            //if (trRule["payType"].Equals(1))
                                            int num = checkWarnTypeExist(trRule, "notplay");
                                            if (num != -1)
                                            {
                                                var amount = trRule.Rows[num]["amount"].ToString();
                                                var amountMax = trRule.Rows[num]["amountMax"].ToString();
                                                //过滤金额
                                                if (Double.Parse(payment) >= Double.Parse(amount) && Double.Parse(payment) < Double.Parse(amountMax))
                                                {
                                                    //检查短信
                                                    if (Convert.ToInt32(tbSellerMsgAcount.Rows[0]["msgCanUseCount"].ToString()) > 0)
                                                    {
                                                        MsgSendHis objHis = null;
                                                        trade = MeesageAtuoSendService.TOPCRM.TBTrade.GetTradeContact(Convert.ToInt64(tid), sessionKey);
                                                        bool Isok = true;
                                                        //黑名单过滤
                                                        if (Convert.ToInt16(trRule.Rows[num]["unPayType"]) == 1)
                                                        {
                                                            if (AutoMsgDB.IsBlackListName(sellerNick, buyer_nick, "付款提醒") == true)
                                                            {
                                                                Isok = false;
                                                            }
                                                        }
                                                        //过滤地区
                                                        if (Convert.ToInt16(trRule.Rows[num]["areaType"]) == 1)
                                                        {
                                                            if (IsInAreaList(Convert.ToString(trRule.Rows[num]["areaList"]), trade.ReceiverCity) == true)
                                                            {
                                                                Isok = false;
                                                            }
                                                        }
                                                        if (Isok == true)
                                                        {
                                                            //get the cellphone no
                                                            string cellPhone = trade == null ? "" : trade.ReceiverMobile;
                                                            if (!String.IsNullOrEmpty(cellPhone) && Utility.IsCellPhone(cellPhone))
                                                            {
                                                                #region send msg
                                                                objHis = new MsgSendHis();
                                                                objHis.TransNumber = tid + "pay";
                                                                objHis.SellerNick = sellerNick;
                                                                objHis.Buyer_nick = buyer_nick;
                                                                objHis.CellPhone = cellPhone;
                                                                objHis.SendDate = DateTime.Now;
                                                                objHis.SendType = "付款提醒";
                                                                objHis.SendStatus = "0";
                                                                //if(true)test
                                                                if (AutoMsgDB.AddMsgSendHis(objHis))
                                                                {
                                                                    var msgContent = Convert.ToString(trRule.Rows[num]["unpayMsg"]);
                                                                    msgContent = msgContent
                                                                        .Replace("**收货人**", trade.ReceiverName)
                                                                        .Replace("**下单时间**", Convert.ToDateTime(createDate).ToShortDateString());


                                                                    string sigNames = CTCRM.Components.SellersBLL.GetSignName(sellerNick);
                                                                    if (String.IsNullOrEmpty(sigNames))
                                                                    {
                                                                        sigNames = sellerNick;
                                                                    }
                                                                    SendMsgForCommon(sigNames, objHis.TransNumber, objHis.CellPhone, msgContent);
                                                                    msgContent = "【" + sigNames + "】" + msgContent;
                                                                    AutoMsgDB.UpdateMsgSendHis(objHis.TransNumber, msgContent);
                                                                    Console.WriteLine("当前卖家：" + sellerNick + "到货提醒内容：" + msgContent);
                                                                    if (msgContent.Length <= 65)
                                                                    {
                                                                        if (AutoMsgDB.UpdateMsgTransUseCount(objHis.SellerNick, 1))
                                                                        {
                                                                            //AutoMsgDB.DeleteNotifyByTid(tid);
                                                                        }
                                                                    }
                                                                    else if (msgContent.Length > 65 && msgContent.Length <= 130)
                                                                    {
                                                                        if (AutoMsgDB.UpdateMsgTransUseCount(objHis.SellerNick, 2))
                                                                        {
                                                                            //AutoMsgDB.DeleteNotifyByTid(tid);
                                                                        }
                                                                    }
                                                                    else if (msgContent.Length > 130 && msgContent.Length <= 195)
                                                                    {
                                                                        if (AutoMsgDB.UpdateMsgTransUseCount(objHis.SellerNick, 3))
                                                                        {
                                                                            //AutoMsgDB.DeleteNotifyByTid(tid);
                                                                        }
                                                                    }
                                                                }
                                                                else
                                                                {
                                                                    Console.WriteLine("付款提醒短信未能发送，原因为短信信息写入数据库失败，交易Id为" + objHis.TransNumber);
                                                                }
                                                                #endregion
                                                            }
                                                            else
                                                            {
                                                                //发送完成后删除消息该条交易信息
                                                                AutoMsgDB.DeleteValidTid(tid);
                                                            }
                                                        }

                                                    }
                                                    else
                                                    {
                                                        AutoMsgDB.DeleteValidTid(tid);
                                                    }

                                                }
                                            }

                                        }

                                        #endregion
                                    }

                                    if (!AutoMsgDB.CheckHisSend(sellerNick, buyer_nick, "延时发货提醒"))
                                    {
                                        #region 延时发货提醒
                                        //taobao_trade_TradeDelayConfirmPay
                                        if (status.Equals("taobao_trade_TradeBuyerPay"))
                                        {
                                            TimeSpan totalSpan = DateTime.Now - Convert.ToDateTime(createDate);

                                            //检查卖家是否开启延时发货自动发信提醒
                                            int num = checkWarnTypeExist(trRule, "delaySend");
                                            if (num != -1)
                                            {
                                                if (totalSpan.Days >= 1)//创建订单付款后1天前还未发货时则提醒
                                                {
                                                    var amount = trRule.Rows[num]["amount"].ToString();
                                                    var amountMax = trRule.Rows[num]["amountMax"].ToString();
                                                    //过滤卖家设置的发送条件
                                                    if (Double.Parse(payment) >= Double.Parse(amount) && Double.Parse(payment) < Double.Parse(amountMax))
                                                    {
                                                        MsgSendHis objHis = null;
                                                        //正式开始发送短信
                                                        if (Convert.ToInt32(tbSellerMsgAcount.Rows[0]["msgCanUseCount"].ToString()) > 0)
                                                        {
                                                            trade = MeesageAtuoSendService.TOPCRM.TBTrade.GetTradeContact(Convert.ToInt64(tid), sessionKey);
                                                            //check the cellphone no
                                                            bool Isok = true;
                                                            //黑名单过滤
                                                            if (Convert.ToInt16(trRule.Rows[num]["unPayType"]) == 1)
                                                            {
                                                                if (AutoMsgDB.IsBlackListName(sellerNick, buyer_nick, "延时发货提醒") == true)
                                                                {
                                                                    Isok = false;
                                                                }
                                                            }
                                                            //过滤地区
                                                            if (Convert.ToInt16(trRule.Rows[num]["areaType"]) == 1)
                                                            {
                                                                if (IsInAreaList(Convert.ToString(trRule.Rows[num]["areaList"]), trade.ReceiverCity) == true)
                                                                {
                                                                    Isok = false;
                                                                }
                                                            }
                                                            //过滤后满足所有条件
                                                            if (Isok == true)
                                                            {
                                                                string cellPhone = trade == null ? "" : trade.ReceiverMobile;
                                                                if (!String.IsNullOrEmpty(cellPhone) && Utility.IsCellPhone(cellPhone))
                                                                {
                                                                    #region 正式开始发送短信
                                                                    objHis = new MsgSendHis();
                                                                    objHis.TransNumber = tid + "delayShip";
                                                                    objHis.SellerNick = sellerNick;
                                                                    objHis.Buyer_nick = buyer_nick;
                                                                    objHis.CellPhone = cellPhone;
                                                                    objHis.SendDate = DateTime.Now;
                                                                    objHis.SendType = "延时发货提醒";
                                                                    objHis.SendStatus = "0";
                                                                    if (AutoMsgDB.AddMsgSendHis(objHis))
                                                                    {
                                                                        Mobile obj = new Mobile();

                                                                        var msgContent = Convert.ToString(trRule.Rows[num]["unpayMsg"]);
                                                                        //获取物流信息
                                                                        msgContent = msgContent.Replace("**收货人**", trade.ReceiverName);

                                                                        //string shopName = trRule["shopName"].ToString();
                                                                       

                                                                        if (msgContent.IndexOf("**快递单号**") > -1)
                                                                        {
                                                                            Logistics objLogstic = new Logistics();
                                                                            LogisticsTraceSearchResponse result = objLogstic.GetLogisticsInfo(Convert.ToInt64(tid), sellerNick);
                                                                            msgContent = msgContent.Replace("**快递单号**", result.OutSid);
                                                                        }
                                                                        string sigNames = CTCRM.Components.SellersBLL.GetSignName(sellerNick);
                                                                        if (String.IsNullOrEmpty(sigNames))
                                                                        {
                                                                            sigNames = sellerNick;
                                                                        }
                                                                        SendMsgForCommon(sigNames, objHis.TransNumber, objHis.CellPhone, msgContent);
                                                                        msgContent = "【" + sigNames + "】" + msgContent;
                                                                        AutoMsgDB.UpdateMsgSendHis(objHis.TransNumber, msgContent);
                                                                        Console.WriteLine("当前卖家：" + sellerNick + "到货提醒内容：" + msgContent);
                                                                        if (msgContent.Length <= 65)
                                                                        {
                                                                            if (AutoMsgDB.UpdateMsgTransUseCount(objHis.SellerNick, 1))
                                                                            {
                                                                                //AutoMsgDB.DeleteNotifyByTid(tid);
                                                                            }
                                                                        }
                                                                        else if (msgContent.Length > 65 && msgContent.Length <= 130)
                                                                        {
                                                                            if (AutoMsgDB.UpdateMsgTransUseCount(objHis.SellerNick, 2))
                                                                            {
                                                                                //AutoMsgDB.DeleteNotifyByTid(tid);
                                                                            }
                                                                        }
                                                                        else if (msgContent.Length > 130 && msgContent.Length <= 195)
                                                                        {
                                                                            if (AutoMsgDB.UpdateMsgTransUseCount(objHis.SellerNick, 3))
                                                                            {
                                                                                //AutoMsgDB.DeleteNotifyByTid(tid);
                                                                            }
                                                                        }
                                                                    }
                                                                    else
                                                                    {
                                                                        Console.WriteLine("延时提醒短信未能发送，原因为短信信息写入数据库失败，交易Id为" + objHis.TransNumber);
                                                                    }
                                                                    #endregion
                                                                }
                                                                else
                                                                {
                                                                    AutoMsgDB.DeleteValidTid(tid);
                                                                }
                                                            }


                                                        }
                                                        else
                                                        {
                                                            AutoMsgDB.DeleteValidTid(tid);
                                                        }
                                                    }
                                                }
                                            }
                                        }
                                        #endregion
                                    }

                                    if (!AutoMsgDB.CheckHisSend(sellerNick, buyer_nick, "发货提醒"))
                                    {
                                        #region 发货提醒

                                        if (status.Equals("taobao_trade_TradeSellerShip"))
                                        {
                                            //检查卖家发货自动发信提醒
                                            int num = checkWarnTypeExist(trRule, "startSend");
                                            if (num != -1)
                                            {
                                                if (ret.Equals("CONSIGN"))
                                                {
                                                    //获取具体卖家信息
                                                    //DataTable sellerData = AutoMsgDB.GetAutoMsgShippingData(sellerNick);
                                                    var amount = trRule.Rows[num]["amount"].ToString();
                                                    var amountMax = trRule.Rows[num]["amountMax"].ToString();

                                                    //过滤金额
                                                    if (Double.Parse(payment) >= Double.Parse(amount) && Double.Parse(payment) < Double.Parse(amountMax))
                                                    {
                                                        MsgSendHis objHis = null;
                                                        //正式开始发送短信
                                                        if (Convert.ToInt32(tbSellerMsgAcount.Rows[0]["msgCanUseCount"].ToString()) > 0)
                                                        {
                                                            trade = MeesageAtuoSendService.TOPCRM.TBTrade.GetTradeContact(Convert.ToInt64(tid), sessionKey);
                                                            if (trade != null)
                                                            {
                                                                //check the cellphone no
                                                                bool Isok = true;
                                                                //黑名单过滤
                                                                if (Convert.ToInt16(trRule.Rows[num]["unPayType"]) == 1)
                                                                {
                                                                    if (AutoMsgDB.IsBlackListName(sellerNick, buyer_nick, "发货提醒") == true)
                                                                    {
                                                                        Isok = false;
                                                                    }
                                                                }
                                                                //过滤地区
                                                                if (Convert.ToInt16(trRule.Rows[num]["areaType"]) == 1)
                                                                {
                                                                    if (IsInAreaList(Convert.ToString(trRule.Rows[num]["areaList"]), trade.ReceiverCity) == true)
                                                                    {
                                                                        Isok = false;
                                                                    }
                                                                }
                                                                //过滤后满足所有条件
                                                                if (Isok == true)
                                                                {
                                                                    string cellPhone = trade == null ? "" : trade.ReceiverMobile;
                                                                    string consign_time = trade.ConsignTime;//发货时间
                                                                    if (!String.IsNullOrEmpty(cellPhone) && Utility.IsCellPhone(cellPhone))
                                                                    {
                                                                        #region 正式开始发送短信
                                                                        objHis = new MsgSendHis();
                                                                        objHis.TransNumber = tid + "ship";
                                                                        objHis.SellerNick = sellerNick;
                                                                        objHis.Buyer_nick = buyer_nick;
                                                                        objHis.CellPhone = cellPhone;
                                                                        objHis.SendDate = DateTime.Now;
                                                                        objHis.SendType = "发货提醒";
                                                                        objHis.SendStatus = "0";
                                                                        if (AutoMsgDB.AddMsgSendHis(objHis))
                                                                        {
                                                                            Mobile obj = new Mobile();
                                                                            var msgContent = Convert.ToString(trRule.Rows[num]["unpayMsg"]);
                                                                            //获取物流信息
                                                                            Logistics objLogstic = new Logistics();
                                                                            LogisticsTraceSearchResponse result = objLogstic.GetLogisticsInfo(Convert.ToInt64(tid), sellerNick);
                                                                            msgContent = msgContent
                                                                                .Replace("**发货时间**", string.IsNullOrEmpty(consign_time) ? createDate : consign_time)
                                                                                .Replace("**快递公司**", result.CompanyName)
                                                                                .Replace("**快递单号**", result.OutSid)
                                                                                .Replace("**收货人**", trade.ReceiverName);


                                                                            string sigNames = CTCRM.Components.SellersBLL.GetSignName(sellerNick);
                                                                            if (String.IsNullOrEmpty(sigNames))
                                                                            {
                                                                                sigNames = sellerNick;
                                                                            }
                                                                            SendMsgForCommon(sigNames, objHis.TransNumber, objHis.CellPhone, msgContent);
                                                                            msgContent = "【" + sigNames + "】" + msgContent;
                                                                            AutoMsgDB.UpdateMsgSendHis(objHis.TransNumber, msgContent);
                                                                            Console.WriteLine("当前卖家：" + sellerNick + "到货提醒内容：" + msgContent);
                                                                            if (msgContent.Length <= 65)
                                                                            {
                                                                                if (AutoMsgDB.UpdateMsgTransUseCount(objHis.SellerNick, 1))
                                                                                {
                                                                                    //AutoMsgDB.DeleteNotifyByTid(tid);
                                                                                }
                                                                            }
                                                                            else if (msgContent.Length > 65 && msgContent.Length <= 130)
                                                                            {
                                                                                if (AutoMsgDB.UpdateMsgTransUseCount(objHis.SellerNick, 2))
                                                                                {
                                                                                    //AutoMsgDB.DeleteNotifyByTid(tid);
                                                                                }
                                                                            }
                                                                            else if (msgContent.Length > 130 && msgContent.Length <= 195)
                                                                            {
                                                                                if (AutoMsgDB.UpdateMsgTransUseCount(objHis.SellerNick, 3))
                                                                                {
                                                                                    //AutoMsgDB.DeleteNotifyByTid(tid);
                                                                                }
                                                                            }
                                                                        }
                                                                        else
                                                                        {
                                                                            Console.WriteLine("发货提醒短信未能发送，原因为短信信息写入数据库失败，交易Id为" + objHis.TransNumber);
                                                                        }
                                                                        #endregion
                                                                    }
                                                                    else
                                                                    {
                                                                        AutoMsgDB.DeleteValidTid(tid);
                                                                    }
                                                                }
                                                            }

                                                        }
                                                        else
                                                        {
                                                            AutoMsgDB.DeleteValidTid(tid);
                                                        }
                                                    }

                                                }
                                            }
                                        }

                                        #endregion
                                    }

                                    if (!AutoMsgDB.CheckHisSend(sellerNick, buyer_nick, "到货提醒"))
                                    {
                                        //需要确认城市是否正确
                                        #region 达到提醒

                                        //是否开启提醒
                                        int num = checkWarnTypeExist(trRule, "arivde");
                                        if (num != -1)
                                        {
                                            if (status.Equals("taobao_trade_TradeSellerShip"))
                                            {
                                                //TimeSpan totalSpan2 = DateTime.Now - Convert.ToDateTime(createDate);
                                                //if (totalSpan2.Days > 1)

                                                if (ret.Equals("SENT_CITY"))
                                                {
                                                    var amount = trRule.Rows[num]["amount"].ToString();
                                                    var amountMax = trRule.Rows[num]["amountMax"].ToString();

                                                    //过滤金额
                                                    if (Double.Parse(payment) >= Double.Parse(amount) && Double.Parse(payment) < Double.Parse(amountMax))
                                                    {

                                                        //正式开始发送短信
                                                        if (Convert.ToInt32(tbSellerMsgAcount.Rows[0]["msgCanUseCount"].ToString()) > 0)
                                                        {
                                                            MsgSendHis objHis = null;
                                                            //check the cellphone no
                                                            string cellPhone = "";
                                                            string buyerCity = "";
                                                            trade = MeesageAtuoSendService.TOPCRM.TBTrade.GetTradeContact(Convert.ToInt64(tid), sessionKey);
                                                            //can get the validate buyer info
                                                            if (trade != null)
                                                            {
                                                                bool Isok = true;
                                                                //黑名单过滤
                                                                if (Convert.ToInt16(trRule.Rows[num]["unPayType"]) == 1)
                                                                {
                                                                    if (AutoMsgDB.IsBlackListName(sellerNick, buyer_nick, "到货提醒") == true)
                                                                    {
                                                                        Isok = false;
                                                                    }
                                                                }
                                                                //过滤地区
                                                                if (Convert.ToInt16(trRule.Rows[num]["areaType"]) == 1)
                                                                {
                                                                    if (IsInAreaList(Convert.ToString(trRule.Rows[num]["areaList"]), trade.ReceiverCity) == true)
                                                                    {
                                                                        Isok = false;
                                                                    }
                                                                }
                                                                //过滤后满足所有条件
                                                                if (Isok == true)
                                                                {
                                                                    cellPhone = trade.ReceiverMobile;
                                                                    buyerCity = trade.ReceiverCity;
                                                                    if (!String.IsNullOrEmpty(cellPhone) && Utility.IsCellPhone(cellPhone) && !String.IsNullOrEmpty(buyerCity))
                                                                    {
                                                                        #region 正式开始发送短信
                                                                        //获取物流信息
                                                                        Logistics objLogstic = new Logistics();
                                                                        LogisticsTraceSearchResponse result = objLogstic.GetLogisticsInfo(Convert.ToInt64(tid), sellerNick);
                                                                        DateTime ArrivedTime;
                                                                        if (GetArrived(buyerCity, result, out ArrivedTime))
                                                                        {
                                                                            objHis = new MsgSendHis();
                                                                            objHis.TransNumber = tid + "arrived";
                                                                            objHis.SellerNick = sellerNick;
                                                                            objHis.Buyer_nick = buyer_nick;
                                                                            objHis.CellPhone = cellPhone;
                                                                            objHis.SendDate = DateTime.Now;
                                                                            objHis.SendType = "到货提醒";
                                                                            objHis.SendStatus = "0";
                                                                            if (AutoMsgDB.AddMsgSendHis(objHis))
                                                                            {
                                                                                Mobile obj = new Mobile();
                                                                                var msgContent = Convert.ToString(trRule.Rows[num]["unpayMsg"]);

                                                                                if (result != null)
                                                                                {
                                                                                    msgContent = msgContent
                                                                                   .Replace("**当前位置**", buyerCity)
                                                                                   .Replace("**快递公司**", result.CompanyName)
                                                                                   .Replace("**收货人**", trade.ReceiverName);

                                                                                   
                                                                                    
                                                                                    
                                                                                    //white list
                                                                                    string sigNames = CTCRM.Components.SellersBLL.GetSignName(sellerNick);
                                                                                    if (String.IsNullOrEmpty(sigNames))
                                                                                    {
                                                                                        sigNames = sellerNick;
                                                                                    }
                                                                                    SendMsgForCommon(sigNames, objHis.TransNumber, objHis.CellPhone, msgContent);
                                                                                    msgContent = "【" + sigNames + "】" + msgContent;
                                                                                    AutoMsgDB.UpdateMsgSendHis(objHis.TransNumber, msgContent);
                                                                                    Console.WriteLine("当前卖家：" + sellerNick + "到货提醒内容：" + msgContent);
                                                                                    if (msgContent.Length <= 65)
                                                                                    {
                                                                                        if (AutoMsgDB.UpdateMsgTransUseCount(objHis.SellerNick, 1))
                                                                                        {
                                                                                            //AutoMsgDB.DeleteNotifyByTid(tid);
                                                                                        }
                                                                                    }
                                                                                    else if (msgContent.Length > 65 && msgContent.Length <= 130)
                                                                                    {
                                                                                        if (AutoMsgDB.UpdateMsgTransUseCount(objHis.SellerNick, 2))
                                                                                        {
                                                                                            //AutoMsgDB.DeleteNotifyByTid(tid);
                                                                                        }
                                                                                    }
                                                                                    else if (msgContent.Length > 130 && msgContent.Length <= 195)
                                                                                    {
                                                                                        if (AutoMsgDB.UpdateMsgTransUseCount(objHis.SellerNick, 3))
                                                                                        {
                                                                                            //AutoMsgDB.DeleteNotifyByTid(tid);
                                                                                        }
                                                                                    }
                                                                                }
                                                                            }
                                                                            else
                                                                            {
                                                                                Console.WriteLine("到达提醒短信未能发送，原因为短信信息写入数据库失败，交易Id为" + objHis.TransNumber);
                                                                            }
                                                                        }
                                                                        #endregion
                                                                    }
                                                                    else
                                                                    {
                                                                        AutoMsgDB.DeleteValidTid(tid);
                                                                    }
                                                                }

                                                            }
                                                        }
                                                        else
                                                        {
                                                            //发送完成后删除消息该条交易信息
                                                            AutoMsgDB.DeleteValidTid(tid);
                                                        }
                                                    }
                                                }
                                            }
                                        }

                                        #endregion
                                    }

                                    if (!AutoMsgDB.CheckHisSend(sellerNick, buyer_nick, "签收提醒"))
                                    {   //该消息的判断应该从物流信息里判断
                                        #region 签收提醒
                                        int num = checkWarnTypeExist(trRule, "sign");
                                        if (num != -1)
                                        {
                                            if (status.Equals("taobao_trade_TradeSuccess"))
                                            {
                                                //TimeSpan totalSpan2;
                                                //DateTime enter;
                                                if (ret.Equals("SIGNED"))
                                                {
                                                    //获取具体卖家信息
                                                    var amount = trRule.Rows[num]["amount"].ToString();
                                                    var amountMax = trRule.Rows[num]["amountMax"].ToString();

                                                    //过滤金额
                                                    if (Double.Parse(payment) >= Double.Parse(amount) && Double.Parse(payment) < Double.Parse(amountMax))
                                                    {
                                                        #region 正式开始发送短信
                                                        //正式开始发送短信
                                                        if (Convert.ToInt32(tbSellerMsgAcount.Rows[0]["msgCanUseCount"].ToString()) > 0)
                                                        {
                                                            MsgSendHis objHis = null;
                                                            //check the cellphone no
                                                            string cellPhone = "";
                                                            string buyerName = "";
                                                            string buyerCity = "";
                                                            trade = MeesageAtuoSendService.TOPCRM.TBTrade.GetTradeContact(Convert.ToInt64(tid), sessionKey);
                                                            //can get the validate buyer info
                                                            if (trade != null)
                                                            {
                                                                if (AutoMsgDB.IsBlackListName(sellerNick, buyer_nick, "签收提醒") == false)
                                                                {
                                                                    //过滤地区
                                                                    if (IsInAreaList(Convert.ToString(trRule.Rows[num]["areaList"]), trade.ReceiverCity) == false)
                                                                    {

                                                                        cellPhone = trade.ReceiverMobile;
                                                                        buyerName = trade.ReceiverName;
                                                                        buyerCity = trade.ReceiverCity;
                                                                        if (!String.IsNullOrEmpty(cellPhone) && Utility.IsCellPhone(cellPhone))
                                                                        {
                                                                            string arrviedDate = AutoMsgDB.GetArrivedDate(sellerNick, buyer_nick);
                                                                            if (!string.IsNullOrEmpty(arrviedDate))
                                                                            {
                                                                                if (DateTime.Now.AddHours(-6) > DateTime.Parse(arrviedDate))
                                                                                {
                                                                                    #region 发送
                                                                                    trade = MeesageAtuoSendService.TOPCRM.TBTrade.GetTradeContact(Convert.ToInt64(tid), sessionKey);
                                                                                    bool Isok = true;
                                                                                    //黑名单过滤
                                                                                    if (Convert.ToInt16(trRule.Rows[num]["unPayType"]) == 1)
                                                                                    {
                                                                                        if (AutoMsgDB.IsBlackListName(sellerNick, trade.BuyerNick, "签收提醒") == true)
                                                                                        {
                                                                                            Isok = false;
                                                                                        }
                                                                                    }
                                                                                    //过滤地区
                                                                                    if (Convert.ToInt16(trRule.Rows[num]["areaType"]) == 1)
                                                                                    {
                                                                                        if (IsInAreaList(Convert.ToString(trRule.Rows[num]["areaList"]), trade.ReceiverCity) == true)
                                                                                        {
                                                                                            Isok = false;
                                                                                        }
                                                                                    }
                                                                                    //过滤后满足所有条件
                                                                                    if (Isok == true)
                                                                                    {
                                                                                        //get the cellphone no
                                                                                        cellPhone = trade == null ? "" : trade.ReceiverMobile;
                                                                                        if (!String.IsNullOrEmpty(cellPhone) && Utility.IsCellPhone(cellPhone))
                                                                                        {
                                                                                            #region 发送明细
                                                                                            Logistics objLogstic = new Logistics();
                                                                                            LogisticsTraceSearchResponse result = objLogstic.GetLogisticsInfo(Convert.ToInt64(tid), sellerNick);
                                                                                            if (!string.IsNullOrEmpty(result.Status) && result.Status.Equals("对方已签收"))
                                                                                            {
                                                                                                objHis = new MsgSendHis();
                                                                                                objHis.TransNumber = tid + "sign";
                                                                                                objHis.SellerNick = sellerNick;
                                                                                                objHis.Buyer_nick = buyer_nick;
                                                                                                objHis.CellPhone = cellPhone;
                                                                                                objHis.SendDate = DateTime.Now;
                                                                                                objHis.SendType = "签收提醒";
                                                                                                objHis.SendStatus = "0";
                                                                                                if (AutoMsgDB.AddMsgSendHis(objHis))
                                                                                                {
                                                                                                    Mobile obj = new Mobile();
                                                                                                    var msgContent = Convert.ToString(trRule.Rows[num]["unpayMsg"]);

                                                                                                    if (result != null)
                                                                                                    {
                                                                                                        msgContent = msgContent
                                                                                                            .Replace("**收货人**", buyerName);

                                                                                                        
                                                                                                        AutoMsgDB.UpdateMsgSendHis(objHis.TransNumber, msgContent);

                                                                                                        Console.WriteLine("当前卖家：" + sellerNick + "签收提醒内容：" + msgContent);
                                                                                                        
                                                                                                        if (msgContent.Length <= 65)
                                                                                                        {
                                                                                                            if (AutoMsgDB.UpdateMsgTransUseCount(objHis.SellerNick, 1))
                                                                                                            {
                                                                                                                //AutoMsgDB.DeleteNotifyByTid(tid);
                                                                                                            }
                                                                                                        }
                                                                                                        else if (msgContent.Length > 65 && msgContent.Length <= 130)
                                                                                                        {
                                                                                                            if (AutoMsgDB.UpdateMsgTransUseCount(objHis.SellerNick, 2))
                                                                                                            {
                                                                                                                //AutoMsgDB.DeleteNotifyByTid(tid);
                                                                                                            }
                                                                                                        }
                                                                                                        else if (msgContent.Length > 130 && msgContent.Length <= 195)
                                                                                                        {
                                                                                                            if (AutoMsgDB.UpdateMsgTransUseCount(objHis.SellerNick, 3))
                                                                                                            {
                                                                                                                //AutoMsgDB.DeleteNotifyByTid(tid);
                                                                                                            }
                                                                                                        }
                                                                                                        //发送完成后删除消息该条交易信息
                                                                                                        AutoMsgDB.DeleteValidTid(tid);
                                                                                                    }
                                                                                                }
                                                                                                else
                                                                                                {
                                                                                                    Console.WriteLine("签收提醒短信未能发送，原因为短信信息写入数据库失败，交易Id为" + objHis.TransNumber);
                                                                                                }
                                                                                            }
                                                                                            #endregion
                                                                                    #endregion


                                                                                        }
                                                                                    }

                                                                                }

                                                                            }
                                                                        }
                                                                    }
                                                                }
                                                                else
                                                                {
                                                                    AutoMsgDB.DeleteNotifyByTid(tid);
                                                                }
                                                            }
                                                        }
                                                        else
                                                        {
                                                            AutoMsgDB.DeleteValidTid(tid);
                                                        }
                                                        #endregion
                                                    }
                                                }
                                                //}
                                            }
                                        }
                                        #endregion
                                    }

                                    if (!AutoMsgDB.CheckHisSend(sellerNick, buyer_nick, "回款提醒"))
                                    {
                                        //该消息貌似没有订阅
                                        #region 回款提醒
                                        int num = checkWarnTypeExist(trRule, "refund");
                                        if (num != -1)
                                        {
                                            if (status.Equals("taobao_refund_RefundSuccess"))
                                            {
                                                TimeSpan totalSpan2 = DateTime.Now - Convert.ToDateTime(createDate);
                                                if (totalSpan2.Days > 1)
                                                {
                                                    //获取具体卖家信息
                                                    var amount = trRule.Rows[num]["amount"].ToString();
                                                    var amountMax = trRule.Rows[num]["amountMax"].ToString();

                                                    //过滤金额
                                                    if (Double.Parse(payment) >= Double.Parse(amount) && Double.Parse(payment) < Double.Parse(amountMax))
                                                    {
                                                        #region 正式开始发送短信
                                                        //正式开始发送短信
                                                        if (Convert.ToInt32(tbSellerMsgAcount.Rows[0]["msgCanUseCount"].ToString()) > 0)
                                                        {
                                                            MsgSendHis objHis = null;
                                                            //check the cellphone no
                                                            string cellPhone = "";
                                                            string buyerName = "";
                                                            string buyerCity = "";
                                                            trade = MeesageAtuoSendService.TOPCRM.TBTrade.GetTradeContact(Convert.ToInt64(tid), sessionKey);
                                                            //can get the validate buyer info
                                                            if (trade != null)
                                                            {
                                                                bool Isok = true;
                                                                //黑名单过滤
                                                                if (Convert.ToInt16(trRule.Rows[num]["unPayType"]) == 1)
                                                                {
                                                                    if (AutoMsgDB.IsBlackListName(sellerNick, buyer_nick, "催付提醒") == true)
                                                                    {
                                                                        Isok = false;
                                                                    }
                                                                }
                                                                //过滤地区
                                                                if (Convert.ToInt16(trRule.Rows[num]["areaType"]) == 1)
                                                                {
                                                                    if (IsInAreaList(Convert.ToString(trRule.Rows[num]["areaList"]), trade.ReceiverCity) == true)
                                                                    {
                                                                        Isok = false;
                                                                    }
                                                                }
                                                                //过滤后满足所有条件
                                                                if (Isok == true)
                                                                {
                                                                    cellPhone = trade.ReceiverMobile;
                                                                    buyerName = trade.ReceiverName;
                                                                    buyerCity = trade.ReceiverCity;
                                                                    if (!String.IsNullOrEmpty(cellPhone) && Utility.IsCellPhone(cellPhone))
                                                                    {
                                                                        #region 发送
                                                                        //获取物流信息
                                                                        Logistics objLogstic = new Logistics();
                                                                        LogisticsTraceSearchResponse result = objLogstic.GetLogisticsInfo(Convert.ToInt64(tid), sellerNick);
                                                                        if (result != null)
                                                                        {
                                                                            DateTime ArrivedTime;
                                                                            if (GetArrived(buyerCity, result, out ArrivedTime))
                                                                            {
                                                                                if (!string.IsNullOrEmpty(result.Status) && result.Status.Equals("对方已签收"))
                                                                                {
                                                                                    if (ArrivedTime != null && DateTime.Now.AddHours(-7) > ArrivedTime)
                                                                                    {
                                                                                        objHis = new MsgSendHis();
                                                                                        objHis.TransNumber = tid + "sign";
                                                                                        objHis.SellerNick = sellerNick;
                                                                                        objHis.Buyer_nick = buyer_nick;
                                                                                        objHis.CellPhone = cellPhone;
                                                                                        objHis.SendDate = DateTime.Now;
                                                                                        objHis.SendType = "回款提醒";
                                                                                        objHis.SendStatus = "0";
                                                                                        if (AutoMsgDB.AddMsgSendHis(objHis))
                                                                                        {
                                                                                            Mobile obj = new Mobile();
                                                                                            var msgContent = Convert.ToString(trRule.Rows[num]["unpayMsg"]);
                                                                                            if (result != null)
                                                                                            {
                                                                                                msgContent = msgContent
                                                                                                    .Replace("**收货人**", buyerName);


                                                                                                string sigNames = CTCRM.Components.SellersBLL.GetSignName(sellerNick);
                                                                                                if (String.IsNullOrEmpty(sigNames))
                                                                                                {
                                                                                                    sigNames = sellerNick;
                                                                                                }
                                                                                                SendMsgForCommon(sigNames, objHis.TransNumber, objHis.CellPhone, msgContent);
                                                                                                msgContent = "【" + sigNames + "】" + msgContent;
                                                                                                AutoMsgDB.UpdateMsgSendHis(objHis.TransNumber, msgContent);
                                                                                                Console.WriteLine("当前卖家：" + sellerNick + "到货提醒内容：" + msgContent);
                                                                                                if (msgContent.Length <= 65)
                                                                                                {
                                                                                                    if (AutoMsgDB.UpdateMsgTransUseCount(objHis.SellerNick, 1))
                                                                                                    {
                                                                                                        AutoMsgDB.DeleteNotifyByTid(tid);
                                                                                                    }
                                                                                                }
                                                                                                else if (msgContent.Length > 65 && msgContent.Length <= 130)
                                                                                                {
                                                                                                    if (AutoMsgDB.UpdateMsgTransUseCount(objHis.SellerNick, 2))
                                                                                                    {
                                                                                                        AutoMsgDB.DeleteNotifyByTid(tid);
                                                                                                    }
                                                                                                }
                                                                                                else if (msgContent.Length > 130 && msgContent.Length <= 195)
                                                                                                {
                                                                                                    if (AutoMsgDB.UpdateMsgTransUseCount(objHis.SellerNick, 3))
                                                                                                    {
                                                                                                        AutoMsgDB.DeleteNotifyByTid(tid);
                                                                                                    }
                                                                                                }
                                                                                                //发送完成后删除消息该条交易信息
                                                                                                AutoMsgDB.DeleteValidTid(tid);
                                                                                            }
                                                                                        }
                                                                                    }
                                                                                }
                                                                            }
                                                                        }
                                                                        #endregion
                                                                    }
                                                                    else
                                                                    {
                                                                        AutoMsgDB.DeleteNotifyByTid(tid);
                                                                    }
                                                                }
                                                            }
                                                        }
                                                        else
                                                        {
                                                            AutoMsgDB.DeleteValidTid(tid);
                                                        }
                                                        #endregion
                                                    }
                                                }
                                            }
                                        }
                                        #endregion
                                    }

                                }
                                catch (Exception ex)
                                {
                                    ExceptionReporter.WriteLog(ex, ExceptionPostion.TBApply_Data);
                                    continue;
                                }
                            }
                        }
                        //else
                        //{
                        //    Console.WriteLine(sellerNick + "不具备发送短信资格！");
                        //}
                    }
                    //自动删除数据                  
                    AutoMsgDB.DeleteValidTrade();
                    AutoMsgDB.DeleteValidTrade2();
                    busySend = false;
                }
                else
                {
                    Console.WriteLine("没有获取到订单！");
                }
            }
            catch (Exception ex)
            {
                ExceptionReporter.WriteLog(ex, ExceptionPostion.TBApply_Data);
            }
            Console.WriteLine(DateTime.Now.ToShortDateString() + "自动分发end.........！");
        }


        public static string SendMsg(string phone, string nick, string msg)
        {
            //try
            //{
            //    ITopClient client = CTCRM.Components.TopCRM.TBManager.GetClient();
            //    AlibabaAliqinTaSmsNumSendRequest req = new AlibabaAliqinTaSmsNumSendRequest();
            //    req.Extend = "123456";
            //    req.SmsType = "normal";
            //    req.SmsFreeSignName = nick;
            //    req.SmsParam = "{\"conter\":\"" + msg + "\"}";
            //    req.RecNum = phone;
            //    req.SmsTemplateCode = "SMS_38420043";

            //    AlibabaAliqinTaSmsNumSendResponse rsp = client.Execute(req);
            //    return rsp.ErrCode;
            //}
            //catch (Exception e)
            //{
            //    return "1";
            //}

             try
             {
                 ITopClient client = CTCRM.Components.TopCRM.TBManager.GetClient();
                 AlibabaAliqinTaSmsNumSendRequest req = new AlibabaAliqinTaSmsNumSendRequest();
                 req.Extend = "123456";
                 req.SmsType = "normal";
                 req.SmsFreeSignName = nick;
                 req.SmsParam = "{\"conter\":\"" + msg + "\"}";
                 req.RecNum = phone;
                 req.SmsTemplateCode = "SMS_39250111";
                 AlibabaAliqinTaSmsNumSendResponse rsp = client.Execute(req);
                 File.AppendAllText(@"D:\log\SendMsg.txt", rsp.ErrCode + rsp.Body, Encoding.Default);
                 return rsp.ErrCode;
             }
             catch (Exception e)
             {
                 return "1";
             }
            
        }

    }
}
