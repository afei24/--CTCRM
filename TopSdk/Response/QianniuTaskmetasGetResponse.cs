using System;
using System.Xml.Serialization;
using System.Collections.Generic;

namespace Top.Api.Response
{
    /// <summary>
    /// QianniuTaskmetasGetResponse.
    /// </summary>
    public class QianniuTaskmetasGetResponse : TopResponse
    {
        /// <summary>
        /// taskmetas
        /// </summary>
        [XmlArray("taskmetas")]
        [XmlArrayItem("q_task_metadata")]
        public List<Top.Api.Domain.QTaskMetadata> Taskmetas { get; set; }

    }
}
