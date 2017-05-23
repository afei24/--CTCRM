using System;
using System.Xml.Serialization;
using System.Collections.Generic;

namespace Top.Api.Response
{
    /// <summary>
    /// WlbWmsStockPruductProcessingNotifyResponse.
    /// </summary>
    public class WlbWmsStockPruductProcessingNotifyResponse : TopResponse
    {
        /// <summary>
        /// 订单编码
        /// </summary>
        [XmlElement("order_code")]
        public string OrderCode { get; set; }

        /// <summary>
        /// 错误编码
        /// </summary>
        [XmlElement("wl_error_code")]
        public string WlErrorCode { get; set; }

        /// <summary>
        /// 错误详细
        /// </summary>
        [XmlElement("wl_error_msg")]
        public string WlErrorMsg { get; set; }

        /// <summary>
        /// 是否成功
        /// </summary>
        [XmlElement("wl_success")]
        public bool WlSuccess { get; set; }

    }
}
