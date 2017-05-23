using System;
using System.Xml.Serialization;

namespace Top.Api.Domain
{
    /// <summary>
    /// CainiaoStockOutBillPackageinfolist Data Structure.
    /// </summary>
    [Serializable]
    public class CainiaoStockOutBillPackageinfolist : TopObject
    {
        /// <summary>
        /// 包裹信息
        /// </summary>
        [XmlElement("package_info")]
        public Top.Api.Domain.CainiaoStockOutBillPackageinfo PackageInfo { get; set; }
    }
}
