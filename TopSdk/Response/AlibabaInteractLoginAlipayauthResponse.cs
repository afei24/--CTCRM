using System;
using System.Xml.Serialization;
using System.Collections.Generic;

namespace Top.Api.Response
{
    /// <summary>
    /// AlibabaInteractLoginAlipayauthResponse.
    /// </summary>
    public class AlibabaInteractLoginAlipayauthResponse : TopResponse
    {
        /// <summary>
        /// 返回值
        /// </summary>
        [XmlElement("result")]
        public string Result { get; set; }

    }
}
