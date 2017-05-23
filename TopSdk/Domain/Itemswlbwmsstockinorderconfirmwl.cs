using System;
using System.Xml.Serialization;

namespace Top.Api.Domain
{
    /// <summary>
    /// Itemswlbwmsstockinorderconfirmwl Data Structure.
    /// </summary>
    [Serializable]
    public class Itemswlbwmsstockinorderconfirmwl : TopObject
    {
        /// <summary>
        /// WMS批次号
        /// </summary>
        [XmlElement("batch_code")]
        public string BatchCode { get; set; }

        /// <summary>
        /// 商品过期日期YYYY-MM-DD
        /// </summary>
        [XmlElement("due_date")]
        public string DueDate { get; set; }

        /// <summary>
        /// 库存类型 1 正品，101 残次，102 机损，103 箱损，201 冻结库存，301 在途库存
        /// </summary>
        [XmlElement("inventory_type")]
        public Nullable<long> InventoryType { get; set; }

        /// <summary>
        /// 商品编码
        /// </summary>
        [XmlElement("item_code")]
        public string ItemCode { get; set; }

        /// <summary>
        /// 商品ID
        /// </summary>
        [XmlElement("item_id")]
        public string ItemId { get; set; }

        /// <summary>
        /// 生产批号
        /// </summary>
        [XmlElement("produce_code")]
        public string ProduceCode { get; set; }

        /// <summary>
        /// 商品生产日期 YYYY-MM-DD
        /// </summary>
        [XmlElement("produce_date")]
        public string ProduceDate { get; set; }

        /// <summary>
        /// 入库数量
        /// </summary>
        [XmlElement("quantity")]
        public Nullable<long> Quantity { get; set; }
    }
}
