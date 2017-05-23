using System;
using System.Xml.Serialization;
using System.Collections.Generic;

namespace Top.Api.Response
{
    /// <summary>
    /// ItemSchemaIncrementUpdateResponse.
    /// </summary>
    public class ItemSchemaIncrementUpdateResponse : TopResponse
    {
        /// <summary>
        /// 商品id
        /// </summary>
        [XmlElement("item_id")]
        public string ItemId { get; set; }

    }
}
