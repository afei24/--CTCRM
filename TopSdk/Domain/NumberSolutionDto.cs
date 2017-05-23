using System;
using System.Xml.Serialization;

namespace Top.Api.Domain
{
    /// <summary>
    /// NumberSolutionDto Data Structure.
    /// </summary>
    [Serializable]
    public class NumberSolutionDto : TopObject
    {
        /// <summary>
        /// 数字知识id
        /// </summary>
        [XmlElement("id")]
        public long Id { get; set; }

        /// <summary>
        /// 数字知识问题详情
        /// </summary>
        [XmlElement("question_desc")]
        public string QuestionDesc { get; set; }

        /// <summary>
        /// 数字知识标题
        /// </summary>
        [XmlElement("question_title")]
        public string QuestionTitle { get; set; }

        /// <summary>
        /// 数字知识答案
        /// </summary>
        [XmlElement("solution")]
        public string Solution { get; set; }

        /// <summary>
        /// 主用户id
        /// </summary>
        [XmlElement("user_id")]
        public long UserId { get; set; }
    }
}
