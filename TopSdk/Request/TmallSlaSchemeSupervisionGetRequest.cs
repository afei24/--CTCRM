using System;
using System.Collections.Generic;
using Top.Api.Util;

namespace Top.Api.Request
{
    /// <summary>
    /// TOP API: tmall.sla.scheme.supervision.get
    /// </summary>
    public class TmallSlaSchemeSupervisionGetRequest : BaseTopRequest<Top.Api.Response.TmallSlaSchemeSupervisionGetResponse>
    {
        /// <summary>
        /// 获取返回结果说明
        /// </summary>
        public string Fields { get; set; }

        #region ITopRequest Members

        public override string GetApiName()
        {
            return "tmall.sla.scheme.supervision.get";
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
        }

        #endregion
    }
}
