using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CTCRM.Entity
{
  public  class SavedSpace
    {
        public Int64 TotalSavedSpace { get; set; }

        public String SellerNick { get; set; }

        public DateTime CreateDate { get; set; }

        public DateTime UpdateDate { get; set; }
    }
}
