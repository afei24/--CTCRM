using System;
using System.Collections.Generic;
using Top.Api.Util;

namespace Top.Api.Request
{
    /// <summary>
    /// TOP API: tmall.brandcat.salespro.get
    /// </summary>
    public class TmallBrandcatSalesproGetRequest : BaseTopRequest<Top.Api.Response.TmallBrandcatSalesproGetResponse>
    {
        /// <summary>
        /// 被管控的品牌Id
        /// </summary>
        public Nullable<long> BrandId { get; set; }

        /// <summary>
        /// 被管控的类目Id
        /// </summary>
        public Nullable<long> CatId { get; set; }

        #region ITopRequest Members

        public override string GetApiName()
        {
            return "tmall.brandcat.salespro.get";
        }

        public override IDictionary<string, string> GetParameters()
        {
            TopDictionary parameters = new TopDictionary();
            parameters.Add("brand_id", this.BrandId);
            parameters.Add("cat_id", this.CatId);
            if (this.otherParams != null)
            {
                parameters.AddAll(this.otherParams);
            }
            return parameters;
        }

        public override void Validate()
        {
            RequestValidator.ValidateRequired("brand_id", this.BrandId);
            RequestValidator.ValidateRequired("cat_id", this.CatId);
        }

        #endregion
    }
}
