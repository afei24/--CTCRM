using System;
using System.Collections.Generic;
using Top.Api.Util;

namespace Top.Api.Request
{
    /// <summary>
    /// TOP API: taobao.fenxiao.order.message.add
    /// </summary>
    public class FenxiaoOrderMessageAddRequest : BaseTopRequest<Top.Api.Response.FenxiaoOrderMessageAddResponse>
    {
        /// <summary>
        /// 留言内容
        /// </summary>
        public string Message { get; set; }

        /// <summary>
        /// 采购单id
        /// </summary>
        public Nullable<long> PurchaseOrderId { get; set; }

        #region ITopRequest Members

        public override string GetApiName()
        {
            return "taobao.fenxiao.order.message.add";
        }

        public override IDictionary<string, string> GetParameters()
        {
            TopDictionary parameters = new TopDictionary();
            parameters.Add("message", this.Message);
            parameters.Add("purchase_order_id", this.PurchaseOrderId);
            if (this.otherParams != null)
            {
                parameters.AddAll(this.otherParams);
            }
            return parameters;
        }

        public override void Validate()
        {
            RequestValidator.ValidateRequired("message", this.Message);
            RequestValidator.ValidateRequired("purchase_order_id", this.PurchaseOrderId);
        }

        #endregion
    }
}
