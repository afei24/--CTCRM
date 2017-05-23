using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Top.Api.Request;
using Top.Api.Response;
using Top.Api;
using CHENGTUAN.Components;
using CHENGTUAN.Entity;

namespace CTCRM.Components.TopCRM
{
   public class UserSubscribes
    {
        /// <summary>
        /// 验证用户是否已经过期
        /// </summary>
        /// <returns></returns>
        public static string VerifyDate()
        {
            UserGetRequest request = new UserGetRequest();
            request.Fields = "user_id";
            request.Nick = Users.Nick;
            UserGetResponse u = TBManager.GetClient().Execute(request, Users.SessionKey);
            if (u == null || u.User == null || u.User.UserId < 1)
            {
                return "false";
            }
            return "true";
        }

        public static VasSubscribeGetResponse GetSellerSubscrib(string sellerNick, string articleCode)
        {
            try
            {
                ITopClient client = TBManager.GetClient();
                VasSubscribeGetRequest req = new VasSubscribeGetRequest();
                req.Nick = sellerNick;
                req.ArticleCode = articleCode;
                VasSubscribeGetResponse response = client.Execute(req);
                return response;
            }
            catch (Exception ex)
            {
                ExceptionReporter.WriteLog(ex, ExceptionPostion.TBApply_Data);
                return null;
            }
           
        }

    }
}
