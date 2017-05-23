using System;
using System.Collections.Generic;
using Top.Api.Util;

namespace Top.Api.Request
{
    /// <summary>
    /// TOP API: taobao.fenxiao.requisitions.get
    /// </summary>
    public class FenxiaoRequisitionsGetRequest : BaseTopRequest<Top.Api.Response.FenxiaoRequisitionsGetResponse>
    {
        /// <summary>
        /// 申请结束时间yyyy-MM-dd
        /// </summary>
        public Nullable<DateTime> ApplyEnd { get; set; }

        /// <summary>
        /// 申请开始时间yyyy-MM-dd
        /// </summary>
        public Nullable<DateTime> ApplyStart { get; set; }

        /// <summary>
        /// 页码（大于0的整数，默认1）
        /// </summary>
        public Nullable<long> PageNo { get; set; }

        /// <summary>
        /// 每页记录数（默认20，最大50）
        /// </summary>
        public Nullable<long> PageSize { get; set; }

        /// <summary>
        /// 申请状态（1-申请中、2-成功、3-被退回、4-已撤消、5-过期）
        /// </summary>
        public Nullable<long> Status { get; set; }

        #region ITopRequest Members

        public override string GetApiName()
        {
            return "taobao.fenxiao.requisitions.get";
        }

        public override IDictionary<string, string> GetParameters()
        {
            TopDictionary parameters = new TopDictionary();
            parameters.Add("apply_end", this.ApplyEnd);
            parameters.Add("apply_start", this.ApplyStart);
            parameters.Add("page_no", this.PageNo);
            parameters.Add("page_size", this.PageSize);
            parameters.Add("status", this.Status);
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
