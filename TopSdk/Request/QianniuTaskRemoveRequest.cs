using System;
using System.Collections.Generic;
using Top.Api.Util;

namespace Top.Api.Request
{
    /// <summary>
    /// TOP API: taobao.qianniu.task.remove
    /// </summary>
    public class QianniuTaskRemoveRequest : BaseTopRequest<Top.Api.Response.QianniuTaskRemoveResponse>
    {
        /// <summary>
        /// 对于发起人删除一个任务，请使用这个字段，同时清除所有处理人。
        /// </summary>
        public Nullable<long> MetadataId { get; set; }

        #region ITopRequest Members

        public override string GetApiName()
        {
            return "taobao.qianniu.task.remove";
        }

        public override IDictionary<string, string> GetParameters()
        {
            TopDictionary parameters = new TopDictionary();
            parameters.Add("metadata_id", this.MetadataId);
            if (this.otherParams != null)
            {
                parameters.AddAll(this.otherParams);
            }
            return parameters;
        }

        public override void Validate()
        {
            RequestValidator.ValidateRequired("metadata_id", this.MetadataId);
        }

        #endregion
    }
}
