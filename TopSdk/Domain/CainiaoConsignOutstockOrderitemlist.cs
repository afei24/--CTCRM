using System;
using System.Xml.Serialization;

namespace Top.Api.Domain
{
    /// <summary>
    /// CainiaoConsignOutstockOrderitemlist Data Structure.
    /// </summary>
    [Serializable]
    public class CainiaoConsignOutstockOrderitemlist : TopObject
    {
        /// <summary>
        /// 订单详情
        /// </summary>
        [XmlElement("order_item")]
        public Top.Api.Domain.CainiaoConsignOutstockOrderitem OrderItem { get; set; }
    }
}
