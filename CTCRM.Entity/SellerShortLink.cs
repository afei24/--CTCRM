using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CTCRM.Entity
{
  public  class SellerShortLink
    {
      public string SellerNick { get; set; }

      public string LinkType { get; set; }

      public string LinkUrl { get; set; }

      public string Memo { get; set; }

      public DateTime CreateDate { get; set; }
    }
}
