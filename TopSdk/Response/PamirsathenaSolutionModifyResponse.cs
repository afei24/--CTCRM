using System;
using System.Xml.Serialization;
using System.Collections.Generic;

namespace Top.Api.Response
{
    /// <summary>
    /// PamirsathenaSolutionModifyResponse.
    /// </summary>
    public class PamirsathenaSolutionModifyResponse : TopResponse
    {
        /// <summary>
        /// 失败
        /// </summary>
        [XmlElement("error_msg")]
        public string ErrorMsg { get; set; }

        /// <summary>
        /// 修改成功消息
        /// </summary>
        [XmlElement("ret")]
        public string Ret { get; set; }

        /// <summary>
        /// 返回成功或者失败
        /// </summary>
        [XmlElement("status")]
        public bool Status { get; set; }

    }
}
