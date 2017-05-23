using System;
using System.Collections.Generic;
using Top.Api.Util;

namespace Top.Api.Request
{
    /// <summary>
    /// TOP API: alibaba.kds.isv.activitylist
    /// </summary>
    public class AlibabaKdsIsvActivitylistRequest : BaseTopRequest<Top.Api.Response.AlibabaKdsIsvActivitylistResponse>
    {
        #region ITopRequest Members

        public override string GetApiName()
        {
            return "alibaba.kds.isv.activitylist";
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
