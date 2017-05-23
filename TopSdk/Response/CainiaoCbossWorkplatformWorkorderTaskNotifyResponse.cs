using System;
using System.Xml.Serialization;
using System.Collections.Generic;

namespace Top.Api.Response
{
    /// <summary>
    /// CainiaoCbossWorkplatformWorkorderTaskNotifyResponse.
    /// </summary>
    public class CainiaoCbossWorkplatformWorkorderTaskNotifyResponse : TopResponse
    {
        /// <summary>
        /// response
        /// </summary>
        [XmlElement("response")]
        public StructDomain Response { get; set; }

	/// <summary>
/// StructDomain Data Structure.
/// </summary>
[Serializable]
public class StructDomain : TopObject
{
	        /// <summary>
	        /// 错误码
	        /// </summary>
	        [XmlElement("res_error_code")]
	        public string ResErrorCode { get; set; }
	
	        /// <summary>
	        /// 错误信息
	        /// </summary>
	        [XmlElement("res_error_msg")]
	        public string ResErrorMsg { get; set; }
	
	        /// <summary>
	        /// 是否成功
	        /// </summary>
	        [XmlElement("res_success")]
	        public bool ResSuccess { get; set; }
}

    }
}
