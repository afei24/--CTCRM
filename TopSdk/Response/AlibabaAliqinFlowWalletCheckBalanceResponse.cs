using System;
using System.Xml.Serialization;
using System.Collections.Generic;

namespace Top.Api.Response
{
    /// <summary>
    /// AlibabaAliqinFlowWalletCheckBalanceResponse.
    /// </summary>
    public class AlibabaAliqinFlowWalletCheckBalanceResponse : TopResponse
    {
        /// <summary>
        /// 余额是否大于校验值，大于返回true，小于返回false
        /// </summary>
        [XmlElement("value")]
        public string Value { get; set; }

    }
}
