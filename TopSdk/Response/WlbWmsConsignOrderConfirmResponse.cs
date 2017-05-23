using System;
using System.Xml.Serialization;
using System.Collections.Generic;

namespace Top.Api.Response
{
    /// <summary>
    /// WlbWmsConsignOrderConfirmResponse.
    /// </summary>
    public class WlbWmsConsignOrderConfirmResponse : TopResponse
    {
        /// <summary>
        /// 销售订单出库确认
        /// </summary>
        [XmlElement("result")]
        public Top.Api.Domain.WlbWmsConsignOrderConfirmResp Result { get; set; }

    }
}
