using System;
using System.Xml.Serialization;

namespace Top.Api.Domain
{
    /// <summary>
    /// CainiaoBillQueryOrderinfolist Data Structure.
    /// </summary>
    [Serializable]
    public class CainiaoBillQueryOrderinfolist : TopObject
    {
        /// <summary>
        /// 订单信息
        /// </summary>
        [XmlElement("order_info")]
        public Top.Api.Domain.CainiaoBillQueryOrderinfo OrderInfo { get; set; }
    }
}
