using System;
using System.Collections.Generic;
using Top.Api.Util;

namespace Top.Api.Request
{
    /// <summary>
    /// TOP API: cainiao.cloudprint.isvtemplates.get
    /// </summary>
    public class CainiaoCloudprintIsvtemplatesGetRequest : BaseTopRequest<Top.Api.Response.CainiaoCloudprintIsvtemplatesGetResponse>
    {
        #region ITopRequest Members

        public override string GetApiName()
        {
            return "cainiao.cloudprint.isvtemplates.get";
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
