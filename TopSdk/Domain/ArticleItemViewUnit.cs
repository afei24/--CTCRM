using System;
using System.Xml.Serialization;

namespace Top.Api.Domain
{
    /// <summary>
    /// ArticleItemViewUnit Data Structure.
    /// </summary>
    [Serializable]
    public class ArticleItemViewUnit : TopObject
    {
        /// <summary>
        /// 需要支付的价格，单位：元
        /// </summary>
        [XmlElement("actual_price")]
        public string ActualPrice { get; set; }

        /// <summary>
        /// 用户是否可以购买
        /// </summary>
        [XmlElement("can_sub")]
        public bool CanSub { get; set; }

        /// <summary>
        /// 周期数，如1，3，6，12。对于周期型和周期计量型返回。
        /// </summary>
        [XmlElement("cyc_num")]
        public long CycNum { get; set; }

        /// <summary>
        /// 1-年，2-月，3-日。对于周期型和周期计量型返回。
        /// </summary>
        [XmlElement("cyc_unit")]
        public long CycUnit { get; set; }

        /// <summary>
        /// 错误码
        /// </summary>
        [XmlElement("error_code")]
        public string ErrorCode { get; set; }

        /// <summary>
        /// 错误文案
        /// </summary>
        [XmlElement("error_msg")]
        public string ErrorMsg { get; set; }

        /// <summary>
        /// 收费项目code
        /// </summary>
        [XmlElement("item_code")]
        public string ItemCode { get; set; }

        /// <summary>
        /// 收费项目名称
        /// </summary>
        [XmlElement("item_name")]
        public string ItemName { get; set; }

        /// <summary>
        /// 原价，单位：元
        /// </summary>
        [XmlElement("origin_price")]
        public string OriginPrice { get; set; }

        /// <summary>
        /// 优惠，单位：元
        /// </summary>
        [XmlElement("prom_price")]
        public string PromPrice { get; set; }

        /// <summary>
        /// 数量。对于周期计量型返回计量数。
        /// </summary>
        [XmlElement("quantity")]
        public long Quantity { get; set; }
    }
}
