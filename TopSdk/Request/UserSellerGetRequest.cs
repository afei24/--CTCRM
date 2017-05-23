using System;
using System.Collections.Generic;
using Top.Api.Util;

namespace Top.Api.Request
{
    /// <summary>
    /// TOP API: taobao.user.seller.get
    /// </summary>
    public class UserSellerGetRequest : BaseTopRequest<Top.Api.Response.UserSellerGetResponse>
    {
        /// <summary>
        /// 需要返回的字段列表，可选值为返回示例值中的可以看到的字段
        /// </summary>
        public string Fields { get; set; }

        #region ITopRequest Members

        public override string GetApiName()
        {
            return "taobao.user.seller.get";
        }

        public override IDictionary<string, string> GetParameters()
        {
            TopDictionary parameters = new TopDictionary();
            parameters.Add("fields", this.Fields);
            if (this.otherParams != null)
            {
                parameters.AddAll(this.otherParams);
            }
            return parameters;
        }

        public override void Validate()
        {
            RequestValidator.ValidateRequired("fields", this.Fields);
            RequestValidator.ValidateMaxListSize("fields", this.Fields, 200);
        }

        #endregion
    }
}
