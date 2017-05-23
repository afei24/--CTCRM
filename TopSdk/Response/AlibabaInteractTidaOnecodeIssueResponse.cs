using System;
using System.Xml.Serialization;
using System.Collections.Generic;

namespace Top.Api.Response
{
    /// <summary>
    /// AlibabaInteractTidaOnecodeIssueResponse.
    /// </summary>
    public class AlibabaInteractTidaOnecodeIssueResponse : TopResponse
    {
        /// <summary>
        /// 透传服务方返回的业务响应
        /// </summary>
        [XmlElement("ext_response")]
        public string ExtResponse { get; set; }

        /// <summary>
        /// ISV收到spi调用信息
        /// </summary>
        [XmlElement("recieved")]
        public bool Recieved { get; set; }

    }
}
