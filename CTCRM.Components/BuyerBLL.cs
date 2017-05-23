using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CTCRM.DAL;
using CTCRM.Entity;
using System.Data;
using Top.Api.Domain;
using CTCRM.Components.TopCRM;
using CHENGTUAN.Components;
using CHENGTUAN.Entity;
using System.IO;

namespace CTCRM.Components
{
    public class BuyerBLL
    {
        public BuyerBLL()
        {

        }
        /// <summary>
        /// 同步会员信息
        /// </summary>
        /// <param name="strNick"></param>
        /// <param name="strSessionKey"></param>
        /// <returns></returns>
        public Boolean SynicBuyersInformation(string strNick, string strSessionKey)
        {
            List<CrmMember> buyers = null;
            int PageNo = 1, PageSize = 100, nProcess;
            long total = 0;

            //交易同步
            List<Trade> allTrades = new List<Trade>();
            Int64 tradePageNo = 1;
            Boolean hasNext = false;
            TBTrade tbTrade = new TBTrade();
            do
            {
                //获取卖家3个月的交易数据
                List<Trade> partTrades = tbTrade.GetBuyerTrades(strSessionKey, tradePageNo, ref hasNext);
                
                if (partTrades != null && partTrades.Count > 0)
                {
                    allTrades.AddRange(partTrades);//将list加入到末尾
                }
                tradePageNo++;
            } while (hasNext);//hasNext表示是否有下一页
            if (allTrades == null)
            {
                Console.WriteLine("卖家" + strNick + "的3个月的交易量：null");
                return false;
            }
            Console.WriteLine("卖家" + strNick + "的3个月的交易量：" + allTrades.Count.ToString());

            do
            {
                try
                {
                    //获取买家信息
                    buyers = GetTBBuyerList(strSessionKey, PageNo, PageSize, ref total);
                    if (buyers == null)
                    {
                        Console.WriteLine("卖家" + strNick + "的买家数量：null");
                        continue;
                    }
                    //Console.WriteLine("卖家" + strNick + "的买家数量：" + buyers.Count.ToString());
                    SynchronizeBuyerInfoWithSeller(strNick, strSessionKey, buyers, allTrades);
                    if (total != 0)
                    {
                        nProcess = (int)(PageNo * PageSize * 100F / total);
                    }
                    else
                    {
                        nProcess = 0;
                    }
                    if (nProcess > 100) nProcess = 100;
                    SellersBLL.SetSyncProcess(strNick, nProcess);
                }
                catch (Exception ex)
                {
                    ExceptionReporter.WriteLog(ex, ExceptionPostion.TBApply_Data);
                }
            } while (PageNo++ * PageSize < total);
            return true;
        }

        /// <summary>
        /// 同步近3个月会员信息
        /// </summary>
        /// <param name="strNick"></param>
        /// <param name="strSessionKey"></param>
        /// <param name="startDate"></param>
        /// <param name="endDate"></param>
        /// <returns></returns>
        public Boolean SynBuyersInfo3Months(string strNick, string strSessionKey, DateTime startDate, DateTime endDate)
        {
            //会员同步
            List<CrmMember> buyers = null;
            int PageNo = 1, PageSize = 100;
            long total = 0;
            //交易同步
            List<Trade> allTrades = new List<Trade>();
            Int64 tradePageNo = 1;
            Boolean hasNext = false;
            TBTrade tbTrade = new TBTrade();  
            do
            {
                //读取卖家最近3个月的交易数据
                List<Trade> partTrades = tbTrade.GetBuyerTrades(strSessionKey, tradePageNo, ref hasNext);
                if (partTrades != null && partTrades.Count > 0)
                {
                    allTrades.AddRange(partTrades);
                }
                PageNo++;
            } while (hasNext);
            do
            {
                try
                {
                    //获取卖家会员
                    buyers = GetTBBuyerList(strSessionKey, PageNo, PageSize, ref total);
                    SynchronizeBuyerInfoWithSeller(strNick, strSessionKey, buyers, allTrades);
                }
                catch (Exception ex)
                {
                    ExceptionReporter.WriteLog(ex, ExceptionPostion.TBApply_Data);
                }
            } while (buyers.Count == 100);
            return true;
        }


