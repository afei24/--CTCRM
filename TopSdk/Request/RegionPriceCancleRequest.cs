using System;
using System.Collections.Generic;
using Top.Api.Util;

namespace Top.Api.Request
{
    /// <summary>
    /// TOP API: taobao.region.price.cancle
    /// </summary>
    public class RegionPriceCancleRequest : BaseTopRequest<Top.Api.Response.RegionPriceCancleResponse>
    {
        /// <summary>
        /// 商品
        /// </summary>
        public Nullable<long> ItemId { get; set; }

        /// <summary>
        /// 无sku传0
        /// </summary>
        public Nullable<long> SkuId { get; set; }

        #region ITopRequest Members

        public override string GetApiName()
        {
            return "taobao.region.price.cancle";
        }

        public override IDictionary<string, string> GetParameters()
        {
            TopDictionary parameters = new TopDictionary();
            parameters.Add("item_id", this.ItemId);
            parameters.Add("sku_id", this.SkuId);
            if (this.otherParams != null)
            {
                parameters.AddAll(this.otherParams);
            }
            return parameters;
        }

        public override void Validate()
        {
            RequestValidator.ValidateRequired("item_id", this.ItemId);
            RequestValidator.ValidateRequired("sku_id", this.SkuId);
        }

        #endregion
    }
}
