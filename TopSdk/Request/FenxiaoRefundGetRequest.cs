using System;
using System.Collections.Generic;
using Top.Api.Util;

namespace Top.Api.Request
{
    /// <summary>
    /// TOP API: taobao.fenxiao.refund.get
    /// </summary>
    public class FenxiaoRefundGetRequest : BaseTopRequest<Top.Api.Response.FenxiaoRefundGetResponse>
    {
        /// <summary>
        /// 是否查询下游买家的退款信息
        /// </summary>
        public Nullable<bool> QuerySellerRefund { get; set; }

        /// <summary>
        /// 要查询的退款子单的id
        /// </summary>
        public Nullable<long> SubOrderId { get; set; }

        #region ITopRequest Members

        public override string GetApiName()
        {
            return "taobao.fenxiao.refund.get";
        }

        public override IDictionary<string, string> GetParameters()
        {
            TopDictionary parameters = new TopDictionary();
            parameters.Add("query_seller_refund", this.QuerySellerRefund);
            parameters.Add("sub_order_id", this.SubOrderId);
            if (this.otherParams != null)
            {
                parameters.AddAll(this.otherParams);
            }
            return parameters;
        }

        public override void Validate()
        {
            RequestValidator.ValidateRequired("sub_order_id", this.SubOrderId);
        }

        #endregion
    }
}
