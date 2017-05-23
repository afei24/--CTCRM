using System;
using System.Collections.Generic;
using Top.Api.Util;

namespace Top.Api.Request
{
    /// <summary>
    /// TOP API: taobao.qianniu.coupon.seller.get
    /// </summary>
    public class QianniuCouponSellerGetRequest : BaseTopRequest<Top.Api.Response.QianniuCouponSellerGetResponse>
    {
        /// <summary>
        /// 当前页号
        /// </summary>
        public Nullable<long> CurrentPage { get; set; }

        /// <summary>
        /// 分页大小
        /// </summary>
        public Nullable<long> PageSize { get; set; }

        #region ITopRequest Members

        public override string GetApiName()
        {
            return "taobao.qianniu.coupon.seller.get";
        }

        public override IDictionary<string, string> GetParameters()
        {
            TopDictionary parameters = new TopDictionary();
            parameters.Add("current_page", this.CurrentPage);
            parameters.Add("page_size", this.PageSize);
            if (this.otherParams != null)
            {
                parameters.AddAll(this.otherParams);
            }
            return parameters;
        }

        public override void Validate()
        {
            RequestValidator.ValidateRequired("current_page", this.CurrentPage);
            RequestValidator.ValidateRequired("page_size", this.PageSize);
        }

        #endregion
    }
}
