using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using Top.Api.Domain;
using CHENGTUAN.Components;
using CHENGTUAN.Entity;
using System.Data;
using Top.Api.Domain;
using Top.Api;
using Top.Api.Request;
using Top.Api.Response;

namespace CTCRM.DAL
{
    public class TradeDAL
    {

        public static bool AddTrade(Trade o)
        {
            try
            {
                string query = @"insert into Trade(tid,title,status,buyer_nick,buyer_alipay_no,seller_nick)
                               values(@tid,@title,@status,@buyer_nick,@buyer_alipay_no,@seller_nick)";

                SqlParameter[] param = new SqlParameter[] 
                {
                    new SqlParameter("@tid",o.Tid),
                    new SqlParameter("@title",o.Title == null?"":o.Title),
                    new SqlParameter("@status",o.Status == null?"":o.Status),
                    new SqlParameter("@buyer_nick",o.BuyerNick == null ? "":o.BuyerNick),
                    new SqlParameter("@seller_nick",o.SellerNick==null?"":o.SellerNick),
                    new SqlParameter("@buyer_alipay_no",o.BuyerAlipayNo == null?"":o.BuyerAlipayNo)
                };
                DataBase.ExecuteSql(query, param);
                return true;
            }
            catch (Exception ex)
            {
                ExceptionReporter.WriteLog(ex, ExceptionPostion.TBApply_Data);
                return false;
            }
        }



        public static bool UpdateTrade(Trade o)
        {
            try
            {
                string query = @"update Trade set title = @title,status = @status where tid = @tid";

                SqlParameter[] param = new SqlParameter[] 
                {
                    new SqlParameter("@tid",o.Tid), 
                    new SqlParameter("@title",o.Title == null?"":o.Title),
                    new SqlParameter("@status",o.Status == null?"":o.Status),
                };
                DataBase.ExecuteSql(query, param);
                return true;
            }
            catch (Exception ex)
            {
                ExceptionReporter.WriteLog(ex, ExceptionPostion.TBApply_Data);
                return false;
            }
        }

