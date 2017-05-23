using System;
using System.Xml.Serialization;
using System.Collections.Generic;

namespace Top.Api.Response
{
    /// <summary>
    /// PamirsathenaSolutionRemoveResponse.
    /// </summary>
    public class PamirsathenaSolutionRemoveResponse : TopResponse
    {
        /// <summary>
        /// 返回失败信息
        /// </summary>
        [XmlElement("error_msg")]
        public string ErrorMsg { get; set; }

        /// <summary>
        /// 返回成功信息
        /// </summary>
        [XmlElement("ret")]
        public string Ret { get; set; }

        /// <summary>
        /// 返回成功或失败
        /// </summary>
        [XmlElement("status")]
        public bool Status { get; set; }

    }
}
