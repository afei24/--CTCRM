using System;
using System.Collections.Generic;
using Top.Api.Util;

namespace Top.Api.Request
{
    /// <summary>
    /// TOP API: taobao.pamirsathena.solution.getbyrelation
    /// </summary>
    public class PamirsathenaSolutionGetbyrelationRequest : BaseTopRequest<Top.Api.Response.PamirsathenaSolutionGetbyrelationResponse>
    {
        /// <summary>
        /// 数字知识列表
        /// </summary>
        public string KnowledgeIds { get; set; }

        /// <summary>
        /// 知识答案是否需要富文本
        /// </summary>
        public Nullable<long> Source { get; set; }

        #region ITopRequest Members

        public override string GetApiName()
        {
            return "taobao.pamirsathena.solution.getbyrelation";
        }

        public override IDictionary<string, string> GetParameters()
        {
            TopDictionary parameters = new TopDictionary();
            parameters.Add("knowledge_ids", this.KnowledgeIds);
            parameters.Add("source", this.Source);
            if (this.otherParams != null)
            {
                parameters.AddAll(this.otherParams);
            }
            return parameters;
        }

        public override void Validate()
        {
            RequestValidator.ValidateRequired("knowledge_ids", this.KnowledgeIds);
            RequestValidator.ValidateMaxListSize("knowledge_ids", this.KnowledgeIds, 20);
            RequestValidator.ValidateRequired("source", this.Source);
        }

        #endregion
    }
}
