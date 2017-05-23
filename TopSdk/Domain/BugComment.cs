using System;
using System.Xml.Serialization;

namespace Top.Api.Domain
{
    /// <summary>
    /// BugComment Data Structure.
    /// </summary>
    [Serializable]
    public class BugComment : TopObject
    {
        /// <summary>
        /// 注释人
        /// </summary>
        [XmlElement("author")]
        public string Author { get; set; }

        /// <summary>
        /// 注释所属缺陷的ID
        /// </summary>
        [XmlElement("bug_id")]
        public long BugId { get; set; }

        /// <summary>
        /// 添加时间.格式:yyyy-mm-dd hh:mm:ss
        /// </summary>
        [XmlElement("created_at")]
        public string CreatedAt { get; set; }

        /// <summary>
        /// 注释详情
        /// </summary>
        [XmlElement("description")]
        public string Description { get; set; }

        /// <summary>
        /// 缺陷注释ID
        /// </summary>
        [XmlElement("id")]
        public long Id { get; set; }

        /// <summary>
        /// 是否对外展示
        /// </summary>
        [XmlElement("is_public")]
        public bool IsPublic { get; set; }

        /// <summary>
        /// 修改时间.格式:yyyy-mm-dd hh:mm:ss
        /// </summary>
        [XmlElement("modified_at")]
        public string ModifiedAt { get; set; }

        /// <summary>
        /// 注释之后状态
        /// </summary>
        [XmlElement("new_status")]
        public string NewStatus { get; set; }

        /// <summary>
        /// 注释之前状态。
        /// </summary>
        [XmlElement("old_status")]
        public string OldStatus { get; set; }

        /// <summary>
        /// 注释序号。注释展示顺序，数据越小越靠前。要求是正整数。
        /// </summary>
        [XmlElement("position")]
        public string Position { get; set; }
    }
}
