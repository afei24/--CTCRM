using System;
using System.Xml.Serialization;

namespace Top.Api.Domain
{
    /// <summary>
    /// CainiaoReturnBillInventoryitemlist Data Structure.
    /// </summary>
    [Serializable]
    public class CainiaoReturnBillInventoryitemlist : TopObject
    {
        /// <summary>
        /// 订单详情
        /// </summary>
        [XmlElement("inventory_item")]
        public Top.Api.Domain.CainiaoReturnBillInventoryitem InventoryItem { get; set; }
    }
}
