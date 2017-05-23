using System;
using System.Collections.Generic;
using Top.Api.Util;

namespace Top.Api.Request
{
    /// <summary>
    /// TOP API: taobao.rp.refund.review
    /// </summary>
    public class RpRefundReviewRequest : BaseTopRequest<Top.Api.Response.RpRefundReviewResponse>
    {
        /// <summary>
        /// 审核留言
        /// </summary>
        public string Message { get; set; }

        /// <summary>
        /// 审核人姓名
        /// </summary>
        public string Operator { get; set; }

        /// <summary>
        /// 退款单编号
        /// </summary>
        public Nullable<long> RefundId { get; set; }

        /// <summary>
        /// 退款阶段，可选值：售中：onsale，售后：aftersale
        /// </summary>
        public string RefundPhase { get; set; }

        /// <summary>
        /// 退款最后更新时间，以时间戳的方式表示
        /// </summary>
        public Nullable<long> RefundVersion { get; set; }

        /// <summary>
        /// 审核是否可用于批量退款，可选值：true（审核通过），false（审核不通过或反审核）
        /// </summary>
        public Nullable<bool> Result { get; set; }

        #region ITopRequest Members

        public override string GetApiName()
        {
            return "taobao.rp.refund.review";
        }

        public override IDictionary<string, string> GetParameters()
        {
            TopDictionary parameters = new TopDictionary();
            parameters.Add("message", this.Message);
            parameters.Add("operator", this.Operator);
            parameters.Add("refund_id", this.RefundId);
            parameters.Add("refund_phase", this.RefundPhase);
            parameters.Add("refund_version", this.RefundVersion);
            parameters.Add("result", this.Result);
            if (this.otherParams != null)
            {
                parameters.AddAll(this.otherParams);
            }
            return parameters;
        }

        public override void Validate()
        {
            RequestValidator.ValidateRequired("message", this.Message);
            RequestValidator.ValidateRequired("operator", this.Operator);
            RequestValidator.ValidateRequired("refund_id", this.RefundId);
            RequestValidator.ValidateRequired("refund_phase", this.RefundPhase);
            RequestValidator.ValidateRequired("refund_version", this.RefundVersion);
            RequestValidator.ValidateRequired("result", this.Result);
        }

        #endregion
    }
}
