using System;
using System.Collections.Generic;
using Top.Api.Util;

namespace Top.Api.Request
{
    /// <summary>
    /// TOP API: taobao.wlb.wms.cainiao.bill.query
    /// </summary>
    public class WlbWmsCainiaoBillQueryRequest : BaseTopRequest<Top.Api.Response.WlbWmsCainiaoBillQueryResponse>
    {
        /// <summary>
        /// 起始时间，此字段检索订单最后修改时间， 格式 yyyy-MM-dd HH:mm:ss。
        /// </summary>
        public Nullable<DateTime> EndModifiedTime { get; set; }

        /// <summary>
        /// 订单类型 201 销售出库 501 退货入库 502 换货出库 503 补发出库904 普通入库 903 普通出库单 306 B2B入库单 305 B2B出库单 601 采购入库 901 退供出库单 701 盘点出库 702 盘点入库 711 库存异动单
        /// </summary>
        public string OrderType { get; set; }

        /// <summary>
        /// 页码。（大于0的整数。默认为1）
        /// </summary>
        public Nullable<long> PageNo { get; set; }

        /// <summary>
        /// 每页条数。（每页条数不超过50条。默认为50）
        /// </summary>
        public Nullable<long> PageSize { get; set; }

        /// <summary>
        /// 结束时间，此字段检索订单最后修改时间， 格式 yyyy-MM-dd HH:mm:ss。
        /// </summary>
        public Nullable<DateTime> StartModifiedTime { get; set; }

        #region ITopRequest Members

        public override string GetApiName()
        {
            return "taobao.wlb.wms.cainiao.bill.query";
        }

        public override IDictionary<string, string> GetParameters()
        {
            TopDictionary parameters = new TopDictionary();
            parameters.Add("end_modified_time", this.EndModifiedTime);
            parameters.Add("order_type", this.OrderType);
            parameters.Add("page_no", this.PageNo);
            parameters.Add("page_size", this.PageSize);
            parameters.Add("start_modified_time", this.StartModifiedTime);
            if (this.otherParams != null)
            {
                parameters.AddAll(this.otherParams);
            }
            return parameters;
        }

        public override void Validate()
        {
            RequestValidator.ValidateRequired("end_modified_time", this.EndModifiedTime);
            RequestValidator.ValidateMaxValue("page_size", this.PageSize, 50);
            RequestValidator.ValidateMinValue("page_size", this.PageSize, 1);
            RequestValidator.ValidateRequired("start_modified_time", this.StartModifiedTime);
        }

        #endregion
    }
}
