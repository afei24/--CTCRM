using System;
using System.Xml.Serialization;

namespace Top.Api.Domain
{
    /// <summary>
    /// ReciverAddressDo Data Structure.
    /// </summary>
    [Serializable]
    public class ReciverAddressDo : TopObject
    {
        /// <summary>
        /// 市级别
        /// </summary>
        [XmlElement("city")]
        public string City { get; set; }

        /// <summary>
        /// 国级别
        /// </summary>
        [XmlElement("country")]
        public string Country { get; set; }

        /// <summary>
        /// 详细地址
        /// </summary>
        [XmlElement("detail_address")]
        public string DetailAddress { get; set; }

        /// <summary>
        /// 区、县级别
        /// </summary>
        [XmlElement("district")]
        public string District { get; set; }

        /// <summary>
        /// 省级别
        /// </summary>
        [XmlElement("province")]
        public string Province { get; set; }

        /// <summary>
        /// 街道
        /// </summary>
        [XmlElement("street")]
        public string Street { get; set; }
    }
}
