using System;
using System.Collections.Generic;
using Top.Api.Util;

namespace Top.Api.Request
{
    /// <summary>
    /// TOP API: tmall.product.specs.get
    /// </summary>
    public class TmallProductSpecsGetRequest : BaseTopRequest<Top.Api.Response.TmallProductSpecsGetResponse>
    {
        /// <summary>
        /// 类目的ID号，该id必须和properties同时传入。 而且只有当product_id不传入的时候才起效果。<br> product_id不传时，该参数必传
        /// </summary>
        public Nullable<long> CatId { get; set; }

        /// <summary>
        /// 产品的ID。这个不能和properties和cat_id同时起效果<br> properties 和cat_id 均不传时，该参数必传。
        /// </summary>
        public Nullable<long> ProductId { get; set; }

        /// <summary>
        /// 关键属性的字符串，pid:vid;pid:vid 该字段必须和cat_id同时传入才起效果。 而且只有当product_id不传入的时候才起效果。<br>product_id 不传时该参数必传
        /// </summary>
        public string Properties { get; set; }

        #region ITopRequest Members

        public override string GetApiName()
        {
            return "tmall.product.specs.get";
        }

        public override IDictionary<string, string> GetParameters()
        {
            TopDictionary parameters = new TopDictionary();
            parameters.Add("cat_id", this.CatId);
            parameters.Add("product_id", this.ProductId);
            parameters.Add("properties", this.Properties);
            if (this.otherParams != null)
            {
                parameters.AddAll(this.otherParams);
            }
            return parameters;
        }

        public override void Validate()
        {
        }

        #endregion
    }
}
