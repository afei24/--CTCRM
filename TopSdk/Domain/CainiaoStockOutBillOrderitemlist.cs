using System;
using System.Xml.Serialization;

namespace Top.Api.Domain
{
    /// <summary>
    /// CainiaoStockOutBillOrderitemlist Data Structure.
    /// </summary>
    [Serializable]
    public class CainiaoStockOutBillOrderitemlist : TopObject
    {
        /// <summary>
        /// 订单商品信息
        /// </summary>
        [XmlElement("order_item")]
        public Top.Api.Domain.CainiaoStockOutBillOrderitem OrderItem { get; set; }
    }
}
