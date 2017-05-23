using System;
using System.Collections.Generic;
using Top.Api.Util;

namespace Top.Api.Request
{
    /// <summary>
    /// TOP API: taobao.refund.refusereason.get
    /// </summary>
    public class RefundRefusereasonGetRequest : BaseTopRequest<Top.Api.Response.RefundRefusereasonGetResponse>
    {
        /// <summary>
        /// 返回参数
        /// </summary>
        public string Fields { get; set; }

        /// <summary>
        /// 退款编号
        /// </summary>
        public Nullable<long> RefundId { get; set; }

        /// <summary>
        /// 售中或售后
        /// </summary>
        public string RefundPhase { get; set; }

        #region ITopRequest Members

        public override string GetApiName()
        {
            return "taobao.refund.refusereason.get";
        }

        public override IDictionary<string, string> GetParameters()
        {
            TopDictionary parameters = new TopDictionary();
            parameters.Add("fields", this.Fields);
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
            RequestValidator.ValidateRequired("refund_id", this.RefundId);
            RequestValidator.ValidateRequired("refund_phase", this.RefundPhase);
        }

        #endregion
    }
}
