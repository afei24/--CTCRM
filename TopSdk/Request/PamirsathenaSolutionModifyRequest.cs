using System;
using System.Collections.Generic;
using Top.Api.Util;

namespace Top.Api.Request
{
    /// <summary>
    /// TOP API: taobao.pamirsathena.solution.modify
    /// </summary>
    public class PamirsathenaSolutionModifyRequest : BaseTopRequest<Top.Api.Response.PamirsathenaSolutionModifyResponse>
    {
        /// <summary>
        /// 数字知识id
        /// </summary>
        public Nullable<long> KnowledgeId { get; set; }

        /// <summary>
        /// 问题描述
        /// </summary>
        public string QuestionDesc { get; set; }

        /// <summary>
        /// 问题答案
        /// </summary>
        public string Solution { get; set; }

        #region ITopRequest Members

        public override string GetApiName()
        {
            return "taobao.pamirsathena.solution.modify";
        }

        public override IDictionary<string, string> GetParameters()
        {
            TopDictionary parameters = new TopDictionary();
            parameters.Add("knowledge_id", this.KnowledgeId);
            parameters.Add("question_desc", this.QuestionDesc);
            parameters.Add("solution", this.Solution);
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
