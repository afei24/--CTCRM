using System;
using System.Xml.Serialization;

namespace Top.Api.Domain
{
    /// <summary>
    /// WlbWmsSkuInfoConfirm Data Structure.
    /// </summary>
    [Serializable]
    public class WlbWmsSkuInfoConfirm : TopObject
    {
        /// <summary>
        /// 条形码，多条码请用”；”分隔
        /// </summary>
        [XmlElement("bar_code")]
        public string BarCode { get; set; }

        /// <summary>
        /// 毛重，单位克
        /// </summary>
        [XmlElement("gross_weight")]
        public Nullable<long> GrossWeight { get; set; }

        /// <summary>
        /// 高度，单位厘米
        /// </summary>
        [XmlElement("height")]
        public Nullable<long> Height { get; set; }

        /// <summary>
        /// 后端商品ID
        /// </summary>
        [XmlElement("item_id")]
        public string ItemId { get; set; }

        /// <summary>
        /// 长度，单位厘米
        /// </summary>
        [XmlElement("length")]
        public Nullable<long> Length { get; set; }

        /// <summary>
        /// 净重，单位克
        /// </summary>
        [XmlElement("net_weight")]
        public Nullable<long> NetWeight { get; set; }

        /// <summary>
        /// 体积，单位立方厘米
        /// </summary>
        [XmlElement("volume")]
        public Nullable<long> Volume { get; set; }

        /// <summary>
        /// 宽度，单位厘米
        /// </summary>
        [XmlElement("width")]
        public Nullable<long> Width { get; set; }
    }
}
