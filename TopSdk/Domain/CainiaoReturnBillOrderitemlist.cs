using System;
using System.Xml.Serialization;

namespace Top.Api.Domain
{
    /// <summary>
    /// CainiaoReturnBillOrderitemlist Data Structure.
    /// </summary>
    [Serializable]
    public class CainiaoReturnBillOrderitemlist : TopObject
    {
        /// <summary>
        /// 订单商品信息
        /// </summary>
        [XmlElement("order_item")]
        public Top.Api.Domain.CainiaoReturnBillOrderitem OrderItem { get; set; }
    }
}
