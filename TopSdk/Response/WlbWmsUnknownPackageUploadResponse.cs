using System;
using System.Xml.Serialization;
using System.Collections.Generic;

namespace Top.Api.Response
{
    /// <summary>
    /// WlbWmsUnknownPackageUploadResponse.
    /// </summary>
    public class WlbWmsUnknownPackageUploadResponse : TopResponse
    {
        /// <summary>
        /// WlbWmsUnknownPackageUploadResp
        /// </summary>
        [XmlElement("response")]
        public WlbWmsUnknownPackageUploadRespDomain Response { get; set; }

	/// <summary>
/// WlbWmsUnknownPackageUploadRespDomain Data Structure.
/// </summary>
[Serializable]
public class WlbWmsUnknownPackageUploadRespDomain : TopObject
{
	        /// <summary>
	        /// 错误码
	        /// </summary>
	        [XmlElement("error_code")]
	        public string ErrorCode { get; set; }
	
	        /// <summary>
	        /// 错误信息
	        /// </summary>
	        [XmlElement("error_msg")]
	        public string ErrorMsg { get; set; }
	
	        /// <summary>
	        /// 是否成功
	        /// </summary>
	        [XmlElement("success")]
	        public string Success { get; set; }
}

    }
}
