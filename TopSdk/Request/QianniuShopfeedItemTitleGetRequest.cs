using System;
using System.Collections.Generic;
using Top.Api.Util;

namespace Top.Api.Request
{
    /// <summary>
    /// TOP API: taobao.qianniu.shopfeed.item.title.get
    /// </summary>
    public class QianniuShopfeedItemTitleGetRequest : BaseTopRequest<Top.Api.Response.QianniuShopfeedItemTitleGetResponse>
    {
        /// <summary>
        /// 用户输入的url
        /// </summary>
        public string Url { get; set; }

        #region ITopRequest Members

        public override string GetApiName()
        {
            return "taobao.qianniu.shopfeed.item.title.get";
        }

        public override IDictionary<string, string> GetParameters()
        {
            TopDictionary parameters = new TopDictionary();
            parameters.Add("url", this.Url);
            if (this.otherParams != null)
            {
                parameters.AddAll(this.otherParams);
            }
            return parameters;
        }

        public override void Validate()
        {
            RequestValidator.ValidateRequired("url", this.Url);
        }

        #endregion
    }
}
