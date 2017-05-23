using System;
using System.Collections.Generic;
using Top.Api.Util;

namespace Top.Api.Request
{
    /// <summary>
    /// TOP API: tmall.brandcat.suiteconf.get
    /// </summary>
    public class TmallBrandcatSuiteconfGetRequest : BaseTopRequest<Top.Api.Response.TmallBrandcatSuiteconfGetResponse>
    {
        #region ITopRequest Members

        public override string GetApiName()
        {
            return "tmall.brandcat.suiteconf.get";
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
