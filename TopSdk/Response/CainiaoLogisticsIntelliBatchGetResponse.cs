using System;
using System.Xml.Serialization;
using System.Collections.Generic;

namespace Top.Api.Response
{
    /// <summary>
    /// CainiaoLogisticsIntelliBatchGetResponse.
    /// </summary>
    public class CainiaoLogisticsIntelliBatchGetResponse : TopResponse
    {
        /// <summary>
        /// 返回结果封装类
        /// </summary>
        [XmlArray("intelli_logistics_result_wraps")]
        [XmlArrayItem("intelli_logistics_result_wrap")]
        public List<IntelliLogisticsResultWrapDomain> IntelliLogisticsResultWraps { get; set; }

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
	        /// 到货地址的区名称
	        /// </summary>
	        [XmlElement("to_district")]
	        public string ToDistrict { get; set; }
	
	        /// <summary>
	        /// 到货地省份名称
	        /// </summary>
	        [XmlElement("to_prov")]
	        public string ToProv { get; set; }
}

	/// <summary>
/// IntelliLogisticsResultWrapDomain Data Structure.
/// </summary>
[Serializable]
public class IntelliLogisticsResultWrapDomain : TopObject
{
	        /// <summary>
	        /// 错误码
	        /// </summary>
	        [XmlElement("error_code")]
	        public string ErrorCode { get; set; }
	
	        /// <summary>
	        /// 错误信息
	        /// </summary>
	        [XmlElement("error_message")]
	        public string ErrorMessage { get; set; }
	
	        /// <summary>
	        /// 智选结果
	        /// </summary>
	        [XmlElement("intelli_logistics_result")]
	        public IntelliLogisticsResultDomain IntelliLogisticsResult { get; set; }
	
	        /// <summary>
	        /// 结果是否成功
	        /// </summary>
	        [XmlElement("success")]
	        public bool Success { get; set; }
}

    }
}
