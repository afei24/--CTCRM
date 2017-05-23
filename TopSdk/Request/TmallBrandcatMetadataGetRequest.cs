using System;
using System.Collections.Generic;
using Top.Api.Util;

namespace Top.Api.Request
{
    /// <summary>
    /// TOP API: tmall.brandcat.metadata.get
    /// </summary>
    public class TmallBrandcatMetadataGetRequest : BaseTopRequest<Top.Api.Response.TmallBrandcatMetadataGetResponse>
    {
        /// <summary>
        /// 品牌id
        /// </summary>
        public Nullable<long> BrandId { get; set; }

        /// <summary>
        /// 叶子类目id
        /// </summary>
        public Nullable<long> CatId { get; set; }

        #region ITopRequest Members

        public override string GetApiName()
        {
            return "tmall.brandcat.metadata.get";
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
            RequestValidator.ValidateRequired("cat_id", this.CatId);
        }

        #endregion
    }
}
