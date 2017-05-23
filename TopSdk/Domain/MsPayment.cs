using System;
using System.Xml.Serialization;

namespace Top.Api.Domain
{
    /// <summary>
    /// MsPayment Data Structure.
    /// </summary>
    [Serializable]
    public class MsPayment : TopObject
    {
        /// <summary>
        /// 订金
        /// </summary>
        [XmlElement("price")]
        public string Price { get; set; }

        /// <summary>
        /// 参考价
        /// </summary>
        [XmlElement("reference_price")]
        public string ReferencePrice { get; set; }

        /// <summary>
        /// 尾款可抵扣金额
        /// </summary>
        [XmlElement("voucher_price")]
        public string VoucherPrice { get; set; }
    }
}
