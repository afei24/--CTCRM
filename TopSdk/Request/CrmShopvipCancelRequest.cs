using System;
using System.Collections.Generic;
using Top.Api.Util;

namespace Top.Api.Request
{
    /// <summary>
    /// TOP API: taobao.crm.shopvip.cancel
    /// </summary>
    public class CrmShopvipCancelRequest : BaseTopRequest<Top.Api.Response.CrmShopvipCancelResponse>
    {
        #region ITopRequest Members

        public override string GetApiName()
        {
            return "taobao.crm.shopvip.cancel";
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
