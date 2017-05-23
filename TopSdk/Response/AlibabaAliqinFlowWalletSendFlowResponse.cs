using System;
using System.Xml.Serialization;
using System.Collections.Generic;

namespace Top.Api.Response
{
    /// <summary>
    /// AlibabaAliqinFlowWalletSendFlowResponse.
    /// </summary>
    public class AlibabaAliqinFlowWalletSendFlowResponse : TopResponse
    {
        /// <summary>
        /// true为成功
        /// </summary>
        [XmlElement("value")]
        public string Value { get; set; }

    }
}
