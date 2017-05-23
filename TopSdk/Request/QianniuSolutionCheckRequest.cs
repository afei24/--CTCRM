using System;
using System.Collections.Generic;
using Top.Api.Util;

namespace Top.Api.Request
{
    /// <summary>
    /// TOP API: taobao.qianniu.solution.check
    /// </summary>
    public class QianniuSolutionCheckRequest : BaseTopRequest<Top.Api.Response.QianniuSolutionCheckResponse>
    {
        /// <summary>
        /// 来源
        /// </summary>
        public string From { get; set; }

        /// <summary>
        /// 类型
        /// </summary>
        public string Ref { get; set; }

        /// <summary>
        /// 解决方案
        /// </summary>
        public string SolutionContent { get; set; }

        #region ITopRequest Members

        public override string GetApiName()
        {
            return "taobao.qianniu.solution.check";
        }

        public override IDictionary<string, string> GetParameters()
        {
            TopDictionary parameters = new TopDictionary();
            parameters.Add("from", this.From);
            parameters.Add("ref", this.Ref);
            parameters.Add("solution_content", this.SolutionContent);
            if (this.otherParams != null)
            {
                parameters.AddAll(this.otherParams);
            }
            return parameters;
        }

        public override void Validate()
        {
            RequestValidator.ValidateRequired("from", this.From);
            RequestValidator.ValidateRequired("ref", this.Ref);
            RequestValidator.ValidateRequired("solution_content", this.SolutionContent);
        }

        #endregion
    }
}
