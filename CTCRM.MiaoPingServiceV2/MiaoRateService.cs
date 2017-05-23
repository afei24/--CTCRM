using System;
using System.Collections.Generic;
using System.Text;
using CHENGTUAN.Components;
using CHENGTUAN.Entity;
using System.Threading;
using System.Net;
using System.Net.Sockets;
using Top.Api.Response;
using System.Timers;
using System.Data;
using Top.Api.Domain;
using CTCRM.MiaoPingServiceV2.TopRating;
using CTCRM.Entity;
using System.Configuration;
using System.Web;
using System.Web.Caching;

namespace CTCRM.MiaoPingServiceV2
{
  public  class MiaoRateService
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
            //定时处理 -------用于定时刷新令牌防止令牌过期不能读取API数据
            sendMessageDoTimer = new System.Timers.Timer();
            sendMessageDoTimer.Enabled = true;
            sendMessageDoTimer.Interval = int.Parse(SEND_MESSAGE_DO_INTERVAL);
            sendMessageDoTimer.Elapsed += new ElapsedEventHandler(SendMessageDoTimer_Elapsed);

            //创建监听SOCKET
            ServerSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            //设置SOCKET允许多个SOCKET访问同一个本地IP地址和端口号
            ServerSocket.SetSocketOption(SocketOptionLevel.Socket, SocketOptionName.ReuseAddress, true);
            ServerInfo = new IPEndPoint(IPAddress.Any, int.Parse(PORT));
            ServerSocket.Bind(ServerInfo);
            Console.WriteLine("店铺管家秒评NewV—自动评价中.....");
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

