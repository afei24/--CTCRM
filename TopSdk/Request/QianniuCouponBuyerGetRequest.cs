using System;
using System.Collections.Generic;
using Top.Api.Util;

namespace Top.Api.Request
{
    /// <summary>
    /// TOP API: taobao.qianniu.coupon.buyer.get
    /// </summary>
    public class QianniuCouponBuyerGetRequest : BaseTopRequest<Top.Api.Response.QianniuCouponBuyerGetResponse>
    {
        /// <summary>
        /// 买家nick
        /// </summary>
        public string BuyerNick { get; set; }

        #region ITopRequest Members

        public override string GetApiName()
        {
            return "taobao.qianniu.coupon.buyer.get";
        }

        public override IDictionary<string, string> GetParameters()
        {
            TopDictionary parameters = new TopDictionary();
            parameters.Add("buyer_nick", this.BuyerNick);
            if (this.otherParams != null)
            {
                parameters.AddAll(this.otherParams);
            }
            return parameters;
        }

        public override void Validate()
        {
            RequestValidator.ValidateRequired("buyer_nick", this.BuyerNick);
        }

        #endregion
    }
}
