using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using Top.Api.Domain;
using System.Data.SqlClient;
using CHENGTUAN.Components;
using CHENGTUAN.Entity;
using CTCRM.RatingServiceHouTai.TOPRating;

namespace CTCRM.RatingServiceHouTai
{
  public  class AutoMsgDB
    {
        /// <summary>
        /// 添加卖家评价历史
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static bool AddRateHisWithSeller(TradeRate obj)
        {
            try
            {
                string query = @"insert into SellerRateHis(oid,tid,nick,result,created,content,rateType)
                                 values(@oid,@tid,@nick,@result,@created,@content,@rateType)";

                SqlParameter[] param = new SqlParameter[] 
                {
                    new SqlParameter("@oid",obj.Oid),
                    new SqlParameter("@tid",obj.Tid),
                    new SqlParameter("@nick",obj.Nick == null ? "" : obj.Nick),
                    new SqlParameter("@result",obj.Result == null ? "" : obj.Result),
                    new SqlParameter("@created",obj.Created == null ? "" : obj.Created),
                    new SqlParameter("@content",obj.Content == null ? "" : obj.Content),
                    new SqlParameter("@rateType","自动评价")
                };
                DataBase.ExecuteSql(query, param);
                return true;
            }
            catch (Exception ex)
            {
                //主键重复，发生异常。ExceptionReporter.WriteLog(ex, CHENGTUAN.Entity.ExceptionPostion.TBApply_Data);
                return false;
            }
        }



        /// <summary>
        /// 查询开通了自动评价的卖家
        /// </summary>
        /// <returns></returns>
        public static DataTable GetSellerWhichSetAtuoRate(string sellerNick)
        {
            try
            {
                string query = @"select * from RateConfig where isAutoRating = 1 and sellerNick = @sellerNick";
                SqlParameter[] param = new SqlParameter[] 
                {
                    new SqlParameter("@sellerNick",sellerNick) 
                };
                DataTable dt = DataBase.ExecuteDt(query, param, CommandType.Text);
                return dt;
            }
            catch (Exception ex)
            {
                ExceptionReporter.WriteLog(ex, ExceptionPostion.TBApply_Data);
                return null;
            }
        }

        /// <summary>
        /// 查询订购日期内有有效的卖家且已经开通了自动评价功能的卖家
        /// </summary>
        /// <returns></returns>
        public static DataTable GetValidSeller()
        {
            try
            {
                string query = @"select S.SESSKEY,S.endDate,S.NICK from Seller S
inner join RateConfig R on S.NICK = R.sellerNick where S.endDate > getdate() and R.isAutoRating = 1";
                DataTable dt = DataBase.ExecuteDt(query);
                return dt;
            }
            catch (Exception ex)
            {
                ExceptionReporter.WriteLog(ex, ExceptionPostion.TBApply_Data);
                return null;
            }
        }

