using System;
using System.Collections.Generic;
using Top.Api.Util;

namespace Top.Api.Request
{
    /// <summary>
    /// TOP API: taobao.qianniu.tasks.count
    /// </summary>
    public class QianniuTasksCountRequest : BaseTopRequest<Top.Api.Response.QianniuTasksCountResponse>
    {
        /// <summary>
        /// 业务ID列表，逗号分隔
        /// </summary>
        public string BizIds { get; set; }

        /// <summary>
        /// 与业务相关的买家nick
        /// </summary>
        public string BizNick { get; set; }

        /// <summary>
        /// 业务类型
        /// </summary>
        public string BizType { get; set; }

        /// <summary>
        /// 按时间段搜索的结束日期。不填则不限。格式为2014-01-01
        /// </summary>
        public string EndDate { get; set; }

        /// <summary>
        /// 需要排除的任务类型
        /// </summary>
        public string ExcludeBizType { get; set; }

        /// <summary>
        /// 关键词搜索。只对任务内容进行模糊匹配，以及bizid和biznick进行精准匹配
        /// </summary>
        public string KeyWord { get; set; }

        /// <summary>
        /// 任务元id，多个以逗号分隔
        /// </summary>
        public string MetadataIds { get; set; }

        /// <summary>
        /// 优先级
        /// </summary>
        public Nullable<long> Priority { get; set; }

        /// <summary>
        /// 任务执行者用户数字ID
        /// </summary>
        public Nullable<long> ReceiverUid { get; set; }

        /// <summary>
        /// 0-不需要提醒，未设提醒时间 1-设置过提醒时间，需要提醒
        /// </summary>
        public Nullable<long> RemindFlag { get; set; }

        /// <summary>
        /// 任务发起者用户数字ID
        /// </summary>
        public Nullable<long> SenderUid { get; set; }

        /// <summary>
        /// 按时间段搜索时的开始日期，格式如2014-01-01，不填则不限
        /// </summary>
        public string StartDate { get; set; }

        /// <summary>
        /// 逗号分隔的任务状态：0-未执行，1-执行中，2-执行完成，3-超时，4-取消，5-忽略
        /// </summary>
        public string Status { get; set; }

        /// <summary>
        /// 子任务类型
        /// </summary>
        public string SubBizType { get; set; }

        /// <summary>
        /// 逗号分隔的子任务状态，由业务方自定义
        /// </summary>
        public string SubStatus { get; set; }

        /// <summary>
        /// 任务的ID列表，用逗号分隔
        /// </summary>
        public string TaskIds { get; set; }

        #region ITopRequest Members

        public override string GetApiName()
        {
            return "taobao.qianniu.tasks.count";
        }

        public override IDictionary<string, string> GetParameters()
        {
            TopDictionary parameters = new TopDictionary();
            parameters.Add("biz_ids", this.BizIds);
            parameters.Add("biz_nick", this.BizNick);
            parameters.Add("biz_type", this.BizType);
            parameters.Add("end_date", this.EndDate);
            parameters.Add("exclude_biz_type", this.ExcludeBizType);
            parameters.Add("key_word", this.KeyWord);
            parameters.Add("metadata_ids", this.MetadataIds);
            parameters.Add("priority", this.Priority);
            parameters.Add("receiver_uid", this.ReceiverUid);
            parameters.Add("remind_flag", this.RemindFlag);
            parameters.Add("sender_uid", this.SenderUid);
            parameters.Add("start_date", this.StartDate);
            parameters.Add("status", this.Status);
            parameters.Add("sub_biz_type", this.SubBizType);
            parameters.Add("sub_status", this.SubStatus);
            parameters.Add("task_ids", this.TaskIds);
            if (this.otherParams != null)
            {
                parameters.AddAll(this.otherParams);
            }
            return parameters;
        }

        public override void Validate()
        {
        }

        #endregion
    }
}
