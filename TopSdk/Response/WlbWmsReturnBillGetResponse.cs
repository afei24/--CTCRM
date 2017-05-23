using System;
using System.Xml.Serialization;
using System.Collections.Generic;

namespace Top.Api.Response
{
    /// <summary>
    /// WlbWmsReturnBillGetResponse.
    /// </summary>
    public class WlbWmsReturnBillGetResponse : TopResponse
    {
        /// <summary>
        /// 回退订单信息
        /// </summary>
        [XmlElement("return_order_info")]
        public Top.Api.Domain.CainiaoReturnBillReturnorderinfo ReturnOrderInfo { get; set; }

    }
}
