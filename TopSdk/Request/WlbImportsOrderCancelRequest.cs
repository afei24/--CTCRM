using System;
using System.Collections.Generic;
using Top.Api.Util;

namespace Top.Api.Request
{
    /// <summary>
    /// TOP API: taobao.wlb.imports.order.cancel
    /// </summary>
    public class WlbImportsOrderCancelRequest : BaseTopRequest<Top.Api.Response.WlbImportsOrderCancelResponse>
    {
        /// <summary>
        /// 物流订单编号
        /// </summary>
        public string LgorderCode { get; set; }

        #region ITopRequest Members

        public override string GetApiName()
        {
            return "taobao.wlb.imports.order.cancel";
        }

        public override IDictionary<string, string> GetParameters()
        {
            TopDictionary parameters = new TopDictionary();
            parameters.Add("lgorder_code", this.LgorderCode);
            if (this.otherParams != null)
            {
                parameters.AddAll(this.otherParams);
            }
            return parameters;
        }

        public override void Validate()
        {
            RequestValidator.ValidateRequired("lgorder_code", this.LgorderCode);
        }

        #endregion
    }
}
