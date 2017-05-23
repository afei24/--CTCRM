using System;
using System.Xml.Serialization;

namespace Top.Api.Domain
{
    /// <summary>
    /// CainiaoInventoryProfitlossOrderitemlist Data Structure.
    /// </summary>
    [Serializable]
    public class CainiaoInventoryProfitlossOrderitemlist : TopObject
    {
        /// <summary>
        /// 损益详情
        /// </summary>
        [XmlElement("order_item")]
        public Top.Api.Domain.CainiaoInventoryProfitlossOrderitem OrderItem { get; set; }
    }
}
