using System;
using System.Xml.Serialization;

namespace Top.Api.Domain
{
    /// <summary>
    /// Receiverwlbwmsstockoutordernotify Data Structure.
    /// </summary>
    [Serializable]
    public class Receiverwlbwmsstockoutordernotify : TopObject
    {
        /// <summary>
        /// 收件方地址
        /// </summary>
        [XmlElement("receiver_address")]
        public string ReceiverAddress { get; set; }

        /// <summary>
        /// 收件方区县
        /// </summary>
        [XmlElement("receiver_area")]
        public string ReceiverArea { get; set; }

        /// <summary>
        /// 收件方城市
        /// </summary>
        [XmlElement("receiver_city")]
        public string ReceiverCity { get; set; }

        /// <summary>
        /// 退供场景ECP填充供应商编码，调拨出库单ECP填充调拨入仓库编码, B2B出库单填写分销商ID(无分销ID的null)
        /// </summary>
        [XmlElement("receiver_code")]
        public string ReceiverCode { get; set; }

        /// <summary>
        /// 收件方手机
        /// </summary>
        [XmlElement("receiver_mobile")]
        public string ReceiverMobile { get; set; }

        /// <summary>
        /// 收件方名称
        /// </summary>
        [XmlElement("receiver_name")]
        public string ReceiverName { get; set; }

        /// <summary>
        /// 收件方电话
        /// </summary>
        [XmlElement("receiver_phone")]
        public string ReceiverPhone { get; set; }

        /// <summary>
        /// 收件方省份
        /// </summary>
        [XmlElement("receiver_province")]
        public string ReceiverProvince { get; set; }

        /// <summary>
        /// 收件方邮编
        /// </summary>
        [XmlElement("receiver_zip_code")]
        public string ReceiverZipCode { get; set; }
    }
}
