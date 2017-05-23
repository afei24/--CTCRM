using System;
using System.Xml.Serialization;
using System.Collections.Generic;

namespace Top.Api.Response
{
    /// <summary>
    /// CainiaoCloudprintStdtemplatesGetResponse.
    /// </summary>
    public class CainiaoCloudprintStdtemplatesGetResponse : TopResponse
    {
        /// <summary>
        /// 结果集
        /// </summary>
        [XmlElement("result")]
        public CloudPrintBaseResultDomain Result { get; set; }

	/// <summary>
/// StandardTemplateDoDomain Data Structure.
/// </summary>
[Serializable]
public class StandardTemplateDoDomain : TopObject
{
	        /// <summary>
	        /// 模板id
	        /// </summary>
	        [XmlElement("standard_template_id")]
	        public long StandardTemplateId { get; set; }
	
	        /// <summary>
	        /// 模板名称
	        /// </summary>
	        [XmlElement("standard_template_name")]
	        public string StandardTemplateName { get; set; }
	
	        /// <summary>
	        /// 模板url
	        /// </summary>
	        [XmlElement("standard_template_url")]
	        public string StandardTemplateUrl { get; set; }
}

	/// <summary>
/// StandardTemplateResultDomain Data Structure.
/// </summary>
[Serializable]
public class StandardTemplateResultDomain : TopObject
{
	        /// <summary>
	        /// cp编码
	        /// </summary>
	        [XmlElement("cp_code")]
	        public string CpCode { get; set; }
	
	        /// <summary>
	        /// 该cp的所有标准模板
	        /// </summary>
	        [XmlArray("standard_templates")]
	        [XmlArrayItem("standard_template_do")]
	        public List<StandardTemplateDoDomain> StandardTemplates { get; set; }
}

	/// <summary>
/// CloudPrintBaseResultDomain Data Structure.
/// </summary>
[Serializable]
public class CloudPrintBaseResultDomain : TopObject
{
	        /// <summary>
	        /// 所有cp的标准模板
	        /// </summary>
	        [XmlArray("datas")]
	        [XmlArrayItem("standard_template_result")]
	        public List<StandardTemplateResultDomain> Datas { get; set; }
	
	        /// <summary>
	        /// 错误码
	        /// </summary>
	        [XmlElement("error_code")]
	        public string ErrorCode { get; set; }
	
	        /// <summary>
	        /// 错误信息
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
