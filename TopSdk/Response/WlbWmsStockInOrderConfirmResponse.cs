using System;
using System.Xml.Serialization;
using System.Collections.Generic;

namespace Top.Api.Response
{
    /// <summary>
    /// WlbWmsStockInOrderConfirmResponse.
    /// </summary>
    public class WlbWmsStockInOrderConfirmResponse : TopResponse
    {
        /// <summary>
        /// 服务出参
        /// </summary>
        [XmlElement("result")]
        public Top.Api.Domain.Responsewlbwmsstockinorderconfirm Result { get; set; }

    }
}
