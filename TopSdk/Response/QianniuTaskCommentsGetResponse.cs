using System;
using System.Xml.Serialization;
using System.Collections.Generic;

namespace Top.Api.Response
{
    /// <summary>
    /// QianniuTaskCommentsGetResponse.
    /// </summary>
    public class QianniuTaskCommentsGetResponse : TopResponse
    {
        /// <summary>
        /// 分布的评论列表
        /// </summary>
        [XmlElement("task_comment_paging")]
        public Top.Api.Domain.TaskCommentPaging TaskCommentPaging { get; set; }

    }
}
