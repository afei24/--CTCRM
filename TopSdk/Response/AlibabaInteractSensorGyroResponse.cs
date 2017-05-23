using System;
using System.Xml.Serialization;
using System.Collections.Generic;

namespace Top.Api.Response
{
    /// <summary>
    /// AlibabaInteractSensorGyroResponse.
    /// </summary>
    public class AlibabaInteractSensorGyroResponse : TopResponse
    {
        /// <summary>
        /// return=0 表示正确
        /// </summary>
        [XmlElement("result")]
        public string Result { get; set; }

    }
}
