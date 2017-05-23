using System;
using System.Xml.Serialization;
using System.Collections.Generic;

namespace Top.Api.Response
{
    /// <summary>
    /// WlbWmsStockOutOrderConfirmResponse.
    /// </summary>
    public class WlbWmsStockOutOrderConfirmResponse : TopResponse
    {
        /// <summary>
        /// 出库单确认
        /// </summary>
        [XmlElement("result")]
        public Top.Api.Domain.WlbWmsStockOutOrderConfirmResp Result { get; set; }

    }
}
