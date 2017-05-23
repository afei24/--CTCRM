using System;
using System.Xml.Serialization;
using System.Collections.Generic;

namespace Top.Api.Response
{
    /// <summary>
    /// CainiaoCbossWorkplatformLogisticsIscainiaoorderResponse.
    /// </summary>
    public class CainiaoCbossWorkplatformLogisticsIscainiaoorderResponse : TopResponse
    {
        /// <summary>
        /// isCainiaoOrder
        /// </summary>
        [XmlElement("is_cainiao_order")]
        public bool IsCainiaoOrder { get; set; }

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
