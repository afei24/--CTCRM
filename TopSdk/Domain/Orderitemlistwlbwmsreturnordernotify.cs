using System;
using System.Xml.Serialization;

namespace Top.Api.Domain
{
    /// <summary>
    /// Orderitemlistwlbwmsreturnordernotify Data Structure.
    /// </summary>
    [Serializable]
    public class Orderitemlistwlbwmsreturnordernotify : TopObject
    {
        /// <summary>
        /// 扩展字段
        /// </summary>
        [XmlElement("extend_fields")]
        public string ExtendFields { get; set; }

        /// <summary>
        /// 商品ID
        /// </summary>
        [XmlElement("item_id")]
        public string ItemId { get; set; }

        /// <summary>
        /// 商品名称
        /// </summary>
        [XmlElement("item_name")]
        public string ItemName { get; set; }

        /// <summary>
        /// 商品数量
        /// </summary>
        [XmlElement("item_quantity")]
        public Nullable<long> ItemQuantity { get; set; }

        /// <summary>
        /// 1
        /// </summary>
        [XmlElement("order_item")]
        public Top.Api.Domain.Orderitemwlbwmsreturnordernotify OrderItem { get; set; }

        /// <summary>
        /// 订单商品ID
        /// </summary>
        [XmlElement("order_item_id")]
        public string OrderItemId { get; set; }

        /// <summary>
        /// 交易编码
        /// </summary>
        [XmlElement("order_source_code")]
        public string OrderSourceCode { get; set; }

        /// <summary>
        /// 子交易编码
        /// </summary>
        [XmlElement("sub_source_code")]
        public string SubSourceCode { get; set; }
    }
}
