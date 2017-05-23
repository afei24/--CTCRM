using System;
using System.Xml.Serialization;

namespace Top.Api.Response
{
    /// <summary>
    /// AlibabaAliqinFlowWalletSendResponse.
    /// </summary>
    public class AlibabaAliqinFlowWalletSendResponse : TopResponse
    {
        /// <summary>
        /// 是否成功
        /// </summary>
        [XmlElement("value")]
        public string Value { get; set; }
    }
}
