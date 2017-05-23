using System;
using System.Xml.Serialization;

namespace Top.Api.Domain
{
    /// <summary>
    /// CainiaoConsignOutstockOutstockinfolist Data Structure.
    /// </summary>
    [Serializable]
    public class CainiaoConsignOutstockOutstockinfolist : TopObject
    {
        /// <summary>
        /// 信息
        /// </summary>
        [XmlElement("out_stock_info")]
        public Top.Api.Domain.CainiaoConsignOutstockOutstockinfo OutStockInfo { get; set; }
    }
}
