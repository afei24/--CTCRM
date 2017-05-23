using System;
using System.Collections.Generic;
using Top.Api.Util;

namespace Top.Api.Request
{
    /// <summary>
    /// TOP API: taobao.fenxiao.distributors.get
    /// </summary>
    public class FenxiaoDistributorsGetRequest : BaseTopRequest<Top.Api.Response.FenxiaoDistributorsGetResponse>
    {
        /// <summary>
        /// 分销商用户名列表。多个之间以“,”分隔;最多支持50个分销商用户名。
        /// </summary>
        public string Nicks { get; set; }

        #region ITopRequest Members

        public override string GetApiName()
        {
            return "taobao.fenxiao.distributors.get";
        }

        public override IDictionary<string, string> GetParameters()
        {
            TopDictionary parameters = new TopDictionary();
            parameters.Add("nicks", this.Nicks);
            if (this.otherParams != null)
            {
                parameters.AddAll(this.otherParams);
            }
            return parameters;
        }

        public override void Validate()
        {
            RequestValidator.ValidateRequired("nicks", this.Nicks);
        }

        #endregion
    }
}
