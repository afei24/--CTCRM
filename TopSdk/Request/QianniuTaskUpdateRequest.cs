using System;
using System.Collections.Generic;
using Top.Api.Util;

namespace Top.Api.Request
{
    /// <summary>
    /// TOP API: taobao.qianniu.task.update
    /// </summary>
    public class QianniuTaskUpdateRequest : BaseTopRequest<Top.Api.Response.QianniuTaskUpdateResponse>
    {
        /// <summary>
        /// 应用自定义参数
        /// </summary>
        public string BizParam { get; set; }

        /// <summary>
        /// 0表示没有删除，1表示删除
        /// </summary>
        public Nullable<long> IsDeleted { get; set; }

        /// <summary>
        /// 任务备注。当memo_mode为1时，memo将采用追加方式。
        /// </summary>
        public string Memo { get; set; }

        /// <summary>
        /// 表示memo字段的更新策略。如需采用追加方式的，请将此字段设置为1。
        /// </summary>
        public Nullable<long> MemoMode { get; set; }

        /// <summary>
        /// 默认填0，数字越大优化级越高。当前常用0和1.
        /// </summary>
        public Nullable<long> Priority { get; set; }

        /// <summary>
        /// 0为不提醒，1为全部提醒，2为PC提醒，3为移动提醒，4为已提醒，5为已忽略。
        /// </summary>
        public Nullable<long> RemindFlag { get; set; }

        /// <summary>
        /// 提醒时间，时间的毫秒数
        /// </summary>
        public Nullable<long> RemindTime { get; set; }

        /// <summary>
        /// 状态值，多个以逗号分隔
        /// </summary>
        public string Status { get; set; }

        /// <summary>
        /// 子任务状态，由业务方自定义
        /// </summary>
        public string SubStatus { get; set; }

        /// <summary>
        /// 任务标签
        /// </summary>
        public string Tag { get; set; }

        /// <summary>
        /// 任务ID
        /// </summary>
        public Nullable<long> TaskId { get; set; }

        #region ITopRequest Members

        public override string GetApiName()
        {
            return "taobao.qianniu.task.update";
        }

        public override IDictionary<string, string> GetParameters()
        {
            TopDictionary parameters = new TopDictionary();
            parameters.Add("biz_param", this.BizParam);
            parameters.Add("is_deleted", this.IsDeleted);
            parameters.Add("memo", this.Memo);
            parameters.Add("memo_mode", this.MemoMode);
            parameters.Add("priority", this.Priority);
            parameters.Add("remind_flag", this.RemindFlag);
            parameters.Add("remind_time", this.RemindTime);
            parameters.Add("status", this.Status);
            parameters.Add("sub_status", this.SubStatus);
            parameters.Add("tag", this.Tag);
            parameters.Add("task_id", this.TaskId);
            if (this.otherParams != null)
            {
                parameters.AddAll(this.otherParams);
            }
            return parameters;
        }

        public override void Validate()
        {
            RequestValidator.ValidateRequired("task_id", this.TaskId);
        }

        #endregion
    }
}
