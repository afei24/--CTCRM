using System;
using System.Collections.Generic;
using Top.Api.Util;

namespace Top.Api.Request
{
    /// <summary>
    /// TOP API: taobao.wlb.wms.order.cancel.notify
    /// </summary>
    public class WlbWmsOrderCancelNotifyRequest : BaseTopRequest<Top.Api.Response.WlbWmsOrderCancelNotifyResponse>
    {
        /// <summary>
        /// 订单类型
        /// </summary>
        public string OrderCode { get; set; }

        /// <summary>
        /// 单据类型 601普通入库单、501销退入库单、302 调拨入库单、904其他入库单、301 调拨出库单、901普通出库单、903 其他出库单、201 一般交易出库单 202 B2B交易出库单 502 换货出库单 503 补发出库单、1102 仓内加工作业单、 701 盘亏单、702盘盈单、711 库存状态调整单
        /// </summary>
        public string OrderType { get; set; }

        /// <summary>
        /// 仓库编码
        /// </summary>
        public string StoreCode { get; set; }

        #region ITopRequest Members

        public override string GetApiName()
        {
            return "taobao.wlb.wms.order.cancel.notify";
        }

        public override IDictionary<string, string> GetParameters()
        {
            TopDictionary parameters = new TopDictionary();
            parameters.Add("order_code", this.OrderCode);
            parameters.Add("order_type", this.OrderType);
            parameters.Add("store_code", this.StoreCode);
            if (this.otherParams != null)
            {
                parameters.AddAll(this.otherParams);
            }
            return parameters;
        }

        public override void Validate()
        {
            RequestValidator.ValidateRequired("order_code", this.OrderCode);
            RequestValidator.ValidateRequired("order_type", this.OrderType);
            RequestValidator.ValidateRequired("store_code", this.StoreCode);
        }

        #endregion
    }
}
