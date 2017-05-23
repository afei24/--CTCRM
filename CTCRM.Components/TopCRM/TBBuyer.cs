using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Top.Api.Response;
using Top.Api.Domain;
using Top.Api;
using Top.Api.Request;
using CTCRM.Entity;
using CTCRM.DAL;
using CHENGTUAN.Components;
using CHENGTUAN.Entity;

namespace CTCRM.Components.TopCRM
{
    public class TBBuyer
    {
        /// <summary>
        /// 调用API获取会员数据
        /// </summary>
        /// <param name="currentPage"></param>
        /// <param name="pagesize"></param>
        /// <param name="total"></param>
        /// <returns></returns>
        public List<CrmMember> GetBuyer(string strSessionKey, Int64 currentPage, Int64 pagesize, ref Int64 total)
        {
            try
            {
                if (currentPage == 0)
                {
                    currentPage = 1L;
                }
                if (pagesize == 0)
                {
                    pagesize = 100;
                }
                ITopClient client = TBManager.GetClient();
                CrmMembersSearchRequest req = new CrmMembersSearchRequest();
                //req.MaxLastTradeTime = DateTime.Now.AddMonths(-3);
                req.CurrentPage = currentPage;
                req.PageSize = pagesize;
                CrmMembersSearchResponse response = client.Execute(req, strSessionKey);
                if (response.IsError)
                {
                    ExceptionReporter.WriteLog(response.SubErrMsg, ExceptionPostion.TopApi, ExceptionRank.important);
                }
                total = response.TotalResult;
                return response.Members;
            }
            catch (Exception ex)
            {
                ExceptionReporter.WriteLog(ex, ExceptionPostion.TopApi);
                return null;
            }
        }

        public List<CrmMember> GetBuyer(string strSessionKey, Int64 currentPage, Int64 pagesize, string getMemberStartDate, string getMemberEndDate)
        {
            try
            {
                if (currentPage == 0)
                {
                    currentPage = 1L;
                }
                if (pagesize == 0)
                {
                    pagesize = 100;
                }
                ITopClient client = TBManager.GetClient();
                CrmMembersSearchRequest req = new CrmMembersSearchRequest();
                req.CurrentPage = currentPage;
                req.PageSize = pagesize;
                if (!string.IsNullOrEmpty(getMemberStartDate))
                {
                    req.MinLastTradeTime = Convert.ToDateTime(getMemberStartDate);
                }
                if (!string.IsNullOrEmpty(getMemberEndDate))
                {
                    req.MaxLastTradeTime = Convert.ToDateTime(getMemberEndDate);
                }
                CrmMembersSearchResponse response = client.Execute(req, strSessionKey);
                if (response.IsError)
                {
                    ExceptionReporter.WriteLog(response.SubErrMsg, ExceptionPostion.TopApi, ExceptionRank.important);
                    throw new Exception();
                }
                return response.Members;
            }
            catch (Exception ex)
            {
                ExceptionReporter.WriteLog(ex, ExceptionPostion.TopApi);
                return null;
            }
        }

        /// <summary>
        /// 调用API获取会员数据
        /// </summary>
        /// <param name="currentPage"></param>
        /// <param name="pagesize"></param>
        /// <returns></returns>
        public List<CrmMember> GetBuyer(string strSessionKey, Int64 currentPage, Int64 pagesize)
        {
            try
            {
                if (currentPage == 0)
                {
                    currentPage = 1L;
                }
                if (pagesize == 0)
                {
                    pagesize = 100;
                }
                ITopClient client = TBManager.GetClient();
                CrmMembersSearchRequest req = new CrmMembersSearchRequest();
                req.CurrentPage = currentPage;
                req.PageSize = pagesize;
                CrmMembersSearchResponse response = client.Execute(req, strSessionKey);
                if (response.IsError)
                {
                    ExceptionReporter.WriteLog("GetBuyer:" + response.SubErrCode + ":" + response.SubErrMsg,null, ExceptionPostion.TopApi,ExceptionRank.important);
                }
                return response.Members;
            }
            catch (Exception ex)
            {
                ExceptionReporter.WriteLog(ex, ExceptionPostion.TopApi);
                return null;
            }
        }

        /// <summary>
        /// 查询买家的信誉等级
        /// </summary>
        /// <param name="buyerNick"></param>
        /// <returns></returns>
        public User GetBuyerDetailInfo(string strSessionKey, string buyerNick)
        {
            try
            {
                ITopClient client = TBManager.GetClient();
                UserGetRequest req = new UserGetRequest();
                req.Fields = "buyer_credit";
                req.Nick = buyerNick;
                UserGetResponse response = client.Execute(req, strSessionKey);
                if (response.IsError)
                {
                    ExceptionReporter.WriteLog("GetBuyerDetailInfo:" + response.SubErrCode + ":" + response.SubErrMsg,null, ExceptionPostion.TopApi,ExceptionRank.important);
                    return null;
                }
                return response.User;

            }
            catch (Exception ex)
            {
                ExceptionReporter.WriteLog(ex, ExceptionPostion.TopApi);
                return null;
            }
        }

      
        //public List<User> GetBuyersInfo(string buyersNick)
        //{
        //    try
        //    {
        //        ITopClient client = TBManager.GetClient();
        //        UsersGetRequest req = new UsersGetRequest();
        //        req.Fields = "user_id,nick,location.city,location.state,location.address,buyer_credit.level";
        //        req.Nicks = buyersNick;
        //        UsersGetResponse response = client.Execute(req,Users.SessionKey);
        //        if (response.IsError)
        //        {
        //            ExceptionReporter.WriteLog("GetBuyersInfo:" + response.SubErrCode + ":" + response.SubErrMsg, null, ExceptionPostion.TopApi, ExceptionRank.important);
        //        }
        //        return response.Users;
        //    }
        //    catch (Exception ex)
        //    {
        //        ExceptionReporter.WriteLog(ex, ExceptionPostion.TopApi);
        //        return null;
        //    }
        //}
    }
}
