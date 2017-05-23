using System;
using System.Xml.Serialization;
using System.Collections.Generic;

namespace Top.Api.Domain
{
    /// <summary>
    /// CainiaoReturnBillOrderitem Data Structure.
    /// </summary>
    [Serializable]
    public class CainiaoReturnBillOrderitem : TopObject
    {
        /// <summary>
        /// 商品信息
        /// </summary>
        [XmlArray("inventory_item_list")]
        [XmlArrayItem("cainiao_return_bill_inventoryitemlist")]
        public List<Top.Api.Domain.CainiaoReturnBillInventoryitemlist> InventoryItemList { get; set; }

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
        /// 商品ID
        /// </summary>
        [XmlElement("order_item_id")]
        public string OrderItemId { get; set; }
    }
}
