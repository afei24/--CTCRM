using System;
using System.Xml.Serialization;
using System.Collections.Generic;

namespace Top.Api.Response
{
    /// <summary>
    /// AlibabaInteractUserIsloginResponse.
    /// </summary>
    public class AlibabaInteractUserIsloginResponse : TopResponse
    {
        /// <summary>
        /// result
        /// </summary>
        [XmlElement("result")]
        public MtopResultDomain Result { get; set; }

	/// <summary>
/// MtopResultDomain Data Structure.
/// </summary>
[Serializable]
public class MtopResultDomain : TopObject
{
	        /// <summary>
	        /// model
	        /// </summary>
	        [XmlElement("model")]
	        public string Model { get; set; }
	
	        /// <summary>
	        /// msgCode
	        /// </summary>
	        [XmlElement("msg_code")]
	        public string MsgCode { get; set; }
	
	        /// <summary>
	        /// msgInfo
	        /// </summary>
	        [XmlElement("msg_info")]
	        public string MsgInfo { get; set; }
	
	        /// <summary>
	        /// success
	        /// </summary>
	        [XmlElement("success")]
	        public bool Success { get; set; }
}

    }
}
