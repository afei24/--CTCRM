using System;
using System.Xml.Serialization;
using System.Collections.Generic;

namespace Top.Api.Response
{
    /// <summary>
    /// CainiaoOpenstorageSellerResourcedetailGetResponse.
    /// </summary>
    public class CainiaoOpenstorageSellerResourcedetailGetResponse : TopResponse
    {
        /// <summary>
        /// result
        /// </summary>
        [XmlElement("result")]
        public CloudPrintBaseResultDomain Result { get; set; }

	/// <summary>
/// SellerResourceMetaInfoDomain Data Structure.
/// </summary>
[Serializable]
public class SellerResourceMetaInfoDomain : TopObject
{
	        /// <summary>
	        /// 是否需要发布
	        /// </summary>
	        [XmlElement("need_publish")]
	        public bool NeedPublish { get; set; }
	
	        /// <summary>
	        /// 父资源id
	        /// </summary>
	        [XmlElement("parent_resource_id")]
	        public long ParentResourceId { get; set; }
	
	        /// <summary>
	        /// 资源id
	        /// </summary>
	        [XmlElement("resource_id")]
	        public long ResourceId { get; set; }
	
	        /// <summary>
	        /// 资源名称
	        /// </summary>
	        [XmlElement("resource_name")]
	        public string ResourceName { get; set; }
	
	        /// <summary>
	        /// 商家资源类型
	        /// </summary>
	        [XmlElement("seller_resource_type")]
	        public string SellerResourceType { get; set; }
}

	/// <summary>
/// SellerResourceResponseDomain Data Structure.
/// </summary>
[Serializable]
public class SellerResourceResponseDomain : TopObject
{
	        /// <summary>
	        /// 正在编辑的资源内容
	        /// </summary>
	        [XmlElement("editing_resource_data")]
	        public string EditingResourceData { get; set; }
	
	        /// <summary>
	        /// 已发布的资源内容
	        /// </summary>
	        [XmlElement("online_resource_data")]
	        public string OnlineResourceData { get; set; }
	
	        /// <summary>
	        /// sellerResourceMetaInfo
	        /// </summary>
	        [XmlElement("seller_resource_meta_info")]
	        public SellerResourceMetaInfoDomain SellerResourceMetaInfo { get; set; }
}

	/// <summary>
/// CloudPrintBaseResultDomain Data Structure.
/// </summary>
[Serializable]
public class CloudPrintBaseResultDomain : TopObject
{
	        /// <summary>
	        /// data
	        /// </summary>
	        [XmlElement("data")]
	        public SellerResourceResponseDomain Data { get; set; }
	
	        /// <summary>
	        /// 错误码
	        /// </summary>
	        [XmlElement("error_code")]
	        public string ErrorCode { get; set; }
	
	        /// <summary>
	        /// 错误消息
	        /// </summary>
	        [XmlElement("error_message")]
	        public string ErrorMessage { get; set; }
	
	        /// <summary>
	        /// 状态
	        /// </summary>
	        [XmlElement("success")]
	        public bool Success { get; set; }
}

    }
}
