using System;
using System.Collections.Generic;
using Top.Api.Util;

namespace Top.Api.Request
{
    /// <summary>
    /// TOP API: taobao.qianniu.taskmetas.get
    /// </summary>
    public class QianniuTaskmetasGetRequest : BaseTopRequest<Top.Api.Response.QianniuTaskmetasGetResponse>
    {
        /// <summary>
        /// 任务类型
        /// </summary>
        public string BizType { get; set; }

        /// <summary>
        /// 客户端的版本信息
        /// </summary>
        public string ClientInfo { get; set; }

        /// <summary>
        /// 当前页码
        /// </summary>
        public Nullable<long> CurrentPage { get; set; }

        /// <summary>
        /// 逗号分隔的字段列表.如id,title,content,sender_uid,sender_nick,finish_strategy,biz_sys_Id,biz_sys_task_type,start_time,end_time,reminder_flag,priority
        /// </summary>
        public string Fields { get; set; }

        /// <summary>
        /// 按关键字搜索
        /// </summary>
        public string KeyWord { get; set; }

        /// <summary>
        /// 任务元ID，多个以逗号分离
        /// </summary>
        public string MetaIds { get; set; }

        /// <summary>
        /// 排序字段。gmt_create,priority等
        /// </summary>
        public string OrderBy { get; set; }

        /// <summary>
        /// 升降序。asc为升，desc为降
        /// </summary>
        public string OrderType { get; set; }

        /// <summary>
        /// 分页数，最大100
        /// </summary>
        public Nullable<long> PageSize { get; set; }

        /// <summary>
        /// 接收人uid
        /// </summary>
        public Nullable<long> ReceiverUid { get; set; }

        /// <summary>
        /// 发起任务人的uid
        /// </summary>
        public Nullable<long> SenderUid { get; set; }

        /// <summary>
        /// 0为未完成。2为完成。4为取消。不填为所有
        /// </summary>
        public Nullable<long> Status { get; set; }

        #region ITopRequest Members

        public override string GetApiName()
        {
            return "taobao.qianniu.taskmetas.get";
        }

        public override IDictionary<string, string> GetParameters()
        {
            TopDictionary parameters = new TopDictionary();
            parameters.Add("biz_type", this.BizType);
            parameters.Add("client_info", this.ClientInfo);
            parameters.Add("current_page", this.CurrentPage);
            parameters.Add("fields", this.Fields);
            parameters.Add("key_word", this.KeyWord);
            parameters.Add("meta_ids", this.MetaIds);
            parameters.Add("order_by", this.OrderBy);
            parameters.Add("order_type", this.OrderType);
            parameters.Add("page_size", this.PageSize);
            parameters.Add("receiver_uid", this.ReceiverUid);
            parameters.Add("sender_uid", this.SenderUid);
            parameters.Add("status", this.Status);
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
