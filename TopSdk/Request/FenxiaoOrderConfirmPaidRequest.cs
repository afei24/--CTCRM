using System;
using System.Collections.Generic;
using Top.Api.Util;

namespace Top.Api.Request
{
    /// <summary>
    /// TOP API: taobao.fenxiao.order.confirm.paid
    /// </summary>
    public class FenxiaoOrderConfirmPaidRequest : BaseTopRequest<Top.Api.Response.FenxiaoOrderConfirmPaidResponse>
    {
        /// <summary>
        /// 确认支付信息（字数小于100）
        /// </summary>
        public string ConfirmRemark { get; set; }

        /// <summary>
        /// 采购单编号。
        /// </summary>
        public Nullable<long> PurchaseOrderId { get; set; }

        #region ITopRequest Members

        public override string GetApiName()
        {
            return "taobao.fenxiao.order.confirm.paid";
        }

        public override IDictionary<string, string> GetParameters()
        {
            TopDictionary parameters = new TopDictionary();
            parameters.Add("confirm_remark", this.ConfirmRemark);
            parameters.Add("purchase_order_id", this.PurchaseOrderId);
            if (this.otherParams != null)
            {
                parameters.AddAll(this.otherParams);
            }
            return parameters;
        }

        public override void Validate()
        {
            RequestValidator.ValidateRequired("purchase_order_id", this.PurchaseOrderId);
        }

        #endregion
    }
}
