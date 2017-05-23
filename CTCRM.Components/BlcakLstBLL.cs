using System.Collections.Generic;
using System.Linq;
using System.Text;
using CTCRM.Entity;
using CTCRM.DAL;
using System.Data;

namespace CTCRM.Components
{
  public  class BlcakLstBLL
    {
      public static bool ChekBlaklist(BlakList obj)
      {
          return BlcakLstDAL.ChekBlaklist(obj);
      }
      public static DataTable GetWhitelistForCKJ()
      {
          return BlcakLstDAL.GetWhitelistForCKJ();
      }
      public static bool ChekWhitelist(WhiteList obj)
      {
          return BlcakLstDAL.ChekWhitelist(obj);
      }
      public static bool AddBlaklist(BlakList obj)
      {
          return BlcakLstDAL.AddBlaklist(obj);
      }
      public static bool AddWhitelist(WhiteList obj)
      {
          return BlcakLstDAL.AddWhitelist(obj);
      }
      public static DataTable GetBlaklist(string sellerNick)
      {
          return BlcakLstDAL.GetBlaklist(sellerNick);
      }
       public static bool DeleteBlaklist(string blakListID)
       {
           return BlcakLstDAL.DeleteBlaklist(blakListID);
       }
       public static bool DeleteWhitelist(string sellerNick)
       {
           return BlcakLstDAL.DeleteWhitelist(sellerNick);
       }
       public static DataTable GetWhitelist()
       {
           return BlcakLstDAL.GetWhitelist();
       }
       public static DataTable GetWhitelistForMarket()
       {
           return BlcakLstDAL.GetWhitelistForMarket();
       }
    }
}
