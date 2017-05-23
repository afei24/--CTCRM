using System;
using System.Collections.Generic;
using Top.Api.Util;

namespace Top.Api.Request
{
    /// <summary>
    /// TOP API: taobao.wlb.wms.consign.outstock.get
    /// </summary>
    public class WlbWmsConsignOutstockGetRequest : BaseTopRequest<Top.Api.Response.WlbWmsConsignOutstockGetResponse>
    {
        /// <summary>
        /// 菜鸟订单编码,cnOrderCode与orderCode必须有一个值不可为空
        /// </summary>
        public string CnOrderCode { get; set; }

        /// <summary>
        /// ERP订单编码,cnOrderCode与orderCode必须有一个值不可为空
        /// </summary>
        public string OrderCode { get; set; }

        #region ITopRequest Members

        public override string GetApiName()
        {
            return "taobao.wlb.wms.consign.outstock.get";
        }

        public override IDictionary<string, string> GetParameters()
        {
            TopDictionary parameters = new TopDictionary();
            parameters.Add("cn_order_code", this.CnOrderCode);
            parameters.Add("order_code", this.OrderCode);
            if (this.otherParams != null)
            {
                parameters.AddAll(this.otherParams);
            }
            return parameters;
        }

        public override void Validate()
        {
        }

        #endregion
    }
}
