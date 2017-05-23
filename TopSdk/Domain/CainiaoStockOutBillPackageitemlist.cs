using System;
using System.Xml.Serialization;

namespace Top.Api.Domain
{
    /// <summary>
    /// CainiaoStockOutBillPackageitemlist Data Structure.
    /// </summary>
    [Serializable]
    public class CainiaoStockOutBillPackageitemlist : TopObject
    {
        /// <summary>
        /// 1
        /// </summary>
        [XmlElement("package_item")]
        public Top.Api.Domain.CainiaoStockOutBillPackageitem PackageItem { get; set; }
    }
}
