using System;
using System.Collections.Generic;
using Top.Api.Util;

namespace Top.Api.Request
{
    /// <summary>
    /// TOP API: taobao.refund.messages.get
    /// </summary>
    public class RefundMessagesGetRequest : BaseTopRequest<Top.Api.Response.RefundMessagesGetResponse>
    {
        /// <summary>
        /// 需返回的字段列表。可选值：RefundMessage结构体中的所有字段，以半角逗号(,)分隔。
        /// </summary>
        public string Fields { get; set; }

        /// <summary>
        /// 页码
        /// </summary>
        public Nullable<long> PageNo { get; set; }

        /// <summary>
        /// 每页条数
        /// </summary>
        public Nullable<long> PageSize { get; set; }

        /// <summary>
        /// 退款单号
        /// </summary>
        public Nullable<long> RefundId { get; set; }

        /// <summary>
        /// 退款阶段，可选值：onsale（售中），aftersale（售后），天猫退款为必传。
        /// </summary>
        public string RefundPhase { get; set; }

        #region ITopRequest Members

        public override string GetApiName()
        {
            return "taobao.refund.messages.get";
        }

        public override IDictionary<string, string> GetParameters()
        {
            TopDictionary parameters = new TopDictionary();
            parameters.Add("fields", this.Fields);
            parameters.Add("page_no", this.PageNo);
            parameters.Add("page_size", this.PageSize);
            parameters.Add("refund_id", this.RefundId);
            parameters.Add("refund_phase", this.RefundPhase);
            if (this.otherParams != null)
            {
                parameters.AddAll(this.otherParams);
            }
            return parameters;
        }

        public override void Validate()
        {
            RequestValidator.ValidateRequired("fields", this.Fields);
            RequestValidator.ValidateMaxListSize("fields", this.Fields, 100);
            RequestValidator.ValidateMinValue("page_no", this.PageNo, 1);
            RequestValidator.ValidateMaxValue("page_size", this.PageSize, 100);
            RequestValidator.ValidateMinValue("page_size", this.PageSize, 1);
            RequestValidator.ValidateRequired("refund_id", this.RefundId);
            RequestValidator.ValidateMinValue("refund_id", this.RefundId, 1);
        }

        #endregion
    }
}
