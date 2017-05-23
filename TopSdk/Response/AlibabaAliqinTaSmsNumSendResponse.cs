using System;
using System.Xml.Serialization;
using System.Collections.Generic;

namespace Top.Api.Response
{
    /// <summary>
    /// AlibabaAliqinTaSmsNumSendResponse.
    /// </summary>
    public class AlibabaAliqinTaSmsNumSendResponse : TopResponse
    {
        /// <summary>
        /// 返回结果
        /// </summary>
        [XmlElement("result")]
        public Top.Api.Domain.BizResult Result { get; set; }

    }
}
