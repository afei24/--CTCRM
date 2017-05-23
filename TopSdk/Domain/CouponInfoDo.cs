using System;
using System.Xml.Serialization;

namespace Top.Api.Domain
{
    /// <summary>
    /// CouponInfoDo Data Structure.
    /// </summary>
    [Serializable]
    public class CouponInfoDo : TopObject
    {
        /// <summary>
        /// 优惠券面额
        /// </summary>
        [XmlElement("amount")]
        public long Amount { get; set; }

        /// <summary>
        /// 已经领用优惠券数量
        /// </summary>
        [XmlElement("apply_count")]
        public long ApplyCount { get; set; }

        /// <summary>
        /// 优惠券领用链接
        /// </summary>
        [XmlElement("apply_url")]
        public string ApplyUrl { get; set; }

        /// <summary>
        /// 优惠券结束时间
        /// </summary>
        [XmlElement("end_time")]
        public string EndTime { get; set; }

        /// <summary>
        /// 使用优惠券是否有前提条件
        /// </summary>
        [XmlElement("has_limit")]
        public bool HasLimit { get; set; }

        /// <summary>
        /// 优惠券id（uuid）
        /// </summary>
        [XmlElement("id")]
        public string Id { get; set; }

        /// <summary>
        /// 优惠券使用前提
        /// </summary>
        [XmlElement("start_fee")]
        public long StartFee { get; set; }

        /// <summary>
        /// 优惠券有效起始时间
        /// </summary>
        [XmlElement("start_time")]
        public string StartTime { get; set; }

        /// <summary>
        /// 优惠券是否领取，0未领取 1已领取
        /// </summary>
        [XmlElement("status")]
        public long Status { get; set; }

        /// <summary>
        /// 卖家优惠券code
        /// </summary>
        [XmlElement("template_code")]
        public long TemplateCode { get; set; }

        /// <summary>
        /// 买家优惠券id
        /// </summary>
        [XmlElement("template_id")]
        public long TemplateId { get; set; }

        /// <summary>
        /// 优惠券名字
        /// </summary>
        [XmlElement("title")]
        public string Title { get; set; }

        /// <summary>
        /// 优惠券总量
        /// </summary>
        [XmlElement("total_count")]
        public long TotalCount { get; set; }

        /// <summary>
        /// 优惠券类型：店铺优惠券或商品优惠券
        /// </summary>
        [XmlElement("type")]
        public long Type { get; set; }
    }
}
