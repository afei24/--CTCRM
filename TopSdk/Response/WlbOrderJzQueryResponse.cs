using System;
using System.Xml.Serialization;
using System.Collections.Generic;

namespace Top.Api.Response
{
    /// <summary>
    /// WlbOrderJzQueryResponse.
    /// </summary>
    public class WlbOrderJzQueryResponse : TopResponse
    {
        /// <summary>
        /// 结果信息
        /// </summary>
        [XmlElement("result")]
        public Top.Api.Domain.JzTopDto Result { get; set; }

        /// <summary>
        /// 错误编码
        /// </summary>
        [XmlElement("result_error_code")]
        public string ResultErrorCode { get; set; }

        /// <summary>
        /// 错误信息
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
