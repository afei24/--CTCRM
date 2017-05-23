using System;
using System.Xml.Serialization;
using System.Collections.Generic;

namespace Top.Api.Response
{
    /// <summary>
    /// WlbImportsWaybillGetResponse.
    /// </summary>
    public class WlbImportsWaybillGetResponse : TopResponse
    {
        /// <summary>
        /// 电子面单链接地址
        /// </summary>
        [XmlElement("waybillurl")]
        public string Waybillurl { get; set; }

    }
}
