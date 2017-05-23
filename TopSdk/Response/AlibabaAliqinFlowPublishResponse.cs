using System;
using System.Xml.Serialization;
using System.Collections.Generic;

namespace Top.Api.Response
{
    /// <summary>
    /// AlibabaAliqinFlowPublishResponse.
    /// </summary>
    public class AlibabaAliqinFlowPublishResponse : TopResponse
    {
        /// <summary>
        /// true为成功，其他为失败
        /// </summary>
        [XmlElement("value")]
        public string Value { get; set; }

    }
}
