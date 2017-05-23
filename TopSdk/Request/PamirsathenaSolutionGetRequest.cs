using System;
using System.Collections.Generic;
using Top.Api.Util;

namespace Top.Api.Request
{
    /// <summary>
    /// TOP API: taobao.pamirsathena.solution.get
    /// </summary>
    public class PamirsathenaSolutionGetRequest : BaseTopRequest<Top.Api.Response.PamirsathenaSolutionGetResponse>
    {
        /// <summary>
        /// 数字知识id集合
        /// </summary>
        public string Knowledgeids { get; set; }

        /// <summary>
        /// api来源
        /// </summary>
        public Nullable<long> Source { get; set; }

        #region ITopRequest Members

        public override string GetApiName()
        {
            return "taobao.pamirsathena.solution.get";
        }

        public override IDictionary<string, string> GetParameters()
        {
            TopDictionary parameters = new TopDictionary();
            parameters.Add("knowledgeids", this.Knowledgeids);
            parameters.Add("source", this.Source);
            if (this.otherParams != null)
            {
                parameters.AddAll(this.otherParams);
            }
            return parameters;
        }

        public override void Validate()
        {
            RequestValidator.ValidateRequired("knowledgeids", this.Knowledgeids);
            RequestValidator.ValidateMaxListSize("knowledgeids", this.Knowledgeids, 20);
            RequestValidator.ValidateRequired("source", this.Source);
        }

        #endregion
    }
}
