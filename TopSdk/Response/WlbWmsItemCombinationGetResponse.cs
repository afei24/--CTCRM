using System;
using System.Xml.Serialization;
using System.Collections.Generic;

namespace Top.Api.Response
{
    /// <summary>
    /// WlbWmsItemCombinationGetResponse.
    /// </summary>
    public class WlbWmsItemCombinationGetResponse : TopResponse
    {
        /// <summary>
        /// 接口返回结果
        /// </summary>
        [XmlElement("result")]
        public ResultDomain Result { get; set; }

	/// <summary>
/// SubItemDomain Data Structure.
/// </summary>
[Serializable]
public class SubItemDomain : TopObject
{
	        /// <summary>
	        /// 子货品数量
	        /// </summary>
	        [XmlElement("count")]
	        public long Count { get; set; }
	
	        /// <summary>
	        /// 子货品ID
	        /// </summary>
	        [XmlElement("sc_item_id")]
	        public long ScItemId { get; set; }
}

	/// <summary>
/// SubItemListDomain Data Structure.
/// </summary>
[Serializable]
public class SubItemListDomain : TopObject
{
	        /// <summary>
	        /// 子货品
	        /// </summary>
	        [XmlElement("sub_item")]
	        public SubItemDomain SubItem { get; set; }
}

	/// <summary>
/// ResultDomain Data Structure.
/// </summary>
[Serializable]
public class ResultDomain : TopObject
{
	        /// <summary>
	        /// 子货品列表
	        /// </summary>
	        [XmlArray("sub_item_list")]
	        [XmlArrayItem("sub_item_list")]
	        public List<SubItemListDomain> SubItemList { get; set; }
	
	        /// <summary>
	        /// 错误编码
	        /// </summary>
	        [XmlElement("wl_error_code")]
	        public string WlErrorCode { get; set; }
	
	        /// <summary>
	        /// 错误信息
	        /// </summary>
	        [XmlElement("wl_error_msg")]
	        public string WlErrorMsg { get; set; }
	
	        /// <summary>
	        /// 是否成功
	        /// </summary>
	        [XmlElement("wl_success")]
	        public bool WlSuccess { get; set; }
}

    }
}
