using System;
using System.Xml.Serialization;

namespace Top.Api.Domain
{
    /// <summary>
    /// LocOrder Data Structure.
    /// </summary>
    [Serializable]
    public class LocOrder : TopObject
    {
        /// <summary>
        /// 物流承运商
        /// </summary>
        [XmlElement("carrier")]
        public string Carrier { get; set; }

        /// <summary>
        /// 费用币种
        /// </summary>
        [XmlElement("currency")]
        public string Currency { get; set; }

        /// <summary>
        /// 关税
        /// </summary>
        [XmlElement("customs_fee")]
        public long CustomsFee { get; set; }

        /// <summary>
        /// 物流订单号
        /// </summary>
        [XmlElement("order_code")]
        public string OrderCode { get; set; }

        /// <summary>
        /// 运费
        /// </summary>
        [XmlElement("shipping_fee")]
        public long ShippingFee { get; set; }

        /// <summary>
        /// 物流订单状态编码
        /// </summary>
        [XmlElement("status_code")]
        public string StatusCode { get; set; }

        /// <summary>
        /// 订单状态中文描述
        /// </summary>
        [XmlElement("status_code_desc")]
        public string StatusCodeDesc { get; set; }

        /// <summary>
        /// 物流运单号
        /// </summary>
        [XmlElement("tracking_no")]
        public string TrackingNo { get; set; }

        /// <summary>
        /// 交易订单号
        /// </summary>
        [XmlElement("trade_id")]
        public long TradeId { get; set; }

        /// <summary>
        /// 重量
        /// </summary>
        [XmlElement("weight")]
        public long Weight { get; set; }

        /// <summary>
        /// 重量单位
        /// </summary>
        [XmlElement("weight_unit")]
        public string WeightUnit { get; set; }
    }
}
