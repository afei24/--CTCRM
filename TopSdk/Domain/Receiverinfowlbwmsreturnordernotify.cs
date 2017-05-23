using System;
using System.Xml.Serialization;

namespace Top.Api.Domain
{
    /// <summary>
    /// Receiverinfowlbwmsreturnordernotify Data Structure.
    /// </summary>
    [Serializable]
    public class Receiverinfowlbwmsreturnordernotify : TopObject
    {
        /// <summary>
        /// 收件人地址
        /// </summary>
        [XmlElement("receiver_address")]
        public string ReceiverAddress { get; set; }

        /// <summary>
        /// 收件人区县
        /// </summary>
        [XmlElement("receiver_area")]
        public string ReceiverArea { get; set; }

        /// <summary>
        /// 收件人城市
        /// </summary>
        [XmlElement("receiver_city")]
        public string ReceiverCity { get; set; }

        /// <summary>
        /// 收件人手机，手机与电话二选一传入
        /// </summary>
        [XmlElement("receiver_mobile")]
        public string ReceiverMobile { get; set; }

        /// <summary>
        /// 收件人姓名
        /// </summary>
        [XmlElement("receiver_name")]
        public string ReceiverName { get; set; }

        /// <summary>
        /// 收件人名称
        /// </summary>
        [XmlElement("receiver_nick")]
        public string ReceiverNick { get; set; }

        /// <summary>
        /// 收件人电话
        /// </summary>
        [XmlElement("receiver_phone")]
        public string ReceiverPhone { get; set; }

        /// <summary>
        /// 收件人省份
        /// </summary>
        [XmlElement("receiver_province")]
        public string ReceiverProvince { get; set; }

        /// <summary>
        /// 收件人镇村
        /// </summary>
        [XmlElement("receiver_town")]
        public string ReceiverTown { get; set; }

        /// <summary>
        /// 收件人邮编
        /// </summary>
        [XmlElement("receiver_zip_code")]
        public string ReceiverZipCode { get; set; }
    }
}
