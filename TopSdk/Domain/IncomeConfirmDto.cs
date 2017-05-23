using System;
using System.Xml.Serialization;

namespace Top.Api.Domain
{
    /// <summary>
    /// IncomeConfirmDto Data Structure.
    /// </summary>
    [Serializable]
    public class IncomeConfirmDto : TopObject
    {
        /// <summary>
        /// appkey
        /// </summary>
        [XmlElement("appkey")]
        public string Appkey { get; set; }

        /// <summary>
        /// 确认扩展信息
        /// </summary>
        [XmlElement("extend")]
        public string Extend { get; set; }

        /// <summary>
        /// 确认金额（单位：分）
        /// </summary>
        [XmlElement("fee")]
        public Nullable<long> Fee { get; set; }

        /// <summary>
        /// 卖家nick
        /// </summary>
        [XmlElement("nick")]
        public string Nick { get; set; }

        /// <summary>
        /// 服务市场有效订单ID
        /// </summary>
        [XmlElement("order_id")]
        public Nullable<long> OrderId { get; set; }

        /// <summary>
        /// 外部确认账单ID
        /// </summary>
        [XmlElement("out_confirm_id")]
        public string OutConfirmId { get; set; }

        /// <summary>
        /// 外部订单ID
        /// </summary>
        [XmlElement("out_order_id")]
        public string OutOrderId { get; set; }
    }
}
