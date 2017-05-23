using System;
using System.Xml.Serialization;
using System.Collections.Generic;

namespace Top.Api.Response
{
    /// <summary>
    /// UmpPromotionGetResponse.
    /// </summary>
    public class UmpPromotionGetResponse : TopResponse
    {
        /// <summary>
        /// 优惠详细信息
        /// </summary>
        [XmlElement("promotions")]
        public Top.Api.Domain.PromotionDisplayTop Promotions { get; set; }

    }
}
