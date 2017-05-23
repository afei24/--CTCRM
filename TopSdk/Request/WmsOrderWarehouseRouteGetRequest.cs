using System;
using System.Collections.Generic;
using Top.Api.Util;

namespace Top.Api.Request
{
    /// <summary>
    /// TOP API: taobao.wms.order.warehouse.route.get
    /// </summary>
    public class WmsOrderWarehouseRouteGetRequest : BaseTopRequest<Top.Api.Response.WmsOrderWarehouseRouteGetResponse>
    {
        /// <summary>
        /// 订单编号
        /// </summary>
        public string OrderCode { get; set; }

        #region ITopRequest Members

        public override string GetApiName()
        {
            return "taobao.wms.order.warehouse.route.get";
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
