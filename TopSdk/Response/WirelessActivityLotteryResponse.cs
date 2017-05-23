using System;
using System.Xml.Serialization;
using System.Collections.Generic;

namespace Top.Api.Response
{
    /// <summary>
    /// WirelessActivityLotteryResponse.
    /// </summary>
    public class WirelessActivityLotteryResponse : TopResponse
    {
        /// <summary>
        /// 返回结果，如：抽奖结果
        /// </summary>
        [XmlElement("result")]
        public string Result { get; set; }

    }
}
