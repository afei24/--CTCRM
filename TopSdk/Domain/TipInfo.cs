using System;
using System.Xml.Serialization;

namespace Top.Api.Domain
{
    /// <summary>
    /// TipInfo Data Structure.
    /// </summary>
    [Serializable]
    public class TipInfo : TopObject
    {
        /// <summary>
        /// 错误码
        /// </summary>
        [XmlElement("error_code")]
        public string ErrorCode { get; set; }

        /// <summary>
        /// 错误信息
        /// </summary>
        [XmlElement("errro_message")]
        public string ErrroMessage { get; set; }

        /// <summary>
        /// 返回信息
        /// </summary>
        [XmlElement("info")]
        public string Info { get; set; }

        /// <summary>
        /// 商品id
        /// </summary>
        [XmlElement("sc_item_id")]
        public string ScItemId { get; set; }

        /// <summary>
        /// 子订单编号
        /// </summary>
        [XmlElement("sub_order_id")]
        public string SubOrderId { get; set; }
    }
}
