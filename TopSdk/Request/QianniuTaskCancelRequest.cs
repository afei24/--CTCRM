using System;
using System.Collections.Generic;
using Top.Api.Util;

namespace Top.Api.Request
{
    /// <summary>
    /// TOP API: taobao.qianniu.task.cancel
    /// </summary>
    public class QianniuTaskCancelRequest : BaseTopRequest<Top.Api.Response.QianniuTaskCancelResponse>
    {
        /// <summary>
        /// 任务备注
        /// </summary>
        public string Memo { get; set; }

        /// <summary>
        /// 任务元数据ID
        /// </summary>
        public Nullable<long> MetaId { get; set; }

        #region ITopRequest Members

        public override string GetApiName()
        {
            return "taobao.qianniu.task.cancel";
        }

        public override IDictionary<string, string> GetParameters()
        {
            TopDictionary parameters = new TopDictionary();
            parameters.Add("memo", this.Memo);
            parameters.Add("meta_id", this.MetaId);
            if (this.otherParams != null)
            {
                parameters.AddAll(this.otherParams);
            }
            return parameters;
        }

        public override void Validate()
        {
            RequestValidator.ValidateRequired("meta_id", this.MetaId);
        }

        #endregion
    }
}
