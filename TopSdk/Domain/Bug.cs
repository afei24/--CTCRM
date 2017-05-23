using System;
using System.Xml.Serialization;
using System.Collections.Generic;

namespace Top.Api.Domain
{
    /// <summary>
    /// Bug Data Structure.
    /// </summary>
    [Serializable]
    public class Bug : TopObject
    {
        /// <summary>
        /// 缺陷指派人
        /// </summary>
        [XmlElement("assigned_to")]
        public string AssignedTo { get; set; }

        /// <summary>
        /// 缺陷创建者
        /// </summary>
        [XmlElement("author")]
        public string Author { get; set; }

        /// <summary>
        /// 缺陷注释。fields中设置为bug_comments.id、bug_comments.desc、bug_comments.position等形式就会返回相应的字段
        /// </summary>
        [XmlArray("bug_comments")]
        [XmlArrayItem("bug_comment")]
        public List<Top.Api.Domain.BugComment> BugComments { get; set; }

        /// <summary>
        /// 缺陷图片。目前最多支持5张。fields中设置为bug_imgs.id、bug_imgs.url、bug_imgs.position 等形式就会返回相应的字段
        /// </summary>
        [XmlArray("bug_imgs")]
        [XmlArrayItem("bug_img")]
        public List<Top.Api.Domain.BugImg> BugImgs { get; set; }

        /// <summary>
        /// 自定义属性过滤。xx表示自定义属性的编号。常用如下： cf_47:缺陷的发现阶段 值：["1-PRD评审前" "2-PRD评审时" "3-PRD评审后UC评审前" "4-UC评审时" "5-UC评审后测试执行前" "6-测试执行期间" "7-预发期间" "8-发布后" "9-daily回归" "10-测试用例评审时" "11-发布前遗留"] cf_55:浏览器  浏览器 cf_59:部署标志
        /// </summary>
        [XmlElement("cf_xx")]
        public string CfXx { get; set; }

        /// <summary>
        /// 缺陷关闭时间
        /// </summary>
        [XmlElement("closed_at")]
        public string ClosedAt { get; set; }

        /// <summary>
        /// 缺陷创建时间
        /// </summary>
        [XmlElement("created_at")]
        public string CreatedAt { get; set; }

        /// <summary>
        /// 详细描述
        /// </summary>
        [XmlElement("description")]
        public string Description { get; set; }

        /// <summary>
        /// 缺陷修复时间
        /// </summary>
        [XmlElement("fixed_at")]
        public string FixedAt { get; set; }

        /// <summary>
        /// 缺陷ID
        /// </summary>
        [XmlElement("id")]
        public long Id { get; set; }

        /// <summary>
        /// 优先级。据不同的优先级，BUG的期望修复时间不同。可选值：1(urgent,为24小时内)，2(high)，3(medium)，4（low）
        /// </summary>
        [XmlElement("priority")]
        public long Priority { get; set; }

        /// <summary>
        /// 产品ID
        /// </summary>
        [XmlElement("project_id")]
        public long ProjectId { get; set; }

        /// <summary>
        /// 严重程度。可选值：1-blocker,2-major,3-normal,4-trivial
        /// </summary>
        [XmlElement("serious_level")]
        public long SeriousLevel { get; set; }

        /// <summary>
        /// 缺陷状态
        /// </summary>
        [XmlElement("status")]
        public string Status { get; set; }

        /// <summary>
        /// 缺陷标题
        /// </summary>
        [XmlElement("subject")]
        public string Subject { get; set; }

        /// <summary>
        /// 功能模块
        /// </summary>
        [XmlElement("testsuite")]
        public string Testsuite { get; set; }

        /// <summary>
        /// 跟踪类型。默认产品缺陷
        /// </summary>
        [XmlElement("tracker")]
        public string Tracker { get; set; }

        /// <summary>
        /// 缺陷修改时间
        /// </summary>
        [XmlElement("updated_at")]
        public string UpdatedAt { get; set; }

        /// <summary>
        /// 项目/日常ID
        /// </summary>
        [XmlElement("version_id")]
        public long VersionId { get; set; }
    }
}
