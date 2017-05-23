using System;
using System.Collections.Generic;
using Top.Api.Util;

namespace Top.Api.Request
{
    /// <summary>
    /// TOP API: taobao.wireless.bunting.shop.shorturl.create
    /// </summary>
    public class WirelessBuntingShopShorturlCreateRequest : BaseTopRequest<Top.Api.Response.WirelessBuntingShopShorturlCreateResponse>
    {
        /// <summary>
        /// 商店id
        /// </summary>
        public string ShopId { get; set; }

        #region ITopRequest Members

        public override string GetApiName()
        {
            return "taobao.wireless.bunting.shop.shorturl.create";
        }

        public override IDictionary<string, string> GetParameters()
        {
            TopDictionary parameters = new TopDictionary();
            parameters.Add("shop_id", this.ShopId);
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
