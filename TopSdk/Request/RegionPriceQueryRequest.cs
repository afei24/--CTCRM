using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using Top.Api.Util;

namespace Top.Api.Request
{
    /// <summary>
    /// TOP API: taobao.region.price.query
    /// </summary>
    public class RegionPriceQueryRequest : BaseTopRequest<Top.Api.Response.RegionPriceQueryResponse>
    {
        /// <summary>
        /// 商品id
        /// </summary>
        public Nullable<long> ItemId { get; set; }

        /// <summary>
        /// 不传则返回所有设置的区域价格
        /// </summary>
        public string RegionalPriceDtos { get; set; }

        public List<RegionalPriceDtoDomain> RegionalPriceDtos_ { set { this.RegionalPriceDtos = TopUtils.ObjectToJson(value); } } 

        /// <summary>
        /// 无sku可传0
        /// </summary>
        public Nullable<long> SkuId { get; set; }

        #region ITopRequest Members

        public override string GetApiName()
        {
            return "taobao.region.price.query";
        }

        public override IDictionary<string, string> GetParameters()
        {
            TopDictionary parameters = new TopDictionary();
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
	        /// 区县，特殊可选
	        /// </summary>
	        [XmlElement("district")]
	        public string District { get; set; }
	
	        /// <summary>
	        /// 省
	        /// </summary>
	        [XmlElement("province")]
	        public string Province { get; set; }
	
	        /// <summary>
	        /// 街道，特殊可选
	        /// </summary>
	        [XmlElement("street")]
	        public string Street { get; set; }
}

        #endregion
    }
}
