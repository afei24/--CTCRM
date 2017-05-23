using System;
using System.Collections.Generic;
using System.Text;
using Top.Api.Domain;

namespace CTCRM.Entity
{
    public class Buyers : CrmMember
    {
        /// <summary>
        /// 买家编号
        /// </summary>
       public Int64 UserID { get; set; }

       public string SELLER_ID { get; set; }

       public string Buyer_alipay_no { get; set; }

       public string Buyer_nick { get; set; }

       public string Buyer_reallName { get; set; }

       //public Int64 Status { get; set; }

       public string Sex { get; set; }

       public string UserLevel { get; set; }

       public decimal TotalMoney { get; set; }

       public DateTime LatestBuyDate { get; set; }

       public string TagName { get; set; }

       public long TradeCount { get; set; }

       public int ProductCount { get; set; }

       public int CloseCount { get; set; }

       public decimal CloseTotalMoney { get; set; }

       public DateTime LastestTradeDate { get; set; }

       //public int Grade { get; set; }

       public DateTime Max_last_trade_time { get; set; }

       public int Min_item_num { get; set; }

       public string BuyerProvince { get; set; }

       public string BuyerCity { get; set; }

       public int Group_id { get; set; }

       public string Order { get; set; }

       public int Max_item_num { get; set; }

       public string Sort { get; set; }

       public string CellPhone { get; set; }

       public string Phone { get; set; }

       public string Buyer_credit { get; set; }

       public string birthDay { get; set; }

       public string Email { get; set; }

       public string QQ { get; set; }

       public string MSN { get; set; }

       public string ZipCode { get; set; }

       public Int64 Jifen { get; set; }

       public DateTime CreateDate { get; set; }

       public string  UpdateDate { get; set; }

       public string Address { get; set; }

       public string Memo { get; set; }

       public string SinaWeibo { get; set; }

       public string QQWeibo { get; set; }

       /// <summary>
       /// 0:店铺自己的会员；1：其他淘宝店铺会员；2：非淘宝店铺会员
       /// </summary>
       public string BuyerType { get; set; }

    }
}
