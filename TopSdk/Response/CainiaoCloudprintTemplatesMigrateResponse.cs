using System;
using System.Xml.Serialization;
using System.Collections.Generic;

namespace Top.Api.Response
{
    /// <summary>
    /// CainiaoCloudprintTemplatesMigrateResponse.
    /// </summary>
    public class CainiaoCloudprintTemplatesMigrateResponse : TopResponse
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
	        /// 变量名称
	        /// </summary>
	        [XmlElement("key_name")]
	        public string KeyName { get; set; }
}

	/// <summary>
/// CustomAreaResultDomain Data Structure.
/// </summary>
[Serializable]
public class CustomAreaResultDomain : TopObject
{
	        /// <summary>
	        /// 自定义区id
	        /// </summary>
	        [XmlElement("custom_area_id")]
	        public long CustomAreaId { get; set; }
	
	        /// <summary>
	        /// 自定义区名称
	        /// </summary>
	        [XmlElement("custom_area_name")]
	        public string CustomAreaName { get; set; }
	
	        /// <summary>
	        /// 自定义区url
	        /// </summary>
	        [XmlElement("custom_area_url")]
	        public string CustomAreaUrl { get; set; }
	
	        /// <summary>
	        /// 变量
	        /// </summary>
	        [XmlArray("keys")]
	        [XmlArrayItem("key_result")]
	        public List<KeyResultDomain> Keys { get; set; }
	
	        /// <summary>
	        /// 标准模板名称
	        /// </summary>
	        [XmlElement("standard_template_id")]
	        public long StandardTemplateId { get; set; }
	
	        /// <summary>
	        /// 标准模板url
	        /// </summary>
	        [XmlElement("standard_template_url")]
	        public string StandardTemplateUrl { get; set; }
	
	        /// <summary>
	        /// 用户模板id，等同于mystdtemplates.get中返回的用户模板id
	        /// </summary>
	        [XmlElement("user_template_id")]
	        public long UserTemplateId { get; set; }
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
	        public CustomAreaResultDomain Data { get; set; }
	
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
