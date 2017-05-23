using System;
using System.Xml.Serialization;
using System.Collections.Generic;

namespace Top.Api.Response
{
    /// <summary>
    /// CainiaoOpenstorageSellerResourceCreateResponse.
    /// </summary>
    public class CainiaoOpenstorageSellerResourceCreateResponse : TopResponse
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
	        /// needPublish
	        /// </summary>
	        [XmlElement("need_publish")]
	        public bool NeedPublish { get; set; }
	
	        /// <summary>
	        /// parentResourceId
	        /// </summary>
	        [XmlElement("parent_resource_id")]
	        public long ParentResourceId { get; set; }
	
	        /// <summary>
	        /// resourceId
	        /// </summary>
	        [XmlElement("resource_id")]
	        public long ResourceId { get; set; }
	
	        /// <summary>
	        /// resourceName
	        /// </summary>
	        [XmlElement("resource_name")]
	        public string ResourceName { get; set; }
	
	        /// <summary>
	        /// sellerResourceType
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
	        /// 待发布的内容
	        /// </summary>
	        [XmlElement("editing_resource_data")]
	        public string EditingResourceData { get; set; }
	
	        /// <summary>
	        /// 已经发布的内容，如果是第一次创建，则值为空
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
	        /// errorCode
	        /// </summary>
	        [XmlElement("error_code")]
	        public string ErrorCode { get; set; }
	
	        /// <summary>
	        /// errorMessage
	        /// </summary>
	        [XmlElement("error_message")]
	        public string ErrorMessage { get; set; }
	
	        /// <summary>
	        /// success
	        /// </summary>
	        [XmlElement("success")]
	        public bool Success { get; set; }
}

    }
}
