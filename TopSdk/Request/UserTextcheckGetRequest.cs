using System;
using System.Collections.Generic;
using Top.Api.Util;

namespace Top.Api.Request
{
    /// <summary>
    /// TOP API: taobao.user.textcheck.get
    /// </summary>
    public class UserTextcheckGetRequest : BaseTopRequest<Top.Api.Response.UserTextcheckGetResponse>
    {
        /// <summary>
        /// isv的APP对应的key
        /// </summary>
        public string AppId { get; set; }

        /// <summary>
        /// 用户ugc内容
        /// </summary>
        public string Content { get; set; }

        #region ITopRequest Members

        public override string GetApiName()
        {
            return "taobao.user.textcheck.get";
        }

        public override IDictionary<string, string> GetParameters()
        {
            TopDictionary parameters = new TopDictionary();
            parameters.Add("app_id", this.AppId);
            parameters.Add("content", this.Content);
            if (this.otherParams != null)
            {
                parameters.AddAll(this.otherParams);
            }
            return parameters;
        }

        public override void Validate()
        {
            RequestValidator.ValidateRequired("app_id", this.AppId);
            RequestValidator.ValidateRequired("content", this.Content);
        }

        #endregion
    }
}
