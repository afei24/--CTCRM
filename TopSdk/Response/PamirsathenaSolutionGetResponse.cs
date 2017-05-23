using System;
using System.Xml.Serialization;
using System.Collections.Generic;

namespace Top.Api.Response
{
    /// <summary>
    /// PamirsathenaSolutionGetResponse.
    /// </summary>
    public class PamirsathenaSolutionGetResponse : TopResponse
    {
        /// <summary>
        /// 数字知识列表
        /// </summary>
        [XmlElement("ret_data")]
        public Top.Api.Domain.ResultMsgDto RetData { get; set; }

    }
}
