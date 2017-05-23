using System;
using System.Xml.Serialization;
using System.Collections.Generic;

namespace Top.Api.Domain
{
    /// <summary>
    /// CainiaoStockInBillOrderitem Data Structure.
    /// </summary>
    [Serializable]
    public class CainiaoStockInBillOrderitem : TopObject
    {
        /// <summary>
        /// 通知数量
        /// </summary>
        [XmlElement("apply_qty")]
        public long ApplyQty { get; set; }

        /// <summary>
        /// 仓库收货商品信息
        /// </summary>
        [XmlArray("inventory_item_list")]
        [XmlArrayItem("cainiao_stock_in_bill_inventoryitemlist")]
        public List<Top.Api.Domain.CainiaoStockInBillInventoryitemlist> InventoryItemList { get; set; }

        /// <summary>
        /// 商家编码
        /// </summary>
        [XmlElement("item_code")]
        public string ItemCode { get; set; }

        /// <summary>
        /// 商品ID
        /// </summary>
        [XmlElement("item_id")]
        public string ItemId { get; set; }

        /// <summary>
        /// ERP订单明细ID
        /// </summary>
        [XmlElement("order_item_id")]
        public string OrderItemId { get; set; }
    }
}
