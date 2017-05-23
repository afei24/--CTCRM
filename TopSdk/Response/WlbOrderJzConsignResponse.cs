using System;
using System.Xml.Serialization;
using System.Collections.Generic;

namespace Top.Api.Response
{
    /// <summary>
    /// WlbOrderJzConsignResponse.
    /// </summary>
    public class WlbOrderJzConsignResponse : TopResponse
    {
        /// <summary>
        /// 错误码
        /// </summary>
        [XmlElement("result_error_code")]
        public string ResultErrorCode { get; set; }

        /// <summary>
        /// 错误信息描述
        /// </summary>
        [XmlElement("result_error_msg")]
        public string ResultErrorMsg { get; set; }

        /// <summary>
        /// 是否成功
        /// </summary>
        [XmlElement("result_success")]
        public bool ResultSuccess { get; set; }

    }
}
