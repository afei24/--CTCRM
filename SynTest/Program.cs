using System;
using System.Collections.Generic;
using System.Text;
using CTCRM.Components;
using Top.Tmc;
using Top.Api.Domain;
using CHENGTUAN.Components;
using CHENGTUAN.Entity;
using Top.Api.Util;
using System.Collections;
using CTCRM.Entity;

namespace SynTest
{
    class Program
    {
        public static string appKey = System.Configuration.ConfigurationManager.AppSettings["appKey"];
        public static string appSecret = System.Configuration.ConfigurationManager.AppSettings["appSecret"];
        public static int syncStartTime = Convert.ToInt32(System.Configuration.ConfigurationManager.AppSettings["SyncStartTime"]);
        public static int syncEndTime = Convert.ToInt32(System.Configuration.ConfigurationManager.AppSettings["SyncEndTime"]);

        public static void Main(string[] args)
        {
            TmcClient client = new TmcClient(appKey, appSecret, "default");
            client.OnMessage += (s, e) =>
            {
                try
                {

                    string status = e.Message.Topic;
                    //将消息进行转换
                    IDictionary obj = TopUtils.ParseJson(e.Message.Content);

                    if (obj != null)
                    {
                        #region //物流信息的处理20160916 yao
                        try
                        {
                            if (obj.Contains("action"))
                            {
                                Console.WriteLine(DateTime.Now.ToString() + ":物流提醒:" + e.Message.Content);
                                LogsticDetailTrace logstic = new LogsticDetailTrace();
                               
                                logstic.Tid = obj["tid"].ToString();
                                logstic.Desc = obj["desc"].ToString();
                                if (obj.Contains("out_sid") ) { logstic.Out_side = obj["out_sid"].ToString(); }
                                logstic.Time = obj["time"].ToString();
                                if (obj.Contains("company_name"))
                                {
                                    logstic.Company_name = obj["company_name"].ToString();
                                }
                                logstic.Action = obj["action"].ToString();
                                if (LogisticsBLL.TidIsExist(logstic.Tid))
                                {

                                    LogisticsBLL.updateLogistics(logstic);
                                }
                                else
                                {
                                    LogisticsBLL.AddLogistics(logstic);
                                }
                            }
                            else
                            {
                                NotifyTrade trade = null;
                                Console.WriteLine(DateTime.Now.ToString() + ":店铺管家订单:" + e.Message.Content);
                                trade = new NotifyTrade();
                                trade.Tid = obj["tid"].ToString();
                                trade.BuyerNick = obj["buyer_nick"].ToString();
                                trade.Status = status;
                                trade.SellerNick = obj["seller_nick"].ToString();
                                trade.Oid = obj["oid"].ToString();
                                trade.Payment = obj["payment"].ToString();
                                if (!DBUtil.CheckNoteTradeIsExit(trade.Tid.ToString()))
                                {
                                    DBUtil.AddNoteTradeToDB(trade);//物流提醒之用
                                    if (status.Equals("taobao_trade_TradeCreate"))//订单拦截之用
                                    {
                                        DBUtil.AddTradeOrderDenfense(trade);
                                    }
                                }
                                else
                                {
                                    DBUtil.UpdateNoteTradeToDB(trade);
                                }

                            }
                        }
                        catch (Exception e1)
                        {
                            Console.WriteLine(e1.ToString());
                        }
                        #endregion

                    }
                    // 默认不抛出异常则认为消息处理成功  
                }
                catch (Exception exp)
                {
                    ExceptionReporter.WriteLog(exp, ExceptionPostion.TBApply_Data);
                    e.Fail(); // 消息处理失败回滚，服务端需要重发  
                }
            };
            client.Connect("ws://mc.api.taobao.com/");
            Console.ReadLine();
        }
    }
}
