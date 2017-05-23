using System;
using System.Xml.Serialization;

namespace Top.Api.Domain
{
    /// <summary>
    /// Orderitemwlbwmsstockoutordernotify Data Structure.
    /// </summary>
    [Serializable]
    public class Orderitemwlbwmsstockoutordernotify : TopObject
    {
        /// <summary>
        /// 批次号
        /// </summary>
        [XmlElement("batch_code")]
        public string BatchCode { get; set; }

        /// <summary>
        /// 到货日期
        /// </summary>
        [XmlElement("due_date")]
        public Nullable<DateTime> DueDate { get; set; }

        /// <summary>
        /// 订单商品拓展属性数据
        /// </summary>
        [XmlElement("extend_fields")]
        public string ExtendFields { get; set; }

        /// <summary>
        /// 库存类型
        /// </summary>
        [XmlElement("inventory_type")]
        public Nullable<long> InventoryType { get; set; }

        /// <summary>
        /// ERP商品ID
        /// </summary>
        [XmlElement("item_id")]
        public string ItemId { get; set; }

        /// <summary>
        /// 商品数量
        /// </summary>
        [XmlElement("item_quantity")]
        public Nullable<long> ItemQuantity { get; set; }

        /// <summary>
        /// ERP主键ID
        /// </summary>
        [XmlElement("order_item_id")]
        public string OrderItemId { get; set; }

        /// <summary>
        /// 生产编码，同一商品可能因商家不同有不同编码
        /// </summary>
        [XmlElement("produce_code")]
        public string ProduceCode { get; set; }

        /// <summary>
        /// 生产日期
        /// </summary>
        [XmlElement("produce_date")]
        public Nullable<DateTime> ProduceDate { get; set; }
    }
}
