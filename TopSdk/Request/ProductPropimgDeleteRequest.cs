using System;
using System.Collections.Generic;
using Top.Api.Util;

namespace Top.Api.Request
{
    /// <summary>
    /// TOP API: taobao.product.propimg.delete
    /// </summary>
    public class ProductPropimgDeleteRequest : BaseTopRequest<Top.Api.Response.ProductPropimgDeleteResponse>
    {
        /// <summary>
        /// 属性图片ID
        /// </summary>
        public Nullable<long> Id { get; set; }

        /// <summary>
        /// 产品ID.Product的id.
        /// </summary>
        public Nullable<long> ProductId { get; set; }

        #region ITopRequest Members

        public override string GetApiName()
        {
            return "taobao.product.propimg.delete";
        }

        public override IDictionary<string, string> GetParameters()
        {
            TopDictionary parameters = new TopDictionary();
            parameters.Add("id", this.Id);
            parameters.Add("product_id", this.ProductId);
            if (this.otherParams != null)
            {
                parameters.AddAll(this.otherParams);
            }
            return parameters;
        }

        public override void Validate()
        {
            RequestValidator.ValidateRequired("id", this.Id);
            RequestValidator.ValidateRequired("product_id", this.ProductId);
        }

        #endregion
    }
}
