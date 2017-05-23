using System;
using System.Xml.Serialization;

namespace Top.Api.Domain
{
    /// <summary>
    /// Orderitemlistwlbwmsstockoutordernotify Data Structure.
    /// </summary>
    [Serializable]
    public class Orderitemlistwlbwmsstockoutordernotify : TopObject
    {
        /// <summary>
        /// 订单商品信息
        /// </summary>
        [XmlElement("order_item")]
        public Top.Api.Domain.Orderitemwlbwmsstockoutordernotify OrderItem { get; set; }
    }
}
