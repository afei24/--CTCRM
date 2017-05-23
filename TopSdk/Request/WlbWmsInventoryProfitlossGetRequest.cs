using System;
using System.Collections.Generic;
using Top.Api.Util;

namespace Top.Api.Request
{
    /// <summary>
    /// TOP API: taobao.wlb.wms.inventory.profitloss.get
    /// </summary>
    public class WlbWmsInventoryProfitlossGetRequest : BaseTopRequest<Top.Api.Response.WlbWmsInventoryProfitlossGetResponse>
    {
        /// <summary>
        /// 菜鸟订单编码
        /// </summary>
        public string CnOrderCode { get; set; }

        #region ITopRequest Members

        public override string GetApiName()
        {
            return "taobao.wlb.wms.inventory.profitloss.get";
        }

        public override IDictionary<string, string> GetParameters()
        {
            TopDictionary parameters = new TopDictionary();
            parameters.Add("cn_order_code", this.CnOrderCode);
            if (this.otherParams != null)
            {
                parameters.AddAll(this.otherParams);
            }
            return parameters;
        }

        public override void Validate()
        {
            RequestValidator.ValidateRequired("cn_order_code", this.CnOrderCode);
        }

        #endregion
    }
}
