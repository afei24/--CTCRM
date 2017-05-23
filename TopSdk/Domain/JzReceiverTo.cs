using System;
using System.Xml.Serialization;

namespace Top.Api.Domain
{
    /// <summary>
    /// JzReceiverTo Data Structure.
    /// </summary>
    [Serializable]
    public class JzReceiverTo : TopObject
    {
        /// <summary>
        /// 详细地址
        /// </summary>
        [XmlElement("address")]
        public string Address { get; set; }

        /// <summary>
        /// 市
        /// </summary>
        [XmlElement("city")]
        public string City { get; set; }

        /// <summary>
        /// 收货人名称
        /// </summary>
        [XmlElement("contact_name")]
        public string ContactName { get; set; }

        /// <summary>
        /// 国家
        /// </summary>
        [XmlElement("country")]
        public string Country { get; set; }

        /// <summary>
        /// 区
        /// </summary>
        [XmlElement("district")]
        public string District { get; set; }

        /// <summary>
        /// 手机号
        /// </summary>
        [XmlElement("mobile_phone")]
        public string MobilePhone { get; set; }

        /// <summary>
        /// 省
        /// </summary>
        [XmlElement("province")]
        public string Province { get; set; }

        /// <summary>
        /// 街道
        /// </summary>
        [XmlElement("street")]
        public string Street { get; set; }

        /// <summary>
        /// 座机号
        /// </summary>
        [XmlElement("tele_phone")]
        public string TelePhone { get; set; }

        /// <summary>
        /// 邮编
        /// </summary>
        [XmlElement("zip_code")]
        public string ZipCode { get; set; }
    }
}