        public static DataTable GetTradeByTID(string tid)
        {
            try
            {
                string query = @"select modified from Trade where tid = @tid ";
                SqlParameter[] param = new SqlParameter[]
                {
                    new SqlParameter("@tid",tid)
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


        public static bool AddOrder(Order o, Int64 tid)
        {
            try
            {
                string query = @"insert into TradeOrder(oid,status,title,seller_nick,buyer_nick,tid,price,num,refund_status)values(@oid,@status,@title,@seller_nick,@buyer_nick,@tid,@price,@num,@refund_status)";

                SqlParameter[] param = new SqlParameter[] 
                {
                    new SqlParameter("@oid",o.Oid),
                    new SqlParameter("@status",o.Status== null?"":o.Status),
                    new SqlParameter("@title",o.Title == null?"":o.Title),
                    new SqlParameter("@seller_nick",o.SellerNick),
                    new SqlParameter("@buyer_nick",o.BuyerNick == null?"":o.BuyerNick),
                    new SqlParameter("@tid",tid),
                     new SqlParameter("@price",o.Price == null?"":o.Price),
                      new SqlParameter("@num",o.Num),
                     new SqlParameter("@refund_status",o.RefundStatus==null?"":o.RefundStatus)
                };
                DataBase.ExecuteSql(query, param);
                return true;
            }
            catch (Exception ex)
            {
                ExceptionReporter.WriteLog(ex, ExceptionPostion.TBApply_Data);
                return false;
            }
        }

        public static bool UpdateOrder(Order o, Int64 tid)
        {
            try
            {
                string query = @"update TradeOrder set status = @status,tid = @tid where oid = @oid";

                SqlParameter[] param = new SqlParameter[] 
                {
                    new SqlParameter("@oid",o.Oid),
                    new SqlParameter("@status",o.Status== null?"":o.Status),
                    new SqlParameter("@tid",tid)
                };
                DataBase.ExecuteSql(query, param);
                return true;
            }
            catch (Exception ex)
            {
                ExceptionReporter.WriteLog(ex, ExceptionPostion.TBApply_Data);
                return false;
            }
        }


        public static DataTable GetOrderByOID(string oid)
        {
            try
            {
                string query = @"select modified from TradeOrder where oid = @oid ";
                SqlParameter[] param = new SqlParameter[]
                {
                    new SqlParameter("@oid",oid)
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


        public static Boolean CheckOrderIsExit(long oid)
        {
            try
            {
                string query = @"SELECT 1 FROM TradeOrder WHERE oid=@oid";
                SqlParameter[] param = new SqlParameter[]
            {
                new SqlParameter("@oid",oid)
            };
                DataTable dt = DataBase.ExecuteDt(query, param, CommandType.Text);
                if (dt.Rows.Count > 0)
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

        public static Boolean CheckTradeIsExit(long tid)
        {
            try
            {
                string query = @"SELECT 1 FROM Trade WHERE tid=@tid";
                SqlParameter[] param = new SqlParameter[]
            {
                new SqlParameter("@tid",tid)
            };
                DataTable dt = DataBase.ExecuteDt(query, param, CommandType.Text);
                if (dt.Rows.Count > 0)
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



        public static DataTable GetTop10Sales(string sellerNick)
        {
            try
            {
                string query = @"select top 15 title,price,count(num) as num,(count(num) * cast(price as decimal(18,2))) as totalTrade from TradeOrder 
                               where seller_nick = @seller_nick group by title,price order by num desc";
                SqlParameter[] param = new SqlParameter[]
            {
                new SqlParameter("@seller_nick",sellerNick)
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
        /// 查询主动通知信息从DB开始用于发送短信
        /// </summary>
        /// <returns></returns>
        public static DataTable GetTradeData(string sellerNick)
        {
            try
            {
                string query = @"select tid,seller_nick,status,buyer_nick,createDate,modified,payment from NotifyTrade  ";
                List<SqlParameter> list = new List<SqlParameter>();
                if (!string.IsNullOrEmpty(sellerNick))
                {
                    query += " where seller_nick = @seller_nick ";
                    SqlParameter p1 = new SqlParameter("@seller_nick", sellerNick);
                    list.Add(p1);
                }
                SqlParameter[] strParam = list.ToArray();
                DataTable dt = DataBase.ExecuteDt(query, strParam, CommandType.Text);
                return dt;
            }
            catch (Exception ex)
            {
                ExceptionReporter.WriteLog(ex, ExceptionPostion.TBApply_Data);
                return null;
            }
        }


        /// <summary>
        /// 查询卖家物流已经签收，但未确认收货的买家的订单
        /// </summary>
        /// <param name="sellerNick"></param>
        /// <param name="status"></param>
        /// <returns></returns>
        public static DataTable GetTradeData(string sellerNick, string status)
        {
            try
            {
                string query = @"select a.buyer_nick,a.tid,a.payment,a.createDate,'已经签收，但未确认收货' as stutas,
                 b.company_name from NotifyTrade as a,tab_logistics as b where a.tid=b.tid and 
                a.status='taobao_trade_TradeSellerShip' and  b.action='SIGNED' ";
                List<SqlParameter> list = new List<SqlParameter>();
                if (!string.IsNullOrEmpty(sellerNick))
                {
                    SqlParameter p1 = new SqlParameter("@nick", sellerNick);
                    list.Add(p1);
                    query += " and a.seller_nick =@nick";
                }
                SqlParameter[] strParam = list.ToArray();
                DataTable dt = DataBase.ExecuteDt(query, strParam, CommandType.Text);
                return dt;
            }
            catch (Exception ex)
            {
                ExceptionReporter.WriteLog(ex, ExceptionPostion.TBApply_Data);
                return null;
            }
        }

        /// <summary>
        /// 查询卖家已经确认收获，但物流未签收的买家订单
        /// </summary>
        /// <param name="sellerNick"></param>
        /// <param name="status"></param>
        /// <returns></returns>
        public static DataTable GetTradeDataNosign(string sellerNick, string status)
        {
            try
            {
                string query = @"
                select a.buyer_nick,a.tid,a.payment,a.createDate,'已经确认收获，但物流未签收' as stutas ,
                 b.company_name from NotifyTrade as a,tab_logistics as b where a.tid=b.tid and 
                 a.status='taobao_trade_TradeSuccess' and  b.action not in('SIGNED','TRADE_SUCCESS') ";
                List<SqlParameter> list = new List<SqlParameter>();
                if (!string.IsNullOrEmpty(sellerNick))
                {
                    SqlParameter p1 = new SqlParameter("@nick", sellerNick);
                    list.Add(p1);
                    query += " and a.seller_nick =@nick";
                }
                SqlParameter[] strParam = list.ToArray();
                DataTable dt = DataBase.ExecuteDt(query, strParam, CommandType.Text);
                return dt;
            }
            catch (Exception ex)
            {
                ExceptionReporter.WriteLog(ex, ExceptionPostion.TBApply_Data);
                return null;
            }
        }

        /// <summary>
        /// 查询物流未签收的买家订单
        /// </summary>
        /// <param name="sellerNick"></param>
        /// <param name="status"></param>
        /// <returns></returns>
        public static DataTable GetTradeDataNoSuccess(string sellerNick, string status)
        {
            try
            {
                string query = @"
                select a.buyer_nick,a.tid,a.payment,a.createDate,'未签收,未收货' as stutas ,
                 b.company_name from NotifyTrade as a,tab_logistics as b where a.tid=b.tid and 
                 a.status!='taobao_trade_TradeSuccess' and  b.action not in('SIGNED','TRADE_SUCCESS')";
                List<SqlParameter> list = new List<SqlParameter>();
                if (!string.IsNullOrEmpty(sellerNick))
                {
                    SqlParameter p1 = new SqlParameter("@nick", sellerNick);
                    list.Add(p1);
                    query += " and a.seller_nick =@nick";
                }
                SqlParameter[] strParam = list.ToArray();
                DataTable dt = DataBase.ExecuteDt(query, strParam, CommandType.Text);
                return dt;
            }
            catch (Exception ex)
            {
                ExceptionReporter.WriteLog(ex, ExceptionPostion.TBApply_Data);
                return null;
            }
        }

        /// <summary>
        /// 查询卖家物流已经签收，但未确认收货的买家的订单
        /// </summary>
        /// <param name="sellerNick"></param>
        /// <param name="status"></param>
        /// <returns></returns>
        public static DataTable GetTradeData(string sellerNick, string startDate, string endDate, string startPay, string endDPay, string status)
        {
            try
            {
                string query = @"select a.buyer_nick,a.tid,a.payment,a.createDate,'已经签收，但未确认收货' as stutas,
                 b.company_name from NotifyTrade as a,tab_logistics as b where a.tid=b.tid and 
                a.status='taobao_trade_TradeSellerShip' and  b.action='SIGNED' ";
                List<SqlParameter> list = new List<SqlParameter>();
                if (!string.IsNullOrEmpty(sellerNick))
                {
                    SqlParameter p1 = new SqlParameter("@nick", sellerNick);
                    list.Add(p1);
                    query += " and a.seller_nick =@nick";
                }
                if (!string.IsNullOrEmpty(startDate))
                {
                    SqlParameter p1 = new SqlParameter("@createdate", startDate);
                    list.Add(p1);
                    query += " and a.createdate >@createdate";
                }
                if (!string.IsNullOrEmpty(endDate))
                {
                    SqlParameter p1 = new SqlParameter("@endcreatedate", endDate);
                    list.Add(p1);
                    query += " and a.createdate <@endcreatedate";
                }
                if (!string.IsNullOrEmpty(startPay))
                {
                    SqlParameter p1 = new SqlParameter("@startPay", startPay);
                    list.Add(p1);
                    query += " and convert(numeric(6,2),a.payment)  >@startPay";
                }
                if (!string.IsNullOrEmpty(endDPay))
                {
                    SqlParameter p1 = new SqlParameter("@endDPay", endDPay);
                    list.Add(p1);
                    query += " and convert(numeric(6,2),a.payment)  <@endDPay";
                }
                SqlParameter[] strParam = list.ToArray();
                DataTable dt = DataBase.ExecuteDt(query, strParam, CommandType.Text);
                return dt;
            }
            catch (Exception ex)
            {
                ExceptionReporter.WriteLog(ex, ExceptionPostion.TBApply_Data);
                return null;
            }
        }

        /// <summary>
        /// 查询卖家已经确认收获，但物流未签收的买家订单
        /// </summary>
        /// <param name="sellerNick"></param>
        /// <param name="status"></param>
        /// <returns></returns>
        public static DataTable GetTradeDataNosign(string sellerNick, string startDate, string endDate, string startPay, string endDPay, string status)
        {
            try
            {
                string query = @"
                select a.buyer_nick,a.tid,a.payment,a.createDate,'已经确认收获，但物流未签收' as stutas ,
                 b.company_name from NotifyTrade as a,tab_logistics as b where a.tid=b.tid and 
                 a.status='taobao_trade_TradeSuccess' and  b.action not in('SIGNED','TRADE_SUCCESS') ";
                List<SqlParameter> list = new List<SqlParameter>();
                if (!string.IsNullOrEmpty(sellerNick))
                {
                    SqlParameter p1 = new SqlParameter("@nick", sellerNick);
                    list.Add(p1);
                    query += " and a.seller_nick =@nick";
                }
                if (!string.IsNullOrEmpty(startDate))
                {
                    SqlParameter p1 = new SqlParameter("@createdate", startDate);
                    list.Add(p1);
                    query += " and a.createdate >@createdate";
                }
                if (!string.IsNullOrEmpty(endDate))
                {
                    SqlParameter p1 = new SqlParameter("@endcreatedate", endDate);
                    list.Add(p1);
                    query += " and a.createdate <@endcreatedate";
                }
                if (!string.IsNullOrEmpty(startPay))
                {
                    SqlParameter p1 = new SqlParameter("@startPay", startPay);
                    list.Add(p1);
                    query += " and convert(numeric(6,2),a.payment)  >@startPay";
                }
                if (!string.IsNullOrEmpty(endDPay))
                {
                    SqlParameter p1 = new SqlParameter("@endDPay", endDPay);
                    list.Add(p1);
                    query += " and convert(numeric(6,2),a.payment)  <@endDPay";
                }
                SqlParameter[] strParam = list.ToArray();
                DataTable dt = DataBase.ExecuteDt(query, strParam, CommandType.Text);
                return dt;
            }
            catch (Exception ex)
            {
                ExceptionReporter.WriteLog(ex, ExceptionPostion.TBApply_Data);
                return null;
            }
        }

        /// <summary>
        /// 查询物流未签收的买家订单
        /// </summary>
        /// <param name="sellerNick"></param>
        /// <param name="status"></param>
        /// <returns></returns>
        public static DataTable GetTradeDataNoSuccess(string sellerNick, string startDate, string endDate, string startPay, string endDPay, string status)
        {
            try
            {
                string query = @"
                select a.buyer_nick,a.tid,a.payment,a.createDate,'未签收,未收货' as stutas ,
                 b.company_name from NotifyTrade as a,tab_logistics as b where a.tid=b.tid and 
                 a.status!='taobao_trade_TradeSuccess' and  b.action not in('SIGNED','TRADE_SUCCESS')";
                List<SqlParameter> list = new List<SqlParameter>();
                if (!string.IsNullOrEmpty(sellerNick))
                {
                    SqlParameter p1 = new SqlParameter("@nick", sellerNick);
                    list.Add(p1);
                    query += " and a.seller_nick =@nick";
                }
                if (!string.IsNullOrEmpty(startDate))
                {
                    SqlParameter p1 = new SqlParameter("@createdate", startDate);
                    list.Add(p1);
                    query += " and a.createdate >@createdate";
                }
                if (!string.IsNullOrEmpty(endDate))
                {
                    SqlParameter p1 = new SqlParameter("@endcreatedate", endDate);
                    list.Add(p1);
                    query += " and a.createdate <@endcreatedate";
                }
                if (!string.IsNullOrEmpty(startPay))
                {
                    SqlParameter p1 = new SqlParameter("@startPay", startPay);
                    list.Add(p1);
                    query += " and convert(numeric(6,2),a.payment)  >@startPay";
                }
                if (!string.IsNullOrEmpty(endDPay))
                {
                    SqlParameter p1 = new SqlParameter("@endDPay", endDPay);
                    list.Add(p1);
                    query += " and convert(numeric(6,2),a.payment)  <@endDPay";
                }
                SqlParameter[] strParam = list.ToArray();
                DataTable dt = DataBase.ExecuteDt(query, strParam, CommandType.Text);
                return dt;
            }
            catch (Exception ex)
            {
                ExceptionReporter.WriteLog(ex, ExceptionPostion.TBApply_Data);
                return null;
            }
        }

    }
}
