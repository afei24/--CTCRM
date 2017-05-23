using System;
using System.Collections.Generic;
using Top.Api.Util;

namespace Top.Api.Request
{
    /// <summary>
    /// TOP API: taobao.fenxiao.product.sku.delete
    /// </summary>
    public class FenxiaoProductSkuDeleteRequest : BaseTopRequest<Top.Api.Response.FenxiaoProductSkuDeleteResponse>
    {
        /// <summary>
        /// 产品id
        /// </summary>
        public Nullable<long> ProductId { get; set; }

        /// <summary>
        /// sku属性
        /// </summary>
        public string Properties { get; set; }

        #region ITopRequest Members

        public override string GetApiName()
        {
            return "taobao.fenxiao.product.sku.delete";
        }

        public override IDictionary<string, string> GetParameters()
        {
            TopDictionary parameters = new TopDictionary();
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
            RequestValidator.ValidateRequired("product_id", this.ProductId);
            RequestValidator.ValidateRequired("properties", this.Properties);
        }

        #endregion
    }
}
