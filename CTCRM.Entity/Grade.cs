using System;
using System.Collections.Generic;
using System.Text;

namespace CTCRM.Entity
{
   public class Grade
    {
       public int Id { get; set; }
       public int LevelID { get; set; }
       public int TradeAmontFrom { get; set; }
       public int TradeAmountTo { get; set; }
       public string SellerNick { get; set; }
    }
}
