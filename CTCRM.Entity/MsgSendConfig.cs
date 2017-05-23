using System;
using System.Collections.Generic;
using System.Text;

namespace CTCRM.Entity
{
  public  class MsgSendConfig
    {
      public string SellerNick { get; set; }
      public string UnPayType { get; set; }
      public string UnpayMsg { get; set; }
      public string UnpayMsgCus { get; set; }
      public string IsUnpayMsgCus { get; set; }

      public string PayType { get; set; }
      public string PayMsg { get; set; }
      public string PayMsgCus { get; set; }
      public string IsPayMsgCus { get; set; }


      public string ShippingType { get; set; }
      public string ShippingNofityMsg { get; set; }
      public string IsShippingMsgCus { get; set; }
      public string ShippingNofityMsgCus { get; set; }

      public string DelayShippingType { get; set; }
      public string DelayShippingNofityMsg { get; set; }
      public string IsDelayShippingMsgCus { get; set; }
      public string DelayShippingNofityMsgCus { get; set; }


      public string ArrivedType { get; set; }
      public string ArrivedNofityMsg { get; set; }
      public string IsArrivedMsgCus { get; set; }
      public string ArrivedNofityMsgCus { get; set; }

      public string SignType { get; set; }
      public string SignNofityMsg { get; set; }
      public string SignNotifyMsgCus { get; set; }
      public string IsSignMsgCus { get; set; }

      public string HuiZJType { get; set; }
      public string HuiZJNofityMsg { get; set; }
      public string HuiZJNofityMsgCus { get; set; }
      public string IsHuiZJMsgCus { get; set; }

      public string ReturnGoodsType { get; set; }
      public string ReturnGoodsMsg { get; set; }
      public string ReturnGoodsMsgCus { get; set; }
      public string IsReturnGoodsCus { get; set; }

      public int  BuyerLevel { get; set; }
      public string Amount { get; set; }
      public string ShopName { get; set; }
      public DateTime CreateDate { get; set; }
      public DateTime UpdateDate { get; set; }

      public int blackListType { get;set;}
      public int threeDayType{get ;set;}
      public int areType { get; set; }
      public string areList { get;set;}
      public string warnType { get;set;}
      public string AmountMax { get;set;}

    }
}
