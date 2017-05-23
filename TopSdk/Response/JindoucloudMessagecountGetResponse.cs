using System;
using System.Xml.Serialization;
using System.Collections.Generic;

namespace Top.Api.Response
{
    /// <summary>
    /// JindoucloudMessagecountGetResponse.
    /// </summary>
    public class JindoucloudMessagecountGetResponse : TopResponse
    {
        /// <summary>
        /// 返回的资源计数列表
        /// </summary>
        [XmlArray("message_infos")]
        [XmlArrayItem("message_info")]
        public List<Top.Api.Domain.MessageInfo> MessageInfos { get; set; }

    }
}
