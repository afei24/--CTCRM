using System;
using System.Collections.Generic;
using Top.Api.Util;

namespace Top.Api.Request
{
    /// <summary>
    /// TOP API: taobao.scitem.map.query
    /// </summary>
    public class ScitemMapQueryRequest : BaseTopRequest<Top.Api.Response.ScitemMapQueryResponse>
    {
        /// <summary>
        /// map_type为1：前台ic商品id  map_type为2：分销productid
        /// </summary>
        public Nullable<long> ItemId { get; set; }

        /// <summary>
        /// map_type为1：前台ic商品skuid   map_type为2：分销商品的skuid
        /// </summary>
        public Nullable<long> SkuId { get; set; }

        #region ITopRequest Members

        public override string GetApiName()
        {
            return "taobao.scitem.map.query";
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
        }

        #endregion
    }
}
