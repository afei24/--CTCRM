using System;
using System.Xml.Serialization;

namespace Top.Api.Domain
{
    /// <summary>
    /// TaskComment Data Structure.
    /// </summary>
    [Serializable]
    public class TaskComment : TopObject
    {
        /// <summary>
        /// 评论的附件信息，userId_timestamp_随机字符串
        /// </summary>
        [XmlElement("attachments")]
        public string Attachments { get; set; }

        /// <summary>
        /// 评论内容
        /// </summary>
        [XmlElement("content")]
        public string Content { get; set; }

        /// <summary>
        /// 创建时间
        /// </summary>
        [XmlElement("gmt_create")]
        public string GmtCreate { get; set; }

        /// <summary>
        /// 评论id
        /// </summary>
        [XmlElement("id")]
        public long Id { get; set; }

        /// <summary>
        /// 任务号
        /// </summary>
        [XmlElement("task_id")]
        public long TaskId { get; set; }

        /// <summary>
        /// 评论人的userid
        /// </summary>
        [XmlElement("user_id")]
        public long UserId { get; set; }

        /// <summary>
        /// 评论人nick
        /// </summary>
        [XmlElement("user_nick")]
        public string UserNick { get; set; }
    }
}
