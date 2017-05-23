using System;
using System.Collections.Generic;
using Top.Api.Util;

namespace Top.Api.Request
{
    /// <summary>
    /// TOP API: taobao.wlb.orderdetail.date.get
    /// </summary>
    public class WlbOrderdetailDateGetRequest : BaseTopRequest<Top.Api.Response.WlbOrderdetailDateGetResponse>
    {
        /// <summary>
        /// 创建时间结束
        /// </summary>
        public Nullable<DateTime> EndTime { get; set; }

        /// <summary>
        /// 分页下标
        /// </summary>
        public Nullable<long> PageNo { get; set; }

        /// <summary>
        /// 分页大小
        /// </summary>
        public Nullable<long> PageSize { get; set; }

        /// <summary>
        /// 创建时间起始
        /// </summary>
        public Nullable<DateTime> StartTime { get; set; }

        #region ITopRequest Members

        public override string GetApiName()
        {
            return "taobao.wlb.orderdetail.date.get";
        }

        public override IDictionary<string, string> GetParameters()
        {
            TopDictionary parameters = new TopDictionary();
            parameters.Add("end_time", this.EndTime);
            parameters.Add("page_no", this.PageNo);
            parameters.Add("page_size", this.PageSize);
            parameters.Add("start_time", this.StartTime);
            if (this.otherParams != null)
            {
                parameters.AddAll(this.otherParams);
            }
            return parameters;
        }

        public override void Validate()
        {
            RequestValidator.ValidateRequired("end_time", this.EndTime);
            RequestValidator.ValidateRequired("start_time", this.StartTime);
        }

        #endregion
    }
}
