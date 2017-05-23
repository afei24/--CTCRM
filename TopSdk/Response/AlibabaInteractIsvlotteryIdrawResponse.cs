using System;
using System.Xml.Serialization;
using System.Collections.Generic;

namespace Top.Api.Response
{
    /// <summary>
    /// AlibabaInteractIsvlotteryIdrawResponse.
    /// </summary>
    public class AlibabaInteractIsvlotteryIdrawResponse : TopResponse
    {
        /// <summary>
        /// 错误信息
        /// </summary>
        [XmlElement("biz_code")]
        public string BizCode { get; set; }

        /// <summary>
        /// 抽奖中奖信息
        /// </summary>
        [XmlElement("data")]
        public Top.Api.Domain.LotteryProxyResult Data { get; set; }

        /// <summary>
        /// 错误信息描述
        /// </summary>
        [XmlElement("error_msg")]
        public string ErrorMsg { get; set; }

        /// <summary>
        /// 是否调用成功
        /// </summary>
        [XmlElement("succ")]
        public bool Succ { get; set; }

    }
}
