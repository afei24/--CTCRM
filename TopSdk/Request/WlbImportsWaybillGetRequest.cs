using System;
using System.Collections.Generic;
using Top.Api.Util;

namespace Top.Api.Request
{
    /// <summary>
    /// TOP API: taobao.wlb.imports.waybill.get
    /// </summary>
    public class WlbImportsWaybillGetRequest : BaseTopRequest<Top.Api.Response.WlbImportsWaybillGetResponse>
    {
        /// <summary>
        /// 物流订单号
        /// </summary>
        public string OrderCode { get; set; }

        #region ITopRequest Members

        public override string GetApiName()
        {
            return "taobao.wlb.imports.waybill.get";
        }

        public override IDictionary<string, string> GetParameters()
        {
            TopDictionary parameters = new TopDictionary();
            parameters.Add("order_code", this.OrderCode);
            if (this.otherParams != null)
            {
                parameters.AddAll(this.otherParams);
            }
            return parameters;
        }

        public override void Validate()
        {
            RequestValidator.ValidateRequired("order_code", this.OrderCode);
        }

        #endregion
    }
}
