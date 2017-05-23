using System;
using System.Xml.Serialization;
using System.Collections.Generic;

namespace Top.Api.Domain
{
    /// <summary>
    /// CainiaoStockOutBillOrderitem Data Structure.
    /// </summary>
    [Serializable]
    public class CainiaoStockOutBillOrderitem : TopObject
    {
        /// <summary>
        /// 通知数量
        /// </summary>
        [XmlElement("apply_qty")]
        public long ApplyQty { get; set; }

        /// <summary>
        /// 商品属性列表
        /// </summary>
        [XmlArray("inventory_item_list")]
        [XmlArrayItem("cainiao_stock_out_bill_inventoryitemlist")]
        public List<Top.Api.Domain.CainiaoStockOutBillInventoryitemlist> InventoryItemList { get; set; }

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
        /// order_item_id
        /// </summary>
        [XmlElement("order_item_id")]
        public string OrderItemId { get; set; }
    }
}
