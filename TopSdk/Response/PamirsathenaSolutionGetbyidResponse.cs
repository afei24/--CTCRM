using System;
using System.Xml.Serialization;
using System.Collections.Generic;

namespace Top.Api.Response
{
    /// <summary>
    /// PamirsathenaSolutionGetbyidResponse.
    /// </summary>
    public class PamirsathenaSolutionGetbyidResponse : TopResponse
    {
        /// <summary>
        /// 数字知识详细
        /// </summary>
        [XmlElement("ret_data")]
        public Top.Api.Domain.ResultMsgDto RetData { get; set; }

    }
}
