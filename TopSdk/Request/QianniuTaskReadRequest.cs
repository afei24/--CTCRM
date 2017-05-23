using System;
using System.Collections.Generic;
using Top.Api.Util;

namespace Top.Api.Request
{
    /// <summary>
    /// TOP API: taobao.qianniu.task.read
    /// </summary>
    public class QianniuTaskReadRequest : BaseTopRequest<Top.Api.Response.QianniuTaskReadResponse>
    {
        /// <summary>
        /// 任务ID的列表，以","进行分隔。例如：73596,73599,73602
        /// </summary>
        public string TaskIds { get; set; }

        #region ITopRequest Members

        public override string GetApiName()
        {
            return "taobao.qianniu.task.read";
        }

        public override IDictionary<string, string> GetParameters()
        {
            TopDictionary parameters = new TopDictionary();
            parameters.Add("task_ids", this.TaskIds);
            if (this.otherParams != null)
            {
                parameters.AddAll(this.otherParams);
            }
            return parameters;
        }

        public override void Validate()
        {
            RequestValidator.ValidateRequired("task_ids", this.TaskIds);
        }

        #endregion
    }
}
