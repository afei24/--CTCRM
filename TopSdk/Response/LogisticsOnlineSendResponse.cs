using System;
using System.Xml.Serialization;
using System.Collections.Generic;

namespace Top.Api.Response
{
    /// <summary>
    /// LogisticsOnlineSendResponse.
    /// </summary>
    public class LogisticsOnlineSendResponse : TopResponse
    {
        /// <summary>
        /// de
        /// </summary>
        [XmlElement("shipping")]
        public Top.Api.Domain.Shipping Shipping { get; set; }

    }
}
