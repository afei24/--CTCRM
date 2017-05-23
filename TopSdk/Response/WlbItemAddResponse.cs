using System;
using System.Xml.Serialization;
using System.Collections.Generic;

namespace Top.Api.Response
{
    /// <summary>
    /// WlbItemAddResponse.
    /// </summary>
    public class WlbItemAddResponse : TopResponse
    {
        /// <summary>
        /// 新增的商品
        /// </summary>
        [XmlElement("item_id")]
        public string ItemId { get; set; }

    }
}
