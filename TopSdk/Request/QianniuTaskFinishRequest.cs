using System;
using System.Collections.Generic;
using Top.Api.Util;

namespace Top.Api.Request
{
    /// <summary>
    /// TOP API: taobao.qianniu.task.finish
    /// </summary>
    public class QianniuTaskFinishRequest : BaseTopRequest<Top.Api.Response.QianniuTaskFinishResponse>
    {
        /// <summary>
        /// 任务备注
        /// </summary>
        public string Memo { get; set; }

        /// <summary>
        /// 任务ID
        /// </summary>
        public Nullable<long> TaskId { get; set; }

        #region ITopRequest Members

        public override string GetApiName()
        {
            return "taobao.qianniu.task.finish";
        }

        public override IDictionary<string, string> GetParameters()
        {
            TopDictionary parameters = new TopDictionary();
            parameters.Add("memo", this.Memo);
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
