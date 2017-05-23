using System;
using System.Collections.Generic;
using Top.Api.Util;

namespace Top.Api.Request
{
    /// <summary>
    /// TOP API: taobao.users.get
    /// </summary>
    public class UsersGetRequest : BaseTopRequest<Top.Api.Response.UsersGetResponse>
    {
        /// <summary>
        /// 查询字段：User数据结构的公开信息字段列表，以半角逗号(,)分隔
        /// </summary>
        public string Fields { get; set; }

        /// <summary>
        /// 用户昵称，多个以半角逗号(,)分隔，最多40个
        /// </summary>
        public string Nicks { get; set; }

        #region ITopRequest Members

        public override string GetApiName()
        {
            return "taobao.users.get";
        }

        public override IDictionary<string, string> GetParameters()
        {
            TopDictionary parameters = new TopDictionary();
            parameters.Add("fields", this.Fields);
            parameters.Add("nicks", this.Nicks);
            if (this.otherParams != null)
            {
                parameters.AddAll(this.otherParams);
            }
            return parameters;
        }

        public override void Validate()
        {
            RequestValidator.ValidateRequired("fields", this.Fields);
            RequestValidator.ValidateMaxListSize("fields", this.Fields, 20);
            RequestValidator.ValidateRequired("nicks", this.Nicks);
        }

        #endregion
    }
}
