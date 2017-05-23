using System;
using System.Xml.Serialization;

namespace Top.Api.Domain
{
    /// <summary>
    /// CainiaoStockInBillInventoryitemlist Data Structure.
    /// </summary>
    [Serializable]
    public class CainiaoStockInBillInventoryitemlist : TopObject
    {
        /// <summary>
        /// 仓库收货商品信息
        /// </summary>
        [XmlElement("inventory_item")]
        public Top.Api.Domain.CainiaoStockInBillInventoryitem InventoryItem { get; set; }
    }
}
