using System;
using System.Xml.Serialization;

namespace Top.Api.Domain
{
    /// <summary>
    /// CainiaoInventoryProfitlossOrderitem Data Structure.
    /// </summary>
    [Serializable]
    public class CainiaoInventoryProfitlossOrderitem : TopObject
    {
        /// <summary>
        /// 批次号
        /// </summary>
        [XmlElement("batch_code")]
        public string BatchCode { get; set; }

        /// <summary>
        /// 商品保质期信息，失效日期
        /// </summary>
        [XmlElement("due_date")]
        public string DueDate { get; set; }

        /// <summary>
        /// 库存类型 1 可销售库存（正品）  101 残次
        /// </summary>
        [XmlElement("inventory_type")]
        public string InventoryType { get; set; }

        /// <summary>
        /// 商家对商品的编码
        /// </summary>
        [XmlElement("item_code")]
        public string ItemCode { get; set; }

        /// <summary>
        /// 商品ID
        /// </summary>
        [XmlElement("item_id")]
        public string ItemId { get; set; }

        /// <summary>
        /// 商品数量
        /// </summary>
        [XmlElement("item_qty")]
        public string ItemQty { get; set; }

        /// <summary>
        /// 生产地区
        /// </summary>
        [XmlElement("produce_area")]
        public string ProduceArea { get; set; }

        /// <summary>
        /// 生产编码，同一商品可能因商家不同有不同编码
        /// </summary>
        [XmlElement("produce_code")]
        public string ProduceCode { get; set; }

        /// <summary>
        /// 商品保质期信息，生产日期
        /// </summary>
        [XmlElement("produce_date")]
        public string ProduceDate { get; set; }
    }
}
