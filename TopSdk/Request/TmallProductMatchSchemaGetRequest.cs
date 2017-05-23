using System;
using System.Collections.Generic;
using Top.Api.Util;

namespace Top.Api.Request
{
    /// <summary>
    /// TOP API: tmall.product.match.schema.get
    /// </summary>
    public class TmallProductMatchSchemaGetRequest : BaseTopRequest<Top.Api.Response.TmallProductMatchSchemaGetResponse>
    {
        /// <summary>
        /// 商品发布的目标类目，必须是叶子类目
        /// </summary>
        public Nullable<long> CategoryId { get; set; }

        #region ITopRequest Members

        public override string GetApiName()
        {
            return "tmall.product.match.schema.get";
        }

        public override IDictionary<string, string> GetParameters()
        {
            TopDictionary parameters = new TopDictionary();
            parameters.Add("category_id", this.CategoryId);
            if (this.otherParams != null)
            {
                parameters.AddAll(this.otherParams);
            }
            return parameters;
        }

        public override void Validate()
        {
            RequestValidator.ValidateRequired("category_id", this.CategoryId);
        }

        #endregion
    }
}
