using System;
using System.Xml.Serialization;

namespace Top.Api.Domain
{
    /// <summary>
    /// PamirsRet Data Structure.
    /// </summary>
    [Serializable]
    public class PamirsRet : TopObject
    {
        /// <summary>
        /// 数字知识id
        /// </summary>
        [XmlElement("id")]
        public long Id { get; set; }

        /// <summary>
        /// 问题描述
        /// </summary>
        [XmlElement("question_desc")]
        public string QuestionDesc { get; set; }

        /// <summary>
        /// 用户数字title
        /// </summary>
        [XmlElement("question_title")]
        public string QuestionTitle { get; set; }

        /// <summary>
        /// 是否关联
        /// </summary>
        [XmlElement("relation")]
        public bool Relation { get; set; }

        /// <summary>
        /// 问题答案
        /// </summary>
        [XmlElement("solution")]
        public string Solution { get; set; }

        /// <summary>
        /// 用户id
        /// </summary>
        [XmlElement("user_id")]
        public long UserId { get; set; }
    }
}
