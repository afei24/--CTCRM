using System;
using System.Xml.Serialization;
using System.Collections.Generic;

namespace Top.Api.Response
{
    /// <summary>
    /// AlibabaInteractSensorToastResponse.
    /// </summary>
    public class AlibabaInteractSensorToastResponse : TopResponse
    {
        /// <summary>
        /// result=0 表示成功
        /// </summary>
        [XmlElement("result")]
        public string Result { get; set; }

    }
}
