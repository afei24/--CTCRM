using System;
using System.Xml.Serialization;
using System.Collections.Generic;

namespace Top.Api.Response
{
    /// <summary>
    /// AlibabaInteractAopdataRegisterResponse.
    /// </summary>
    public class AlibabaInteractAopdataRegisterResponse : TopResponse
    {
        /// <summary>
        /// 接口返回model
        /// </summary>
        [XmlElement("result")]
        public ResultDomain Result { get; set; }

	/// <summary>
/// ResultDomain Data Structure.
/// </summary>
[Serializable]
public class ResultDomain : TopObject
{
	        /// <summary>
	        /// xx
	        /// </summary>
	        [XmlElement("data")]
	        public string Data { get; set; }
	
	        /// <summary>
	        /// xxx失败
	        /// </summary>
	        [XmlElement("err_code")]
	        public string ErrCode { get; set; }
	
	        /// <summary>
	        /// xxx失败
	        /// </summary>
	        [XmlElement("err_msg")]
	        public string ErrMsg { get; set; }
	
	        /// <summary>
	        /// 接口调用成功
	        /// </summary>
	        [XmlElement("success")]
	        public bool Success { get; set; }
	
	        /// <summary>
	        /// 跟踪请求使用
	        /// </summary>
	        [XmlElement("trace_id")]
	        public string TraceId { get; set; }
}

    }
}
