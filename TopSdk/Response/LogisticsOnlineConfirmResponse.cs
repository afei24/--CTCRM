using System;
using System.Xml.Serialization;
using System.Collections.Generic;

namespace Top.Api.Response
{
    /// <summary>
    /// LogisticsOnlineConfirmResponse.
    /// </summary>
    public class LogisticsOnlineConfirmResponse : TopResponse
    {
        /// <summary>
        /// 只返回is_success：是否成功。
        /// </summary>
        [XmlElement("shipping")]
        public Top.Api.Domain.Shipping Shipping { get; set; }

    }
}
