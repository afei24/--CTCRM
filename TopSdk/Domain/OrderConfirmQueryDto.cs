using System;
using System.Xml.Serialization;

namespace Top.Api.Domain
{
    /// <summary>
    /// OrderConfirmQueryDto Data Structure.
    /// </summary>
    [Serializable]
    public class OrderConfirmQueryDto : TopObject
    {
        /// <summary>
        /// APPKEY，必填
        /// </summary>
        [XmlElement("app_key")]
        public string AppKey { get; set; }

        /// <summary>
        /// 周期数量，必填
        /// </summary>
        [XmlElement("cyc_num")]
        public string CycNum { get; set; }

        /// <summary>
        /// 周期单位(必选 数值1:年 2:月， 3：天)，必填
        /// </summary>
        [XmlElement("cyc_unit")]
        public string CycUnit { get; set; }

        /// <summary>
        /// 设备类型，目前只支持PC，可选
        /// </summary>
        [XmlElement("device_type")]
        public string DeviceType { get; set; }

        /// <summary>
        /// 内购服务的规格CODE，必填
        /// </summary>
        [XmlElement("item_code")]
        public string ItemCode { get; set; }

        /// <summary>
        /// 使用该参数完成查询订单等操作，可选
        /// </summary>
        [XmlElement("out_trade_code")]
        public string OutTradeCode { get; set; }

        /// <summary>
        /// 计量型服务的数量，如果是计量型内购服务，则必填
        /// </summary>
        [XmlElement("quantity")]
        public string Quantity { get; set; }
    }
}
