using System;
using System.Xml.Serialization;
using System.Collections.Generic;

namespace Top.Api.Response
{
    /// <summary>
    /// QianniuTasklistCountResponse.
    /// </summary>
    public class QianniuTasklistCountResponse : TopResponse
    {
        /// <summary>
        /// 未完成任务
        /// </summary>
        [XmlElement("qtask_count")]
        public Top.Api.Domain.QtaskCount QtaskCount { get; set; }

    }
}
