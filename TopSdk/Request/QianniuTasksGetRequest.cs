using System;
using System.Collections.Generic;
using Top.Api.Util;

namespace Top.Api.Request
{
    /// <summary>
    /// TOP API: taobao.qianniu.tasks.get
    /// </summary>
    public class QianniuTasksGetRequest : BaseTopRequest<Top.Api.Response.QianniuTasksGetResponse>
    {
        /// <summary>
        /// 业务ID列表，逗号分隔
        /// </summary>
        public string BizIds { get; set; }

        /// <summary>
        /// 业务相关的对象，当前主要表示买家nick
        /// </summary>
        public string BizNick { get; set; }

        /// <summary>
        /// 业务类型
        /// </summary>
        public string BizType { get; set; }

        /// <summary>
        /// 客户端的版本信息
        /// </summary>
        public string ClientInfo { get; set; }

        /// <summary>
        /// 当前页数，从1开始
        /// </summary>
        public Nullable<long> CurrentPage { get; set; }

        /// <summary>
        /// 根据任务创建时间搜索的结束日期（含），不填则不限。例如只查询2014-01-01当天的任务，则将start_date和end_date都设置成2014-01-01
        /// </summary>
        public string EndDate { get; set; }

        /// <summary>
        /// 需要排除的任务类型
        /// </summary>
        public string ExcludeBizType { get; set; }

        /// <summary>
        /// 逗号分隔的字段列表，各个字段含义： id：任务ID receiver_uid：执行者用户数字ID receiver_nick：执行者用户昵称 status：任务状态：0-未执行，1-执行中，2-执行完成，3-超时，4-取消，5-忽略 sub_status：子任务状态，由业务方自定义 finish_strategy：任务完成策略：1-一个人完成，2-所有人完成 gmt_finished：任务完成时间，格式：时间毫秒数 biz_type：业务类型 sub_biz_type：子业务类型 biz_id：业务ID biz_param：业务参数 biz_entry：业务入口 tag：任务标签 memo：任务备注
        /// </summary>
        public string Fields { get; set; }

        /// <summary>
        /// 关键词搜索。只对任务内容进行模糊匹配，以及bizid和biznick进行精准匹配
        /// </summary>
        public string KeyWord { get; set; }

        /// <summary>
        /// 任务元id，多个以逗号分隔
        /// </summary>
        public string MetadataIds { get; set; }

        /// <summary>
        /// 根据任务修改时间搜索的结束时间（含），不填则不限。例如查询“2014-01-01 00:00:10”之前有修改的任务，则将modify_end_time_str设置成“2014-01-01 00:00:10”
        /// </summary>
        public string ModifyEndTimeStr { get; set; }

        /// <summary>
        /// 根据任务修改时间搜索的开始时间（含），不填则不限。例如查询“2014-01-01 00:00:10”之后有修改的任务，则将modify_start_time_str设置成“2014-01-01 00:00:10”
        /// </summary>
        public string ModifyStartTimeStr { get; set; }

        /// <summary>
        /// 是否需要删除的任务，默认为false
        /// </summary>
        public Nullable<bool> NeedDeleted { get; set; }

        /// <summary>
        /// 是否需要meta信息，默认值为false
        /// </summary>
        public Nullable<bool> NeedMeta { get; set; }

        /// <summary>
        /// 排序字段，可以为id,gmt_create,gmt_finished,metadata_id等
        /// </summary>
        public string OrderBy { get; set; }

        /// <summary>
        /// asc为升，desc为降
        /// </summary>
        public string OrderType { get; set; }

        /// <summary>
        /// 每页条数
        /// </summary>
        public Nullable<long> PageSize { get; set; }

        /// <summary>
        /// 优先级。即创建时的metadata中的优先级。0为低，1为中，2为高。
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
        /// 根据任务创建时间搜索的开始日期（含），不填则不限。例如只查询2014-01-01当天的任务，则将start_date和end_date都设置成2014-01-01
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
            return "taobao.qianniu.tasks.get";
        }

        public override IDictionary<string, string> GetParameters()
        {
            TopDictionary parameters = new TopDictionary();
            parameters.Add("biz_ids", this.BizIds);
            parameters.Add("biz_nick", this.BizNick);
            parameters.Add("biz_type", this.BizType);
            parameters.Add("client_info", this.ClientInfo);
            parameters.Add("current_page", this.CurrentPage);
            parameters.Add("end_date", this.EndDate);
            parameters.Add("exclude_biz_type", this.ExcludeBizType);
            parameters.Add("fields", this.Fields);
            parameters.Add("key_word", this.KeyWord);
            parameters.Add("metadata_ids", this.MetadataIds);
            parameters.Add("modify_end_time_str", this.ModifyEndTimeStr);
            parameters.Add("modify_start_time_str", this.ModifyStartTimeStr);
            parameters.Add("need_deleted", this.NeedDeleted);
            parameters.Add("need_meta", this.NeedMeta);
            parameters.Add("order_by", this.OrderBy);
            parameters.Add("order_type", this.OrderType);
            parameters.Add("page_size", this.PageSize);
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
            RequestValidator.ValidateRequired("fields", this.Fields);
        }

        #endregion
    }
}
