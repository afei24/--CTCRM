using System;
using System.Xml.Serialization;

namespace Top.Api.Domain
{
    /// <summary>
    /// Senderinfowlbwmsstockinordernotifywl Data Structure.
    /// </summary>
    [Serializable]
    public class Senderinfowlbwmsstockinordernotifywl : TopObject
    {
        /// <summary>
        /// 发件方地址
        /// </summary>
        [XmlElement("sender_address")]
        public string SenderAddress { get; set; }

        /// <summary>
        /// 发件方区县
        /// </summary>
        [XmlElement("sender_area")]
        public string SenderArea { get; set; }

        /// <summary>
        /// 发件方城市
        /// </summary>
        [XmlElement("sender_city")]
        public string SenderCity { get; set; }

        /// <summary>
        /// 发件方编码，销退场景下填写买家nick，旺旺号等； 调拨场景下填写调拨出仓库编码；
        /// </summary>
        [XmlElement("sender_code")]
        public string SenderCode { get; set; }

        /// <summary>
        /// 发件方手机
        /// </summary>
        [XmlElement("sender_mobile")]
        public string SenderMobile { get; set; }

        /// <summary>
        /// 发件方名称，销退场景下填写买家名称； 调拨场景下填写调拨出仓库名称；
        /// </summary>
        [XmlElement("sender_name")]
        public string SenderName { get; set; }

        /// <summary>
        /// 发件方电话
        /// </summary>
        [XmlElement("sender_phone")]
        public string SenderPhone { get; set; }

        /// <summary>
        /// 发件方省份
        /// </summary>
        [XmlElement("sender_province")]
        public string SenderProvince { get; set; }

        /// <summary>
        /// 发件方镇
        /// </summary>
        [XmlElement("sender_town")]
        public string SenderTown { get; set; }

        /// <summary>
        /// 发件方邮编
        /// </summary>
        [XmlElement("sender_zip_code")]
        public string SenderZipCode { get; set; }
    }
}
