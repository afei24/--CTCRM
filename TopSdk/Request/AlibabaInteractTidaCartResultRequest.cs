using System;
using System.Collections.Generic;
using Top.Api.Util;

namespace Top.Api.Request
{
    /// <summary>
    /// TOP API: alibaba.interact.tida.cart.result
    /// </summary>
    public class AlibabaInteractTidaCartResultRequest : BaseTopRequest<Top.Api.Response.AlibabaInteractTidaCartResultResponse>
    {
        /// <summary>
        /// ISV自定义，推荐字符串，慎用json
        /// </summary>
        public string IsvExt { get; set; }

        /// <summary>
        /// tida加购物车接口的商品id
        /// </summary>
        public string ItemId { get; set; }

        /// <summary>
        /// 买家混淆nick
        /// </summary>
        public string MixBuyerNick { get; set; }

        /// <summary>
        /// 卖家昵称
        /// </summary>
        public string SellerNick { get; set; }

        /// <summary>
        /// tida加购物车接口的skuid
        /// </summary>
        public string SkuId { get; set; }

        /// <summary>
        /// 排查线索
        /// </summary>
        public string TraceId { get; set; }

        #region ITopRequest Members

        public override string GetApiName()
        {
            return "alibaba.interact.tida.cart.result";
        }

        public override IDictionary<string, string> GetParameters()
        {
            TopDictionary parameters = new TopDictionary();
            parameters.Add("isv_ext", this.IsvExt);
            parameters.Add("item_id", this.ItemId);
            parameters.Add("mix_buyer_nick", this.MixBuyerNick);
            parameters.Add("seller_nick", this.SellerNick);
            parameters.Add("sku_id", this.SkuId);
            parameters.Add("trace_id", this.TraceId);
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
