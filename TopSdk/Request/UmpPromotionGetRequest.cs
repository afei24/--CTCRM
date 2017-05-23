using System;
using System.Collections.Generic;
using Top.Api.Util;

namespace Top.Api.Request
{
    /// <summary>
    /// TOP API: taobao.ump.promotion.get
    /// </summary>
    public class UmpPromotionGetRequest : BaseTopRequest<Top.Api.Response.UmpPromotionGetResponse>
    {
        /// <summary>
        /// 渠道来源，第三方站点
        /// </summary>
        public string ChannelKey { get; set; }

        /// <summary>
        /// 商品id
        /// </summary>
        public Nullable<long> ItemId { get; set; }

        #region ITopRequest Members

        public override string GetApiName()
        {
            return "taobao.ump.promotion.get";
        }

        public override IDictionary<string, string> GetParameters()
        {
            TopDictionary parameters = new TopDictionary();
            parameters.Add("channel_key", this.ChannelKey);
            parameters.Add("item_id", this.ItemId);
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
