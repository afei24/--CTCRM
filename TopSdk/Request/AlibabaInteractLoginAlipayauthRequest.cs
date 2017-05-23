using System;
using System.Collections.Generic;
using Top.Api.Util;

namespace Top.Api.Request
{
    /// <summary>
    /// TOP API: alibaba.interact.login.alipayauth
    /// </summary>
    public class AlibabaInteractLoginAlipayauthRequest : BaseTopRequest<Top.Api.Response.AlibabaInteractLoginAlipayauthResponse>
    {
        #region ITopRequest Members

        public override string GetApiName()
        {
            return "alibaba.interact.login.alipayauth";
        }

        public override IDictionary<string, string> GetParameters()
        {
            TopDictionary parameters = new TopDictionary();
            if (this.otherParams != null)
            {
                parameters.AddAll(this.otherParams);
            }
            return parameters;
        }

        public override void Validate()
        {
        }

        #endregion
    }
}
