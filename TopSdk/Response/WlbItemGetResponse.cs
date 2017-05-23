using System;
using System.Xml.Serialization;
using System.Collections.Generic;

namespace Top.Api.Response
{
    /// <summary>
    /// WlbItemGetResponse.
    /// </summary>
    public class WlbItemGetResponse : TopResponse
    {
        /// <summary>
        /// 商品信息
        /// </summary>
        [XmlElement("item")]
        public Top.Api.Domain.WlbItem Item { get; set; }

    }
}