        /// <summary>
        /// 同步会员信息
        /// </summary>
        /// <param name="strNick"></param>
        /// <param name="strSessionKey"></param>
        /// <param name="obj"></param>
        /// <param name="allTrades"></param>
        /// <returns></returns>
        public static bool SynchronizeBuyerInfoWithSeller(string strNick, string strSessionKey, List<CrmMember> obj, List<Trade> allTrades)
        {
            try
            {
                int synCount = 0;
                    string sellerId = SellersDAL.GetSellerIdByNick(strNick);
                    Buyers membs = null;
                    if (obj != null && obj.Count > 0)
                    {
                        foreach (var o in obj)
                        {
                            try
                            {
                                //检查卖家是否存在当前买家信息
                                if (!BuyerDAL.CheckBuyerIsExit(o.BuyerNick.ToString(), strNick, sellerId))
                                {
                                    
                                    //此处开始处理数据
                                    membs = new Buyers();
                                    //membs.BuyerId = o.BuyerId;官方接口停止返回
                                    Random random = new Random();
                                    string id = DateTime.Now.Ticks.ToString().Substring(0, DateTime.Now.Ticks.ToString().Length - 4) + random.Next(1, 100).ToString();
                                    membs.BuyerId = Convert.ToInt64(id);
                                    membs.Buyer_nick = o.BuyerNick;
                                    membs.AvgPrice = o.AvgPrice;
                                    membs.Status = o.Status;
                                    membs.CloseTradeCount = o.CloseTradeCount;
                                    membs.CloseTradeAmount = o.CloseTradeAmount;
                                    membs.ItemCloseCount = o.ItemCloseCount;
                                    membs.LastTradeTime = o.LastTradeTime;
                                    membs.ItemNum = o.ItemNum;
                                    membs.TradeAmount = o.TradeAmount;
                                    membs.Grade = o.Grade;
                                    membs.Province = o.Province;
                                    membs.City = o.City;
                                    membs.TradeCount = o.TradeCount;
                                    //在交易订单中找买家详情信息
                                    Trade buyerInfo = GetBuyerInfoByNick(allTrades, o.BuyerNick);
                                    if (buyerInfo != null)
                                    {//如果有交易订单
                                        membs.Buyer_reallName = buyerInfo.ReceiverName;
                                        membs.CellPhone = buyerInfo.ReceiverMobile;
                                        membs.Address = buyerInfo.ReceiverState + buyerInfo.ReceiverCity + buyerInfo.ReceiverDistrict + buyerInfo.ReceiverAddress;
                                        membs.BuyerProvince = buyerInfo.ReceiverState.Equals("0") ? "其它" : buyerInfo.ReceiverState;
                                        membs.Buyer_credit = "1";
                                        //membs.Buyer_email = buyerInfo.BuyerEmail;
                                    }
                                    //写入买家基数信息
                                    bool re =  BuyerDAL.Add(membs, strNick, UpdateGroup(o), sellerId);//groupNo:== 1:新客户；> 1:老客户;== 0:潜在客户;3个月未购买：休眠3个月:此处为系统默认分组，不能删除，卖家可以自定义分组，可以删除。
                                    if (re)
                                    {
                                        synCount++;
                                    }
                                }
                            }
                            catch (Exception ex)
                            {
                                continue;
                            }
                        }
                    }
                    Console.WriteLine("新增卖家：" + strNick + "会员数量" + synCount);
                    ExceptionManager exceptionManager = new ExceptionManager();
                    exceptionManager.WriteFileLog(strNick, allTrades.Count.ToString(), synCount.ToString());
                return true;
            }
            catch
            {
                return false;
            }
        }
        
