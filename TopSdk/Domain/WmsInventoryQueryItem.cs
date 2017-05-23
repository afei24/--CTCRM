using System;
using System.Xml.Serialization;

namespace Top.Api.Domain
{
    /// <summary>
    /// WmsInventoryQueryItem Data Structure.
    /// </summary>
    [Serializable]
    public class WmsInventoryQueryItem : TopObject
    {
        /// <summary>
        /// 库存批次号，type=2时字段有返回值。
        /// </summary>
        [XmlElement("batch_code")]
        public string BatchCode { get; set; }

        /// <summary>
        /// 渠道编码，type=3时字段有返回值。（TB 淘系，OTHERS 其他）
        /// </summary>
        [XmlElement("channel_code")]
        public string ChannelCode { get; set; }

        /// <summary>
        /// 失效日期，type=2时字段有返回值。
        /// </summary>
        [XmlElement("due_date")]
        public string DueDate { get; set; }

        /// <summary>
        /// 库存类型(1 正品 101 残次 102 机损 103 箱损 201 冻结库存 301 在途库存 )
        /// </summary>
        [XmlElement("inventory_type")]
        public long InventoryType { get; set; }

        /// <summary>
        /// 商品ID
        /// </summary>
        [XmlElement("item_id")]
        public string ItemId { get; set; }

        /// <summary>
        /// 锁库存数量
        /// </summary>
        [XmlElement("lock_quantity")]
        public long LockQuantity { get; set; }

        /// <summary>
        /// 生产日期，type=2时字段有返回值
        /// </summary>
        [XmlElement("produce_date")]
        public string ProduceDate { get; set; }

        /// <summary>
        /// 库存数量
        /// </summary>
        [XmlElement("quantity")]
        public long Quantity { get; set; }

        /// <summary>
        /// 仓库编码
        /// </summary>
        [XmlElement("store_code")]
        public string StoreCode { get; set; }
    }
}
