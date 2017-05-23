using System;
using System.Xml.Serialization;
using System.Collections.Generic;

namespace Top.Api.Response
{
    /// <summary>
    /// WirelessXcodeCreateResponse.
    /// </summary>
    public class WirelessXcodeCreateResponse : TopResponse
    {
        /// <summary>
        /// 创建二维码/短连接 返回信息
        /// </summary>
        [XmlElement("xcode")]
        public Top.Api.Domain.XCodeTo Xcode { get; set; }

    }
}
