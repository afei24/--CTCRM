using System;
using System.Xml.Serialization;
using System.Collections.Generic;

namespace Top.Api.Response
{
    /// <summary>
    /// WlbSubscriptionQueryResponse.
    /// </summary>
    public class WlbSubscriptionQueryResponse : TopResponse
    {
        /// <summary>
        /// 卖家定购的服务列表
        /// </summary>
        [XmlArray("seller_subscription_list")]
        [XmlArrayItem("wlb_seller_subscription")]
        public List<Top.Api.Domain.WlbSellerSubscription> SellerSubscriptionList { get; set; }

        /// <summary>
        /// 结果总数
        /// </summary>
        [XmlElement("total_count")]
        public long TotalCount { get; set; }

    }
}
