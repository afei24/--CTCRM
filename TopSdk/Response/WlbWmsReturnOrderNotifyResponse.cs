using System;
using System.Xml.Serialization;
using System.Collections.Generic;

namespace Top.Api.Response
{
    /// <summary>
    /// WlbWmsReturnOrderNotifyResponse.
    /// </summary>
    public class WlbWmsReturnOrderNotifyResponse : TopResponse
    {
        /// <summary>
        /// 订单创建时间
        /// </summary>
        [XmlElement("create_time")]
        public string CreateTime { get; set; }

        /// <summary>
        /// LBX929829111
        /// </summary>
        [XmlElement("store_order_code")]
        public string StoreOrderCode { get; set; }

        /// <summary>
        /// 错误编码
        /// </summary>
        [XmlElement("wl_error_code")]
        public string WlErrorCode { get; set; }

        /// <summary>
        /// 错误信息
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
