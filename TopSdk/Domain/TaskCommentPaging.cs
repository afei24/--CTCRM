using System;
using System.Xml.Serialization;
using System.Collections.Generic;

namespace Top.Api.Domain
{
    /// <summary>
    /// TaskCommentPaging Data Structure.
    /// </summary>
    [Serializable]
    public class TaskCommentPaging : TopObject
    {
        /// <summary>
        /// 评论列表
        /// </summary>
        [XmlArray("list")]
        [XmlArrayItem("task_comment")]
        public List<Top.Api.Domain.TaskComment> List { get; set; }

        /// <summary>
        /// 当前页页码
        /// </summary>
        [XmlElement("page")]
        public long Page { get; set; }

        /// <summary>
        /// 每页数据长度
        /// </summary>
        [XmlElement("page_size")]
        public long PageSize { get; set; }

        /// <summary>
        /// 总页数
        /// </summary>
        [XmlElement("total_page")]
        public long TotalPage { get; set; }

        /// <summary>
        /// 总记录数
        /// </summary>
        [XmlElement("total_record")]
        public long TotalRecord { get; set; }
    }
}
