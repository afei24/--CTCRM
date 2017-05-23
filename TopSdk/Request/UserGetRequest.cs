using System;
using System.Collections.Generic;
using Top.Api.Util;

namespace Top.Api.Request
{
    /// <summary>
    /// TOP API: taobao.user.get
    /// </summary>
    public class UserGetRequest : BaseTopRequest<Top.Api.Response.UserGetResponse>
    {
        /// <summary>
        /// 需返回的字段列表，可选值为返回值中看得到的所有字段。
        /// </summary>
        public string Fields { get; set; }

        /// <summary>
        /// 用户昵称，session和nick必须传其中一个（其中nick优先），传入nick只能获取用户公开信息，传入session可以获取用户隐私信息
        /// </summary>
        public string Nick { get; set; }

        /// <summary>
        /// 指定哪个入参是混淆入参
        /// </summary>
        public string TopMixParams { get; set; }

        #region ITopRequest Members

        public override string GetApiName()
        {
            return "taobao.user.get";
        }

        public override IDictionary<string, string> GetParameters()
        {
            TopDictionary parameters = new TopDictionary();
            parameters.Add("fields", this.Fields);
            parameters.Add("nick", this.Nick);
            parameters.Add("top_mix_params", this.TopMixParams);
            if (this.otherParams != null)
            {
                parameters.AddAll(this.otherParams);
            }
            return parameters;
        }

        public override void Validate()
        {
            RequestValidator.ValidateRequired("fields", this.Fields);
        }

        #endregion
    }
}
