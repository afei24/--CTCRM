using System;
using System.Xml.Serialization;
using System.Collections.Generic;

namespace Top.Api.Response
{
    /// <summary>
    /// PamirsathenaSolutionGetbyrelationResponse.
    /// </summary>
    public class PamirsathenaSolutionGetbyrelationResponse : TopResponse
    {
        /// <summary>
        /// 数字关联问题列表
        /// </summary>
        [XmlElement("result_data")]
        public Top.Api.Domain.ResultMsgDto ResultData { get; set; }

    }
}
