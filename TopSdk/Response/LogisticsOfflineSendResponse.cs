using System;
using System.Xml.Serialization;
using System.Collections.Generic;

namespace Top.Api.Response
{
    /// <summary>
    /// LogisticsOfflineSendResponse.
    /// </summary>
    public class LogisticsOfflineSendResponse : TopResponse
    {
        /// <summary>
        /// 自己联系的调用结果
        /// </summary>
        [XmlElement("shipping")]
        public Top.Api.Domain.Shipping Shipping { get; set; }

    }
}
