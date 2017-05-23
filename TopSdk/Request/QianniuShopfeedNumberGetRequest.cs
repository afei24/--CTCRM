using System;
using System.Collections.Generic;
using Top.Api.Util;

namespace Top.Api.Request
{
    /// <summary>
    /// TOP API: taobao.qianniu.shopfeed.number.get
    /// </summary>
    public class QianniuShopfeedNumberGetRequest : BaseTopRequest<Top.Api.Response.QianniuShopfeedNumberGetResponse>
    {
        #region ITopRequest Members

        public override string GetApiName()
        {
            return "taobao.qianniu.shopfeed.number.get";
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
