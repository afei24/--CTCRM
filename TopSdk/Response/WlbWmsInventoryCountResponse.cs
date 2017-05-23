using System;
using System.Xml.Serialization;
using System.Collections.Generic;

namespace Top.Api.Response
{
    /// <summary>
    /// WlbWmsInventoryCountResponse.
    /// </summary>
    public class WlbWmsInventoryCountResponse : TopResponse
    {
        /// <summary>
        /// result
        /// </summary>
        [XmlElement("result")]
        public Top.Api.Domain.WlbWmsInventoryCountResp Result { get; set; }

    }
}
