using System;
using System.Collections.Generic;
using Top.Api.Util;

namespace Top.Api.Request
{
    /// <summary>
    /// TOP API: taobao.qianniu.account.receptionability.get
    /// </summary>
    public class QianniuAccountReceptionabilityGetRequest : BaseTopRequest<Top.Api.Response.QianniuAccountReceptionabilityGetResponse>
    {
        /// <summary>
        /// 账号id
        /// </summary>
        public string AccountIds { get; set; }

        /// <summary>
        /// 主账号id
        /// </summary>
        public Nullable<long> MainAcountId { get; set; }

        #region ITopRequest Members

        public override string GetApiName()
        {
            return "taobao.qianniu.account.receptionability.get";
        }

        public override IDictionary<string, string> GetParameters()
        {
            TopDictionary parameters = new TopDictionary();
            parameters.Add("account_ids", this.AccountIds);
            parameters.Add("main_acount_id", this.MainAcountId);
            if (this.otherParams != null)
            {
                parameters.AddAll(this.otherParams);
            }
            return parameters;
        }

        public override void Validate()
        {
            RequestValidator.ValidateRequired("account_ids", this.AccountIds);
            RequestValidator.ValidateMaxListSize("account_ids", this.AccountIds, 100);
            RequestValidator.ValidateRequired("main_acount_id", this.MainAcountId);
        }

        #endregion
    }
}
