using System;
using System.Collections.Generic;
using Top.Api.Util;

namespace Top.Api.Request
{
    /// <summary>
    /// TOP API: taobao.promotion.mjs.get
    /// </summary>
    public class PromotionMjsGetRequest : BaseTopRequest<Top.Api.Response.PromotionMjsGetResponse>
    {
        #region ITopRequest Members

        public override string GetApiName()
        {
            return "taobao.promotion.mjs.get";
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
