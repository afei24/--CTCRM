using System;
using System.Xml.Serialization;
using System.Collections.Generic;

namespace Top.Api.Response
{
    /// <summary>
    /// CainiaoCbossWorkplatformBiztypeQueryallResponse.
    /// </summary>
    public class CainiaoCbossWorkplatformBiztypeQueryallResponse : TopResponse
    {
        /// <summary>
        /// bizTypeJson
        /// </summary>
        [XmlElement("biz_type_json")]
        public string BizTypeJson { get; set; }

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
