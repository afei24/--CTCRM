using System;
using System.Collections.Generic;
using Top.Api.Util;

namespace Top.Api.Request
{
    /// <summary>
    /// TOP API: taobao.kelude.qianniu.bugs.add
    /// </summary>
    public class KeludeQianniuBugsAddRequest : BaseTopRequest<Top.Api.Response.KeludeQianniuBugsAddResponse>
    {
        /// <summary>
        /// 缺陷指派人
        /// </summary>
        public string AssignedTo { get; set; }

        /// <summary>
        /// 缺陷创建者
        /// </summary>
        public string Author { get; set; }

        /// <summary>
        /// 缺陷图片ID列表
        /// </summary>
        public string BugImgIds { get; set; }

        /// <summary>
        /// 值：["1-PRD评审前" "2-PRD评审时" "3-PRD评审后UC评审前" "4-UC评审时" "5-UC评审后测试执行前" "6-测试执行期间" "7-预发期间" "8-发布后" "9-daily回归" "10-测试用例评审时" "11-发布前遗留"]
        /// </summary>
        public string Cf47 { get; set; }

        /// <summary>
        /// 值：["1-很容易发现" "2-正常发现" "3-很难发现"]
        /// </summary>
        public string Cf57 { get; set; }

        /// <summary>
        /// 自定义属性过滤。xx表示自定义属性的编号。常用如下：  cf_47:缺陷的发现阶段 值：["1-PRD评审前" "2-PRD评审时" "3-PRD评审后UC评审前" "4-UC评审时" "5-UC评审后测试执行前" "6-测试执行期间" "7-预发期间" "8-发布后" "9-daily回归" "10-测试用例评审时" "11-发布前遗留"]  cf_57:缺陷深度，值：["1-很容易发现"  "2-正常发现" "3-很难发现"]  更多自定义属性，请查询kelude后台管理->自定义属性
        /// </summary>
        public string CfXx { get; set; }

        /// <summary>
        /// 详细描述。字数要求小于65535个字符
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// 优先级。据不同的优先级，BUG的期望修复时间不同。可选值：94(urgent,为24小时内)，95(high)，96(medium)，97（low）。不传入此参数表示默认96
        /// </summary>
        public Nullable<long> Priority { get; set; }

        /// <summary>
        /// 严重程度。可选值：87-90。分别表示1-Blocker、2-Major、3-Normal、4-Trivial.不传入默认88
        /// </summary>
        public Nullable<long> SeriousLevel { get; set; }

        /// <summary>
        /// 缺陷标题。字符要求1-255。
        /// </summary>
        public string Subject { get; set; }

        /// <summary>
        /// 缺陷关联的测试集编号
        /// </summary>
        public Nullable<long> TestsuiteId { get; set; }

        /// <summary>
        /// 测试模板的类型
        /// </summary>
        public Nullable<long> TrackerId { get; set; }

        /// <summary>
        /// 项目/日常ID
        /// </summary>
        public Nullable<long> VersionId { get; set; }

        /// <summary>
        /// 跟踪者的用户编号。可以传入多个
        /// </summary>
        public string WatcherUserIds { get; set; }

        #region ITopRequest Members

        public override string GetApiName()
        {
            return "taobao.kelude.qianniu.bugs.add";
        }

        public override IDictionary<string, string> GetParameters()
        {
            TopDictionary parameters = new TopDictionary();
            parameters.Add("assigned_to", this.AssignedTo);
            parameters.Add("author", this.Author);
            parameters.Add("bug_img_ids", this.BugImgIds);
            parameters.Add("cf_47", this.Cf47);
            parameters.Add("cf_57", this.Cf57);
            parameters.Add("cf_xx", this.CfXx);
            parameters.Add("description", this.Description);
            parameters.Add("priority", this.Priority);
            parameters.Add("serious_level", this.SeriousLevel);
            parameters.Add("subject", this.Subject);
            parameters.Add("testsuite_id", this.TestsuiteId);
            parameters.Add("tracker_id", this.TrackerId);
            parameters.Add("version_id", this.VersionId);
            parameters.Add("watcher_user_ids", this.WatcherUserIds);
            if (this.otherParams != null)
            {
                parameters.AddAll(this.otherParams);
            }
            return parameters;
        }

        public override void Validate()
        {
            RequestValidator.ValidateRequired("assigned_to", this.AssignedTo);
            RequestValidator.ValidateRequired("author", this.Author);
            RequestValidator.ValidateMaxListSize("bug_img_ids", this.BugImgIds, 10);
            RequestValidator.ValidateMaxListSize("cf_47", this.Cf47, 100);
            RequestValidator.ValidateMaxListSize("cf_57", this.Cf57, 100);
            RequestValidator.ValidateMaxListSize("cf_xx", this.CfXx, 5);
            RequestValidator.ValidateRequired("description", this.Description);
            RequestValidator.ValidateMaxLength("description", this.Description, 65535);
            RequestValidator.ValidateRequired("subject", this.Subject);
            RequestValidator.ValidateMaxLength("subject", this.Subject, 255);
            RequestValidator.ValidateRequired("tracker_id", this.TrackerId);
            RequestValidator.ValidateRequired("version_id", this.VersionId);
            RequestValidator.ValidateMaxListSize("watcher_user_ids", this.WatcherUserIds, 200);
            RequestValidator.ValidateMaxLength("watcher_user_ids", this.WatcherUserIds, 200);
        }

        #endregion
    }
}
