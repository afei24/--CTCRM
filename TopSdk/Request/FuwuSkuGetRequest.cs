using System;
using System.Collections.Generic;
using Top.Api.Util;

namespace Top.Api.Request
{
    /// <summary>
    /// TOP API: taobao.fuwu.sku.get
    /// </summary>
    public class FuwuSkuGetRequest : BaseTopRequest<Top.Api.Response.FuwuSkuGetResponse>
    {
        /// <summary>
        /// 应用注册在开放平台的的Appkey
        /// </summary>
        public string AppKey { get; set; }

        /// <summary>
        /// 服务code
        /// </summary>
        public string ArticleCode { get; set; }

        /// <summary>
        /// 用户的淘宝nick
        /// </summary>
        public string Nick { get; set; }

        #region ITopRequest Members

        public override string GetApiName()
        {
            return "taobao.fuwu.sku.get";
        }

        public override IDictionary<string, string> GetParameters()
        {
            TopDictionary parameters = new TopDictionary();
            parameters.Add("appKey", this.AppKey);
            parameters.Add("article_code", this.ArticleCode);
            parameters.Add("nick", this.Nick);
            if (this.otherParams != null)
            {
                parameters.AddAll(this.otherParams);
            }
            return parameters;
        }

        public override void Validate()
        {
            RequestValidator.ValidateRequired("appKey", this.AppKey);
            RequestValidator.ValidateRequired("article_code", this.ArticleCode);
            RequestValidator.ValidateRequired("nick", this.Nick);
        }

        #endregion
    }
}
