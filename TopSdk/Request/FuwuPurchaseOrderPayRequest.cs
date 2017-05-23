using System;
using System.Collections.Generic;
using Top.Api.Util;

namespace Top.Api.Request
{
    /// <summary>
    /// TOP API: taobao.fuwu.purchase.order.pay
    /// </summary>
    public class FuwuPurchaseOrderPayRequest : BaseTopRequest<Top.Api.Response.FuwuPurchaseOrderPayResponse>
    {
        /// <summary>
        /// APPKEY，必填
        /// </summary>
        public string Appkey { get; set; }

        /// <summary>
        /// 设备类型，目前只支持PC，可选
        /// </summary>
        public string DeviceType { get; set; }

        /// <summary>
        /// 订单号，与外部订单号二选一
        /// </summary>
        public Nullable<long> OrderId { get; set; }

        /// <summary>
        /// 外部订单号，使用该参数完成查询订单等操作，与外部订单号二选一
        /// </summary>
        public string OutOrderId { get; set; }

        #region ITopRequest Members

        public override string GetApiName()
        {
            return "taobao.fuwu.purchase.order.pay";
        }

        public override IDictionary<string, string> GetParameters()
        {
            TopDictionary parameters = new TopDictionary();
            parameters.Add("appkey", this.Appkey);
            parameters.Add("device_type", this.DeviceType);
            parameters.Add("order_id", this.OrderId);
            parameters.Add("out_order_id", this.OutOrderId);
            if (this.otherParams != null)
            {
                parameters.AddAll(this.otherParams);
            }
            return parameters;
        }

        public override void Validate()
        {
            RequestValidator.ValidateRequired("appkey", this.Appkey);
        }

        #endregion
    }
}
