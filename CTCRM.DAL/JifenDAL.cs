using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using CHENGTUAN.Components;
using CHENGTUAN.Entity;
using System.Data.SqlClient;
using CTCRM.Entity;

namespace CTCRM.DAL
{
   public class JifenDAL
    {
        /// <summary>
        /// 查询买家积分历史
        /// </summary>
        /// <returns></returns>
       public static DataTable GetBuyerJifenDetails(string buyerNick, string sellerNick)
        {
            try
            {
                string query = @"select buyer_nick,sellerNick,orderNo,jifenHis,jifenAmount,jifenComeFrom,createDate from BuyerJifen 
                                 where buyer_nick = @buyer_nick and sellerNick = @sellerNick order by createDate desc";
                SqlParameter[] param = new SqlParameter[]
                {
                    new SqlParameter("@buyer_nick",buyerNick),
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

       public static string GetBuyerTotalJifen(string buyerNick, string sellerNick)
        {
            try
            {
                string query = @"select sum(jifenHis) as jifenAmount from BuyerJifen where buyer_nick =@buyer_nick and sellerNick = @sellerNick";
                SqlParameter[] param = new SqlParameter[]
                {
                    new SqlParameter("@buyer_nick",buyerNick),
                    new SqlParameter("@sellerNick",sellerNick)
                };
                DataTable dt = DataBase.ExecuteDt(query, param, CommandType.Text);
                return String.IsNullOrEmpty(dt.Rows[0]["jifenAmount"].ToString()) ? "0" : dt.Rows[0]["jifenAmount"].ToString();
               
            }
            catch (Exception ex)
            {
                ExceptionReporter.WriteLog(ex, ExceptionPostion.TBApply_Data);
                return "0";
            }
        }

        public static DataTable GetBuyerLastTimeAddJifen(string buyerNick,string sellerNick)
        {
            try
            {
                string query = @"select jifenHis from BuyerJifen where buyer_nick = @buyer_nick and sellerNick = @sellerNick
                                 and jifenComeFrom = '系统策略赠送积分' order by createDate ";
                SqlParameter[] param = new SqlParameter[]
                {
                    new SqlParameter("@buyer_nick",buyerNick),
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


        public static bool AddJifen(Jifen jifen)
        {
            try
            {
                string query = @"insert into BuyerJifen(buyer_nick,orderNo,jifenHis,jifenAmount,jifenComeFrom,createDate,sellerNick)values
                                (@buyer_nick,@orderNo,@jifenHis,@jifenAmount,@jifenComeFrom,getdate(),@sellerNick)";
                //如果第一次增加积分
                int initJifen = Convert.ToInt32(GetBuyerTotalJifen(jifen.Buyer_Nick,jifen.SellerNick));
                if (initJifen == 0)
                {
                    initJifen = jifen.jifenHis;
                }
                else
                {
                    initJifen = initJifen + jifen.jifenHis;
                }
                SqlParameter[] param = new SqlParameter[] 
                {
                    new SqlParameter("@buyer_nick",jifen.Buyer_Nick),
                    new SqlParameter("@orderNo",jifen.OrderNo),
                    new SqlParameter("@jifenHis",jifen.jifenHis),
                    //累计买家剩余积分
                    new SqlParameter("@jifenAmount",initJifen),
                    new SqlParameter("@sellerNick",jifen.SellerNick),
                    new SqlParameter("@jifenComeFrom",jifen.JifenComeFrom)
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

        public static bool MinusJifen(Jifen jifen)
        {
            try
            {
                string query = @"insert into BuyerJifen(buyer_nick,orderNo,jifenHis,jifenAmount,jifenComeFrom,createDate,sellerNick)values
                                (@buyer_nick,@orderNo,@jifenHis,@jifenAmount,@jifenComeFrom,getdate(),@sellerNick)";

                int jifenAmount = Convert.ToInt32(GetBuyerTotalJifen(jifen.Buyer_Nick,jifen.SellerNick)) - Convert.ToInt32(jifen.jifenHis);
                if (jifenAmount < 0) {
                    return false;
                }
                SqlParameter[] param = new SqlParameter[] 
                {
                    new SqlParameter("@buyer_nick",jifen.Buyer_Nick),
                    new SqlParameter("@orderNo",jifen.OrderNo),
                    new SqlParameter("@jifenHis",Convert.ToInt32("-" + jifen.jifenHis)),
                    //累计买家剩余积分
                    new SqlParameter("@jifenAmount",Convert.ToString(Convert.ToInt32(GetBuyerTotalJifen(jifen.Buyer_Nick,jifen.SellerNick)) - Convert.ToInt32(jifen.jifenHis))),
                    new SqlParameter("@jifenComeFrom","手工消耗积分"),
                    new SqlParameter("@sellerNick",jifen.SellerNick)
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


        public static bool AddJifenConfig(JifenConfig jifen)
        {
            try
            {
                string query = @"insert into SellerJifenConfig(sellerNick,tradeAmount,canGetJifen,startDate,flag)
values(@sellerNick,@tradeAmount,@canGetJifen,@startDate,@flag)";
                SqlParameter[] param = new SqlParameter[] 
                {
                    new SqlParameter("@sellerNick",jifen.SellerNick),
                    new SqlParameter("@tradeAmount",jifen.TradeAmount),
                    new SqlParameter("@canGetJifen",jifen.CanGetJifen),
                    //累计买家剩余积分
                    new SqlParameter("@startDate",jifen.StartDate),
                    new SqlParameter("@flag",jifen.Flag)
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

        public static DataTable GetJifenConfigByNick(string sellerNick)
        {
            try
            {
                string query = @"select * from SellerJifenConfig where sellerNick =@sellerNick";
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

        public static bool UpdateJifenConfigStauts(JifenConfig o)
        {
            try
            {
                string query = @"update SellerJifenConfig set flag = @flag,tradeAmount = @tradeAmount,canGetJifen = @canGetJifen where sellerNick = @sellerNick
";

                SqlParameter[] param = new SqlParameter[] 
                {
                    new SqlParameter("@flag",o.Flag),
                    new SqlParameter("@tradeAmount",o.TradeAmount),
                    new SqlParameter("@canGetJifen",o.CanGetJifen),
                    new SqlParameter("@sellerNick",o.SellerNick)
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

    }
}
