using System;
using System.Xml.Serialization;

namespace Top.Api.Domain
{
    /// <summary>
    /// Orderitemwlbwmsstockinordernotifywl Data Structure.
    /// </summary>
    [Serializable]
    public class Orderitemwlbwmsstockinordernotifywl : TopObject
    {
        /// <summary>
        /// 批次编号
        /// </summary>
        [XmlElement("batch_code")]
        public string BatchCode { get; set; }

        /// <summary>
        /// 失效日期
        /// </summary>
        [XmlElement("due_date")]
        public Nullable<DateTime> DueDate { get; set; }

        /// <summary>
        /// 订单商品拓展属性
        /// </summary>
        [XmlElement("extend_fields")]
        public string ExtendFields { get; set; }

        /// <summary>
        /// 库存类型 1 正品 101 残次 102 机损 103 箱损 201 冻结库存 301 在途库存
        /// </summary>
        [XmlElement("inventory_type")]
        public Nullable<long> InventoryType { get; set; }

        /// <summary>
        /// 后端商品ID
        /// </summary>
        [XmlElement("item_id")]
        public string ItemId { get; set; }

        /// <summary>
        /// 商品数量
        /// </summary>
        [XmlElement("item_quantity")]
        public Nullable<long> ItemQuantity { get; set; }

        /// <summary>
        /// 单据明细ID
        /// </summary>
        [XmlElement("order_item_id")]
        public string OrderItemId { get; set; }

        /// <summary>
        /// 生产批号
        /// </summary>
        [XmlElement("produce_code")]
        public string ProduceCode { get; set; }

        /// <summary>
        /// 生产日期
        /// </summary>
        [XmlElement("produce_date")]
        public Nullable<DateTime> ProduceDate { get; set; }

        /// <summary>
        /// 采购价格
        /// </summary>
        [XmlElement("purchase_price")]
        public Nullable<long> PurchasePrice { get; set; }
    }
}
