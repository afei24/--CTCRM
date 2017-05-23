using System;
using System.Collections.Generic;
using Top.Api.Util;

namespace Top.Api.Request
{
    /// <summary>
    /// TOP API: taobao.qianniu.task.message.send
    /// </summary>
    public class QianniuTaskMessageSendRequest : BaseTopRequest<Top.Api.Response.QianniuTaskMessageSendResponse>
    {
        /// <summary>
        /// 任务元id，如果taskid不为空，则只发给task对应的单个接收人。如果taskid为空，则发给metadata_id对应的所有接收人。
        /// </summary>
        public Nullable<long> MetadataId { get; set; }

        /// <summary>
        /// 任务ID。如果taskid不为空，则只发给task对应的单个接收人。如果taskid为空，则发给metadata_id对应的所有接收人。
        /// </summary>
        public Nullable<long> TaskId { get; set; }

        #region ITopRequest Members

        public override string GetApiName()
        {
            return "taobao.qianniu.task.message.send";
        }

        public override IDictionary<string, string> GetParameters()
        {
            TopDictionary parameters = new TopDictionary();
            parameters.Add("metadata_id", this.MetadataId);
            parameters.Add("task_id", this.TaskId);
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
