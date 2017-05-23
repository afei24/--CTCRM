using System;
using System.Collections.Generic;
using Top.Api.Util;

namespace Top.Api.Request
{
    /// <summary>
    /// TOP API: taobao.wlb.item.delete
    /// </summary>
    public class WlbItemDeleteRequest : BaseTopRequest<Top.Api.Response.WlbItemDeleteResponse>
    {
        /// <summary>
        /// 商品ID
        /// </summary>
        public Nullable<long> ItemId { get; set; }

        /// <summary>
        /// 商品所有人淘宝nick
        /// </summary>
        public string UserNick { get; set; }

        #region ITopRequest Members

        public override string GetApiName()
        {
            return "taobao.wlb.item.delete";
        }

        public override IDictionary<string, string> GetParameters()
        {
            TopDictionary parameters = new TopDictionary();
            parameters.Add("item_id", this.ItemId);
            parameters.Add("user_nick", this.UserNick);
            if (this.otherParams != null)
            {
                parameters.AddAll(this.otherParams);
            }
            return parameters;
        }

        public override void Validate()
        {
            RequestValidator.ValidateRequired("item_id", this.ItemId);
            RequestValidator.ValidateRequired("user_nick", this.UserNick);
        }

        #endregion
    }
}
