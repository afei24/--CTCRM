using System;
using System.Xml.Serialization;
using System.Collections.Generic;

namespace Top.Api.Response
{
    /// <summary>
    /// CainiaoLogisticsIntelliGetResponse.
    /// </summary>
    public class CainiaoLogisticsIntelliGetResponse : TopResponse
    {
        /// <summary>
        /// 智选物流返回结果类
        /// </summary>
        [XmlElement("intelli_logistics_result")]
        public IntelliLogisticsResultDomain IntelliLogisticsResult { get; set; }

	/// <summary>
/// IntelliLogisticsResultDomain Data Structure.
/// </summary>
[Serializable]
public class IntelliLogisticsResultDomain : TopObject
{
	        /// <summary>
	        /// 物流公司编码
	        /// </summary>
	        [XmlElement("cp_code")]
	        public string CpCode { get; set; }
	
	        /// <summary>
	        /// 物流公司id
	        /// </summary>
	        [XmlElement("cp_id")]
	        public long CpId { get; set; }
	
	        /// <summary>
	        /// 物流公司名称
	        /// </summary>
	        [XmlElement("cp_name")]
	        public string CpName { get; set; }
	
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
	        /// 淘宝交易订单id
	        /// </summary>
	        [XmlElement("order_id")]
	        public long OrderId { get; set; }
	
	        /// <summary>
	        /// 商家id(主账号id)
	        /// </summary>
	        [XmlElement("seller_id")]
	        public long SellerId { get; set; }
	
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

    }
}
