using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.ServiceProcess;
using System.Text;
using CHENGTUAN.Components;
using CHENGTUAN.Entity;
using System.Threading;
using CTCRM.Entity;
using CTCRM.RatingServiceHouTai.TOPRating;
using Top.Api.Domain;

namespace CTCRM.RatingServiceHouTai
{
    public partial class Service1 : ServiceBase
    {
        public Service1()
        {
            InitializeComponent();
        }

        //#if DEBUG
        //        static byte DeleNum = 1;
        //#else
        static byte DeleNum = 64;
        //#endif

        public delegate int funTraderUserDele(string strUserName, string strSession);
        funTraderUserDele[] TraderUserFunc = new funTraderUserDele[DeleNum];
        IAsyncResult[] TraderUserSync = new IAsyncResult[DeleNum];
        List<WaitHandle> TraderUserWait = new List<WaitHandle>();

        public void DoDealList()
        {
            //获取有效期内同时开通了自动评价的卖家
            DataTable tbValidSeller = AutoMsgDB.GetValidSeller();
            //for (int i = 0; i < lsUserName.Count; i++)
            for (int i = 0; i < tbValidSeller.Rows.Count; i++)
            {
                try
                {
                    if (TraderUserWait.Count >= DeleNum)
                        WaitHandle.WaitAny(TraderUserWait.ToArray());
                    for (int k = 0; k < TraderUserSync.Length; k++)
                    {
                        if (TraderUserSync[k] == null || TraderUserSync[k].IsCompleted)
                        {
                            if (TraderUserFunc[k] != null)  //委托使用过，进行释放
                            {
                                TraderUserFunc[k].EndInvoke(TraderUserSync[k]);
                                TraderUserWait.Remove(TraderUserSync[k].AsyncWaitHandle);
                                TraderUserSync[k] = null;
                                TraderUserFunc[k] = null;
                            }
                            TraderUserFunc[k] = new funTraderUserDele(funTraderUserRating);
                            //TraderUserSync[k] = TraderUserFunc[k].BeginInvoke(lsUserName[i], lsSession[i], null, null);
                            TraderUserSync[k] = TraderUserFunc[k].BeginInvoke(tbValidSeller.Rows[i]["NICK"].ToString(), tbValidSeller.Rows[i]["SESSKEY"].ToString(), null, null);
                            TraderUserWait.Add(TraderUserSync[k].AsyncWaitHandle);
                            break;
                        }
                    }
                }
                catch (Exception err)
                {
                    ExceptionReporter.WriteLog(err, ExceptionPostion.TBApply_Data);
                }
            }

            if (TraderUserWait.Count > 0)
            {
                WaitHandle.WaitAll(TraderUserWait.ToArray());
            }
            for (int j = 0; j < TraderUserSync.Length; j++) //等待所有委托执行完成
            {
                if (TraderUserFunc[j] != null)
                {
                    TraderUserFunc[j].EndInvoke(TraderUserSync[j]);
                    TraderUserWait.Remove(TraderUserSync[j].AsyncWaitHandle);
                    TraderUserSync[j] = null;
                    TraderUserFunc[j] = null;
                }
            }
        }

        object trlockobj;
        Timer TrTimer;
        void TrTimerEvent(object sender)
        {
            if (Monitor.TryEnter(trlockobj, 30 * 60 * 1000))
            {
                try
                {
                    DoDealList();
                }
                catch (Exception err)
                {
                    ExceptionReporter.WriteLog(err, ExceptionPostion.TBApply_Data);
                }
                finally
                {
                    Monitor.Exit(trlockobj);
                }
            }
        }
        protected override void OnStart(string[] args)
        {
            trlockobj = new object();
            TrTimer = new Timer(new TimerCallback(TrTimerEvent), null, 40 * 1000, 10 * 60 * 1000);  //自动评价Timer:10分钟轮训一次
        }

        public int funTraderUserRating(string sellerNick, string sesionKey)
        {
            try
            {
                //查询卖家对应的评价策略
                DataTable tbSellerRateConfig = AutoMsgDB.GetSellerWhichSetAtuoRate(sellerNick);
                DateTime startDate = DateTime.Now.AddMonths(-1);
                DateTime endDate = DateTime.Now;
                DataTable tbRateData = AutoMsgDB.GetRateTradeData(sellerNick, tbSellerRateConfig.Rows[0], startDate, endDate, sesionKey);
                if (tbRateData != null && tbRateData.Rows.Count > 0)
                {
                    RateConfig objRate = null;
                    foreach (DataRow rw in tbRateData.Rows)
                    {
                        #region 开始评价
                        try
                        {
                            objRate = new RateConfig();
                            string tid = rw["tid"].ToString();
                            objRate.Tid = Convert.ToInt64(tid);
                            objRate.Oid = Convert.ToInt64(rw["oid"].ToString());
                            string badRattingContent = tbSellerRateConfig.Rows[0]["badRateContent"].ToString();
                            if (rw["blackBuyerRatedIsRate"].Equals("1"))//不自动评价
                            {
                                continue;
                            }
                            else if (rw["blackBuyerRatedIsRate"].Equals("3"))
                            {
                                objRate.Content1 = badRattingContent;
                                objRate.Content2 = badRattingContent;
                                objRate.Content3 = badRattingContent;
                                objRate.Result = "neutral";
                            }
                            else if (rw["blackBuyerRatedIsRate"].Equals("4"))
                            {
                                objRate.Content1 = badRattingContent;
                                objRate.Content2 = badRattingContent;
                                objRate.Content3 = badRattingContent;
                                objRate.Result = "bad";
                            }
                            else
                            {
                                objRate.Content1 = tbSellerRateConfig.Rows[0]["content1"].ToString();
                                objRate.Content2 = tbSellerRateConfig.Rows[0]["content2"].ToString();
                                objRate.Content3 = tbSellerRateConfig.Rows[0]["content3"].ToString();
                                objRate.Result = "good";
                            }
                            objRate.SellerNick = sellerNick;
                            string strContent = "";
                            TBRating objRateDal = new TBRating();
                            //新增单个评价,if faild, then list rate
                            TradeRate obj = null;
                            obj = objRateDal.BuyerTradeRateOneByOne(objRate, ref strContent, sesionKey);
                            if (obj == null)
                            {
                                obj = objRateDal.BuyerTradeRate(objRate, ref strContent, sesionKey);
                            }

                            if (obj != null)
                            {   //rating sucessfull
                                obj.Content = strContent;
                                obj.Nick = objRate.SellerNick;
                                obj.Tid = Convert.ToInt64(rw["tid"]);
                                obj.Created = obj.Created;
                                //Console.WriteLine("评价卖家：" + obj.Nick + " 评价日期：" + obj.Created);
                                AutoMsgDB.AddRateHisWithSeller(obj);
                            }
                        }
                        catch (Exception ex)
                        {
                            ExceptionReporter.WriteLog(ex, ExceptionPostion.TBApply_Data);
                            continue;
                        }
                        #endregion
                    }

                }
            }
            catch (Exception ex)
            {
                ExceptionReporter.WriteLog(ex, ExceptionPostion.TBApply_Data);
            }
            return 0;
        }
        protected override void OnStop()
        {
        }

    }
}
