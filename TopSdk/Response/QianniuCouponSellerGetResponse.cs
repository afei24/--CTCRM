using System;
using System.Xml.Serialization;
using System.Collections.Generic;

namespace Top.Api.Response
{
    /// <summary>
    /// QianniuCouponSellerGetResponse.
    /// </summary>
    public class QianniuCouponSellerGetResponse : TopResponse
    {
        /// <summary>
        /// 优惠券列表
        /// </summary>
        [XmlArray("coupons")]
        [XmlArrayItem("coupon_info_do")]
        public List<Top.Api.Domain.CouponInfoDo> Coupons { get; set; }

        /// <summary>
        /// 调用是否成功
        /// </summary>
        [XmlElement("is_success")]
        public bool IsSuccess { get; set; }

    }
}
