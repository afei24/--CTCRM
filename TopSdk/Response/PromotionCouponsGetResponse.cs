using System;
using System.Xml.Serialization;
using System.Collections.Generic;

namespace Top.Api.Response
{
    /// <summary>
    /// PromotionCouponsGetResponse.
    /// </summary>
    public class PromotionCouponsGetResponse : TopResponse
    {
        /// <summary>
        /// 优惠券列表
        /// </summary>
        [XmlArray("coupons")]
        [XmlArrayItem("coupon")]
        public List<Top.Api.Domain.Coupon> Coupons { get; set; }

        /// <summary>
        /// 查询的总数量
        /// </summary>
        [XmlElement("total_results")]
        public long TotalResults { get; set; }

    }
}
