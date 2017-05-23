using System;
using System.Xml.Serialization;
using System.Collections.Generic;

namespace Top.Api.Response
{
    /// <summary>
    /// AlibabaInteractIsvadminGetpondbyinteractResponse.
    /// </summary>
    public class AlibabaInteractIsvadminGetpondbyinteractResponse : TopResponse
    {
        /// <summary>
        /// 奖池信息
        /// </summary>
        [XmlElement("data")]
        public Top.Api.Domain.PrizePondDTO Data { get; set; }

        /// <summary>
        /// 调用错误原因
        /// </summary>
        [XmlElement("error")]
        public string Error { get; set; }

        /// <summary>
        /// 错误描述
        /// </summary>
        [XmlElement("error_msg")]
        public string ErrorMsg { get; set; }

        /// <summary>
        /// 是否调用成功
        /// </summary>
        [XmlElement("succ")]
        public bool Succ { get; set; }

    }
}
