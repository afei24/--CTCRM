using System;
using System.Collections.Generic;
using Top.Api.Util;

namespace Top.Api.Request
{
    /// <summary>
    /// TOP API: tmall.product.update.schema.get
    /// </summary>
    public class TmallProductUpdateSchemaGetRequest : BaseTopRequest<Top.Api.Response.TmallProductUpdateSchemaGetResponse>
    {
        /// <summary>
        /// 产品编号
        /// </summary>
        public Nullable<long> ProductId { get; set; }

        #region ITopRequest Members

        public override string GetApiName()
        {
            return "tmall.product.update.schema.get";
        }

        public override IDictionary<string, string> GetParameters()
        {
            TopDictionary parameters = new TopDictionary();
            parameters.Add("product_id", this.ProductId);
            if (this.otherParams != null)
            {
                parameters.AddAll(this.otherParams);
            }
            return parameters;
        }

        public override void Validate()
        {
            RequestValidator.ValidateRequired("product_id", this.ProductId);
        }

        #endregion
    }
}
