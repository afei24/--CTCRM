using System;
using System.Xml.Serialization;
using System.Collections.Generic;

namespace Top.Api.Response
{
    /// <summary>
    /// AlibabaInteractAllsparkisvDrawResponse.
    /// </summary>
    public class AlibabaInteractAllsparkisvDrawResponse : TopResponse
    {
        /// <summary>
        /// ddd
        /// </summary>
        [XmlElement("ddd")]
        public string Ddd { get; set; }

    }
}
