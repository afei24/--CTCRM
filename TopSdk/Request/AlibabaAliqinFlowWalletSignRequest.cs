using System;
using System.Collections.Generic;
using Top.Api.Util;

namespace Top.Api.Request
{
    /// <summary>
    /// TOP API: alibaba.aliqin.flow.wallet.sign
    /// </summary>
    public class AlibabaAliqinFlowWalletSignRequest : BaseTopRequest<Top.Api.Response.AlibabaAliqinFlowWalletSignResponse>
    {
        /// <summary>
        /// 用户昵称
        /// </summary>
        public string UserNick { get; set; }

        #region ITopRequest Members

        public override string GetApiName()
        {
            return "alibaba.aliqin.flow.wallet.sign";
        }

        public override IDictionary<string, string> GetParameters()
        {
            TopDictionary parameters = new TopDictionary();
            parameters.Add("user_nick", this.UserNick);
            if (this.otherParams != null)
            {
                parameters.AddAll(this.otherParams);
            }
            return parameters;
        }

        public override void Validate()
        {
            RequestValidator.ValidateRequired("user_nick", this.UserNick);
            RequestValidator.ValidateMaxLength("user_nick", this.UserNick, 64);
        }

        #endregion
    }
}
