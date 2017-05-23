using System;
using System.Collections.Generic;
using Top.Api.Util;

namespace Top.Api.Request
{
    /// <summary>
    /// TOP API: tmall.crm.equity.get
    /// </summary>
    public class TmallCrmEquityGetRequest : BaseTopRequest<Top.Api.Response.TmallCrmEquityGetResponse>
    {
        #region ITopRequest Members

        public override string GetApiName()
        {
            return "tmall.crm.equity.get";
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
