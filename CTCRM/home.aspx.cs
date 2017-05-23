using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using CTCRM.Components;
using CTCRM.Entity;
using System.Drawing;
using CHENGTUAN.Entity;
using CHENGTUAN.Components;

namespace CTCRM
{
    public partial class home : System.Web.UI.Page
    {
        public string sigName = "淘宝";
        public string sigPrveName = "";
        public string cellPhone = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                //检查卖家是否为新卖家
                var result = SellersBLL.CheckSeller();
                if (result == "0")
                {
                    Response.Redirect("http://container.api.taobao.com/container/transform?appkey=21088197", false);
                }
                //ExceptionReporter.WriteLog("result2:" + result, ExceptionPostion.TBApply_Data, ExceptionRank.important);
                if (!string.IsNullOrEmpty(Users.OrderVersion))
                {
                    var checkIsExit = MsgBLL.CheckSellerMsgTransIsExit(Users.Nick);
                    if (String.IsNullOrEmpty(checkIsExit))//卖家第一次订购
                    {
                        MsgPackage obj = new MsgPackage();
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
                else {
                    Response.Redirect("http://crm.new9channel.com/relogin.aspx");
                }
            }
        }           
    }
}
