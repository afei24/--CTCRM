using System;
using System.Collections.Generic;
using Top.Api.Util;

namespace Top.Api.Request
{
    /// <summary>
    /// TOP API: taobao.rp.returngoods.refill
    /// </summary>
    public class RpReturngoodsRefillRequest : BaseTopRequest<Top.Api.Response.RpReturngoodsRefillResponse>
    {
        /// <summary>
        /// 物流公司编号
        /// </summary>
        public string LogisticsCompanyCode { get; set; }

        /// <summary>
        /// 物流公司运单号
        /// </summary>
        public string LogisticsWaybillNo { get; set; }

        /// <summary>
        /// 退款单编号
        /// </summary>
        public Nullable<long> RefundId { get; set; }

        /// <summary>
        /// 退款阶段，可选值：售中：onsale，售后：aftersale
        /// </summary>
        public string RefundPhase { get; set; }

        #region ITopRequest Members

        public override string GetApiName()
        {
            return "taobao.rp.returngoods.refill";
        }

        public override IDictionary<string, string> GetParameters()
        {
            TopDictionary parameters = new TopDictionary();
            parameters.Add("logistics_company_code", this.LogisticsCompanyCode);
            parameters.Add("logistics_waybill_no", this.LogisticsWaybillNo);
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
            RequestValidator.ValidateRequired("logistics_company_code", this.LogisticsCompanyCode);
            RequestValidator.ValidateRequired("logistics_waybill_no", this.LogisticsWaybillNo);
            RequestValidator.ValidateRequired("refund_id", this.RefundId);
            RequestValidator.ValidateRequired("refund_phase", this.RefundPhase);
        }

        #endregion
    }
}
