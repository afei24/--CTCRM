using System;
using System.Collections.Generic;
using Top.Api.Util;

namespace Top.Api.Request
{
    /// <summary>
    /// TOP API: taobao.healthcenter.countfortop.query
    /// </summary>
    public class HealthcenterCountfortopQueryRequest : BaseTopRequest<Top.Api.Response.HealthcenterCountfortopQueryResponse>
    {
        /// <summary>
        /// pending_count:待处理违规,history_punish_count:历史违规,pending_market_manager_count:待处理管控,history_market_manager_count:历史管控。 fields支持多个字段, 多个字段用英文逗号(,)隔开
        /// </summary>
        public string Fields { get; set; }

        #region ITopRequest Members

        public override string GetApiName()
        {
            return "taobao.healthcenter.countfortop.query";
        }

        public override IDictionary<string, string> GetParameters()
        {
            TopDictionary parameters = new TopDictionary();
            parameters.Add("fields", this.Fields);
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
