using System;
using System.Xml.Serialization;
using System.Collections.Generic;

namespace Top.Api.Response
{
    /// <summary>
    /// AlibabaInteractSensorFavoritesResponse.
    /// </summary>
    public class AlibabaInteractSensorFavoritesResponse : TopResponse
    {
        /// <summary>
        /// r=0
        /// </summary>
        [XmlElement("r")]
        public string R { get; set; }

    }
}
