using System;
using System.Xml.Serialization;

namespace Top.Api.Domain
{
    /// <summary>
    /// OrderWarehouseRouteGetItems Data Structure.
    /// </summary>
    [Serializable]
    public class OrderWarehouseRouteGetItems : TopObject
    {
        /// <summary>
        /// 商品信息
        /// </summary>
        [XmlElement("item")]
        public Top.Api.Domain.OrderWarehouseRouteGetItem Item { get; set; }
    }
}
