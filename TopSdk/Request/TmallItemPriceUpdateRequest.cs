using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using Top.Api.Util;

namespace Top.Api.Request
{
    /// <summary>
    /// TOP API: tmall.item.price.update
    /// </summary>
    public class TmallItemPriceUpdateRequest : BaseTopRequest<Top.Api.Response.TmallItemPriceUpdateResponse>
    {
        /// <summary>
        /// 商品ID
        /// </summary>
        public Nullable<long> ItemId { get; set; }

        /// <summary>
        /// 被更新商品价格
        /// </summary>
        public string ItemPrice { get; set; }

        /// <summary>
        /// 商品价格更新时候的可选参数
        /// </summary>
        public string Options { get; set; }

        public UpdateItemPriceOptionDomain Options_ { set { this.Options = TopUtils.ObjectToJson(value); } } 

        /// <summary>
        /// 更新SKU价格时候的SKU价格对象；如果没有SKU或者不更新SKU价格，可以不填;查找SKU目前支持ID，属性串和商家编码三种模式，建议选用一种最合适的，切勿滥用，一次调用中如果混合使用，更新结果不可预期！
        /// </summary>
        public string SkuPrices { get; set; }

        public List<UpdateSkuPriceDomain> SkuPrices_ { set { this.SkuPrices = TopUtils.ObjectToJson(value); } } 

        #region ITopRequest Members

        public override string GetApiName()
        {
            return "tmall.item.price.update";
        }

        public override IDictionary<string, string> GetParameters()
        {
            TopDictionary parameters = new TopDictionary();
            parameters.Add("item_id", this.ItemId);
            parameters.Add("item_price", this.ItemPrice);
            parameters.Add("options", this.Options);
            parameters.Add("sku_prices", this.SkuPrices);
            if (this.otherParams != null)
            {
                parameters.AddAll(this.otherParams);
            }
            return parameters;
        }

        public override void Validate()
        {
            RequestValidator.ValidateRequired("item_id", this.ItemId);
            RequestValidator.ValidateObjectMaxListSize("sku_prices", this.SkuPrices, 999999);
        }

	/// <summary>
/// UpdateSkuPriceDomain Data Structure.
/// </summary>
[Serializable]
public class UpdateSkuPriceDomain : TopObject
{
	        /// <summary>
	        /// Sku的商家外部id，用于指定被修改价格的SKU
	        /// </summary>
	        [XmlElement("outer_id")]
	        public string OuterId { get; set; }
	
	        /// <summary>
	        /// 属于这个sku的商品的价格 取值范围:0-100000000;精确到2位小数;单位:元。如:200.07，表示:200元7分。
	        /// </summary>
	        [XmlElement("price")]
	        public string Price { get; set; }
	
	        /// <summary>
	        /// Sku属性串。格式:pid:vid;pid:vid,如: 1627207:3232483;1630696:3284570,表示机身颜色:军绿色;手机套餐:一电一充，用于指定被修改价格的SKU
	        /// </summary>
	        [XmlElement("properties")]
	        public string Properties { get; set; }
	
	        /// <summary>
	        /// SkuID，用于指定被修改价格的SKU
	        /// </summary>
	        [XmlElement("sku_id")]
	        public Nullable<long> SkuId { get; set; }
}

	/// <summary>
/// UpdateItemPriceOptionDomain Data Structure.
/// </summary>
[Serializable]
public class UpdateItemPriceOptionDomain : TopObject
{
	        /// <summary>
	        /// 目标币种，非必填，仅支持天猫国际官网同购商家将外币价格修改成人民币价格时使用
	        /// </summary>
	        [XmlElement("currency_type")]
	        public string CurrencyType { get; set; }
	
	        /// <summary>
	        /// 是否忽略涉嫌炒信警告信息
	        /// </summary>
	        [XmlElement("ignore_fake_credit")]
	        public Nullable<bool> IgnoreFakeCredit { get; set; }
}

        #endregion
    }
}
