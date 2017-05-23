using System;
using System.Collections.Generic;
using Top.Api.Util;

namespace Top.Api.Request
{
    /// <summary>
    /// TOP API: taobao.fenxiao.product.map.delete
    /// </summary>
    public class FenxiaoProductMapDeleteRequest : BaseTopRequest<Top.Api.Response.FenxiaoProductMapDeleteResponse>
    {
        /// <summary>
        /// 分销产品id。
        /// </summary>
        public Nullable<long> ProductId { get; set; }

        /// <summary>
        /// 分销产品的sku id列表，逗号分隔，在有sku时需要指定。
        /// </summary>
        public string SkuIds { get; set; }

        #region ITopRequest Members

        public override string GetApiName()
        {
            return "taobao.fenxiao.product.map.delete";
        }

        public override IDictionary<string, string> GetParameters()
        {
            TopDictionary parameters = new TopDictionary();
            parameters.Add("product_id", this.ProductId);
            parameters.Add("sku_ids", this.SkuIds);
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
