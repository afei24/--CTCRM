using System;
using System.Xml.Serialization;
using System.Collections.Generic;

namespace Top.Api.Response
{
    /// <summary>
    /// AlibabaInteractIsvGatewayResponse.
    /// </summary>
    public class AlibabaInteractIsvGatewayResponse : TopResponse
    {
        /// <summary>
        /// ret=0
        /// </summary>
        [XmlElement("ret")]
        public string Ret { get; set; }

    }
}
