using System;
using System.Xml.Serialization;
using System.Collections.Generic;

namespace Top.Api.Response
{
    /// <summary>
    /// AlibabaAliqinFlowWalletSignResponse.
    /// </summary>
    public class AlibabaAliqinFlowWalletSignResponse : TopResponse
    {
        /// <summary>
        /// 是否成功
        /// </summary>
        [XmlElement("value")]
        public string Value { get; set; }

    }
}