        /// <summary>
        /// 在交易订单中找买家详情信息
        /// </summary>
        /// <param name="tradelst"></param>
        /// <param name="buyerNick"></param>
        /// <returns></returns>
        private static Trade GetBuyerInfoByNick(List<Trade> tradelst,string buyerNick)
        {
            Trade trade = null;
            if (tradelst != null && tradelst.Count > 0)
            {
                foreach (Trade o in tradelst)
                {
                    if (o.BuyerNick.Equals(buyerNick))
                    {                       
                        trade = o;
                        break;
                    }
                }
            }
            return trade;
        }

        public static Boolean SynicOldTrade(string strSessionKey, DateTime startDate, DateTime endDate, string strNick)
        {
            List<Trade> listTrade = null;
            TBTrade tbTrade = new TBTrade();
            Buyers objBuyer = null;
            //一次性获取卖家手机号码为空的数据
            DataTable tb = BuyerOldDAL.GetBuyerNoPhone(strNick);
            if (tb != null && tb.Rows.Count > 0)
            {
                for (int i = 0; i < tb.Rows.Count; i++)
                {
                    try
                    {
                        string buyerNick = tb.Rows[i]["buyer_nick"].ToString();
                        listTrade = tbTrade.GetBuyerTrade(strSessionKey, buyerNick);
                        if (listTrade != null && listTrade.Count > 0)
                        {
                            foreach (Trade obj2 in listTrade)
                            {
                                string buyerId = tb.Rows[i]["buyer_id"].ToString();
                                objBuyer = new Buyers();
                                objBuyer.SELLER_ID = strNick;
                                objBuyer.BuyerNick = buyerNick;
                                objBuyer.Buyer_credit = "1";
                                objBuyer.BuyerId = Convert.ToInt64(buyerId);
                                objBuyer.Address = obj2.ReceiverState + obj2.ReceiverCity + obj2.ReceiverDistrict + obj2.ReceiverAddress;
                                objBuyer.BuyerProvince = obj2.ReceiverState.Equals("0") ? "其它" : obj2.ReceiverState;
                                objBuyer.CellPhone = obj2.ReceiverMobile;
                                objBuyer.Buyer_reallName = String.IsNullOrEmpty(obj2.ReceiverName) ? "unknown!" : obj2.ReceiverName;
                                BuyerOldDAL.Update(objBuyer);
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        continue;
                    }
                }
            }
            return true;
        }

        public static bool UpdateForHistory(Buyers o, string Seller_Id)
        {
            return BuyerDAL.UpdateForHistory(o, Seller_Id);
        }
        public static Boolean UpdateBuyerToBlackList(string buyerId)
        {
           return  BuyerDAL.UpdateBuyerToBlackList(buyerId,Users.SellerId); 
        }
        public static DataTable GetSellerNoDetailsInfo(string Seller_Id)
        {
            return BuyerDAL.GetSellerNoDetailsInfo(Seller_Id); 
        }

        /// <summary>
        /// 同步买家的分组
        /// </summary>
        /// <param name="o"></param>
        /// <returns></returns>
        public static string UpdateGroup(CrmMember o)
        {
            //新客户
            if (o.TradeCount == 1)
            {
                return "1";
            }
            //老客户
            if (o.TradeCount > 1)
            {
                return "2";
            }
            //潜在客户
            if (o.TradeCount == 0)
            {
                return "0";
            }
            //休眠3个月
            if (Convert.ToDateTime(o.LastTradeTime) < DateTime.Now.AddMonths(-3))
            {
                return "3";
            }
            return "0";
        }

        public static bool Update(Buyers obj)
        {
            return BuyerDAL.Update(obj,Users.SellerId);
        }

        public static DataTable GetBuyerListFromDB(Buyers entity)
        {
            return BuyerDAL.GetBuyerByBuyerID(entity,Users.SellerId);
        }
        public static String GetBuyerCount(string flag, string sellerNick)
        {
            return BuyerDAL.GetBuyerCount(flag, sellerNick, SellersDAL.GetSellerIdByNick(sellerNick));
        }
        public static String GetOldBuyerCount(string flag, string sellerNick)
        {
            return BuyerOldDAL.GetBuyerCount(flag, sellerNick);
        }
        public static bool UpdateBuyerDetails(Buyers o)
        {
            return BuyerDAL.UpdateBuyerDetails(o,Users.SellerId);
        }
        public static string GetBuyerNickByID(string buyerID)
        {
            return BuyerDAL.GetBuyerNickByID(buyerID,Users.SellerId);
        }


        public static String GetBuyerNick(string buyerID, string sellerNick)
        {
            return BuyerDAL.GetBuyerNick(buyerID, sellerNick,Users.SellerId);
        }

        /// <summary>
        /// 获取卖家的所有会员
        /// </summary>
        /// <param name="currentPage"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        public static List<CrmMember> GetTBBuyerList(string strSessionKey, long currentPage, long pageSize)
        {
            return new TBBuyer().GetBuyer(strSessionKey, currentPage, pageSize);
        }
        public static List<CrmMember> GetTBBuyerList(string strSessionKey, long currentPage, long pageSize, ref long total)
        {
            return new TBBuyer().GetBuyer(strSessionKey, currentPage, pageSize, ref total);
        }
        public static List<CrmMember> GetTBBuyerList(string strSessionKey, long currentPage, 
            long pageSize, string startDate,string endDate)
        {
            return new TBBuyer().GetBuyer(strSessionKey, currentPage, pageSize, startDate, endDate);
        }
      

        public static DataTable GetBuyerInfo(string buyerNick, string status, string area, string grade, string group, string tradeAmount1,
          string tradeAmount2, string buerNick2, string buyCount)
        {
            if (Convert.ToDateTime("2015-06-20") > Convert.ToDateTime("2015-03-31"))
            {
                return BuyerDAL.GetBuyerInfo(buyerNick, status, area, grade, group, tradeAmount1, tradeAmount2, buerNick2, buyCount, Users.SellerId);
            }
            else {
                return BuyerOldDAL.GetBuyerInfo(buyerNick, status, area, grade, group, tradeAmount1, tradeAmount2, buerNick2, buyCount);
            }
        }

        public static DataTable GetTBBuyerJiFenList(string buyerNick, string sellerNick)
        {
            return JifenDAL.GetBuyerJifenDetails(buyerNick, sellerNick);
        }

        public static bool AddJifen(Jifen jifen)
        {
            return JifenDAL.AddJifen(jifen);
        }

        public static bool MinusJifen(Jifen jifen)
        {
            return JifenDAL.MinusJifen(jifen);
        }

        public static DataTable GetGradeByID(Grade o)
        {
            return GradeDAL.GetGradeByID(o);
        }

        public static Boolean CheckTheSameHPNoIsExit(string sellerNick, string cellphone)
        {
            BuyerDAL objBuyerDal = new BuyerDAL();
            return objBuyerDal.CheckTheSameHPNoIsExit(sellerNick, cellphone,Users.SellerId);
        }

        #region 根据卖家昵称获取买家级别
        /// <summary>
        /// 根据卖家昵称获取买家级别
        /// </summary>
        /// <param name="o"></param>
        /// <returns></returns>
        public static Boolean CheckSellerGrade(Grade o)
        {
            return GradeDAL.CheckSellerGrade(o);
        }
    
        public static bool UpdateGrade(Grade o)
        {
            return GradeDAL.UpdateGrade(o);
        }
        public static bool AddGrade(Grade o)
        {
            return GradeDAL.AddGrade(o);
        }
        #endregion

        public static DataTable GetBuyerInfoBySellerNick(string sellerNick)
        {
            return BuyerDAL.GetBuyerInfoBySellerNick(sellerNick,Users.SellerId);
        }

        public static bool UpdateGrade(Buyers o)
        {
            return BuyerDAL.UpdateGrade(o,Users.SellerId);
        }


        public static bool AddGroup(CTCRM.Entity.Group o)
        {
            return GroupDAL.AddGroup(o);
        }

        public static Boolean CheckGroupIsExit(string strNick, string groupName)
        {
            return GroupDAL.CheckGroupIsExit(groupName, strNick);
        }

        public static DataTable GetGroupByID(string sellerNick)
        {
            return GroupDAL.GetGroupByID(sellerNick);
        }
        public static string GetBuyerIdByBuyerNick(string buyerNick, string sellerNick)
        {
            return BuyerDAL.GetBuyerIdByBuyerNick(buyerNick, sellerNick,Users.SellerId);
        }

        public static DataTable GetBuyerInfoToMsg(string buyerNick, string lastTradeDate1, string lastTradeDate2, string grade,string num1, string num2,
        string area, string tradeAmount1, string tradeAmount2, string buerNick2, string drpDay, string tradePinNv, string buyCount)
        {
             return BuyerDAL.GetBuyerInfoToMsg(buyerNick, lastTradeDate1, lastTradeDate2, grade, num1, num2, area,
               tradeAmount1, tradeAmount2, buerNick2, drpDay, tradePinNv, buyCount, Users.SellerId);
        }

        public static int GetBuyerTotalCount(string sellerNick)
        {
            return BuyerDAL.GetBuyerTotalCount(sellerNick,Users.SellerId);
        }

     
        public static DataTable GetExportBuyers(string SELLER_ID)
        {
             return BuyerDAL.GetExportBuyers(SELLER_ID, Users.SellerId);
        }

        /// <summary>
        /// 获取所有买家信息
        /// 20160626 yao c
        /// </summary>
        /// <param name="seller_nick">卖家昵称</param>
        /// <param name="seller_id">卖家id</param>
        /// <returns>买家信息</returns>
        public static DataTable GetExportBuyers(string seller_nick, string seller_id)
        {
            return BuyerDAL.GetExportBuyers(seller_nick, seller_id);
        }

        /// <summary>
        /// 按时间查询买家信息
        /// 20160701 yao c
        /// </summary>
        /// <param name="seller_nick">买家昵称</param>
        /// <param name="startTime">开始时间</param>
        /// <param name="endTIme">结束时间</param>
        /// <param name="seller_id">卖家id</param>
        /// <returns>买家信息</returns>
        public static DataTable GetExportBuyers(string seller_nick, string startTime, string endTIme, string seller_id)
        {
            return BuyerDAL.GetExportBuyers(seller_nick, startTime, endTIme, "all", null, null, seller_id);
        }

        public static DataTable GetExportBuyers(string SELLER_ID, string startDate, string endDate,string area,string tradeFrom,string tradeTo)
        {
             return BuyerDAL.GetExportBuyers(SELLER_ID, startDate, endDate, area, tradeFrom, tradeTo, Users.SellerId);
        }

        /// <summary>
        /// 卖家手动添加买家基本信息
        /// </summary>
        /// <param name="o"></param>
        /// <returns></returns>
        public static bool AddBuyerBySeller(Buyers o)
        {
            BuyerDAL objBuyerDal = new BuyerDAL();
            return objBuyerDal.AddBuyerBySeller(o,Users.SellerId);
        }

        public static bool Add(Buyers o, string strNick, string gorupid, string SellerId)
        {
            return BuyerDAL.Add(o, strNick, gorupid,SellerId);
        }

        /// <summary>
        /// 卖家手动添加其他店铺的买家基本信息
        /// </summary>
        /// <param name="o"></param>
        /// <returns></returns>
        public static bool AddBuyerOtherShop(Buyers o)
        {
            BuyerDAL objBuyerDal = new BuyerDAL();
            return objBuyerDal.AddBuyerOtherShop(o,Users.SellerId);
        }

        /// <summary>
        /// 通过SQL获取会员数据
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        public static DataTable GetExportBuyers(string sql,int o)
        {
            return BuyerDAL.GetExportBuyers(sql);

        }
        public static Boolean CheckBuyerIsExit(string buyer_nick, string sellerNick, string Seller_Id)
        {
            return BuyerDAL.CheckBuyerIsExit(buyer_nick, sellerNick, Seller_Id);
        }
    }
}
