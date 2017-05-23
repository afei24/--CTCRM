using System;
using System.Collections.Generic;
using Top.Api.Util;

namespace Top.Api.Request
{
    /// <summary>
    /// TOP API: taobao.weitao.feed.isrelation
    /// </summary>
    public class WeitaoFeedIsrelationRequest : BaseTopRequest<Top.Api.Response.WeitaoFeedIsrelationResponse>
    {
        /// <summary>
        /// 要查询的粉丝的淘宝昵称
        /// </summary>
        public string FansNick { get; set; }

        /// <summary>
        /// 要查询的公共账号的淘宝昵称
        /// </summary>
        public string SellerNick { get; set; }

        #region ITopRequest Members

        public override string GetApiName()
        {
            return "taobao.weitao.feed.isrelation";
        }

        public override IDictionary<string, string> GetParameters()
        {
            TopDictionary parameters = new TopDictionary();
            parameters.Add("fans_nick", this.FansNick);
            parameters.Add("seller_nick", this.SellerNick);
            if (this.otherParams != null)
            {
                parameters.AddAll(this.otherParams);
            }
            return parameters;
        }

        public override void Validate()
        {
            RequestValidator.ValidateRequired("fans_nick", this.FansNick);
            RequestValidator.ValidateRequired("seller_nick", this.SellerNick);
        }

        #endregion
    }
}
