using System;
using System.Collections.Generic;
using Top.Api.Util;

namespace Top.Api.Request
{
    /// <summary>
    /// TOP API: taobao.fenxiao.dealer.requisitionorder.agree
    /// </summary>
    public class FenxiaoDealerRequisitionorderAgreeRequest : BaseTopRequest<Top.Api.Response.FenxiaoDealerRequisitionorderAgreeResponse>
    {
        /// <summary>
        /// 采购申请/经销采购单编号
        /// </summary>
        public Nullable<long> DealerOrderId { get; set; }

        #region ITopRequest Members

        public override string GetApiName()
        {
            return "taobao.fenxiao.dealer.requisitionorder.agree";
        }

        public override IDictionary<string, string> GetParameters()
        {
            TopDictionary parameters = new TopDictionary();
            parameters.Add("dealer_order_id", this.DealerOrderId);
            if (this.otherParams != null)
            {
                parameters.AddAll(this.otherParams);
            }
            return parameters;
        }

        public override void Validate()
        {
            RequestValidator.ValidateRequired("dealer_order_id", this.DealerOrderId);
        }

        #endregion
    }
}
