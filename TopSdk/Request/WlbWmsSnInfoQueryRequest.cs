using System;
using System.Collections.Generic;
using Top.Api.Util;

namespace Top.Api.Request
{
    /// <summary>
    /// TOP API: taobao.wlb.wms.sn.info.query
    /// </summary>
    public class WlbWmsSnInfoQueryRequest : BaseTopRequest<Top.Api.Response.WlbWmsSnInfoQueryResponse>
    {
        /// <summary>
        /// 订单编码
        /// </summary>
        public string OrderCode { get; set; }

        /// <summary>
        /// 订单类型（1:仓配订单 10：配送扫码 20：增值扫码 40:ERP单号; 50：交易订单 ）
        /// </summary>
        public Nullable<long> OrderCodeType { get; set; }

        /// <summary>
        /// 页数，默认每页50条
        /// </summary>
        public Nullable<long> PageIndex { get; set; }

        #region ITopRequest Members

        public override string GetApiName()
        {
            return "taobao.wlb.wms.sn.info.query";
        }

        public override IDictionary<string, string> GetParameters()
        {
            TopDictionary parameters = new TopDictionary();
            parameters.Add("order_code", this.OrderCode);
            parameters.Add("order_code_type", this.OrderCodeType);
            parameters.Add("page_index", this.PageIndex);
            if (this.otherParams != null)
            {
                parameters.AddAll(this.otherParams);
            }
            return parameters;
        }

        public override void Validate()
        {
            RequestValidator.ValidateRequired("order_code", this.OrderCode);
            RequestValidator.ValidateRequired("order_code_type", this.OrderCodeType);
            RequestValidator.ValidateRequired("page_index", this.PageIndex);
        }

        #endregion
    }
}
