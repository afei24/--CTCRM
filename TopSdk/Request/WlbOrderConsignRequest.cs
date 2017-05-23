using System;
using System.Collections.Generic;
using Top.Api.Util;

namespace Top.Api.Request
{
    /// <summary>
    /// TOP API: taobao.wlb.order.consign
    /// </summary>
    public class WlbOrderConsignRequest : BaseTopRequest<Top.Api.Response.WlbOrderConsignResponse>
    {
        /// <summary>
        /// 物流宝订单编号
        /// </summary>
        public string WlbOrderCode { get; set; }

        #region ITopRequest Members

        public override string GetApiName()
        {
            return "taobao.wlb.order.consign";
        }

        public override IDictionary<string, string> GetParameters()
        {
            TopDictionary parameters = new TopDictionary();
            parameters.Add("wlb_order_code", this.WlbOrderCode);
            if (this.otherParams != null)
            {
                parameters.AddAll(this.otherParams);
            }
            return parameters;
        }

        public override void Validate()
        {
            RequestValidator.ValidateRequired("wlb_order_code", this.WlbOrderCode);
            RequestValidator.ValidateMaxLength("wlb_order_code", this.WlbOrderCode, 64);
        }

        #endregion
    }
}
