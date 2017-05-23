using System;
using System.Xml.Serialization;
using System.Collections.Generic;

namespace Top.Api.Response
{
    /// <summary>
    /// AlibabaInteractTidaCartResultResponse.
    /// </summary>
    public class AlibabaInteractTidaCartResultResponse : TopResponse
    {
        /// <summary>
        /// ISV收到spi调用信息
        /// </summary>
        [XmlElement("recieved")]
        public bool Recieved { get; set; }

    }
}
