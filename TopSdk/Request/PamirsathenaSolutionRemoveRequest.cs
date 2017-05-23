using System;
using System.Collections.Generic;
using Top.Api.Util;

namespace Top.Api.Request
{
    /// <summary>
    /// TOP API: taobao.pamirsathena.solution.remove
    /// </summary>
    public class PamirsathenaSolutionRemoveRequest : BaseTopRequest<Top.Api.Response.PamirsathenaSolutionRemoveResponse>
    {
        /// <summary>
        /// 数字知识id
        /// </summary>
        public Nullable<long> KnowledgeId { get; set; }

        #region ITopRequest Members

        public override string GetApiName()
        {
            return "taobao.pamirsathena.solution.remove";
        }

        public override IDictionary<string, string> GetParameters()
        {
            TopDictionary parameters = new TopDictionary();
            parameters.Add("knowledge_id", this.KnowledgeId);
            if (this.otherParams != null)
            {
                parameters.AddAll(this.otherParams);
            }
            return parameters;
        }

        public override void Validate()
        {
            RequestValidator.ValidateRequired("knowledge_id", this.KnowledgeId);
        }

        #endregion
    }
}
