using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CTCRM.Entity;
using CTCRM.DAL;
using System.Data;

namespace CTCRM.Components
{
   public class ShopsBLL
    {
       public List<Shops> Init()
       {
           //检查店铺信息
           Shops shop = new Shops();
           if (Users.Nick == null)
           {
               return null;
           }
           shop.Nick = Users.Nick;         
           return null;
       }
       public static DataTable GetShopeInfoStatic(string sellerNickName)
       {
           return ShopsDAL.GetShopeInfoStatic(sellerNickName);
       }

       public static DataTable GetBuyerGrade(string nickName)
       {
          return ShopsDAL.GetBuyerGrade(nickName);
       }
       public static string GetShopeTradeAmount(string sellerNickName)
       {
           return ShopsDAL.GetShopeTradeAmount(sellerNickName);
       }
       public static string GetShopeTradeOrder(string sellerNickName)
       {
           return ShopsDAL.GetShopeTradeOrder(sellerNickName);
       }
       public static string GetShopeBuyerCount(string sellerNickName)
       {
           return ShopsDAL.GetShopeBuyerCount(sellerNickName);
       }
       public static string GetShopeAvgPrice(string sellerNickName)
       {
           return ShopsDAL.GetShopeAvgPrice(sellerNickName);
       }
       public static string GetShopeNewOrderCount(string sellerNickName)
       {
           return ShopsDAL.GetShopeNewOrderCount(sellerNickName);
       }
       public static string GetShopeRefundCount(string sellerNickName)
       {
           return ShopsDAL.GetShopeRefundCount(sellerNickName);
       }
       public static string GetShopeUnPayOrderCount(string sellerNickName)
       {
           return ShopsDAL.GetShopeUnPayOrderCount(sellerNickName);
       }
       public static string GetShopeNoLogin3Months(string sellerNickName)
       {
           return ShopsDAL.GetShopeNoLogin3Months(sellerNickName);
       }
       public static string GetShopeOldBuyerCount(string sellerNickName)
       {
           return ShopsDAL.GetShopeOldBuyerCount(sellerNickName);
       }

       public static DataTable GetSellerShopInfo(string sellerNick)
       {
           return ShopsDAL.GetSellerShopInfo(sellerNick);
       }

    }
}
