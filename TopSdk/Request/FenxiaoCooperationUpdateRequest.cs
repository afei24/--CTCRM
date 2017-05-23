using System;
using System.Collections.Generic;
using Top.Api.Util;

namespace Top.Api.Request
{
    /// <summary>
    /// TOP API: taobao.fenxiao.cooperation.update
    /// </summary>
    public class FenxiaoCooperationUpdateRequest : BaseTopRequest<Top.Api.Response.FenxiaoCooperationUpdateResponse>
    {
        /// <summary>
        /// 分销商ID
        /// </summary>
        public Nullable<long> DistributorId { get; set; }

        /// <summary>
        /// 等级ID(0代表取消)
        /// </summary>
        public Nullable<long> GradeId { get; set; }

        /// <summary>
        /// 分销方式(新增)： AGENT(代销)、DEALER(经销)(默认为代销)
        /// </summary>
        public string TradeType { get; set; }

        #region ITopRequest Members

        public override string GetApiName()
        {
            return "taobao.fenxiao.cooperation.update";
        }

        public override IDictionary<string, string> GetParameters()
        {
            TopDictionary parameters = new TopDictionary();
            parameters.Add("distributor_id", this.DistributorId);
            parameters.Add("grade_id", this.GradeId);
            parameters.Add("trade_type", this.TradeType);
            if (this.otherParams != null)
            {
                parameters.AddAll(this.otherParams);
            }
            return parameters;
        }

        public override void Validate()
        {
            RequestValidator.ValidateRequired("distributor_id", this.DistributorId);
            RequestValidator.ValidateRequired("grade_id", this.GradeId);
        }

        #endregion
    }
}
