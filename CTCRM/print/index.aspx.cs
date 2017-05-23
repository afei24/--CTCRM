using CHENGTUAN.Components;
using CHENGTUAN.Entity;
using CTCRM.Common;
using CTCRM.Components;
using CTCRM.Components.TopCRM;
using CTCRM.Entity;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Top.Api.Domain;

namespace CTCRM.print
{
    public partial class index : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string methd = Request.Form["method"];
            ExceptionReporter.WriteLog(methd, ExceptionPostion.TBApply_Data, ExceptionRank.important);
            switch (methd)
            {
                case "yto.user_token_get"://ok
                    user_token_get();
                    break;
            }
        }
        #region 获取用户授权token
        private void user_token_get()
        {
            string paras = Request.Form["paras"];//获取查询参数
            string user_id = Request.Form["user_id"];//获取用户
            string app_id = Request.Form["app_id"];//获取合作ID
            //ExceptionReporter.WriteLog("app_id:" + app_id, ExceptionPostion.TBApply_Data, ExceptionRank.important);
            if (!string.IsNullOrEmpty(app_id) && app_id.Equals("8"))//检测用户
            {
                try
                {
                    //ExceptionReporter.WriteLog("paras:" + paras, ExceptionPostion.TBApply_Data, ExceptionRank.important);
                    string where = Base64.DecodeBase64(HttpUtility.UrlDecode(paras));
                    //ExceptionReporter.WriteLog("where:" + where, ExceptionPostion.TBApply_Data, ExceptionRank.important);
                    IDictionary<string, string> whereVales = TBPrint.GetParas(where);
                    if (whereVales != null && whereVales.Count > 0)
                    {
                        try
                        {
                            string userId = whereVales["code"];
                            string nick_name = "";
                            string expires_in = "";
                            string token = "";
                            string freshToken = "";
                            //ExceptionReporter.WriteLog("userId:" + userId, ExceptionPostion.TBApply_Data, ExceptionRank.important);
                            DataTable tbSeller = PrintBLL.GetSellerNickById(userId);
                            if (tbSeller != null && tbSeller.Rows.Count > 0)
                            {
                                nick_name = tbSeller.Rows[0]["NICK"].ToString();
                                expires_in = tbSeller.Rows[0]["endDate"].ToString();
                                token = tbSeller.Rows[0]["SESSKEY"].ToString();
                                freshToken = tbSeller.Rows[0]["Refresh_Token"].ToString();

                            }
                            string userInfo = "{\"users\":{\"user\":{\"token\":\"" + token + "\",\"token_refresh\":\"" + freshToken + "\",\"user_id\":\"" + userId + "\",\"nick_name\":\"" + UTF8String.ValueOf(nick_name).getContent() + "\",\"expires_in\":\"" + expires_in + "\"}}}";
                            ExceptionReporter.WriteLog(userInfo, ExceptionPostion.TBApply_Data, ExceptionRank.important);
                            Response.Write(userInfo);

                        }
                        catch (Exception ex)
                        {
                            ExceptionReporter.WriteLog(ex, ExceptionPostion.TBApply_Data);
                        }
                    }
                    else
                    {
                        Response.Write("");
                    }
                }
                catch (Exception ex)
                {
                    ExceptionReporter.WriteLog(ex, ExceptionPostion.TBApply_Data);
                }
            }
        }
        #endregion 
    }
}