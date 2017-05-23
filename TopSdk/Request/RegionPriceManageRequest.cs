using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using Top.Api.Util;

namespace Top.Api.Request
{
    /// <summary>
    /// TOP API: taobao.region.price.manage
    /// </summary>
    public class RegionPriceManageRequest : BaseTopRequest<Top.Api.Response.RegionPriceManageResponse>
    {
        /// <summary>
        /// true:全量, false:增量
        /// </summary>
        public Nullable<bool> IsFull { get; set; }

        /// <summary>
        /// 商品id
        /// </summary>
        public Nullable<long> ItemId { get; set; }

        /// <summary>
        /// 列表
        /// </summary>
        public string RegionalPriceDtos { get; set; }

        public List<RegionalPriceDtoDomain> RegionalPriceDtos_ { set { this.RegionalPriceDtos = TopUtils.ObjectToJson(value); } } 

        /// <summary>
        /// 无sku传0
        /// </summary>
        public Nullable<long> SkuId { get; set; }

        #region ITopRequest Members

        public override string GetApiName()
        {
            return "taobao.region.price.manage";
        }

        public override IDictionary<string, string> GetParameters()
        {
            TopDictionary parameters = new TopDictionary();
            parameters.Add("is_full", this.IsFull);
            parameters.Add("item_id", this.ItemId);
            parameters.Add("regional_price_dtos", this.RegionalPriceDtos);
            parameters.Add("sku_id", this.SkuId);
            if (this.otherParams != null)
            {
                parameters.AddAll(this.otherParams);
            }
            return parameters;
        }

        public override void Validate()
        {
            RequestValidator.ValidateRequired("item_id", this.ItemId);
            RequestValidator.ValidateRequired("regional_price_dtos", this.RegionalPriceDtos);
            RequestValidator.ValidateObjectMaxListSize("regional_price_dtos", this.RegionalPriceDtos, 20);
        }

	/// <summary>
/// RegionalPriceDtoDomain Data Structure.
/// </summary>
[Serializable]
public class RegionalPriceDtoDomain : TopObject
{
	        /// <summary>
	        /// 市
	        /// </summary>
	        [XmlElement("city")]
	        public string City { get; set; }
	
	        /// <summary>
	        /// 金额（分）
	        /// </summary>
	        [XmlElement("price")]
	        public Nullable<long> Price { get; set; }
	
	        /// <summary>
	        /// 省
	        /// </summary>
	        [XmlElement("province")]
	        public string Province { get; set; }
}

        #endregion
    }
}
