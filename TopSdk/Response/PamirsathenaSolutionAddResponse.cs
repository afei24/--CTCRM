using System;
using System.Xml.Serialization;
using System.Collections.Generic;

namespace Top.Api.Response
{
    /// <summary>
    /// PamirsathenaSolutionAddResponse.
    /// </summary>
    public class PamirsathenaSolutionAddResponse : TopResponse
    {
        /// <summary>
        /// 数字知识新增
        /// </summary>
        [XmlElement("ret_data")]
        public Top.Api.Domain.ResultMsgDto RetData { get; set; }

    }
}
