using System;
using System.Collections.Generic;
using Top.Api.Util;

namespace Top.Api.Request
{
    /// <summary>
    /// TOP API: taobao.wlb.imports.order.get
    /// </summary>
    public class WlbImportsOrderGetRequest : BaseTopRequest<Top.Api.Response.WlbImportsOrderGetResponse>
    {
        /// <summary>
        /// 交易订单结束创建时间
        /// </summary>
        public Nullable<DateTime> GmtCreateEnd { get; set; }

        /// <summary>
        /// 交易订单开始创建时间
        /// </summary>
        public Nullable<DateTime> GmtCreateStart { get; set; }

        /// <summary>
        /// 页码。取值范围:大于零的整数; 默认值:1
        /// </summary>
        public Nullable<long> PageNo { get; set; }

        /// <summary>
        /// 每页条数。取值范围:大于0小于等于100的整数; 默认值:40; 最小值：1；最大值:20
        /// </summary>
        public Nullable<long> PageSize { get; set; }

        /// <summary>
        /// 物流订单状态编码。以下依（物流订单状态编码，描述）的形式列举出来：(TIN_CONSING,发货中),(SENT_WAIT_COMPANY_MAKE_SURE,待仓库收货),(ORDER_CANCELED,订单关闭),(COMPANY_MAKE_SURE,海外仓已揽收),(REJECTED_RECEIVED_BY_COMPANY,海外仓拒收),(ORDER_REFUNDING,退货中),(ORDER_REFUND_BY_COMPANY,订单已退货),(EXCEPTION_IN_COMPANY,海外仓内异常),(FAILED_PAID_SHIPPING_FEE,支付失败),(PAID_SHIPPING_FEE,待仓库发货),(COMPANY_CONSIGN_CONFIRM,海外仓已发货),(WAIT_CUSTOMS_MAKE_SURE,清关已收货),(EXCEPTION_IN_CUSTOMS,清关异常),(CUSTOMSING,清关中),(COMPANY_DELIVERY,国内配送)。
        /// </summary>
        public string StatusCode { get; set; }

        /// <summary>
        /// 交易订单号
        /// </summary>
        public Nullable<long> TradeId { get; set; }

        #region ITopRequest Members

        public override string GetApiName()
        {
            return "taobao.wlb.imports.order.get";
        }

        public override IDictionary<string, string> GetParameters()
        {
            TopDictionary parameters = new TopDictionary();
            parameters.Add("gmt_create_end", this.GmtCreateEnd);
            parameters.Add("gmt_create_start", this.GmtCreateStart);
            parameters.Add("page_no", this.PageNo);
            parameters.Add("page_size", this.PageSize);
            parameters.Add("status_code", this.StatusCode);
            parameters.Add("trade_id", this.TradeId);
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
