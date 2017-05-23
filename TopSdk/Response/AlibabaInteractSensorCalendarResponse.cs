using System;
using System.Xml.Serialization;
using System.Collections.Generic;

namespace Top.Api.Response
{
    /// <summary>
    /// AlibabaInteractSensorCalendarResponse.
    /// </summary>
    public class AlibabaInteractSensorCalendarResponse : TopResponse
    {
        /// <summary>
        /// 返回结果
        /// </summary>
        [XmlElement("succ")]
        public bool Succ { get; set; }

    }
}
