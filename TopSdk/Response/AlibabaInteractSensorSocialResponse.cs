using System;
using System.Xml.Serialization;
using System.Collections.Generic;

namespace Top.Api.Response
{
    /// <summary>
    /// AlibabaInteractSensorSocialResponse.
    /// </summary>
    public class AlibabaInteractSensorSocialResponse : TopResponse
    {
        /// <summary>
        /// result=1
        /// </summary>
        [XmlElement("result")]
        public string Result { get; set; }

    }
}
