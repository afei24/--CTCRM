using System;
using System.Xml.Serialization;
using System.Collections.Generic;

namespace Top.Api.Response
{
    /// <summary>
    /// CainiaoOpenstorageIsvResourcesGetResponse.
    /// </summary>
    public class CainiaoOpenstorageIsvResourcesGetResponse : TopResponse
    {
        /// <summary>
        /// result
        /// </summary>
        [XmlElement("result")]
        public CloudPrintBaseResultDomain Result { get; set; }

	/// <summary>
/// IsvResourceMetaInfoDomain Data Structure.
/// </summary>
[Serializable]
public class IsvResourceMetaInfoDomain : TopObject
{
	        /// <summary>
	        /// 是否需要发布
	        /// </summary>
	        [XmlElement("need_publish")]
	        public bool NeedPublish { get; set; }
	
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
	        /// 资源类型
	        /// </summary>
	        [XmlElement("resource_type")]
	        public string ResourceType { get; set; }
}

	/// <summary>
/// CloudPrintBaseResultDomain Data Structure.
/// </summary>
[Serializable]
public class CloudPrintBaseResultDomain : TopObject
{
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
	        /// data
	        /// </summary>
	        [XmlArray("resourcelist")]
	        [XmlArrayItem("isv_resource_meta_info")]
	        public List<IsvResourceMetaInfoDomain> Resourcelist { get; set; }
	
	        /// <summary>
	        /// success
	        /// </summary>
	        [XmlElement("success")]
	        public bool Success { get; set; }
}

    }
}
