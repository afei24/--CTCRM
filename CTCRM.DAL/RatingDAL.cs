using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using CHENGTUAN.Components;
using CHENGTUAN.Entity;
using System.Data.SqlClient;
using CTCRM.Entity;
using TTNI.Framework.Dao;
using Top.Api.Domain;
using CTCRM.Common;

namespace CTCRM.DAL
{
    //原代码访问数据库方法错误
    //修改人：Lu
    //时间：20160908
    public class RatingDAL : GenericDao
    {
        /// <summary>
        /// 查询卖家当前黑名单的个数
        /// </summary>
        /// <param name="sellerNick"></param>
        /// <returns></returns>
        public int GetBlakListCount(string sellerNick)
        {

            try
            {
                string query = "select count(1) as blakListCount from BlakList where sellerNick = @sellerNick";
                // 设置SQL参数
                SqlParameter[] param = new SqlParameter[] 
                {
                    new SqlParameter("@sellerNick",sellerNick)
                };
                DataTable dt = DataBase.ExecuteDt(query, param,CommandType.Text);
                if (dt.Rows.Count > 0)
                {
                    return Convert.ToInt32(dt.Rows[0]["blakListCount"].ToString());
                }
                return 0;
            }
            catch (Exception ex)
            {
                ExceptionReporter.WriteLog(ex, ExceptionPostion.TBApply_Data);
                return 0;
            }
        }
        public int GetBlakListCloseOrderCount(string sellerNick)
        {
            try
            {
                string query = "select count(1) as blakListCount from BlakListCloseOrder where sellerNick = @sellerNick";
                // 设置SQL参数
                SqlParameter[] param = new SqlParameter[] 
                {
                    new SqlParameter("@sellerNick",sellerNick)
                };
                DataTable dt = DataBase.ExecuteDt(query, param, CommandType.Text);
                if (dt.Rows.Count > 0)
                {
                    return Convert.ToInt32(dt.Rows[0]["blakListCount"].ToString());
                }
                return 0;
            }
            catch (Exception ex)
            {
                ExceptionReporter.WriteLog(ex, ExceptionPostion.TBApply_Data);
                return 0;
            }
        }

