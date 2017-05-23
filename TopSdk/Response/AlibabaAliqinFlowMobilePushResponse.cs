using System;
using System.Xml.Serialization;

namespace Top.Api.Response
{
    /// <summary>
    /// AlibabaAliqinFlowMobilePushResponse.
    /// </summary>
    public class AlibabaAliqinFlowMobilePushResponse : TopResponse
    {
        /// <summary>
        /// 为true则成功
        /// </summary>
        [XmlElement("value")]
        public string Value { get; set; }
    }
}
