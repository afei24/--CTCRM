using System;
using System.Xml.Serialization;
using System.Collections.Generic;

namespace Top.Api.Response
{
    /// <summary>
    /// CainiaoCbossWorkplatformOperationReplyResponse.
    /// </summary>
    public class CainiaoCbossWorkplatformOperationReplyResponse : TopResponse
    {
        /// <summary>
        /// result
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
	        /// errorCode
	        /// </summary>
	        [XmlElement("res_error_code")]
	        public string ResErrorCode { get; set; }
	
	        /// <summary>
	        /// errorMsg
	        /// </summary>
	        [XmlElement("res_error_msg")]
	        public string ResErrorMsg { get; set; }
	
	        /// <summary>
	        /// success
	        /// </summary>
	        [XmlElement("res_success")]
	        public bool ResSuccess { get; set; }
}

    }
}
