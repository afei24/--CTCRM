using System;
using System.Xml.Serialization;
using System.Collections.Generic;

namespace Top.Api.Response
{
    /// <summary>
    /// CainiaoCloudprintMystdtemplatesGetResponse.
    /// </summary>
    public class CainiaoCloudprintMystdtemplatesGetResponse : TopResponse
    {
        /// <summary>
        /// 返回结果
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
	        /// key的名称
	        /// </summary>
	        [XmlElement("key_name")]
	        public string KeyName { get; set; }
}

	/// <summary>
/// UserTemplateDoDomain Data Structure.
/// </summary>
[Serializable]
public class UserTemplateDoDomain : TopObject
{
	        /// <summary>
	        /// keys
	        /// </summary>
	        [XmlArray("keys")]
	        [XmlArrayItem("key_result")]
	        public List<KeyResultDomain> Keys { get; set; }
	
	        /// <summary>
	        /// 用户使用模板的id
	        /// </summary>
	        [XmlElement("user_std_template_id")]
	        public long UserStdTemplateId { get; set; }
	
	        /// <summary>
	        /// 用户使用模板名称
	        /// </summary>
	        [XmlElement("user_std_template_name")]
	        public string UserStdTemplateName { get; set; }
	
	        /// <summary>
	        /// 用户使用模板的url
	        /// </summary>
	        [XmlElement("user_std_template_url")]
	        public string UserStdTemplateUrl { get; set; }
}

	/// <summary>
/// UserTemplateResultDomain Data Structure.
/// </summary>
[Serializable]
public class UserTemplateResultDomain : TopObject
{
	        /// <summary>
	        /// cp编码
	        /// </summary>
	        [XmlElement("cp_code")]
	        public string CpCode { get; set; }
	
	        /// <summary>
	        /// 用户使用的模板数据
	        /// </summary>
	        [XmlArray("user_std_templates")]
	        [XmlArrayItem("user_template_do")]
	        public List<UserTemplateDoDomain> UserStdTemplates { get; set; }
}

	/// <summary>
/// CloudPrintBaseResultDomain Data Structure.
/// </summary>
[Serializable]
public class CloudPrintBaseResultDomain : TopObject
{
	        /// <summary>
	        /// 所有cp的数据
	        /// </summary>
	        [XmlArray("datas")]
	        [XmlArrayItem("user_template_result")]
	        public List<UserTemplateResultDomain> Datas { get; set; }
	
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
