using System;
using System.Xml.Serialization;
using System.Collections.Generic;

namespace Top.Api.Response
{
    /// <summary>
    /// WlbWmsSnInfoQueryResponse.
    /// </summary>
    public class WlbWmsSnInfoQueryResponse : TopResponse
    {
        /// <summary>
        /// 接口返回
        /// </summary>
        [XmlElement("result")]
        public ResultDomain Result { get; set; }

	/// <summary>
/// SninfoDomain Data Structure.
/// </summary>
[Serializable]
public class SninfoDomain : TopObject
{
	        /// <summary>
	        /// 库存类型（1 可销售库存(正品) 101 残次 102 机损 103 箱损201 冻结库存）
	        /// </summary>
	        [XmlElement("inventory_type")]
	        public long InventoryType { get; set; }
	
	        /// <summary>
	        /// 商家对商品的编码
	        /// </summary>
	        [XmlElement("item_code")]
	        public string ItemCode { get; set; }
	
	        /// <summary>
	        /// 商品ID
	        /// </summary>
	        [XmlElement("item_id")]
	        public string ItemId { get; set; }
	
	        /// <summary>
	        /// sn编码
	        /// </summary>
	        [XmlElement("sn_code")]
	        public string SnCode { get; set; }
}

	/// <summary>
/// SninfolistDomain Data Structure.
/// </summary>
[Serializable]
public class SninfolistDomain : TopObject
{
	        /// <summary>
	        /// SN信息
	        /// </summary>
	        [XmlElement("sn_info")]
	        public SninfoDomain SnInfo { get; set; }
}

	/// <summary>
/// ResultDomain Data Structure.
/// </summary>
[Serializable]
public class ResultDomain : TopObject
{
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
	        /// SN信息列表
	        /// </summary>
	        [XmlArray("sn_info_list")]
	        [XmlArrayItem("sninfolist")]
	        public List<SninfolistDomain> SnInfoList { get; set; }
	
	        /// <summary>
	        /// 是否成功
	        /// </summary>
	        [XmlElement("success")]
	        public bool Success { get; set; }
	
	        /// <summary>
	        /// 总条数
	        /// </summary>
	        [XmlElement("total_count")]
	        public long TotalCount { get; set; }
}

    }
}
