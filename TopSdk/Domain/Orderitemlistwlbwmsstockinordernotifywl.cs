using System;
using System.Xml.Serialization;

namespace Top.Api.Domain
{
    /// <summary>
    /// Orderitemlistwlbwmsstockinordernotifywl Data Structure.
    /// </summary>
    [Serializable]
    public class Orderitemlistwlbwmsstockinordernotifywl : TopObject
    {
        /// <summary>
        /// 订单商品
        /// </summary>
        [XmlElement("order_item")]
        public Top.Api.Domain.Orderitemwlbwmsstockinordernotifywl OrderItem { get; set; }
    }
}
