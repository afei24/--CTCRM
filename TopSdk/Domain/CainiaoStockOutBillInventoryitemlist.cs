using System;
using System.Xml.Serialization;

namespace Top.Api.Domain
{
    /// <summary>
    /// CainiaoStockOutBillInventoryitemlist Data Structure.
    /// </summary>
    [Serializable]
    public class CainiaoStockOutBillInventoryitemlist : TopObject
    {
        /// <summary>
        /// 商品属性
        /// </summary>
        [XmlElement("inventory_item")]
        public Top.Api.Domain.CainiaoStockOutBillInventoryitem InventoryItem { get; set; }
    }
}
