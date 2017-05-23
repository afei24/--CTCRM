using System;
using System.Collections.Generic;
using Top.Api.Util;

namespace Top.Api.Request
{
    /// <summary>
    /// TOP API: taobao.pamirsathena.solution.add
    /// </summary>
    public class PamirsathenaSolutionAddRequest : BaseTopRequest<Top.Api.Response.PamirsathenaSolutionAddResponse>
    {
        /// <summary>
        /// 发什么快递
        /// </summary>
        public string QuestionDesc { get; set; }

        /// <summary>
        /// 1
        /// </summary>
        public string QuestionTitle { get; set; }

        /// <summary>
        /// 亲,顺丰
        /// </summary>
        public string Solution { get; set; }

        #region ITopRequest Members

        public override string GetApiName()
        {
            return "taobao.pamirsathena.solution.add";
        }

        public override IDictionary<string, string> GetParameters()
        {
            TopDictionary parameters = new TopDictionary();
            parameters.Add("question_desc", this.QuestionDesc);
            parameters.Add("question_title", this.QuestionTitle);
            parameters.Add("solution", this.Solution);
            if (this.otherParams != null)
            {
                parameters.AddAll(this.otherParams);
            }
            return parameters;
        }

        public override void Validate()
        {
            RequestValidator.ValidateRequired("question_desc", this.QuestionDesc);
            RequestValidator.ValidateRequired("question_title", this.QuestionTitle);
            RequestValidator.ValidateRequired("solution", this.Solution);
        }

        #endregion
    }
}
