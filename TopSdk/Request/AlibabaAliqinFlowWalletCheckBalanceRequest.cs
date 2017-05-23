using System;
using System.Collections.Generic;
using Top.Api.Util;

namespace Top.Api.Request
{
    /// <summary>
    /// TOP API: alibaba.aliqin.flow.wallet.check.balance
    /// </summary>
    public class AlibabaAliqinFlowWalletCheckBalanceRequest : BaseTopRequest<Top.Api.Response.AlibabaAliqinFlowWalletCheckBalanceResponse>
    {
        /// <summary>
        /// 检查金额档位id
        /// </summary>
        public string GradeId { get; set; }

        #region ITopRequest Members

        public override string GetApiName()
        {
            return "alibaba.aliqin.flow.wallet.check.balance";
        }

        public override IDictionary<string, string> GetParameters()
        {
            TopDictionary parameters = new TopDictionary();
            parameters.Add("grade_id", this.GradeId);
            if (this.otherParams != null)
            {
                parameters.AddAll(this.otherParams);
            }
            return parameters;
        }

        public override void Validate()
        {
            RequestValidator.ValidateRequired("grade_id", this.GradeId);
        }

        #endregion
    }
}
