using CTCRM.DAL;
using CTCRM.Entity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace CTCRM.Components
{
  public  class ShortLinkBLL
    {
      public static bool AddShortLink(SellerShortLink entity)
      {
          return ShortLinkDAL.AddShortLink(entity);
      }
      public static DataTable GetShortLinkByNick(string sellerNick)
      {
          return ShortLinkDAL.GetShortLinkByNick(sellerNick);
      }

    }
}
