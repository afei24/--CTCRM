using System;
using System.Collections.Generic;
using Top.Api.Util;

namespace Top.Api.Request
{
    /// <summary>
    /// TOP API: cainiao.cboss.workplatform.operation.reply
    /// </summary>
    public class CainiaoCbossWorkplatformOperationReplyRequest : BaseTopRequest<Top.Api.Response.CainiaoCbossWorkplatformOperationReplyResponse>
    {
        /// <summary>
        /// 任务操作时间
        /// </summary>
        public Nullable<DateTime> ActionTime { get; set; }

        /// <summary>
        /// 任务操作类型
        /// </summary>
        public Nullable<long> ActionType { get; set; }

        /// <summary>
        /// 凭证照片地址拼接
        /// </summary>
        public string AttachPath { get; set; }

        /// <summary>
        /// 操作者联系方式
        /// </summary>
        public string DealerContact { get; set; }

        /// <summary>
        /// 操作者userId
        /// </summary>
        public string DealerUserId { get; set; }

        /// <summary>
        /// 扩展字段
        /// </summary>
        public string Features { get; set; }

        /// <summary>
        /// 商家工单操作回传备注
        /// </summary>
        public string Memo { get; set; }

        /// <summary>
        /// 工单任务id
        /// </summary>
        public string TaskId { get; set; }

        /// <summary>
        /// 工单id
        /// </summary>
        public string WorkOrderId { get; set; }

        #region ITopRequest Members

        public override string GetApiName()
        {
            return "cainiao.cboss.workplatform.operation.reply";
        }

        public override IDictionary<string, string> GetParameters()
        {
            TopDictionary parameters = new TopDictionary();
            parameters.Add("action_time", this.ActionTime);
            parameters.Add("action_type", this.ActionType);
            parameters.Add("attach_path", this.AttachPath);
            parameters.Add("dealer_contact", this.DealerContact);
            parameters.Add("dealer_user_id", this.DealerUserId);
            parameters.Add("features", this.Features);
            parameters.Add("memo", this.Memo);
            parameters.Add("task_id", this.TaskId);
            parameters.Add("work_order_id", this.WorkOrderId);
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
