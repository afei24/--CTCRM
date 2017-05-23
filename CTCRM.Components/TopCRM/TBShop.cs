using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Top.Api.Domain;
using Top.Api.Response;
using Top.Api;
using Top.Api.Request;

namespace CTCRM.Components.TopCRM
{
  public  class TBShop
    {
      
        public global::Top.Api.Domain.Shop Get(string parameter, int pageIndex, int pageNum, long total)
        {
            try
            {
                ITopClient client = TBManager.GetClient();
                ShopGetRequest req = new ShopGetRequest();
                req.Fields = "sid,cid,nick,title,desc,bulletin,pic_path,created,modified,shop_score";
                req.Nick = Users.Nick;
                ShopGetResponse response = client.Execute(req, Users.SessionKey);
                return response.Shop;
            }
            catch (Exception ex)
            {
                CHENGTUAN.Components.ExceptionReporter.WriteLog(ex, CHENGTUAN.Entity.ExceptionPostion.TBApply_Components);
                return null;

            }
        }

     
     
        public List<global::Top.Api.Domain.Shop> GetList(string parameter, int pageIndex, int PageNum, out long total)
        {
            throw new NotImplementedException();
        }
      

        public List<ItemProp> Shop(long cid)
        {
            ItempropsGetResponse response = null;
            try
            {
                ITopClient client = TBManager.GetClient();
                ItempropsGetRequest req = new ItempropsGetRequest();
                req.Fields = "pid,name,must,multi,prop_values";
                req.Cid = cid;
                response = client.Execute(req, Users.SessionKey);
            }
            catch (Exception ex)
            {

                CHENGTUAN.Components.ExceptionReporter.WriteLog(ex, CHENGTUAN.Entity.ExceptionPostion.TBApply_Components);
            }
            return response.ItemProps;
        }
    }
}
