using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CTCRM.Entity
{
   public class MsgContents
    {

        string pageType = string.Empty;

        public string PageType
        {
            get { return pageType; }
            set { pageType = value; }
        }

        string typeTitle = string.Empty;

        public string TypeTitle
        {
            get { return typeTitle; }
            set { typeTitle = value; }
        }

        string msgContent = string.Empty;

        public string MsgContent
        {
            get { return msgContent; }
            set { msgContent = value; }
        }

        public int msgUse { get; set; }

    }
}
