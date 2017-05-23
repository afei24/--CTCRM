using System;
using System.Xml.Serialization;

namespace Top.Api.Domain
{
    /// <summary>
    /// Productitemswlbwmsstockpruductprocessingnotify Data Structure.
    /// </summary>
    [Serializable]
    public class Productitemswlbwmsstockpruductprocessingnotify : TopObject
    {
        /// <summary>
        /// 商品列表
        /// </summary>
        [XmlElement("order_item")]
        public Top.Api.Domain.Orderitemwlbwmsstockpruductprocessingnotify OrderItem { get; set; }
    }
}
