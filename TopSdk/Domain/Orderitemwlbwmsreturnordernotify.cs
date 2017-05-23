using System;
using System.Xml.Serialization;

namespace Top.Api.Domain
{
    /// <summary>
    /// Orderitemwlbwmsreturnordernotify Data Structure.
    /// </summary>
    [Serializable]
    public class Orderitemwlbwmsreturnordernotify : TopObject
    {
        /// <summary>
        /// 扩展属性, key-value结构，格式要求： 以英文分号“;”分隔每组key-value，以英文冒号“:”分隔key与value。如果value中带有分号，需要转成下划线“_”，如果带有冒号，需要转成中划线“-”
        /// </summary>
        [XmlElement("extend_fields")]
        public string ExtendFields { get; set; }

        /// <summary>
        /// 后端商品ID
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
        /// 平台交易订单编码,淘系交易请传入交易单号
        /// </summary>
        [XmlElement("order_item_id")]
        public string OrderItemId { get; set; }

        /// <summary>
        /// 平台交易订单编码,淘系交易请传入交易单号
        /// </summary>
        [XmlElement("order_source_code")]
        public string OrderSourceCode { get; set; }

        /// <summary>
        /// 平台交易子订单编码，交易单号传入，子交易编号必填
        /// </summary>
        [XmlElement("sub_source_code")]
        public string SubSourceCode { get; set; }
    }
}
