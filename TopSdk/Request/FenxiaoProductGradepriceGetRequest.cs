using System;
using System.Collections.Generic;
using Top.Api.Util;

namespace Top.Api.Request
{
    /// <summary>
    /// TOP API: taobao.fenxiao.product.gradeprice.get
    /// </summary>
    public class FenxiaoProductGradepriceGetRequest : BaseTopRequest<Top.Api.Response.FenxiaoProductGradepriceGetResponse>
    {
        /// <summary>
        /// 产品id
        /// </summary>
        public Nullable<long> ProductId { get; set; }

        /// <summary>
        /// skuId
        /// </summary>
        public Nullable<long> SkuId { get; set; }

        /// <summary>
        /// 经、代销模式（1：代销、2：经销）
        /// </summary>
        public Nullable<long> TradeType { get; set; }

        #region ITopRequest Members

        public override string GetApiName()
        {
            return "taobao.fenxiao.product.gradeprice.get";
        }

        public override IDictionary<string, string> GetParameters()
        {
            TopDictionary parameters = new TopDictionary();
            parameters.Add("product_id", this.ProductId);
            parameters.Add("sku_id", this.SkuId);
            parameters.Add("trade_type", this.TradeType);
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
