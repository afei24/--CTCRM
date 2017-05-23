using System;
using System.Xml.Serialization;

namespace Top.Api.Domain
{
    /// <summary>
    /// CainiaoStockOutBillPackageitem Data Structure.
    /// </summary>
    [Serializable]
    public class CainiaoStockOutBillPackageitem : TopObject
    {
        /// <summary>
        /// 库存类型1 可销售库存 101残次品
        /// </summary>
        [XmlElement("inventory_type")]
        public long InventoryType { get; set; }

        /// <summary>
        /// ERP商品编码
        /// </summary>
        [XmlElement("item_code")]
        public string ItemCode { get; set; }

        /// <summary>
        /// 菜鸟商品编码
        /// </summary>
        [XmlElement("item_id")]
        public string ItemId { get; set; }

        /// <summary>
        /// 数量
        /// </summary>
        [XmlElement("item_qty")]
        public long ItemQty { get; set; }

        /// <summary>
        /// ERP订单明细ID
        /// </summary>
        [XmlElement("order_item_id")]
        public string OrderItemId { get; set; }
    }
}
