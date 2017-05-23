using System;
using System.Xml.Serialization;
using System.Collections.Generic;

namespace Top.Api.Response
{
    /// <summary>
    /// WlbWmsInventoryLackUploadResponse.
    /// </summary>
    public class WlbWmsInventoryLackUploadResponse : TopResponse
    {
        /// <summary>
        /// 缺货回告
        /// </summary>
        [XmlElement("result")]
        public Top.Api.Domain.WlbWmsInventoryLackUploadResp Result { get; set; }

    }
}
