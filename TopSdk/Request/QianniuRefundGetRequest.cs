using System;
using System.Collections.Generic;
using Top.Api.Util;

namespace Top.Api.Request
{
    /// <summary>
    /// TOP API: taobao.qianniu.refund.get
    /// </summary>
    public class QianniuRefundGetRequest : BaseTopRequest<Top.Api.Response.QianniuRefundGetResponse>
    {
        /// <summary>
        /// 退款id
        /// </summary>
        public Nullable<long> RefundId { get; set; }

        #region ITopRequest Members

        public override string GetApiName()
        {
            return "taobao.qianniu.refund.get";
        }

        public override IDictionary<string, string> GetParameters()
        {
            TopDictionary parameters = new TopDictionary();
            parameters.Add("refund_id", this.RefundId);
            if (this.otherParams != null)
            {
                parameters.AddAll(this.otherParams);
            }
            return parameters;
        }

        public override void Validate()
        {
            RequestValidator.ValidateRequired("refund_id", this.RefundId);
        }

        #endregion
    }
}
