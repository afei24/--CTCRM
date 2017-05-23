using System;
using System.Xml.Serialization;
using System.Collections.Generic;

namespace Top.Api.Response
{
    /// <summary>
    /// AlibabaInteractIsvlotteryIsvdrawResponse.
    /// </summary>
    public class AlibabaInteractIsvlotteryIsvdrawResponse : TopResponse
    {
        /// <summary>
        /// 无用参数
        /// </summary>
        [XmlElement("stub")]
        public string Stub { get; set; }

    }
}
