using System;
using System.Xml.Serialization;
using System.Collections.Generic;

namespace Top.Api.Response
{
    /// <summary>
    /// CainiaoCloudprintIsvResourcesGetResponse.
    /// </summary>
    public class CainiaoCloudprintIsvResourcesGetResponse : TopResponse
    {
        /// <summary>
        /// result
        /// </summary>
        [XmlElement("result")]
        public CloudPrintBaseResultDomain Result { get; set; }

	/// <summary>
/// IsvResourceDoDomain Data Structure.
/// </summary>
[Serializable]
public class IsvResourceDoDomain : TopObject
{
	        /// <summary>
	        /// 资源内容（当资源类型为TEMPLATE时，为空）
	        /// </summary>
	        [XmlElement("resource_content")]
	        public string ResourceContent { get; set; }
	
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
	
	        /// <summary>
	        /// 资源url（当资源类型为打印项时，为空）
	        /// </summary>
	        [XmlElement("resource_url")]
	        public string ResourceUrl { get; set; }
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
	        [XmlArray("resource_list")]
	        [XmlArrayItem("isv_resource_do")]
	        public List<IsvResourceDoDomain> ResourceList { get; set; }
	
	        /// <summary>
	        /// 状态
	        /// </summary>
	        [XmlElement("success")]
	        public bool Success { get; set; }
}

    }
}
