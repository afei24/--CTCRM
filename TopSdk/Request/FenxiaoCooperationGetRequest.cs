using System;
using System.Collections.Generic;
using Top.Api.Util;

namespace Top.Api.Request
{
    /// <summary>
    /// TOP API: taobao.fenxiao.cooperation.get
    /// </summary>
    public class FenxiaoCooperationGetRequest : BaseTopRequest<Top.Api.Response.FenxiaoCooperationGetResponse>
    {
        /// <summary>
        /// 合作结束时间yyyy-MM-dd HH:mm:ss
        /// </summary>
        public Nullable<DateTime> EndDate { get; set; }

        /// <summary>
        /// 页码（大于0的整数，默认1）
        /// </summary>
        public Nullable<long> PageNo { get; set; }

        /// <summary>
        /// 每页记录数（默认20，最大50）
        /// </summary>
        public Nullable<long> PageSize { get; set; }

        /// <summary>
        /// 合作开始时间yyyy-MM-dd HH:mm:ss
        /// </summary>
        public Nullable<DateTime> StartDate { get; set; }

        /// <summary>
        /// 合作状态： NORMAL(合作中)、 ENDING(终止中) 、END (终止)
        /// </summary>
        public string Status { get; set; }

        /// <summary>
        /// 分销方式：AGENT(代销) 、DEALER（经销）
        /// </summary>
        public string TradeType { get; set; }

        #region ITopRequest Members

        public override string GetApiName()
        {
            return "taobao.fenxiao.cooperation.get";
        }

        public override IDictionary<string, string> GetParameters()
        {
            TopDictionary parameters = new TopDictionary();
            parameters.Add("end_date", this.EndDate);
            parameters.Add("page_no", this.PageNo);
            parameters.Add("page_size", this.PageSize);
            parameters.Add("start_date", this.StartDate);
            parameters.Add("status", this.Status);
            parameters.Add("trade_type", this.TradeType);
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
