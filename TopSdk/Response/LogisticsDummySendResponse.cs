using System;
using System.Xml.Serialization;
using System.Collections.Generic;

namespace Top.Api.Response
{
    /// <summary>
    /// LogisticsDummySendResponse.
    /// </summary>
    public class LogisticsDummySendResponse : TopResponse
    {
        /// <summary>
        /// 返回发货是否成功is_success
        /// </summary>
        [XmlElement("shipping")]
        public Top.Api.Domain.Shipping Shipping { get; set; }

    }
}
