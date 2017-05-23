using System;
using System.Xml.Serialization;
using System.Collections.Generic;

namespace Top.Api.Response
{
    /// <summary>
    /// AlibabaInteractIsvlotteryMdrawResponse.
    /// </summary>
    public class AlibabaInteractIsvlotteryMdrawResponse : TopResponse
    {
        /// <summary>
        /// ret
        /// </summary>
        [XmlElement("ret")]
        public string Ret { get; set; }

    }
}
