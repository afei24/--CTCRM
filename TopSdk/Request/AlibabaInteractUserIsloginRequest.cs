using System;
using System.Collections.Generic;
using Top.Api.Util;

namespace Top.Api.Request
{
    /// <summary>
    /// TOP API: alibaba.interact.user.islogin
    /// </summary>
    public class AlibabaInteractUserIsloginRequest : BaseTopRequest<Top.Api.Response.AlibabaInteractUserIsloginResponse>
    {
        /// <summary>
        /// 用户nick
        /// </summary>
        public string BuyerNick { get; set; }

        #region ITopRequest Members

        public override string GetApiName()
        {
            return "alibaba.interact.user.islogin";
        }

        public override IDictionary<string, string> GetParameters()
        {
            TopDictionary parameters = new TopDictionary();
            parameters.Add("buyer_nick", this.BuyerNick);
            if (this.otherParams != null)
            {
                parameters.AddAll(this.otherParams);
            }
            return parameters;
        }

        public override void Validate()
        {
            RequestValidator.ValidateRequired("buyer_nick", this.BuyerNick);
        }

        #endregion
    }
}
