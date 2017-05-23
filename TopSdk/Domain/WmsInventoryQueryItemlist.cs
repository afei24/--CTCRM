using System;
using System.Xml.Serialization;

namespace Top.Api.Domain
{
    /// <summary>
    /// WmsInventoryQueryItemlist Data Structure.
    /// </summary>
    [Serializable]
    public class WmsInventoryQueryItemlist : TopObject
    {
        /// <summary>
        /// 商品详情
        /// </summary>
        [XmlElement("item")]
        public Top.Api.Domain.WmsInventoryQueryItem Item { get; set; }
    }
}
