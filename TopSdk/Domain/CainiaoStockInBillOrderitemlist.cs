using System;
using System.Xml.Serialization;

namespace Top.Api.Domain
{
    /// <summary>
    /// CainiaoStockInBillOrderitemlist Data Structure.
    /// </summary>
    [Serializable]
    public class CainiaoStockInBillOrderitemlist : TopObject
    {
        /// <summary>
        /// 入库单信息
        /// </summary>
        [XmlElement("order_item")]
        public Top.Api.Domain.CainiaoStockInBillOrderitem OrderItem { get; set; }
    }
}
