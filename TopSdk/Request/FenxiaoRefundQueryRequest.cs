using System;
using System.Collections.Generic;
using Top.Api.Util;

namespace Top.Api.Request
{
    /// <summary>
    /// TOP API: taobao.fenxiao.refund.query
    /// </summary>
    public class FenxiaoRefundQueryRequest : BaseTopRequest<Top.Api.Response.FenxiaoRefundQueryResponse>
    {
        /// <summary>
        /// 代销采购退款最迟修改时间。与start_date的最大时间间隔不能超过30天
        /// </summary>
        public Nullable<DateTime> EndDate { get; set; }

        /// <summary>
        /// 页码（大于0的整数。无值或小于1的值按默认值1计）
        /// </summary>
        public Nullable<long> PageNo { get; set; }

        /// <summary>
        /// 每页条数（大于0但小于等于50的整数。无值或大于50或小于1的值按默认值50计）
        /// </summary>
        public Nullable<long> PageSize { get; set; }

        /// <summary>
        /// 是否查询下游买家的退款信息
        /// </summary>
        public Nullable<bool> QuerySellerRefund { get; set; }

        /// <summary>
        /// 代销采购退款单最早修改时间
        /// </summary>
        public Nullable<DateTime> StartDate { get; set; }

        #region ITopRequest Members

        public override string GetApiName()
        {
            return "taobao.fenxiao.refund.query";
        }

        public override IDictionary<string, string> GetParameters()
        {
            TopDictionary parameters = new TopDictionary();
            parameters.Add("end_date", this.EndDate);
            parameters.Add("page_no", this.PageNo);
            parameters.Add("page_size", this.PageSize);
            parameters.Add("query_seller_refund", this.QuerySellerRefund);
            parameters.Add("start_date", this.StartDate);
            if (this.otherParams != null)
            {
                parameters.AddAll(this.otherParams);
            }
            return parameters;
        }

        public override void Validate()
        {
            RequestValidator.ValidateRequired("end_date", this.EndDate);
            RequestValidator.ValidateRequired("start_date", this.StartDate);
        }

        #endregion
    }
}