        /// <summary>
        /// 检查秒评用户是否是黑名单用户
        /// </summary>
        /// <param name="sellerNick"></param>
        /// <param name="buerNick"></param>
        /// <returns></returns>
        public static Boolean CheckIsBlacklst(string sellerNick, string buerNick)
        {
            try
            {
                string query = @"select 1 from BlakList where sellerNick = @sellerNick and blakName = @blakName";
                SqlParameter[] param = new SqlParameter[]
            {
                new SqlParameter("@sellerNick",sellerNick),
                new SqlParameter("@blakName",buerNick)   
            };
                DataTable dt = DataBase.ExecuteDt(query, param, CommandType.Text);
                if (dt != null && dt.Rows.Count > 0)
                {
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                ExceptionReporter.WriteLog(ex, ExceptionPostion.TBApply_Data);
                return false;
            }
        }

        /// <summary>
        /// 根据条件过滤需要评价的交易数据
        /// </summary>
        /// <param name="sellerNick"></param>
        /// <param name="fliterRow"></param>
        /// <param name="startDate"></param>
        /// <param name="endDate"></param>
        /// <param name="hasNextPage"></param>
        /// <param name="sesionKey"></param>
        /// <returns></returns>

        public static DataTable GetRateTradeData(string sellerNick, DataRow fliterRow, DateTime startDate, DateTime endDate, string sesionKey)
        {
            try
            {
                //默认取第一页
                Boolean hasNextPage = false;
                long pageNo = 0;
                //返回需要评价的交易数据源：根据保存的评价配置策略
                DataTable dtAllOrder = new DataTable();
                dtAllOrder.Columns.Add("tid");
                dtAllOrder.Columns.Add("oid");
                dtAllOrder.Columns.Add("blackBuyerRatedIsRate");//如果黑名单买家已评之后的处理方式
                //取得设定条件内的订单数据
                do
                {
                    pageNo++;
                    GetCanRateTID(sellerNick, fliterRow, startDate, endDate, ref hasNextPage, sesionKey, pageNo, dtAllOrder);
                }
                while (hasNextPage);

                return dtAllOrder;
            }
            catch (Exception ex)
            {
                ExceptionReporter.WriteLog(ex, ExceptionPostion.TBApply_Data);
                return null;
            }
        }

        private static void GetCanRateTID(string sellerNick, DataRow fliterRow, DateTime startDate, DateTime endDate, ref bool hasNextPage, string sesionKey, long pageNo, DataTable dtAllOrder)
        {

            List<Trade> objTradeRateList = TBTrade.GetBuyerTrade(sellerNick, startDate, endDate, ref hasNextPage, sesionKey, pageNo);
            for (int i = 0; i < objTradeRateList.Count; i++)
            {
                //在评价之前需要对订单成功的时间进行判定（end_time）,如果超过15天，不用再通过该接口进行评价
                if (Convert.ToDateTime(objTradeRateList[i].EndTime) < DateTime.Now.AddDays(-15)) { continue; }
                //如果双方已评价则过滤
                if (objTradeRateList[i].SellerRate) { continue; }

                DateTime tradeEndTime = Convert.ToDateTime(objTradeRateList[i].EndTime);

                #region 第二套评价：买家评价以后评价
                if (Convert.ToInt32(fliterRow["isWaitBuyerRate"]).Equals(1))
                {
                    foreach (Order o in objTradeRateList[i].Orders)
                    {
                        var buyerNick = objTradeRateList[i].BuyerNick;
                        //检查是不是黑名单买家
                        if (!CheckIsBlacklst(sellerNick, buyerNick))
                        {
                            if (o.BuyerRate)//买家已评价
                            {
                                DataRow drALLOrder = dtAllOrder.NewRow();
                                drALLOrder["tid"] = objTradeRateList[i].Tid.ToString();
                                drALLOrder["oid"] = o.Oid.ToString();
                                drALLOrder["blackBuyerRatedIsRate"] = "0";//表示默认好评
                                dtAllOrder.Rows.Add(drALLOrder);
                            }
                            else
                            {
                                if (Convert.ToInt32(fliterRow["waitBuyerTimeDay"]).Equals(0)
                                    && Convert.ToInt32(fliterRow["waitBuyerTimeHour"]).Equals(0)
                                    && Convert.ToInt32(fliterRow["waitBuyerTimeFen"]).Equals(0))
                                {
                                    continue;
                                }

                                DateTime BuyerStartRateDate = tradeEndTime
                                      .AddDays(Convert.ToDouble(fliterRow["waitBuyerTimeDay"]))
                                      .AddHours(Convert.ToDouble(fliterRow["waitBuyerTimeHour"]))
                                      .AddMinutes(Convert.ToDouble(fliterRow["waitBuyerTimeFen"]));
                                TimeSpan ts = DateTime.Now.Subtract(BuyerStartRateDate);
                                if (ts.Days > 0 || ts.Hours > 0 || ts.Minutes > 0)//定时评价
                                {
                                    DataRow drALLOrder2 = dtAllOrder.NewRow();
                                    drALLOrder2["tid"] = objTradeRateList[i].Tid.ToString();
                                    drALLOrder2["oid"] = o.Oid.ToString();
                                    drALLOrder2["blackBuyerRatedIsRate"] = "0";//表示默认好评
                                    dtAllOrder.Rows.Add(drALLOrder2);
                                }
                            }
                        }
                        else//黑名单买家
                        {
                            if (!o.BuyerRate)//如果黑名单买家一直未评价
                            {
                                if (Convert.ToInt32(fliterRow["blackBuyerNoRateQiangRateDay"]).Equals(0)
                                   && Convert.ToInt32(fliterRow["blackBuyerNoRateQiangRateHour"]).Equals(0)
                                   && Convert.ToInt32(fliterRow["blackBuyerNoRateQiangRateFen"]).Equals(0))
                                {
                                    continue;
                                }
                                DateTime blackBuyerStartRateDate = tradeEndTime
                                        .AddDays(Convert.ToInt32(fliterRow["blackBuyerNoRateQiangRateDay"]))
                                        .AddHours(Convert.ToInt32(fliterRow["blackBuyerNoRateQiangRateHour"]))
                                        .AddMinutes(Convert.ToInt32(fliterRow["blackBuyerNoRateQiangRateFen"]));

                                TimeSpan ts2 = DateTime.Now.Subtract(blackBuyerStartRateDate);
                                if (ts2.Days > 0 || ts2.Hours > 0 || ts2.Minutes > 0)//定时评价
                                {
                                    DataRow drALLOrder3 = dtAllOrder.NewRow();
                                    drALLOrder3["tid"] = objTradeRateList[i].Tid.ToString();
                                    drALLOrder3["oid"] = o.Oid.ToString();
                                    drALLOrder3["blackBuyerRatedIsRate"] = "0";//表示默认好评;
                                    dtAllOrder.Rows.Add(drALLOrder3);
                                }

                            }
                            else if (o.BuyerRate)
                            {
                                if (Convert.ToInt32(fliterRow["blackBuyerRatedIsRate"]).Equals(1))//不自动评价
                                {
                                    continue;
                                }
                                if (Convert.ToInt32(fliterRow["blackBuyerRatedIsRate"]).Equals(2))//自动好评
                                {
                                    DataRow drALLOrder = dtAllOrder.NewRow();
                                    drALLOrder["tid"] = objTradeRateList[i].Tid.ToString();
                                    drALLOrder["oid"] = o.Oid.ToString();
                                    drALLOrder["blackBuyerRatedIsRate"] = "2";
                                    dtAllOrder.Rows.Add(drALLOrder);
                                }
                                if (Convert.ToInt32(fliterRow["blackBuyerRatedIsRate"]).Equals(3))//自动中评
                                {
                                    DataRow drALLOrder = dtAllOrder.NewRow();
                                    drALLOrder["tid"] = objTradeRateList[i].Tid.ToString();
                                    drALLOrder["oid"] = o.Oid.ToString();
                                    drALLOrder["blackBuyerRatedIsRate"] = "3";
                                    dtAllOrder.Rows.Add(drALLOrder);
                                }
                                if (Convert.ToInt32(fliterRow["blackBuyerRatedIsRate"]).Equals(4))//自动差评
                                {
                                    DataRow drALLOrder = dtAllOrder.NewRow();
                                    drALLOrder["tid"] = objTradeRateList[i].Tid.ToString();
                                    drALLOrder["oid"] = o.Oid.ToString();
                                    drALLOrder["blackBuyerRatedIsRate"] = "4";
                                    dtAllOrder.Rows.Add(drALLOrder);
                                }
                            }
                        }
                    }

                }

                #endregion

                #region 评价方案三：总是在交易完成后多久评价
                if (Convert.ToInt32(fliterRow["isQiangRate"]).Equals(1))
                {
                    foreach (Order o in objTradeRateList[i].Orders)
                    {
                        if (Convert.ToInt32(fliterRow["qiangRateTimeDay"]).Equals(0)
                              && Convert.ToInt32(fliterRow["qiangRateTimeHour"]).Equals(0)
                              && Convert.ToInt32(fliterRow["qiangRateTimeFen"]).Equals(0))
                        {
                            continue;
                        }

                        DateTime qiangRateStartDate = tradeEndTime
                            .AddDays(Convert.ToInt32(fliterRow["qiangRateTimeDay"]))
                            .AddHours(Convert.ToInt32(fliterRow["qiangRateTimeHour"]))
                            .AddMinutes(Convert.ToInt32(fliterRow["qiangRateTimeFen"]));

                        TimeSpan ts3 = DateTime.Now.Subtract(qiangRateStartDate);
                        if (ts3.Days > 0 || ts3.Hours > 0 || ts3.Minutes > 0)//定时评价
                        {
                            DataRow drALLOrder = dtAllOrder.NewRow();
                            drALLOrder["tid"] = objTradeRateList[i].Tid.ToString();
                            drALLOrder["oid"] = o.Oid.ToString();
                            drALLOrder["blackBuyerRatedIsRate"] = "0";//表示默认好评
                            dtAllOrder.Rows.Add(drALLOrder);
                        }
                    }
                }
                #endregion
            }
        }
    }
}
