using System;
using System.Xml.Serialization;
using System.Collections.Generic;

namespace Top.Api.Response
{
    /// <summary>
    /// WlbWmsOrderStatusUploadResponse.
    /// </summary>
    public class WlbWmsOrderStatusUploadResponse : TopResponse
    {
        /// <summary>
        /// 出参
        /// </summary>
        [XmlElement("result")]
        public Top.Api.Domain.WlbWmsOrderStatusUploadResp Result { get; set; }

    }
}
