using System;
using System.Xml.Serialization;

namespace Top.Api.Domain
{
    /// <summary>
    /// Materialitemswlbwmsstockpruductprocessingnotify Data Structure.
    /// </summary>
    [Serializable]
    public class Materialitemswlbwmsstockpruductprocessingnotify : TopObject
    {
        /// <summary>
        /// 商品列表
        /// </summary>
        [XmlElement("order_item")]
        public Top.Api.Domain.Orderitemwlbwmsstockpruductprocessingnotify OrderItem { get; set; }
    }
}
