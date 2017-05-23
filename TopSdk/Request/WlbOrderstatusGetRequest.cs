using System;
using System.Collections.Generic;
using Top.Api.Util;

namespace Top.Api.Request
{
    /// <summary>
    /// TOP API: taobao.wlb.orderstatus.get
    /// </summary>
    public class WlbOrderstatusGetRequest : BaseTopRequest<Top.Api.Response.WlbOrderstatusGetResponse>
    {
        /// <summary>
        /// 物流宝订单编码
        /// </summary>
        public string OrderCode { get; set; }

        #region ITopRequest Members

        public override string GetApiName()
        {
            return "taobao.wlb.orderstatus.get";
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
