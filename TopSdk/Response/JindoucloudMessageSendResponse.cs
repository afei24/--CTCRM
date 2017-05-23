using System;
using System.Xml.Serialization;
using System.Collections.Generic;

namespace Top.Api.Response
{
    /// <summary>
    /// JindoucloudMessageSendResponse.
    /// </summary>
    public class JindoucloudMessageSendResponse : TopResponse
    {
        /// <summary>
        /// 返回结果
        /// </summary>
        [XmlArray("send_results")]
        [XmlArrayItem("message_send_result")]
        public List<Top.Api.Domain.MessageSendResult> SendResults { get; set; }

    }
}
