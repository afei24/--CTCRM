using System;
using System.Xml.Serialization;
using System.Collections.Generic;

namespace Top.Api.Domain
{
    /// <summary>
    /// DeliveryTime Data Structure.
    /// </summary>
    [Serializable]
    public class DeliveryTime : TopObject
    {
        /// <summary>
        /// 商品级别设置的发货时间。设置了商品级别的发货时间，相对发货时间，则填写相对发货时间的天数（大于3）；绝对发货时间，则填写yyyy-mm-dd格式，如2013-11-11
        /// </summary>
        [XmlElement("delivery_time")]
        public string DeliveryTime_ { get; set; }

        /// <summary>
        /// 发货时间类型：绝对发货时间或者相对发货时间
        /// </summary>
        [XmlElement("delivery_time_type")]
        public string DeliveryTimeType { get; set; }

        /// <summary>
        /// 设置是否使用发货时间，商品级别，sku级别
        /// </summary>
        [XmlElement("need_delivery_time")]
        public string NeedDeliveryTime { get; set; }

        /// <summary>
        /// 商品自动退款参数
        /// </summary>
        [XmlElement("onsale_auto_refund_ratio")]
        public long OnsaleAutoRefundRatio { get; set; }

        /// <summary>
        /// 发货时间列表
        /// </summary>
        [XmlArray("skus_delivery_time_list")]
        [XmlArrayItem("skus_delivery_time")]
        public List<Top.Api.Domain.SkusDeliveryTime> SkusDeliveryTimeList { get; set; }
    }
}
