using System;
using System.Xml.Serialization;
using System.Collections.Generic;

namespace Top.Api.Response
{
    /// <summary>
    /// LogisticsAddressReachablebatchGetResponse.
    /// </summary>
    public class LogisticsAddressReachablebatchGetResponse : TopResponse
    {
        /// <summary>
        /// 物流是否可达结果列表
        /// </summary>
        [XmlArray("reachable_results")]
        [XmlArrayItem("address_reachable_top_result")]
        public List<AddressReachableTopResultDomain> ReachableResults { get; set; }

	/// <summary>
/// AddressReachableResultDomain Data Structure.
/// </summary>
[Serializable]
public class AddressReachableResultDomain : TopObject
{
	        /// <summary>
	        /// 区域编码
	        /// </summary>
	        [XmlElement("division_id")]
	        public long DivisionId { get; set; }
	
	        /// <summary>
	        /// 错误码
	        /// </summary>
	        [XmlElement("error_code")]
	        public string ErrorCode { get; set; }
	
	        /// <summary>
	        /// 错误信息
	        /// </summary>
	        [XmlElement("error_msg")]
	        public string ErrorMsg { get; set; }
	
	        /// <summary>
	        /// 物流公司代号
	        /// </summary>
	        [XmlElement("partner_code")]
	        public string PartnerCode { get; set; }
	
	        /// <summary>
	        /// 物流公司编码ID
	        /// </summary>
	        [XmlElement("partner_id")]
	        public long PartnerId { get; set; }
	
	        /// <summary>
	        /// 物流公司名称
	        /// </summary>
	        [XmlElement("partner_name")]
	        public string PartnerName { get; set; }
	
	        /// <summary>
	        /// 服务是否可达， 0 - 不可达 1 - 可达 2 - 不确定 3 - 未配置
	        /// </summary>
	        [XmlElement("reachable")]
	        public string Reachable { get; set; }
	
	        /// <summary>
	        /// 服务对应的数字编码，如揽派范围对应88
	        /// </summary>
	        [XmlElement("service_type")]
	        public string ServiceType { get; set; }
	
	        /// <summary>
	        /// 是否成功
	        /// </summary>
	        [XmlElement("success")]
	        public bool Success { get; set; }
}

	/// <summary>
/// AddressReachableTopResultDomain Data Structure.
/// </summary>
[Serializable]
public class AddressReachableTopResultDomain : TopObject
{
	        /// <summary>
	        /// 筛单结果l列表
	        /// </summary>
	        [XmlArray("reachable_result_list")]
	        [XmlArrayItem("address_reachable_result")]
	        public List<AddressReachableResultDomain> ReachableResultList { get; set; }
}

    }
}
