using System;
using System.Xml.Serialization;

namespace Top.Api.Domain
{
    /// <summary>
    /// Orderitemwlbwmsstockpruductprocessingnotify Data Structure.
    /// </summary>
    [Serializable]
    public class Orderitemwlbwmsstockpruductprocessingnotify : TopObject
    {
        /// <summary>
        /// 商品失效日期
        /// </summary>
        [XmlElement("due_date")]
        public Nullable<DateTime> DueDate { get; set; }

        /// <summary>
        /// 拓展属性
        /// </summary>
        [XmlElement("extend_fields")]
        public string ExtendFields { get; set; }

        /// <summary>
        /// 库存类型 1 正品 101 残次 102 机损 103 箱损 201 冻结库存 301 在途库存
        /// </summary>
        [XmlElement("inventory_type")]
        public Nullable<long> InventoryType { get; set; }

        /// <summary>
        /// 后端商品ID，特指原料
        /// </summary>
        [XmlElement("item_id")]
        public string ItemId { get; set; }

        /// <summary>
        /// ERP明细行号
        /// </summary>
        [XmlElement("order_item_id")]
        public string OrderItemId { get; set; }

        /// <summary>
        /// 计划数量
        /// </summary>
        [XmlElement("plan_qty")]
        public Nullable<long> PlanQty { get; set; }

        /// <summary>
        /// 商品生产批号
        /// </summary>
        [XmlElement("produce_code")]
        public string ProduceCode { get; set; }

        /// <summary>
        /// 商品生产日期
        /// </summary>
        [XmlElement("produce_date")]
        public Nullable<DateTime> ProduceDate { get; set; }

        /// <summary>
        /// 配比数量
        /// </summary>
        [XmlElement("ratio_qty")]
        public Nullable<long> RatioQty { get; set; }

        /// <summary>
        /// 备注
        /// </summary>
        [XmlElement("remark")]
        public string Remark { get; set; }
    }
}
