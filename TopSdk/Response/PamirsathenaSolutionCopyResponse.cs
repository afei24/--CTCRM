using System;
using System.Xml.Serialization;
using System.Collections.Generic;

namespace Top.Api.Response
{
    /// <summary>
    /// PamirsathenaSolutionCopyResponse.
    /// </summary>
    public class PamirsathenaSolutionCopyResponse : TopResponse
    {
        /// <summary>
        /// 数据复制列表
        /// </summary>
        [XmlElement("ret_data")]
        public Top.Api.Domain.ResultMsgDto RetData { get; set; }

    }
}
