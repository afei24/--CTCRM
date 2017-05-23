using System;
using System.Collections.Generic;
using Top.Api.Util;

namespace Top.Api.Request
{
    /// <summary>
    /// TOP API: taobao.qianniu.task.comments.get
    /// </summary>
    public class QianniuTaskCommentsGetRequest : BaseTopRequest<Top.Api.Response.QianniuTaskCommentsGetResponse>
    {
        /// <summary>
        /// 当前页数，从1开始
        /// </summary>
        public Nullable<long> CurrentPage { get; set; }

        /// <summary>
        /// 任务元id。获取的是整个任务元的评论。当taskId为空时有效。
        /// </summary>
        public Nullable<long> MetaId { get; set; }

        /// <summary>
        /// 排序字段，可以为id,gmt_create
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
        /// 任务id
        /// </summary>
        public Nullable<long> TaskId { get; set; }

        /// <summary>
        /// 评论人userid。当前仅限自己的userId。为空时返回task下的所有评论。
        /// </summary>
        public Nullable<long> UserId { get; set; }

        #region ITopRequest Members

        public override string GetApiName()
        {
            return "taobao.qianniu.task.comments.get";
        }

        public override IDictionary<string, string> GetParameters()
        {
            TopDictionary parameters = new TopDictionary();
            parameters.Add("current_page", this.CurrentPage);
            parameters.Add("meta_id", this.MetaId);
            parameters.Add("order_by", this.OrderBy);
            parameters.Add("order_type", this.OrderType);
            parameters.Add("page_size", this.PageSize);
            parameters.Add("task_id", this.TaskId);
            parameters.Add("user_id", this.UserId);
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
