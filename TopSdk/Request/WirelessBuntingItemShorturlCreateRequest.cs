using System;
using System.Collections.Generic;
using Top.Api.Util;

namespace Top.Api.Request
{
    /// <summary>
    /// TOP API: taobao.wireless.bunting.item.shorturl.create
    /// </summary>
    public class WirelessBuntingItemShorturlCreateRequest : BaseTopRequest<Top.Api.Response.WirelessBuntingItemShorturlCreateResponse>
    {
        /// <summary>
        /// 商品ID
        /// </summary>
        public string ItemId { get; set; }

        #region ITopRequest Members

        public override string GetApiName()
        {
            return "taobao.wireless.bunting.item.shorturl.create";
        }

        public override IDictionary<string, string> GetParameters()
        {
            TopDictionary parameters = new TopDictionary();
            parameters.Add("item_id", this.ItemId);
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