        /// <summary>
        /// 卖家短信自动分发
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        bool busySend = false;
        private void SendMessageDoTimer_Elapsed(object sender, ElapsedEventArgs e)
        {
            try
            {
                sendMessageDoTimer.Enabled = true;
                //查询同步过来的消息MESSAGE
                //查询主动通知信息从DB开始用于发送短信:只取交易完成的数据用于秒评
                DataTable tbTrade = DBUtil.GetTradeData("");
                //如果该卖家有消息推送
                if (!busySend && tbTrade != null && tbTrade.Rows.Count > 0)
                {
                    busySend = true;
                    foreach (DataRow row in tbTrade.Rows)//轮训通知消息
                    {
                        string sellerNick = row["seller_nick"].ToString();
                        string buyerNick = row["buyer_nick"].ToString();
                        string tid = row["tid"].ToString();
                        DateTime createDate = Convert.ToDateTime( row["createDate"]);

                        // 获取卖家保存的自动评价策略
                        DataTable dtAutoConfig = DBUtil.GetSellerAutoRateConfig(sellerNick);
                        int isMiaoRate = 0;
                        int isWaitBuyerRate = 0;
                        int isQiangRate = 0;
                        if (dtAutoConfig == null || dtAutoConfig.Rows.Count == 0)
                        {
                            continue;
                        }

                        isMiaoRate = Convert.ToInt32( dtAutoConfig.Rows[0]["isMiaoRate"]);
                        isWaitBuyerRate = Convert.ToInt32(dtAutoConfig.Rows[0]["isWaitBuyerRate"]);
                        isQiangRate = Convert.ToInt32(dtAutoConfig.Rows[0]["isQiangRate"]);
                        //判断卖家是否开通秒评
                        if (isMiaoRate==1)
                        {
                            #region 秒评

                                //评价开始
                                string sessionKey = DBUtil.GetSellerSessionKey(sellerNick);
                                if (!string.IsNullOrEmpty(sessionKey))
                                {
                                    // 获取卖家保存的评价策略
                                    DataTable tbSellerRateConfig = DBUtil.GetSellerRateConfig(sellerNick);
                                    //检查商家设置：秒评：只检查该用户是否在黑名单
                                    if (!DBUtil.CheckIsBlacklst(sellerNick, buyerNick))
                                    {
                                        Trade objTrade = TBTrade.GetBuyerTrade(tid, sessionKey);
                                        if (objTrade != null && objTrade.Orders.Count > 0)
                                        {
                                            foreach (Order o in objTrade.Orders)
                                            {
                                                if (!o.SellerRate)
                                                {
                                                    RateConfig objRate = new RateConfig();
                                                    objRate.Tid = Convert.ToInt64(tid);
                                                    objRate.Oid = o.Oid;
                                                    objRate.Content1 = tbSellerRateConfig.Rows[0]["content1"].ToString();
                                                    objRate.Content2 = tbSellerRateConfig.Rows[0]["content2"].ToString();
                                                    objRate.Content3 = tbSellerRateConfig.Rows[0]["content3"].ToString();
                                                    objRate.Result = tbSellerRateConfig.Rows[0]["result"].ToString();
                                                    objRate.SellerNick = sellerNick;
                                                    string strContent = "";
                                                    TBRating objRateDal = new TBRating();
                                                    TradeRate obj = null;
                                                    //调用接口 新增单个评价
                                                    obj = objRateDal.BuyerTradeRateOneByOne(objRate, ref strContent, sessionKey);
                                                    if (obj == null)
                                                    {
                                                        // 调用API进行批量评价
                                                        obj = objRateDal.BuyerTradeRate(objRate, ref strContent, sessionKey);
                                                    }
                                                    if (obj != null)
                                                    {   //rating sucessfull
                                                        obj.Content = strContent;
                                                        obj.Nick = objRate.SellerNick;
                                                        obj.Tid = Convert.ToInt64(tid);
                                                        obj.Created = obj.Created;

                                                        // 添加卖家评价:秒评
                                                        //Console.WriteLine("评价卖家：" + obj.Nick + " 评价日期：" + obj.Created);
                                                        DBUtil.AddRateHisWithSeller(obj,"秒评");

                                                        Console.WriteLine("当前卖家：" + sellerNick + "评价时间：" + DateTime.Now.ToString());
                                                    }
                                                }
                                            }
                                        }
                                    }
                                }
                            #endregion
                        }

                        //判断卖家是否开通买家评价以后评价
                        if (isWaitBuyerRate == 1)
                        {
                            #region 方案二（买家评价以后评价）                                         
                            string sessionKey = DBUtil.GetSellerSessionKey(sellerNick);
                            RateConfig objRate = new RateConfig();
                            TBRating objRateDal = new TBRating();

                            objRate.Content1 = dtAutoConfig.Rows[0]["content1"].ToString();
                            objRate.Content2 = dtAutoConfig.Rows[0]["content2"].ToString();
                            objRate.Content3 = dtAutoConfig.Rows[0]["content3"].ToString();
                            objRate.SellerNick = sellerNick;
                            //默认好评
                            objRate.Result = dtAutoConfig.Rows[0]["result"].ToString();

                            //检查买家是否评论
                            List<TradeRate> sates = objRateDal.GetTradeRate(sessionKey);
                            bool isRated = false;
                            foreach (TradeRate trade in sates)
                            {
                                if (trade.Tid.ToString() == tid)
                                {
                                    isRated = true;
                                    break;
                                }
                            }
                            if (isRated) //买家已评价
                            {
                                
                                //买家在黑名单
                                if (DBUtil.CheckIsBlacklst(sellerNick, buyerNick))
                                {
                                    int blackBuyerRatedIsRate = Convert.ToInt32(dtAutoConfig.Rows[0]["blackBuyerRatedIsRate"]);
                                    if (blackBuyerRatedIsRate==1)
                                    {
                                        continue;
                                    }
                                    if (blackBuyerRatedIsRate == 3)
                                    {
                                        objRate.Result = "neutral";
                                        objRate.BadRateContent = dtAutoConfig.Rows[0]["badRateContent"].ToString();
                                        objRate.Content1 = dtAutoConfig.Rows[0]["badRateContent"].ToString();
                                        objRate.Content2 = dtAutoConfig.Rows[0]["badRateContent"].ToString();
                                        objRate.Content3 = dtAutoConfig.Rows[0]["badRateContent"].ToString();
                                    }
                                    if (blackBuyerRatedIsRate == 4)
                                    {
                                        objRate.Result = "bad";
                                        objRate.BadRateContent = dtAutoConfig.Rows[0]["badRateContent"].ToString();
                                        objRate.Content1 = dtAutoConfig.Rows[0]["badRateContent"].ToString();
                                        objRate.Content2 = dtAutoConfig.Rows[0]["badRateContent"].ToString();
                                        objRate.Content3 = dtAutoConfig.Rows[0]["badRateContent"].ToString();
                                    }

                                }
                            }
                            else //买家未评价
                            {
                                
                                //买家在黑名单
                                if (DBUtil.CheckIsBlacklst(sellerNick, buyerNick))
                                {
                                    
                                    //检查是否到评论时间
                                    TimeSpan ts = DateTime.Now - createDate;
                                    int jiange = (ts.Days * 24 * 60 * 60) + (ts.Hours * 60 * 60) + (ts.Minutes * 60) + (ts.Minutes);
                                    int congigJiange = (Convert.ToInt32(dtAutoConfig.Rows[0]["blackBuyerNoRateQiangRateDay"]) * 24 * 60 * 60)
                                        + (Convert.ToInt32(dtAutoConfig.Rows[0]["blackBuyerNoRateQiangRateHour"]) * 60 * 60) + (Convert.ToInt32(dtAutoConfig.Rows[0]["blackBuyerNoRateQiangRateFen"]) * 60);
                                    if (congigJiange < jiange)
                                    {
                                        continue;
                                    }
                                }
                                else //买家不在黑名单
                                {
                                    
                                    //检查是否到评论时间
                                    TimeSpan ts = DateTime.Now - createDate;
                                    int jiange = (ts.Days * 24 * 60 * 60) + (ts.Hours * 60 * 60) + (ts.Minutes * 60) + (ts.Minutes);
                                    int congigJiange = (Convert.ToInt32(dtAutoConfig.Rows[0]["waitBuyerTimeDay"]) * 24 * 60 * 60)
                                        + (Convert.ToInt32(dtAutoConfig.Rows[0]["waitBuyerTimeHour"]) * 60 * 60) + (Convert.ToInt32(dtAutoConfig.Rows[0]["waitBuyerTimeFen"]) * 60);
                                    if (congigJiange < jiange)
                                    {
                                        continue;
                                    }
                                
                                }
                            }

                            //评价开始
                            if (!string.IsNullOrEmpty(sessionKey))
                            {
                                // 获取卖家保存的评价策略
                                //DataTable tbSellerRateConfig = DBUtil.GetSellerRateConfig(sellerNick);

                                    Trade objTrade = TBTrade.GetBuyerTrade(tid, sessionKey);
                                    if (objTrade != null && objTrade.Orders.Count > 0)
                                    {
                                        foreach (Order o in objTrade.Orders)
                                        {
                                            if (!o.SellerRate)
                                            {
                                                
                                                objRate.Tid = Convert.ToInt64(tid);
                                                objRate.Oid = o.Oid;
                                                string strContent = "";                                               
                                                TradeRate obj = null;
                                                //调用接口 新增单个评价
                                                obj = objRateDal.BuyerTradeRateOneByOne(objRate, ref strContent, sessionKey);
                                                if (obj == null)
                                                {
                                                    // 调用API进行批量评价
                                                    obj = objRateDal.BuyerTradeRate(objRate, ref strContent, sessionKey);
                                                }
                                                if (obj != null)
                                                {   //rating sucessfull
                                                    obj.Content = strContent;
                                                    obj.Nick = objRate.SellerNick;
                                                    obj.Tid = Convert.ToInt64(tid);
                                                    obj.Created = obj.Created;

                                                    // 添加卖家评价
                                                    //Console.WriteLine("评价卖家：" + obj.Nick + " 评价日期：" + obj.Created);
                                                    DBUtil.AddRateHisWithSeller(obj,"方案二");
                                                    Console.WriteLine("当前卖家：" + sellerNick + "评价时间：" + DateTime.Now.ToString());
                                                }
                                            }
                                        }
                                    }
                                
                            }
                            #endregion
                        }

                        //判断卖家是否开通交易后多长时间评价
                        if (isQiangRate == 1)
                        {
                            #region 方案三（交易后多长时间评价）

                            //检查是否到评论时间
                            TimeSpan ts = DateTime.Now - createDate;
                            //当前时间到提单的时间间隔
                            int jiange = (ts.Days * 24 * 60 * 60) + (ts.Hours * 60 * 60) + (ts.Minutes * 60) + (ts.Minutes);
                            //评价配置的时间间隔
                            int congigJiange = (Convert.ToInt32(dtAutoConfig.Rows[0]["qiangRateTimeDay"]) * 24 * 60 * 60)
                                + (Convert.ToInt32(dtAutoConfig.Rows[0]["qiangRateTimeHour"]) * 60 * 60) + (Convert.ToInt32(dtAutoConfig.Rows[0]["qiangRateTimeFen"]) * 60);
                            if (congigJiange < jiange)
                            {
                                continue;
                            }
                            //评价开始
                            string sessionKey = DBUtil.GetSellerSessionKey(sellerNick);
                            if (!string.IsNullOrEmpty(sessionKey))
                            {
                                //检查商家设置：秒评：只检查该用户是否在黑名单
                                if (!DBUtil.CheckIsBlacklst(sellerNick, buyerNick))
                                {
                                    Trade objTrade = TBTrade.GetBuyerTrade(tid, sessionKey);
                                    if (objTrade != null && objTrade.Orders.Count > 0)
                                    {
                                        foreach (Order o in objTrade.Orders)
                                        {
                                            if (!o.SellerRate)
                                            {
                                                RateConfig objRate = new RateConfig();
                                                objRate.Tid = Convert.ToInt64(tid);
                                                objRate.Oid = o.Oid;
                                                objRate.Content1 = dtAutoConfig.Rows[0]["content1"].ToString();
                                                objRate.Content2 = dtAutoConfig.Rows[0]["content2"].ToString();
                                                objRate.Content3 = dtAutoConfig.Rows[0]["content3"].ToString();
                                                objRate.Result = dtAutoConfig.Rows[0]["result"].ToString();
                                                objRate.SellerNick = sellerNick;
                                                string strContent = "";
                                                TBRating objRateDal = new TBRating();
                                                TradeRate obj = null;
                                                //调用接口 新增单个评价
                                                obj = objRateDal.BuyerTradeRateOneByOne(objRate, ref strContent, sessionKey);
                                                if (obj == null)
                                                {
                                                    // 调用API进行批量评价
                                                    obj = objRateDal.BuyerTradeRate(objRate, ref strContent, sessionKey);
                                                }
                                                if (obj != null)
                                                {   //rating sucessfull
                                                    obj.Content = strContent;
                                                    obj.Nick = objRate.SellerNick;
                                                    obj.Tid = Convert.ToInt64(tid);
                                                    obj.Created = obj.Created;

                                                    // 添加卖家评价:秒评
                                                    //Console.WriteLine("评价卖家：" + obj.Nick + " 评价日期：" + obj.Created);
                                                    DBUtil.AddRateHisWithSeller(obj, "方案三");

                                                    Console.WriteLine("当前卖家：" + sellerNick + "评价时间：" + DateTime.Now.ToString());
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                            #endregion
                        }
                        //自动删除数据
                        DBUtil.DeleteValidTradeForMiaoRate(tid); 
                    }
                    busySend = false;
                }
            }
            catch (Exception ex)
            {
                ExceptionReporter.WriteLog(ex, ExceptionPostion.TBApply_Data);
            }
            finally
            {
                sendMessageDoTimer.Enabled = true;
            }
        }
    }
}
