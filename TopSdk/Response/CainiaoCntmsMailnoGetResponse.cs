using System;
using System.Xml.Serialization;
using System.Collections.Generic;

namespace Top.Api.Response
{
    /// <summary>
    /// CainiaoCntmsMailnoGetResponse.
    /// </summary>
    public class CainiaoCntmsMailnoGetResponse : TopResponse
    {
        /// <summary>
        /// 揽货商（分拨中心）编码
        /// </summary>
        [XmlElement("allocator_code")]
        public string AllocatorCode { get; set; }

        /// <summary>
        /// 揽货商（分拨中心）名称
        /// </summary>
        [XmlElement("allocator_name")]
        public string AllocatorName { get; set; }

        /// <summary>
        /// 物流商公司编码  （ERP在调用菜鸟发货接口时此字段赋值到tms_code, 调用淘宝“自己联系物流（线下物流）发货”时，做为company_code传入）
        /// </summary>
        [XmlElement("logistics_code")]
        public string LogisticsCode { get; set; }

        /// <summary>
        /// 物流商名称
        /// </summary>
        [XmlElement("logistics_name")]
        public string LogisticsName { get; set; }

        /// <summary>
        /// 面单号
        /// </summary>
        [XmlElement("mailno")]
        public string Mailno { get; set; }

        /// <summary>
        /// 集包地代码
        /// </summary>
        [XmlElement("package_center_code")]
        public string PackageCenterCode { get; set; }

        /// <summary>
        /// 集包地名称
        /// </summary>
        [XmlElement("package_center_name")]
        public string PackageCenterName { get; set; }

        /// <summary>
        /// 二级流向信息
        /// </summary>
        [XmlElement("sec_distribution")]
        public string SecDistribution { get; set; }

        /// <summary>
        /// 一级流向信息，大头笔
        /// </summary>
        [XmlElement("short_address")]
        public string ShortAddress { get; set; }

        /// <summary>
        /// 二级配送公司编码
        /// </summary>
        [XmlElement("tms_code")]
        public string TmsCode { get; set; }

        /// <summary>
        /// 二级配送公司名称
        /// </summary>
        [XmlElement("tms_name")]
        public string TmsName { get; set; }

    }
}
