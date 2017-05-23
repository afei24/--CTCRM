using System;
using System.Collections.Generic;
using Top.Api.Util;

namespace Top.Api.Request
{
    /// <summary>
    /// TOP API: tmall.product.spec.get
    /// </summary>
    public class TmallProductSpecGetRequest : BaseTopRequest<Top.Api.Response.TmallProductSpecGetResponse>
    {
        /// <summary>
        /// 要获取信息的产品规格信息。
        /// </summary>
        public Nullable<long> SpecId { get; set; }

        #region ITopRequest Members

        public override string GetApiName()
        {
            return "tmall.product.spec.get";
        }

        public override IDictionary<string, string> GetParameters()
        {
            TopDictionary parameters = new TopDictionary();
            parameters.Add("spec_id", this.SpecId);
            if (this.otherParams != null)
            {
                parameters.AddAll(this.otherParams);
            }
            return parameters;
        }

        public override void Validate()
        {
            RequestValidator.ValidateRequired("spec_id", this.SpecId);
        }

        #endregion
    }
}
