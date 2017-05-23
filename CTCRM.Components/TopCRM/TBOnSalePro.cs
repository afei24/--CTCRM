using CHENGTUAN.Components;
using CHENGTUAN.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Top.Api;
using Top.Api.Domain;
using Top.Api.Request;
using Top.Api.Response;

namespace CTCRM.Components.TopCRM
{
   public class TBOnSalePro
    {

       /// <summary>
       /// 返回商品在售的总数
       /// </summary>
       /// <param name="sessionKey"></param>
       /// <returns></returns>
       public static string GetAllOnSalePro(string sessionKey)
       {
           try
           {
               ITopClient client = TBManager.GetClient();
               ItemsOnsaleGetRequest req = new ItemsOnsaleGetRequest();
               req.Fields = "num_iid";
               ItemsOnsaleGetResponse response = client.Execute(req, sessionKey);
               return response.TotalResults.ToString();
           }
           catch (Exception ex)
           {
               ExceptionReporter.WriteLog(ex, ExceptionPostion.TopApi);
               return "0";
           }
       }

       /// <summary>
       /// 获取单个商品详细信息
       /// </summary>
       /// <param name="sessionKey"></param>
       /// <param name="itemNo"></param>
       /// <returns></returns>
       public static Item GetItemByID(string sessionKey,string itemNo)
       {
           try
           {
               ITopClient client = TBManager.GetClient();
               ItemSellerGetRequest req = new ItemSellerGetRequest();
               req.NumIid = Convert.ToInt64(itemNo);
               req.Fields = "pic_url,detail_url,title, price, sold_quantity";
               ItemSellerGetResponse response = client.Execute(req, sessionKey);
               return response.Item;
           }
           catch (Exception ex)
           {
               //ExceptionReporter.WriteLog(ex, ExceptionPostion.TopApi);
               return null;
           }
       }

       /// <summary>
       /// 获取前台展示的店铺内卖家自定义商品类目
       /// </summary>
       /// <param name="sessionKey"></param>
       /// <param name="sellerNick"></param>
       /// <returns></returns>
       public static List<ShopCat> GetCatsList(string sessionKey, string sellerNick)
       {
           try
           {
               ITopClient client = TBManager.GetClient();
               ShopcatsListGetRequest req = new ShopcatsListGetRequest();
               //req.Nick = sellerNick;
               req.Fields = "cid,name";
               ShopcatsListGetResponse response = client.Execute(req, sessionKey);
               return response.ShopCats;
           }
           catch (Exception ex)
           {
               //ExceptionReporter.WriteLog(ex, ExceptionPostion.TopApi);
               return null;
           }
       }

    }
}
