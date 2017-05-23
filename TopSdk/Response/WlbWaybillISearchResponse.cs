using System;
using System.Xml.Serialization;
using System.Collections.Generic;

namespace Top.Api.Response
{
    /// <summary>
    /// WlbWaybillISearchResponse.
    /// </summary>
    public class WlbWaybillISearchResponse : TopResponse
    {
        /// <summary>
        /// 订购关系
        /// </summary>
        [XmlArray("subscribtions")]
        [XmlArrayItem("waybill_apply_subscription_info")]
        public List<Top.Api.Domain.WaybillApplySubscriptionInfo> Subscribtions { get; set; }

    }
}
