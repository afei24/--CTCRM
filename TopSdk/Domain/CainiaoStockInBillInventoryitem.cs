using System;
using System.Xml.Serialization;

namespace Top.Api.Domain
{
    /// <summary>
    /// CainiaoStockInBillInventoryitem Data Structure.
    /// </summary>
    [Serializable]
    public class CainiaoStockInBillInventoryitem : TopObject
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
        /// 库存类型1 可销售库存 101残次品
        /// </summary>
        [XmlElement("inventory_type")]
        public long InventoryType { get; set; }

        /// <summary>
        /// 数量
        /// </summary>
        [XmlElement("item_qty")]
        public long ItemQty { get; set; }

        /// <summary>
        /// 生产地区，仓库采集的商品信息，供记录参考
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
