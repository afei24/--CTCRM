using System;
using System.Collections.Generic;
using Top.Api.Util;

namespace Top.Api.Request
{
    /// <summary>
    /// TOP API: taobao.sellercenter.subusers.get
    /// </summary>
    public class SellercenterSubusersGetRequest : BaseTopRequest<Top.Api.Response.SellercenterSubusersGetResponse>
    {
        /// <summary>
        /// 表示卖家昵称
        /// </summary>
        public string Nick { get; set; }

        #region ITopRequest Members

        public override string GetApiName()
        {
            return "taobao.sellercenter.subusers.get";
        }

        public override IDictionary<string, string> GetParameters()
        {
            TopDictionary parameters = new TopDictionary();
            parameters.Add("nick", this.Nick);
            if (this.otherParams != null)
            {
                parameters.AddAll(this.otherParams);
            }
            return parameters;
        }

        public override void Validate()
        {
            RequestValidator.ValidateRequired("nick", this.Nick);
        }

        #endregion
    }
}
