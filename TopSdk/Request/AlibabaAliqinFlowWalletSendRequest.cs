using System;
using System.Collections.Generic;
using Top.Api.Response;
using Top.Api.Util;

namespace Top.Api.Request
{
    /// <summary>
    /// TOP API: alibaba.aliqin.flow.wallet.send
    /// </summary>
    public class AlibabaAliqinFlowWalletSendRequest : BaseTopRequest<AlibabaAliqinFlowWalletSendResponse>
    {
        /// <summary>
        /// 发给谁
        /// </summary>
        public string BuyerNick { get; set; }

        /// <summary>
        /// 发送多少
        /// </summary>
        public string Flow { get; set; }

        /// <summary>
        /// 发送原因
        /// </summary>
        public string Reason { get; set; }

        #region ITopRequest Members

        public override string GetApiName()
        {
            return "alibaba.aliqin.flow.wallet.send";
        }

        public override IDictionary<string, string> GetParameters()
        {
            TopDictionary parameters = new TopDictionary();
            parameters.Add("buyer_nick", this.BuyerNick);
            parameters.Add("flow", this.Flow);
            parameters.Add("reason", this.Reason);
            if (this.otherParams != null)
            {
                parameters.AddAll(this.otherParams);
            }
            return parameters;
        }

        public override void Validate()
        {
            RequestValidator.ValidateRequired("buyer_nick", this.BuyerNick);
            RequestValidator.ValidateMaxLength("buyer_nick", this.BuyerNick, 256);
            RequestValidator.ValidateRequired("flow", this.Flow);
            RequestValidator.ValidateMaxLength("flow", this.Flow, 256);
            RequestValidator.ValidateRequired("reason", this.Reason);
            RequestValidator.ValidateMaxLength("reason", this.Reason, 1024);
        }

        #endregion
    }
}
