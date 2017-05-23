using System;
using System.Collections.Generic;
using Top.Api.Util;

namespace Top.Api.Request
{
    /// <summary>
    /// TOP API: tmall.product.template.get
    /// </summary>
    public class TmallProductTemplateGetRequest : BaseTopRequest<Top.Api.Response.TmallProductTemplateGetResponse>
    {
        /// <summary>
        /// 类目ID
        /// </summary>
        public Nullable<long> Cid { get; set; }

        #region ITopRequest Members

        public override string GetApiName()
        {
            return "tmall.product.template.get";
        }

        public override IDictionary<string, string> GetParameters()
        {
            TopDictionary parameters = new TopDictionary();
            parameters.Add("cid", this.Cid);
            if (this.otherParams != null)
            {
                parameters.AddAll(this.otherParams);
            }
            return parameters;
        }

        public override void Validate()
        {
            RequestValidator.ValidateRequired("cid", this.Cid);
        }

        #endregion
    }
}
