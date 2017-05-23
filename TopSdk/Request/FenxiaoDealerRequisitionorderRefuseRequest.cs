using System;
using System.Collections.Generic;
using Top.Api.Util;

namespace Top.Api.Request
{
    /// <summary>
    /// TOP API: taobao.fenxiao.dealer.requisitionorder.refuse
    /// </summary>
    public class FenxiaoDealerRequisitionorderRefuseRequest : BaseTopRequest<Top.Api.Response.FenxiaoDealerRequisitionorderRefuseResponse>
    {
        /// <summary>
        /// 采购申请/经销采购单编号
        /// </summary>
        public Nullable<long> DealerOrderId { get; set; }

        /// <summary>
        /// 驳回原因（1：价格不合理；2：采购数量不合理；3：其他原因）
        /// </summary>
        public Nullable<long> Reason { get; set; }

        /// <summary>
        /// 驳回详细原因，字数范围5-200字
        /// </summary>
        public string ReasonDetail { get; set; }

        #region ITopRequest Members

        public override string GetApiName()
        {
            return "taobao.fenxiao.dealer.requisitionorder.refuse";
        }

        public override IDictionary<string, string> GetParameters()
        {
            TopDictionary parameters = new TopDictionary();
            parameters.Add("dealer_order_id", this.DealerOrderId);
            parameters.Add("reason", this.Reason);
            parameters.Add("reason_detail", this.ReasonDetail);
            if (this.otherParams != null)
            {
                parameters.AddAll(this.otherParams);
            }
            return parameters;
        }

        public override void Validate()
        {
            RequestValidator.ValidateRequired("dealer_order_id", this.DealerOrderId);
            RequestValidator.ValidateRequired("reason", this.Reason);
            RequestValidator.ValidateRequired("reason_detail", this.ReasonDetail);
        }

        #endregion
    }
}
