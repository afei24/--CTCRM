using System;
using System.Xml.Serialization;
using System.Collections.Generic;

namespace Top.Api.Response
{
    /// <summary>
    /// AlibabaInteractIsvdataQueryscoreResponse.
    /// </summary>
    public class AlibabaInteractIsvdataQueryscoreResponse : TopResponse
    {
        /// <summary>
        /// 用户游戏分数
        /// </summary>
        [XmlElement("data")]
        public Top.Api.Domain.InteractGamePoint Data { get; set; }

        /// <summary>
        /// 是否成功
        /// </summary>
        [XmlElement("succ")]
        public bool Succ { get; set; }

    }
}
