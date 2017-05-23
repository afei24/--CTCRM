using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CHENGTUAN.Components;
using CHENGTUAN.Entity;
using CTCRM.Components;
using CTCRM.Entity;
using Top.Api;
using Top.Tmc;
using Top.Api.Domain;
using Top.Api.Request;
using Top.Api.Response;
using CTCRM.Components.TopCRM;

namespace CTCRM.WIN_Aspx
{
    public partial class main : System.Web.UI.Page
    {
        public string userName = string.Empty;
        public string orderVersion = string.Empty;
        public string deadline = string.Empty;
        public string msgCount = string.Empty;
        public string systemMsg = @" <div><a href='#'><label style='float: left'>暂无公告</label></a></div>";
        string title1 = string.Empty;
        string title2 = string.Empty;
        string title3 = string.Empty;
        string title4 = string.Empty;
        string title5 = string.Empty;
        string news = string.Empty;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {

                try
                {
                    var result = SellersBLL.CheckSeller();
                    if (result == "0")
                    {
                        //Response.Redirect("http://container.api.taobao.com/container/transform?appkey=21088197", false);
                        Response.Redirect("error_root.aspx");
                    }

                    userName = Users.Nick == null ? "未登录的用户" : Users.Nick;
                    orderVersion = string.IsNullOrEmpty(Users.OrderVersion) ? "最高版本" : Users.OrderVersion.ToString();
                    deadline = Users.Deadline == null ? "当前" : Users.Deadline.Substring(0, 10);
                    SellersBLL.UpdateUnUseDate(deadline, userName);//20161106 yao 
                    var checkIsExit = MsgBLL.CheckSellerMsgTransIsExit(Users.Nick);
                    if (String.IsNullOrEmpty(checkIsExit))//卖家第一次订购
                    {
                        
                        MsgPackage obj = new MsgPackage();
                        if (Users.OrderVersion == "订购一年送3000条短信")
                        {
                            obj.PackageName = "店铺管家短信套餐(淘宝)3000条";
                            obj.Type = "永久有效";
                            obj.SellerNick = Users.Nick;
                            obj.Price = 0;
                            obj.PerPrice = "0";
                            obj.Rank = "短信套餐(赠送)";
                            obj.OrderDate = DateTime.Now;
                            obj.PayStatus = true;
                            MsgBLL.AddMsgPackage(obj);
                            obj.ServiceStatus = true;
                            obj.CanUseStartDate = DateTime.Now;
                            obj.MsgCanUseCount = 3000;
                            obj.MsgTotalCount = 3000;
                            MsgBLL.AddMsgTrans(obj);
                        }
                        else
                        {
                            TimeSpan sp = Convert.ToDateTime(deadline) - DateTime.Now;
                            if (sp.Days > 15)
                            {
                                obj.PackageName = "店铺管家短信套餐(淘宝)200条";
                                obj.Type = "永久有效";
                                obj.SellerNick = Users.Nick;
                                obj.Price = 0;
                                obj.PerPrice = "0";
                                obj.Rank = "短信套餐(赠送)";
                                obj.OrderDate = DateTime.Now;
                                obj.PayStatus = true;
                                MsgBLL.AddMsgPackage(obj);
                                obj.ServiceStatus = true;
                                obj.CanUseStartDate = DateTime.Now;
                                obj.MsgCanUseCount = 200;
                                obj.MsgTotalCount = 200;
                                MsgBLL.AddMsgTrans(obj);
                            }
                            else
                            {
                                obj.PackageName = "店铺管家短信套餐(淘宝)10条";
                                obj.Type = "永久有效";
                                obj.SellerNick = Users.Nick;
                                obj.Price = 0;
                                obj.PerPrice = "0";
                                obj.Rank = "短信套餐(赠送)";
                                obj.OrderDate = DateTime.Now;
                                obj.PayStatus = true;
                                MsgBLL.AddMsgPackage(obj);
                                obj.ServiceStatus = true;
                                obj.CanUseStartDate = DateTime.Now;
                                obj.MsgCanUseCount = 10;
                                obj.MsgTotalCount = 10;
                                MsgBLL.AddMsgTrans(obj);
                            }
                        }
                        
                        OpenLogistics(obj.SellerNick);
                    }
                    DataTable tb = MsgBLL.GetSellerMsgStatus(Users.Nick);
                    if (tb != null && tb.Rows.Count > 0)
                    {
                        msgCount = tb.Rows[0]["msgCanUseCount"].ToString() + "条";
                    }
                    else
                    {
                        msgCount = "0条";
                    }
                    //string medo = @" <div><a href='{1}'><lable style='float: left'>{0}</lable><br /></a></div>";
                    //DataTable dt = SystemMessagesBLL.QueryShowMsg();
                    //if (dt == null || dt.Rows.Count <= 0)
                    //{ return; }
                    //systemMsg = "";
                    //for (int i = 0; i < dt.Rows.Count; i++)
                    //{

                    //    systemMsg += string.Format(medo, dt.Rows[i]["SystemMsg"].ToString(), dt.Rows[i]["SystemLink"].ToString());
                    //}
                }
                catch (Exception ex)
                {

                    ExceptionReporter.WriteLog(ex, ExceptionPostion.TBApply_Web_UI);
                }
                finally
                {
                    DataTable tb = MsgBLL.GetSellerMsgStatus(Users.Nick);
                    if (tb != null && tb.Rows.Count > 0)
                    {
                        msgCount = tb.Rows[0]["msgCanUseCount"].ToString() + "条";
                    }
                    else
                    {
                        msgCount = "0条";
                    }
                }
            }

        }
        //授权开通物流提醒
        public static void OpenLogistics(string sellerNick)
        {
            string key = SellersBLL.GetSellerSessionKey(sellerNick);
            ITopClient client = TBManager.GetClient();
            TmcUserPermitRequest req = new TmcUserPermitRequest();
            //req.Topics = "taobao_trade_TradeCreate,taobao_refund_RefundCreate"; 不需要设置
            TmcUserPermitResponse rsp = client.Execute(req, key);
            //Console.WriteLine(rsp.Body);
        }


    }
}