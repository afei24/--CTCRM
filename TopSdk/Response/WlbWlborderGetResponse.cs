using System;
using System.Xml.Serialization;
using System.Collections.Generic;

namespace Top.Api.Response
{
    /// <summary>
    /// WlbWlborderGetResponse.
    /// </summary>
    public class WlbWlborderGetResponse : TopResponse
    {
        /// <summary>
        /// 物流宝订单对象
        /// </summary>
        [XmlElement("wlb_order")]
        public Top.Api.Domain.WlbOrder WlbOrder { get; set; }

    }
}
