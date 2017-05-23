using System;
using System.Xml.Serialization;
using System.Collections.Generic;

namespace Top.Api.Response
{
    /// <summary>
    /// PromotionmiscMarketingNumberGetResponse.
    /// </summary>
    public class PromotionmiscMarketingNumberGetResponse : TopResponse
    {
        /// <summary>
        /// 营销活动数量
        /// </summary>
        [XmlElement("marketing_number")]
        public Top.Api.Domain.MarketingNumber MarketingNumber { get; set; }

    }
}
