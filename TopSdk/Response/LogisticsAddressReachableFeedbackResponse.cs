using System;
using System.Xml.Serialization;
using System.Collections.Generic;

namespace Top.Api.Response
{
    /// <summary>
    /// LogisticsAddressReachableFeedbackResponse.
    /// </summary>
    public class LogisticsAddressReachableFeedbackResponse : TopResponse
    {
        /// <summary>
        /// 调用是否成功：true-反馈成功；false-反馈失败
        /// </summary>
        [XmlElement("is_success")]
        public bool IsSuccess { get; set; }

        /// <summary>
        /// 错误返回码
        /// </summary>
        [XmlElement("ret_code")]
        public string RetCode { get; set; }

        /// <summary>
        /// 错误返回信息
        /// </summary>
        [XmlElement("ret_msg")]
        public string RetMsg { get; set; }

    }
}