        /// <summary>
        /// 检查用户是否开通了秒评和自动评价
        /// </summary>
        /// <param name="sellerNick"></param>
        /// <returns></returns>
        public Boolean CheckIsMiaoPingAuto(string sellerNick)
        {
            try
            {
                string query = "select isMiaoRate from RateConfig where sellerNick = @sellerNick and isAutoRating = 1";
                // 设置SQL参数
                SqlParameter[] param = new SqlParameter[] 
                {
                    new SqlParameter("@sellerNick",sellerNick)
                };
                DataTable dt = DataBase.ExecuteDt(query, param, CommandType.Text);
                if (dt.Rows.Count > 0)
                {
                    return Convert.ToBoolean(dt.Rows[0]["isMiaoRate"].ToString());
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
        /// 查询卖家是否设置了将中差评买家自动加入黑名单中
        /// </summary>
        /// <param name="sellerNick"></param>
        /// <returns></returns>
        public DataRow CheckIsOpenAddBlakList(string sellerNick)
        {
            try
            {
                string query = "select atuoAddBlackListBadRate,atuoAddBlackListTuiKuan from RateConfig where sellerNick = @sellerNick";
                // 设置SQL参数
                SqlParameter[] param = new SqlParameter[] 
                {
                    new SqlParameter("@sellerNick",sellerNick)
                };
                DataTable dt = DataBase.ExecuteDt(query, param, CommandType.Text);
                if (dt.Rows.Count > 0)
                {
                    return dt.Rows[0];
                }
                return null;
            }
            catch (Exception ex)
            {
                ExceptionReporter.WriteLog(ex, ExceptionPostion.TBApply_Data);
                return null;
            }
        }


        /// <summary>
        /// 检查卖家是否已经开通评价配置
        /// </summary>
        /// <param name="sellerNick"></param>
        /// <returns></returns>
        public Boolean CheckRateConfigIsExit(string sellerNick)
        {
            try
            {
                string query = "select 1 from RateConfig where sellerNick = @sellerNick";
                // 设置SQL参数
                SqlParameter[] param = new SqlParameter[] 
                {
                    new SqlParameter("@sellerNick",sellerNick)
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




        /// <summary>
        /// 更新自动评价状态
        /// </summary>
        /// <param name="sellerNick"></param>
        /// <returns></returns>
        public Boolean UpdateAutoRatingStatus(string sellerNick, int openStatus)
        {
            try
            {
                string query = "update RateConfig set isAutoRating = @isAutoRating where sellerNick = @sellerNick";
                // 设置SQL参数
                SqlParameter[] param = new SqlParameter[] 
                {
                    new SqlParameter("@sellerNick",sellerNick),
                    new SqlParameter("@isAutoRating",openStatus)
                };
                int i = DataBase.ExecuteSql(query, param);
                return true;
            }
            catch (Exception ex)
            {
                ExceptionReporter.WriteLog(ex, ExceptionPostion.TBApply_Data);
                return false;
            }
        }


        /// <summary>
        /// 查询卖家当前自动评价状态
        /// </summary>
        /// <param name="sellerNick"></param>
        /// <returns></returns>
        public String GetAutoRateStatus(string sellerNick)
        {
            try
            {
                string query = "select isAutoRating from RateConfig where sellerNick = @sellerNick";
                // 设置SQL参数
                SqlParameter[] param = new SqlParameter[] 
                {
                    new SqlParameter("@sellerNick",sellerNick)
                };
                DataTable dt = DataBase.ExecuteDt(query, param, CommandType.Text);
                if (dt.Rows.Count > 0)
                {
                    if (dt.Rows[0]["isAutoRating"].Equals(1))
                    {
                        return "已开启";
                    }
                }
                return "未开启";
            }
            catch (Exception ex)
            {
                ExceptionReporter.WriteLog(ex, ExceptionPostion.TBApply_Data);
                return "未开启";
            }
        }

        /// <summary>
        /// 查询卖家昨天和今天自动评价状况
        /// </summary>
        /// <param name="sellerNick"></param>
        /// <returns></returns>
        public DataTable GetSellerAutoRateStatus(string sellerNick)
        {
            try
            {
                string query = @"select count(1) as totalYestSuc from SellerRateHis where nick = @sellerNick 
                                and CONVERT(varchar, created, 112) = CONVERT(varchar, dateadd(day,-1,getdate()), 112)
                                union all
                                select count(1) as totalTodaySuc from SellerRateHis where nick = @sellerNick  
                                and CONVERT(varchar, created, 112) = CONVERT(varchar, getdate(), 112)";
                // 设置SQL参数
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


        private DataTable ALLOrder()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("tid");
            dt.Columns.Add("oid");
            DataRow dr = dt.NewRow();
            for (int i = 0; i < 100; i++)
            {
                dr = dt.NewRow();
                dr["id"] = "00" + i.ToString();
                dr["name"] = "姓名" + i.ToString();

                dt.Rows.Add(dr);
            }
            return dt;
        }


        /// <summary>
        /// 添加卖家评价历史
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public bool AddRateHisWithSeller(TradeRate obj)
        {
            try
            {
                string query = "proc_AddRateHisWithSeller";
                SqlParameter[] param = new SqlParameter[] 
                {
                    new SqlParameter("@oid", obj.Oid),
                    new SqlParameter("@tid", obj.Tid),
                    new SqlParameter("@nick", obj.Nick == null ? "" : obj.Nick),
                    new SqlParameter("@result", obj.Result == null ? "" : obj.Result),
                    new SqlParameter("@created", obj.Created == null ? "" : obj.Created),
                    new SqlParameter("@rated_nick", obj.RatedNick == null ? "" : obj.RatedNick),
                    new SqlParameter("@content", obj.Content == null ? "" : obj.Content),
                    new SqlParameter("@reply", obj.Reply == null ? "" : obj.Reply),
                    new SqlParameter("@rateType", "手动评价")
                };
                DataBase db = new DataBase();
                db.RunProc(query, param);
                return true;
            }
            catch (Exception ex)
            {
                ExceptionReporter.WriteLog(ex, ExceptionPostion.TBApply_Data);
                return false;
            }
        }



        /// <summary>
        /// 添加卖家预警策略配置
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public bool AddRatePreReminderWithSeller(ReminderRateConfig obj)
        {
            try
            {

                SqlParameter[] param = new SqlParameter[] 
                {
                    new SqlParameter("@sellerNick", obj.SellerNick),
                    new SqlParameter("@preReminderPhone", obj.PreReminderPhone),
                    new SqlParameter("@preReminderMsgContent", obj.PreReminderMsgContent)
                };
                DataBase db = new DataBase();
                db.RunProc("proc_ReminderRateConfig2", param);
                return true;
            }
            catch (Exception ex)
            {
                ExceptionReporter.WriteLog(ex, ExceptionPostion.TBApply_Data);
                return false;
            }
        }

        /// <summary>
        /// 更新卖家预警评价配置
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public bool UpdatePreReminderRateConfig(ReminderRateConfig obj)
        {
            try
            {

                SqlParameter[] param = new SqlParameter[] 
                {
                    new SqlParameter("@sellerNick", obj.SellerNick),
                    new SqlParameter("@preReminderPhone", obj.PreReminderPhone),
                    new SqlParameter("@preReminderMsgContent", obj.PreReminderMsgContent)
                };
                DataBase db = new DataBase();
                db.RunProc("proc_UpdatePreReminderRateConfig", param);
                return true;
            }
            catch (Exception ex)
            {
                ExceptionReporter.WriteLog(ex, ExceptionPostion.TBApply_Data);
                return false;
            }
        }


        /// <summary>
        /// 添加卖家报警策略配置
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public bool AddRateReminderWithSeller(ReminderRateConfig obj)
        {
            try
            {

                SqlParameter[] param = new SqlParameter[] 
                {
                    new SqlParameter("@sellerNick", obj.SellerNick),
                    new SqlParameter("@reminderPhone", obj.ReminderPhone),
                    new SqlParameter("@reminderMsgContent", obj.ReminderMsgContent),
                    new SqlParameter("@isSendMsgToBuyer", obj.IsSendMsgToBuyer),
                    new SqlParameter("@buyerMsgContent", obj.BuyerMsgContent)
                };
                DataBase db = new DataBase();
                db.RunProc("proc_ReminderRateConfig", param);
                return true;
            }
            catch (Exception ex)
            {
                ExceptionReporter.WriteLog(ex, ExceptionPostion.TBApply_Data);
                return false;
            }
        }


        /// <summary>
        /// 更新卖家报警评价配置
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public bool UpdateReminderRateConfig(ReminderRateConfig obj)
        {
            try
            {
                SqlParameter[] param = new SqlParameter[] 
                {
                    new SqlParameter("@sellerNick", obj.SellerNick),
                    new SqlParameter("@reminderPhone", obj.ReminderPhone),
                    new SqlParameter("@reminderMsgContent", obj.ReminderMsgContent),
                    new SqlParameter("@isSendMsgToBuyer", obj.IsSendMsgToBuyer),
                    new SqlParameter("@buyerMsgContent", obj.BuyerMsgContent)
                };
                DataBase db = new DataBase();
                db.RunProc("proc_UpdateReminderRateConfig", param);
                return true;
            }
            catch (Exception ex)
            {
                ExceptionReporter.WriteLog(ex, ExceptionPostion.TBApply_Data);
                return false;
            }
        }


        /// <summary>
        /// 检查卖家是否设置了报警评价配置
        /// </summary>
        /// <param name="sellerNick"></param>
        /// <returns></returns>
        public Boolean CheckReminderRateConfigIsExit(string sellerNick)
        {
            try
            {

                SqlParameter[] param = new SqlParameter[] 
                {
                    new SqlParameter("@sellerNick", sellerNick)
                };
                DataBase db = new DataBase();
                DataTable dt = DataBase.ExecuteDt("proc_CheckReminderRateConfigIsExit", param, CommandType.StoredProcedure);
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

        /// <summary>
        /// 查询卖家的报警策略配置
        /// </summary>
        /// <param name="sellerNick"></param>
        /// <returns></returns>
        public DataTable GetReminderRateConfig(string sellerNick)
        {
            try
            {
                SqlParameter[] param = new SqlParameter[] 
                {
                    new SqlParameter("@sellerNick", sellerNick)
                };
                DataBase db = new DataBase();
                DataTable dt = DataBase.ExecuteDt("proc_GetReminderRateConfig", param, CommandType.StoredProcedure);
                return dt;

            }
            catch (Exception ex)
            {
                ExceptionReporter.WriteLog(ex, ExceptionPostion.TBApply_Data);
                return null;
            }
        }




        /// <summary>
        /// 添加卖家评价配置
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public bool AddRateConfig(RateConfig obj)
        {
            try
            {
                string query = @"
                    insert into RateConfig(sellerNick,isMiaoRate,isWaitBuyerRate,waitBuyerTimeDay,waitBuyerTimeHour,waitBuyerTimeFen,blackBuyerRatedIsRate,
                    blackBuyerNoRateQiangRateDay,blackBuyerNoRateQiangRateHour,blackBuyerNoRateQiangRateFen,isQiangRate,
                    qiangRateTimeDay,qiangRateTimeHour,qiangRateTimeFen,atuoAddBlackListBadRate,atuoAddBlackListTuiKuan,badRateContent,result,content1,content2,content3,contentChoice,
                    createDate,isAutoRating)
                    values(@sellerNick,@isMiaoRate,@isWaitBuyerRate,@waitBuyerTimeDay,@waitBuyerTimeHour,@waitBuyerTimeFen,@blackBuyerRatedIsRate,
                    @blackBuyerNoRateQiangRateDay,@blackBuyerNoRateQiangRateHour,@blackBuyerNoRateQiangRateFen,@isQiangRate,
                    @qiangRateTimeDay,@qiangRateTimeHour,@qiangRateTimeFen,@atuoAddBlackListBadRate,@atuoAddBlackListTuiKuan,@badRateContent,@result,@content1,@content2,@content3,@contentChoice,
                    getdate(),0)";
                // 设置SQL参数

                SqlParameter[] param = new SqlParameter[] 
                {

                new SqlParameter("@sellerNick", obj.SellerNick),
                new SqlParameter("@isMiaoRate", obj.IsMiaoRate),
                new SqlParameter("@isWaitBuyerRate", obj.IsWaitBuyerRate),
                new SqlParameter("@waitBuyerTimeDay", obj.WaitBuyerTimeDay),
                new SqlParameter("@waitBuyerTimeHour", obj.WaitBuyerTimeHour),
                new SqlParameter("@waitBuyerTimeFen", obj.WaitBuyerTimeFen),
               new SqlParameter("@blackBuyerRatedIsRate", obj.BlackBuyerRatedIsRate),
               new SqlParameter("@blackBuyerNoRateQiangRateDay", obj.BlackBuyerNoRateQiangRateDay),
                new SqlParameter("@blackBuyerNoRateQiangRateHour", obj.BlackBuyerNoRateQiangRateHour),
                new SqlParameter("@blackBuyerNoRateQiangRateFen", obj.BlackBuyerNoRateQiangRateFen),
                new SqlParameter("@isQiangRate", obj.IsQiangRate),
                new SqlParameter("@qiangRateTimeDay", obj.QiangRateTimeDay),
                new SqlParameter("@qiangRateTimeHour", obj.QiangRateTimeHour),
                new SqlParameter("@qiangRateTimeFen", obj.QiangRateTimeFen),
                new SqlParameter("@atuoAddBlackListBadRate", obj.AtuoAddBlackListBadRate),
                new SqlParameter("@atuoAddBlackListTuiKuan", obj.AtuoAddBlackListTuiKuan),
               new SqlParameter("@badRateContent", obj.BadRateContent== null ? "" : obj.BadRateContent),
                new SqlParameter("@result", obj.Result== null ? "" : obj.Result),
                new SqlParameter("@content1", obj.Content1 == null ? "" : obj.Content1),
                new SqlParameter("@content2", obj.Content2 == null ? "" : obj.Content2),
                new SqlParameter("@content3", obj.Content3 == null ? "" : obj.Content3),
                new SqlParameter("@contentChoice", obj.ContentChoice)
                };
                DataTable dt = DataBase.ExecuteDt(query, param,CommandType.Text);
                return true;
            }
            catch (Exception ex)
            {
                ExceptionReporter.WriteLog(ex, ExceptionPostion.TBApply_Data);
                return false;
            }
        }

        /// <summary>
        /// 判断卖家黑名单用户是否重复
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public bool ChekBlaklist(BlakList obj)
        {
            try
            {
                string query = "select 1 from BlakList where sellerNick = @sellerNick and blakName = @blakName";
                // 设置SQL参数
                SqlParameter[] param = new SqlParameter[] 
                {

                new SqlParameter("@sellerNick", obj.SellerNick),
                new SqlParameter("@blakName", obj.BlakName)
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
        public bool ChekBlaklistCloseOrder(BlakList obj)
        {
            try
            {
                string query = "select 1 from BlakListCloseOrder where sellerNick = @sellerNick and blakName = @blakName";
                // 设置SQL参数
                SqlParameter[] param = new SqlParameter[] 
                {

                new SqlParameter("@sellerNick", obj.SellerNick),
                new SqlParameter("@blakName", obj.BlakName)
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

        /// <summary>
        /// 添加卖家黑名单
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public bool AddBlaklist(BlakList obj)
        {
            try
            {
                string query = "insert into BlakList(sellerNick,blakName,createDate)values(@sellerNick,@blakName,getdate())";
                // 设置SQL参数
                SqlParameter[] param = new SqlParameter[] 
                {

                new SqlParameter("@sellerNick", obj.SellerNick),
                new SqlParameter("@blakName", obj.BlakName)
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
        public bool AddBlaklistCloseOrder(BlakList obj)
        {
            try
            {
                string query = "insert into AddBlaklist(sellerNick,blakName,createDate)values(@sellerNick,@blakName,getdate())";
                // 设置SQL参数
                SqlParameter[] param = new SqlParameter[] 
                {

                new SqlParameter("@sellerNick", obj.SellerNick),
                new SqlParameter("@blakName", obj.BlakName)
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
        /// <summary>
        /// 删除卖家黑名单
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public bool DeleteCloseOrderBlaklist(string blakListID)
        {
            try
            {
                string query = "delete from BlakListCloseOrder where blakListID = @blakListID";
                // 设置SQL参数

                SqlParameter[] param = new SqlParameter[] 
                {
                new SqlParameter("@blakListID", blakListID)
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
        public bool DeleteAllCloseOrderBlaklist(string sellerNick)
        {
            try
            {
                string query = "delete from BlakListCloseOrder where sellerNick = @sellerNick";
                // 设置SQL参数
                SqlParameter[] param = new SqlParameter[] 
                {
                new SqlParameter("@sellerNick", sellerNick)
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

        public bool DeleteBlaklist(string blakListID)
        {
            try
            {
                string query = "delete from BlakList where blakListID = @blakListID";
                // 设置SQL参数
                SqlParameter[] param = new SqlParameter[] 
                {
                new SqlParameter("@blakListID", blakListID)
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
        /// <summary>
        /// 修改卖家评价配置
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public bool UpdateRateConfig(RateConfig obj)
        {
            try
            {
                string query = @"update RateConfig 
                                set isMiaoRate = @isMiaoRate,
                                isWaitBuyerRate = @isWaitBuyerRate,
                                waitBuyerTimeDay = @waitBuyerTimeDay,
                                waitBuyerTimeHour = @waitBuyerTimeHour,
                                waitBuyerTimeFen = @waitBuyerTimeFen,
                                blackBuyerRatedIsRate = @blackBuyerRatedIsRate,
                                blackBuyerNoRateQiangRateDay = @blackBuyerNoRateQiangRateDay,
                                blackBuyerNoRateQiangRateHour = @blackBuyerNoRateQiangRateHour,
                                blackBuyerNoRateQiangRateFen = @blackBuyerNoRateQiangRateFen,
                                isQiangRate = @isQiangRate,
                                qiangRateTimeDay = @qiangRateTimeDay,
                                qiangRateTimeHour = @qiangRateTimeHour,
                                qiangRateTimeFen = @qiangRateTimeFen,
                                atuoAddBlackListBadRate =@atuoAddBlackListBadRate,
                                atuoAddBlackListTuiKuan =@atuoAddBlackListTuiKuan,
                                badRateContent = @badRateContent,
                                content1 = @content1,
                                content2 = @content2,
                                content3 = @content3,
                                contentChoice = @contentChoice,
                                updateDate = getdate()
                                where sellerNick = @sellerNick";
                // 设置SQL参数
                SqlParameter[] param = new SqlParameter[] 
                {

                new SqlParameter("@sellerNick", obj.SellerNick),
                new SqlParameter("@isMiaoRate", obj.IsMiaoRate),
                new SqlParameter("@isWaitBuyerRate", obj.IsWaitBuyerRate),
                new SqlParameter("@waitBuyerTimeDay", obj.WaitBuyerTimeDay),
                new SqlParameter("@waitBuyerTimeHour", obj.WaitBuyerTimeHour),
                new SqlParameter("@waitBuyerTimeFen", obj.WaitBuyerTimeFen),
                new SqlParameter("@blackBuyerRatedIsRate", obj.BlackBuyerRatedIsRate),
                new SqlParameter("@blackBuyerNoRateQiangRateDay", obj.BlackBuyerNoRateQiangRateDay),
                new SqlParameter("@blackBuyerNoRateQiangRateHour", obj.BlackBuyerNoRateQiangRateHour),
                new SqlParameter("@blackBuyerNoRateQiangRateFen", obj.BlackBuyerNoRateQiangRateFen),
                new SqlParameter("@isQiangRate", obj.IsQiangRate),
                new SqlParameter("@qiangRateTimeDay", obj.QiangRateTimeDay),
                new SqlParameter("@qiangRateTimeHour", obj.QiangRateTimeHour),
                new SqlParameter("@qiangRateTimeFen", obj.QiangRateTimeFen),
               new SqlParameter("@atuoAddBlackListBadRate", obj.AtuoAddBlackListBadRate),
                new SqlParameter("@atuoAddBlackListTuiKuan", obj.AtuoAddBlackListTuiKuan),
                new SqlParameter("@badRateContent", obj.BadRateContent == null ? "" : obj.BadRateContent),
                new SqlParameter("@content1", obj.Content1 == null ? "" : obj.Content1),
                new SqlParameter("@content2", obj.Content2 == null ? "" : obj.Content2),
                new SqlParameter("@content3", obj.Content3 == null ? "" : obj.Content3),
                new SqlParameter("@contentChoice", obj.ContentChoice)
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


        /// <summary>
        /// 查询卖家设定的评价策略
        /// </summary>
        /// <param name="sellerNick"></param>
        /// <returns></returns>
        public DataTable GetRateConfigByNick(string sellerNick)
        {
            try
            {
                string query = "select * from RateConfig where sellerNick = @sellerNick";
                // 设置SQL参数
                SqlParameter[] param = new SqlParameter[] 
                {
                new SqlParameter("@sellerNick", sellerNick)
                };
               DataTable dt =  DataBase.ExecuteDt(query, param,CommandType.Text);
                return dt;

            }
            catch (Exception ex)
            {
                ExceptionReporter.WriteLog(ex, ExceptionPostion.TBApply_Data);
                return null;
            }
        }




        /// <summary>
        /// 查询卖家的差评列表
        /// </summary>
        /// <param name="sellerNick"></param>
        /// <returns></returns>
        public DataTable GetBadRateListByNick(string sellerNick, string startDate, string endRateDate)
        {
            try
            {
                string query = @"select badContent,badBuyerNick,sellerNick,realName + cellphone as namePhone,rateDate,orderInfo,memo
                                from BadList where sellerNick = @sellerNick  ";
                if (!string.IsNullOrEmpty(startDate))
                {
                    query += " AND rateDate >= @startDate ";
                }
                if (!string.IsNullOrEmpty(endRateDate))
                {
                    query += " AND rateDate <= @rateDate ";
                }
                query += " order by rateDate desc ";
                SqlParameter[] param = new SqlParameter[] 
                {
                new SqlParameter("@sellerNick", sellerNick),
                new SqlParameter("@startDate", startDate),
                new SqlParameter("@rateDate", endRateDate)
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
        /// 查询批量评价日志表
        /// </summary>
        /// <param name="sellerNick"></param>
        /// <returns></returns>
        public DataTable GetAutoRateListByNick(string sellerNick, string startDate, string endRateDate)
        {
            try
            {
                string query = @"select created,tid,nick,content,rateType,result from SellerRateHis where 1 = 1  ";
                if (!string.IsNullOrEmpty(sellerNick))
                {
                    query += " AND nick = @sellerNick ";
                }
                if (!string.IsNullOrEmpty(startDate))
                {
                    query += " AND created >= @startDate ";
                }
                if (!string.IsNullOrEmpty(endRateDate))
                {
                    query += " AND created <= @rateDate ";
                }
                query += " order by created desc ";
                SqlParameter[] param = new SqlParameter[] 
                {
                new SqlParameter("@sellerNick", sellerNick),
                new SqlParameter("@startDate", startDate),
                new SqlParameter("@rateDate", endRateDate)
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
        public DataTable GetAutoRateListByNick(string sellerNick, string startDate, string endRateDate, string rateType)
        {
            try
            {
                string query = @"select created,tid,nick,content,rateType,result from SellerRateHis where 1 = 1  ";
                if (!string.IsNullOrEmpty(sellerNick))
                {
                    query += " AND nick = @sellerNick ";
                }
                if (!string.IsNullOrEmpty(startDate))
                {
                    query += " AND created >= @startDate ";
                }
                if (!string.IsNullOrEmpty(endRateDate))
                {
                    query += " AND created <= @rateDate ";
                }
                if (rateType.Equals("秒评"))
                {
                    query += " AND rateType = '秒评'";
                }
                if (rateType.Equals("自动评价"))
                {
                    query += " AND rateType = '自动评价'";
                }
                query += " order by created desc ";
                SqlParameter[] param = new SqlParameter[] 
                {
                new SqlParameter("@sellerNick", sellerNick),
                new SqlParameter("@startDate", startDate),
                new SqlParameter("@rateDate", endRateDate)
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
        /// 删除评价日志
        /// </summary>
        /// <param name="sellerNick"></param>
        /// <returns></returns>
        public Boolean DeleteRatingLog(string startDate, string endDate)
        {
            try
            {
                string query = @"delete from SellerRateHis where created >= @startDate and created <= @rateDate  ";
                if (!string.IsNullOrEmpty(startDate))
                {
                    _DBSession.SetInParam("@startDate", startDate);
                }
                if (!string.IsNullOrEmpty(endDate))
                {
                    _DBSession.SetInParam("@rateDate", endDate);
                }
                SqlParameter[] param = new SqlParameter[] 
                {
                new SqlParameter("@startDate", startDate),
                new SqlParameter("@rateDate", endDate)
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

        /// <summary>
        /// 查询卖家设置的黑名单
        /// </summary>
        /// <param name="sellerNick"></param>
        /// <returns></returns>
        public DataTable GetBlakListByNick(string sellerNick)
        {
            try
            {
                string query = "select blakListID,blakName,createDate from BlakList where sellerNick = @sellerNick";
                // 设置SQL参数
                SqlParameter[] param = new SqlParameter[] 
                {
                new SqlParameter("@sellerNick", sellerNick)
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

        public DataTable GetShopTypeByNick(string sellerNick)
        {
            try
            {
                string query = "select shopType from Seller where NICK = @NICK";
                // 设置SQL参数
                SqlParameter[] param = new SqlParameter[] 
                {
                new SqlParameter("@NICK", sellerNick)
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

        public DataTable GetCloseOrderBlakListByNick(string sellerNick)
        {
            try
            {
                string query = @"select * from BlakListCloseOrder where sellerNick = @sellerNick";
                // 设置SQL参数
                SqlParameter[] param = new SqlParameter[] 
                {
                new SqlParameter("@sellerNick", sellerNick)
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
        public DataTable GetCloseOrderLogByNick(string buerNick, string orderNo, string sellerNick)
        {
            try
            {
                string query = @"select * from CloseOrderLog where sellerNick = @sellerNick";
                if (!string.IsNullOrEmpty(buerNick))
                {
                    query += " AND buyerNick = @buyerNick ";
                }
                if (!string.IsNullOrEmpty(orderNo))
                {
                    query += " AND ordreNo = @ordreNo ";
                }
                // 设置SQL参数
                SqlParameter[] param = new SqlParameter[] 
                {
                new SqlParameter("@sellerNick", sellerNick),
                new SqlParameter("@buyerNick", buerNick),
                new SqlParameter("@ordreNo", orderNo)
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
        /// 检查卖家差自动评拦截开关是否开启
        /// </summary>
        /// <param name="sellerNick"></param>
        /// <returns></returns>
        public Boolean CheckIsAutoCloseOrder(string sellerNick)
        {
            try
            {
                string query = "select 1 from CloseOrderConfig where sellerNick = @sellerNick and isAutoCloseOrder = 1";
                // 设置SQL参数
                SqlParameter[] param = new SqlParameter[] 
                {
                new SqlParameter("@sellerNick", sellerNick)
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

        /// <summary>
        /// 更新自动评价状态：后台开启或者关闭卖家的评价状态
        /// </summary>
        /// <param name="sellerNick"></param>
        /// <returns></returns>
        public Boolean ManageRateStatus(string sellerNick, string isAutoRating)
        {
            try
            {
                string query = "update RateConfig set isAutoRating = @isAutoRating where sellerNick = @sellerNick";
                // 设置SQL参数
                SqlParameter[] param = new SqlParameter[] 
                {
                new SqlParameter("@sellerNick", sellerNick),
                new SqlParameter("@isAutoRating", isAutoRating)
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


        /// <summary>
        /// 查询有效期内已开通自动评价总数的卖家
        /// </summary>
        /// <param name="sellerNick"></param>
        /// <param name="startDate"></param>
        /// <param name="endRateDate"></param>
        /// <param name="rateType"></param>
        /// <returns></returns>
        public DataTable GetSellerRateConfig(string sellerNick, string startDate, string endRateDate)
        {
            try
            {
                string query = @"select sellerNick,isMiaoRate,isWaitBuyerRate,isQiangRate,
(case isAutoRating when 1 then '已开通' ELSE '未开通' END ) AS isAutoRating 
from RateConfig R INNER JOIN Seller S
ON R.sellerNick = S.NICK where R.isAutoRating = 1 and S.endDate >= getdate()  ";
                if (!string.IsNullOrEmpty(sellerNick))
                {
                    query += " AND R.sellerNick = @sellerNick ";
                }
                if (!string.IsNullOrEmpty(startDate))
                {
                    query += " AND R.createDate >= @startDate ";
                }
                if (!string.IsNullOrEmpty(endRateDate))
                {
                    query += " AND R.createDate <= @rateDate ";
                }
                query += " order by R.createDate desc ";
                SqlParameter[] param = new SqlParameter[] 
                {
                new SqlParameter("@sellerNick", sellerNick),
                new SqlParameter("@startDate", startDate),
                new SqlParameter("@rateDate", endRateDate)
                };
                DataTable ds = DataBase.ExecuteDt(query, param,CommandType.Text);
                return ds;
            }
            catch (Exception ex)
            {
                ExceptionReporter.WriteLog(ex, ExceptionPostion.TBApply_Data);
                return null;
            }
        }

        #region 主动通知

        public bool AddAppCus(AppCustomer obj)
        {
            try
            {
                string query = @"insert into CusPermitConfig (nick,created,[status])values(@nick,@created,@status)";
                // 设置SQL参数
                SqlParameter[] param = new SqlParameter[] 
                {
                new SqlParameter("@nick", obj.Nick),
                new SqlParameter("@created", obj.Created),
                new SqlParameter("@status", obj.Status)
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


        public Boolean CheckAppCusIsExit(string sellerNick)
        {
            try
            {
                string query = @"SELECT 1 FROM CusPermitConfig WHERE nick = @nick";
                // 设置SQL参数
                SqlParameter[] param = new SqlParameter[] 
                {
                new SqlParameter("@nick", sellerNick)
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

        public bool DeleteSellerNifty(String sellerID)
        {
            try
            {
                ComDbOpen.DbOpen(_DBSession);
                //清空参数
                _DBSession.ClearParam();
                string query = @"delete from CusPermitConfig where nick = @nick";
                // 设置SQL参数
                SqlParameter[] param = new SqlParameter[] 
                {
                new SqlParameter("@nick", sellerID)
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

        #endregion 

    }
}
