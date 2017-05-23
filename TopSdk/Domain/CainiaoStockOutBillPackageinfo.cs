using System;
using System.Xml.Serialization;
using System.Collections.Generic;

namespace Top.Api.Domain
{
    /// <summary>
    /// CainiaoStockOutBillPackageinfo Data Structure.
    /// </summary>
    [Serializable]
    public class CainiaoStockOutBillPackageinfo : TopObject
    {
        /// <summary>
        /// 包裹号
        /// </summary>
        [XmlElement("package_code")]
        public string PackageCode { get; set; }

        /// <summary>
        /// 包裹高度，单位：毫米
        /// </summary>
        [XmlElement("package_height")]
        public long PackageHeight { get; set; }

        /// <summary>
        /// 包裹里面的商品信息列表
        /// </summary>
        [XmlArray("package_item_list")]
        [XmlArrayItem("cainiao_stock_out_bill_packageitemlist")]
        public List<Top.Api.Domain.CainiaoStockOutBillPackageitemlist> PackageItemList { get; set; }

        /// <summary>
        /// 包裹长度，单位：毫米
        /// </summary>
        [XmlElement("package_length")]
        public long PackageLength { get; set; }

        /// <summary>
        /// 包裹质量，单位：克
        /// </summary>
        [XmlElement("package_weight")]
        public long PackageWeight { get; set; }

        /// <summary>
        /// 包裹宽度,单位：毫米
        /// </summary>
        [XmlElement("package_width")]
        public long PackageWidth { get; set; }

        /// <summary>
        /// 快递公司服务编码
        /// </summary>
        [XmlElement("tms_code")]
        public string TmsCode { get; set; }

        /// <summary>
        /// 运单编码
        /// </summary>
        [XmlElement("tms_order_code")]
        public string TmsOrderCode { get; set; }
    }
}
