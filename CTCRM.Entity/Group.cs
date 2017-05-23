using System;
using System.Collections.Generic;
using System.Text;

namespace CTCRM.Entity
{
   public class Group
    {
       public string Group_name { get; set; }

       public string SellerNick { get; set; }

       public string Memo { get; set; }

       public DateTime CreateDate { get; set; }

       public Boolean OpenStatus { get; set; }


    }
}
