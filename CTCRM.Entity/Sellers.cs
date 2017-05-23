using System;
using System.Collections.Generic;
using System.Text;

namespace CTCRM.Entity
{
   public class Sellers
    {
        /// <summary>
        /// 卖家编号
        /// </summary>
        public Int64 Seller_Id { get; set; }
        /// <summary>
        /// 卖家昵称
        /// </summary>
       
        public string Nick { get; set; }
        /// <summary>
        /// 卖家信用度
        /// </summary>
      
        public Int16 Seller_Creadit { get; set; }

        /// <summary>
        /// 店铺类型：B或者C
        /// </summary>
        public string shopType { get; set; }
        /// <summary>
        /// 邮箱地址
        /// </summary>    
        public string Email { get; set; }
        /// <summary>
        /// 用户Session值
        /// </summary>
     
        public string SessionKey { get; set; }
        /// <summary>
        /// 邮编
        /// </summary>     
        public string Location_Zip { get; set; }
        /// <summary>
        /// 地址
        /// </summary>   
        public string Address { get; set; }
        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime Created { get; set; }

        public string Last_visit { get; set; }

       /// <summary>
       /// 卖家当前类型：免费试用、高级版
       /// </summary>
        public string SellerType { get; set; }

        public string OrderVersion { get; set; }
       /// <summary>
       /// 订购日期
       /// </summary>
        public string OrderDate { get; set; }

       /// <summary>
       /// 订购到期日期
       /// </summary>
        public string EndDate { get; set; }

        public int Buyer_credit { get; set; }

        public Boolean Has_shop { get; set; }

        public string Refresh_token { get; set; }

        public DateTime CreatedDate { get; set; }

        public DateTime UpdateDate { get; set; }

       /// <summary>
       /// 判断卖家是否已经下载会员数据
       /// </summary>
        public int IsDownData { get; set; }

        /// <summary>
        /// 判断卖家是否处于正常使用状态：正常/不可用
        /// </summary>
        public int CurrentStatus { get; set; }

       /// <summary>
       /// 卖家订购软件周期
       /// </summary>
        public int OrderCyc { get; set; }

        /// <summary>
        /// 店铺签名
        /// </summary>
        public string SignShopName { get; set; }

        public string Cellphone { get; set; }

        /// <summary>
        /// 发送短信扩展ID
        /// </summary>
        public string Appendid { get; set; }
    }
}
