using System;
using System.Collections.Generic;
using Top.Api.Util;

namespace Top.Api.Request
{
    /// <summary>
    /// TOP API: tmall.brandcat.control.get
    /// </summary>
    public class TmallBrandcatControlGetRequest : BaseTopRequest<Top.Api.Response.TmallBrandcatControlGetResponse>
    {
        #region ITopRequest Members

        public override string GetApiName()
        {
            return "tmall.brandcat.control.get";
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
