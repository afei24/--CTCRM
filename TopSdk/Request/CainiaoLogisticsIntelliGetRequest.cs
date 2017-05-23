using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using Top.Api.Util;

namespace Top.Api.Request
{
    /// <summary>
    /// TOP API: cainiao.logistics.intelli.get
    /// </summary>
    public class CainiaoLogisticsIntelliGetRequest : BaseTopRequest<Top.Api.Response.CainiaoLogisticsIntelliGetResponse>
    {
        /// <summary>
        /// 智选物流请求参数类
        /// </summary>
        public string IntelliLogisticsParam { get; set; }

        public IntelliLogisticsParamDomain IntelliLogisticsParam_ { set { this.IntelliLogisticsParam = TopUtils.ObjectToJson(value); } } 

        #region ITopRequest Members

        public override string GetApiName()
        {
            return "cainiao.logistics.intelli.get";
        }

        public override IDictionary<string, string> GetParameters()
        {
            TopDictionary parameters = new TopDictionary();
            parameters.Add("intelli_logistics_param", this.IntelliLogisticsParam);
            if (this.otherParams != null)
            {
                parameters.AddAll(this.otherParams);
            }
            return parameters;
        }

        public override void Validate()
        {
            RequestValidator.ValidateRequired("intelli_logistics_param", this.IntelliLogisticsParam);
        }

	/// <summary>
/// IntelliLogisticsParamDomain Data Structure.
/// </summary>
[Serializable]
public class IntelliLogisticsParamDomain : TopObject
{
	        /// <summary>
	        /// 发货地城市名称
	        /// </summary>
	        [XmlElement("from_city")]
	        public string FromCity { get; set; }
	
	        /// <summary>
	        /// 发货地的详细地址
	        /// </summary>
	        [XmlElement("from_detail_address")]
	        public string FromDetailAddress { get; set; }
	
	        /// <summary>
	        /// 发货地的区名称
	        /// </summary>
	        [XmlElement("from_district")]
	        public string FromDistrict { get; set; }
	
	        /// <summary>
	        /// 发货地省份名称
	        /// </summary>
	        [XmlElement("from_prov")]
	        public string FromProv { get; set; }
	
	        /// <summary>
	        /// 淘宝交易订单id（为了更好效果，推荐填写）
	        /// </summary>
	        [XmlElement("order_id")]
	        public Nullable<long> OrderId { get; set; }
	
	        /// <summary>
	        /// 商家id(主账号id)
	        /// </summary>
	        [XmlElement("seller_id")]
	        public Nullable<long> SellerId { get; set; }
	
	        /// <summary>
	        /// 到货地城市名称
	        /// </summary>
	        [XmlElement("to_city")]
	        public string ToCity { get; set; }
	
	        /// <summary>
	        /// 到货地的详细地址
	        /// </summary>
	        [XmlElement("to_detail_address")]
	        public string ToDetailAddress { get; set; }
	
	        /// <summary>
	        /// 到货地的区名称
	        /// </summary>
	        [XmlElement("to_district")]
	        public string ToDistrict { get; set; }
	
	        /// <summary>
	        /// 到货地省份名称
	        /// </summary>
	        [XmlElement("to_prov")]
	        public string ToProv { get; set; }
}

        #endregion
    }
}
