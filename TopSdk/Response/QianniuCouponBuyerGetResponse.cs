using System;
using System.Xml.Serialization;
using System.Collections.Generic;

namespace Top.Api.Response
{
    /// <summary>
    /// QianniuCouponBuyerGetResponse.
    /// </summary>
    public class QianniuCouponBuyerGetResponse : TopResponse
    {
        /// <summary>
        /// 优惠券列表信息
        /// </summary>
        [XmlArray("coupons")]
        [XmlArrayItem("coupon_info_do")]
        public List<Top.Api.Domain.CouponInfoDo> Coupons { get; set; }

        /// <summary>
        /// 是否成功
        /// </summary>
        [XmlElement("is_success")]
        public bool IsSuccess { get; set; }

    }
}
