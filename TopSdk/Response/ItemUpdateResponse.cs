using System;
using System.Xml.Serialization;
using System.Collections.Generic;

namespace Top.Api.Response
{
    /// <summary>
    /// ItemUpdateResponse.
    /// </summary>
    public class ItemUpdateResponse : TopResponse
    {
        /// <summary>
        /// 商品结构里的num_iid，modified
        /// </summary>
        [XmlElement("item")]
        public Top.Api.Domain.Item Item { get; set; }

    }
}
