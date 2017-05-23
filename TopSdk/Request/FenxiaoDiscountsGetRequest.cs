using System;
using System.Collections.Generic;
using Top.Api.Util;

namespace Top.Api.Request
{
    /// <summary>
    /// TOP API: taobao.fenxiao.discounts.get
    /// </summary>
    public class FenxiaoDiscountsGetRequest : BaseTopRequest<Top.Api.Response.FenxiaoDiscountsGetResponse>
    {
        /// <summary>
        /// 折扣ID
        /// </summary>
        public Nullable<long> DiscountId { get; set; }

        /// <summary>
        /// 指定查询额外的信息，可选值：DETAIL（查询折扣详情），多个可选值用逗号分割。（只允许指定折扣ID情况下使用）
        /// </summary>
        public string ExtFields { get; set; }

        #region ITopRequest Members

        public override string GetApiName()
        {
            return "taobao.fenxiao.discounts.get";
        }

        public override IDictionary<string, string> GetParameters()
        {
            TopDictionary parameters = new TopDictionary();
            parameters.Add("discount_id", this.DiscountId);
            parameters.Add("ext_fields", this.ExtFields);
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
