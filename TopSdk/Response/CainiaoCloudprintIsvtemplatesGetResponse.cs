using System;
using System.Xml.Serialization;
using System.Collections.Generic;

namespace Top.Api.Response
{
    /// <summary>
    /// CainiaoCloudprintIsvtemplatesGetResponse.
    /// </summary>
    public class CainiaoCloudprintIsvtemplatesGetResponse : TopResponse
    {
        /// <summary>
        /// result
        /// </summary>
        [XmlElement("result")]
        public CloudPrintBaseResultDomain Result { get; set; }

	/// <summary>
/// KeyResultDomain Data Structure.
/// </summary>
[Serializable]
public class KeyResultDomain : TopObject
{
	        /// <summary>
	        /// key名称
	        /// </summary>
	        [XmlElement("key_name")]
	        public string KeyName { get; set; }
}

	/// <summary>
/// CustomTemplateResultDomain Data Structure.
/// </summary>
[Serializable]
public class CustomTemplateResultDomain : TopObject
{
	        /// <summary>
	        /// isv模板的id
	        /// </summary>
	        [XmlElement("isv_template_id")]
	        public long IsvTemplateId { get; set; }
	
	        /// <summary>
	        /// isv模板的名称
	        /// </summary>
	        [XmlElement("isv_template_name")]
	        public string IsvTemplateName { get; set; }
	
	        /// <summary>
	        /// isv模板的url
	        /// </summary>
	        [XmlElement("isv_template_url")]
	        public string IsvTemplateUrl { get; set; }
	
	        /// <summary>
	        /// 模板的keys
	        /// </summary>
	        [XmlArray("keys")]
	        [XmlArrayItem("key_result")]
	        public List<KeyResultDomain> Keys { get; set; }
	
	        /// <summary>
	        /// 版本号
	        /// </summary>
	        [XmlElement("version")]
	        public string Version { get; set; }
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
	        [XmlArray("datas")]
	        [XmlArrayItem("custom_template_result")]
	        public List<CustomTemplateResultDomain> Datas { get; set; }
	
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
	        /// 是否成功
	        /// </summary>
	        [XmlElement("success")]
	        public bool Success { get; set; }
}

    }
}
