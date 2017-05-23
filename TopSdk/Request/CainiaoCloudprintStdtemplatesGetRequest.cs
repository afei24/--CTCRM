using System;
using System.Collections.Generic;
using Top.Api.Util;

namespace Top.Api.Request
{
    /// <summary>
    /// TOP API: cainiao.cloudprint.stdtemplates.get
    /// </summary>
    public class CainiaoCloudprintStdtemplatesGetRequest : BaseTopRequest<Top.Api.Response.CainiaoCloudprintStdtemplatesGetResponse>
    {
        #region ITopRequest Members

        public override string GetApiName()
        {
            return "cainiao.cloudprint.stdtemplates.get";
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
