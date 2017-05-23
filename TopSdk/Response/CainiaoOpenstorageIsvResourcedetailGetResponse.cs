using System;
using System.Xml.Serialization;
using System.Collections.Generic;

namespace Top.Api.Response
{
    /// <summary>
    /// CainiaoOpenstorageIsvResourcedetailGetResponse.
    /// </summary>
    public class CainiaoOpenstorageIsvResourcedetailGetResponse : TopResponse
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
	        /// 是否需要发布，如果online_resource_data中没有值，则为true，表示需要发布
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
/// IsvResourceResponseDomain Data Structure.
/// </summary>
[Serializable]
public class IsvResourceResponseDomain : TopObject
{
	        /// <summary>
	        /// 编辑版本的内容
	        /// </summary>
	        [XmlElement("editing_resource_data")]
	        public string EditingResourceData { get; set; }
	
	        /// <summary>
	        /// isvResourceMetaInfo
	        /// </summary>
	        [XmlElement("isv_resource_meta_info")]
	        public IsvResourceMetaInfoDomain IsvResourceMetaInfo { get; set; }
	
	        /// <summary>
	        /// 已发布的内容
	        /// </summary>
	        [XmlElement("online_resource_data")]
	        public string OnlineResourceData { get; set; }
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
	        public IsvResourceResponseDomain Data { get; set; }
	
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
