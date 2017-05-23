using System;
using System.Xml.Serialization;
using System.Collections.Generic;

namespace Top.Api.Response
{
    /// <summary>
    /// CainiaoWaybillIiSearchResponse.
    /// </summary>
    public class CainiaoWaybillIiSearchResponse : TopResponse
    {
        /// <summary>
        /// CP网点信息及对应的商家的发货信息
        /// </summary>
        [XmlArray("waybill_apply_subscription_cols")]
        [XmlArrayItem("waybill_apply_subscription_info")]
        public List<WaybillApplySubscriptionInfoDomain> WaybillApplySubscriptionCols { get; set; }

	/// <summary>
/// AddressDtoDomain Data Structure.
/// </summary>
[Serializable]
public class AddressDtoDomain : TopObject
{
	        /// <summary>
	        /// 市名称（二级地址）
	        /// </summary>
	        [XmlElement("city")]
	        public string City { get; set; }
	
	        /// <summary>
	        /// 详细地址
	        /// </summary>
	        [XmlElement("detail")]
	        public string Detail { get; set; }
	
	        /// <summary>
	        /// 区名称（三级地址）
	        /// </summary>
	        [XmlElement("district")]
	        public string District { get; set; }
	
	        /// <summary>
	        /// 省名称（一级地址）
	        /// </summary>
	        [XmlElement("province")]
	        public string Province { get; set; }
	
	        /// <summary>
	        /// 街道\镇名称（四级地址）
	        /// </summary>
	        [XmlElement("town")]
	        public string Town { get; set; }
}

	/// <summary>
/// WaybillBranchAccountDomain Data Structure.
/// </summary>
[Serializable]
public class WaybillBranchAccountDomain : TopObject
{
	        /// <summary>
	        /// 已用面单数量
	        /// </summary>
	        [XmlElement("allocated_quantity")]
	        public long AllocatedQuantity { get; set; }
	
	        /// <summary>
	        /// 网点Code
	        /// </summary>
	        [XmlElement("branch_code")]
	        public string BranchCode { get; set; }
	
	        /// <summary>
	        /// 网点名称
	        /// </summary>
	        [XmlElement("branch_name")]
	        public string BranchName { get; set; }
	
	        /// <summary>
	        /// 网点状态
	        /// </summary>
	        [XmlElement("branch_status")]
	        public long BranchStatus { get; set; }
	
	        /// <summary>
	        /// 取消的面单总数
	        /// </summary>
	        [XmlElement("cancel_quantity")]
	        public long CancelQuantity { get; set; }
	
	        /// <summary>
	        /// 已经打印的面单总数
	        /// </summary>
	        [XmlElement("print_quantity")]
	        public long PrintQuantity { get; set; }
	
	        /// <summary>
	        /// 电子面单余额数量
	        /// </summary>
	        [XmlElement("quantity")]
	        public long Quantity { get; set; }
	
	        /// <summary>
	        /// 当前网点下的发货地址
	        /// </summary>
	        [XmlArray("shipp_address_cols")]
	        [XmlArrayItem("address_dto")]
	        public List<AddressDtoDomain> ShippAddressCols { get; set; }
}

	/// <summary>
/// WaybillApplySubscriptionInfoDomain Data Structure.
/// </summary>
[Serializable]
public class WaybillApplySubscriptionInfoDomain : TopObject
{
	        /// <summary>
	        /// CP网点信息及对应的商家的发货信息
	        /// </summary>
	        [XmlArray("branch_account_cols")]
	        [XmlArrayItem("waybill_branch_account")]
	        public List<WaybillBranchAccountDomain> BranchAccountCols { get; set; }
	
	        /// <summary>
	        /// 物流服务商ID
	        /// </summary>
	        [XmlElement("cp_code")]
	        public string CpCode { get; set; }
	
	        /// <summary>
	        /// 1是直营，2是加盟
	        /// </summary>
	        [XmlElement("cp_type")]
	        public long CpType { get; set; }
}

    }
}
