using System;
using System.Xml.Serialization;
using System.Collections.Generic;

namespace Top.Api.Response
{
    /// <summary>
    /// AlibabaInteractSensorContactsResponse.
    /// </summary>
    public class AlibabaInteractSensorContactsResponse : TopResponse
    {
        /// <summary>
        /// return=0 表示成功
        /// </summary>
        [XmlElement("result")]
        public string Result { get; set; }

    }
}
