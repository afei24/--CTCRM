using System;
using System.Collections.Generic;
using Top.Api.Util;

namespace Top.Api.Request
{
    /// <summary>
    /// TOP API: taobao.scitem.outercode.get
    /// </summary>
    public class ScitemOutercodeGetRequest : BaseTopRequest<Top.Api.Response.ScitemOutercodeGetResponse>
    {
        /// <summary>
        /// 商品编码
        /// </summary>
        public string OuterCode { get; set; }

        #region ITopRequest Members

        public override string GetApiName()
        {
            return "taobao.scitem.outercode.get";
        }

        public override IDictionary<string, string> GetParameters()
        {
            TopDictionary parameters = new TopDictionary();
            parameters.Add("outer_code", this.OuterCode);
            if (this.otherParams != null)
            {
                parameters.AddAll(this.otherParams);
            }
            return parameters;
        }

        public override void Validate()
        {
            RequestValidator.ValidateRequired("outer_code", this.OuterCode);
        }

        #endregion
    }
}
