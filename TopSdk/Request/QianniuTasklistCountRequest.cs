using System;
using System.Collections.Generic;
using Top.Api.Util;

namespace Top.Api.Request
{
    /// <summary>
    /// TOP API: taobao.qianniu.tasklist.count
    /// </summary>
    public class QianniuTasklistCountRequest : BaseTopRequest<Top.Api.Response.QianniuTasklistCountResponse>
    {
        #region ITopRequest Members

        public override string GetApiName()
        {
            return "taobao.qianniu.tasklist.count";
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
