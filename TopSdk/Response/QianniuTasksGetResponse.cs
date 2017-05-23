using System;
using System.Xml.Serialization;
using System.Collections.Generic;

namespace Top.Api.Response
{
    /// <summary>
    /// QianniuTasksGetResponse.
    /// </summary>
    public class QianniuTasksGetResponse : TopResponse
    {
        /// <summary>
        /// 返回的任务列表
        /// </summary>
        [XmlArray("tasks")]
        [XmlArrayItem("q_task")]
        public List<Top.Api.Domain.QTask> Tasks { get; set; }

    }
}
