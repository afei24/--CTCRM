using System;
using System.Collections.Generic;
using Top.Api.Util;

namespace Top.Api.Request
{
    /// <summary>
    /// TOP API: taobao.fenxiao.cooperation.audit
    /// </summary>
    public class FenxiaoCooperationAuditRequest : BaseTopRequest<Top.Api.Response.FenxiaoCooperationAuditResponse>
    {
        /// <summary>
        /// 1:审批通过，审批通过后要加入授权产品线列表；  2:审批拒绝
        /// </summary>
        public Nullable<long> AuditResult { get; set; }

        /// <summary>
        /// 当审批通过时需要指定授权产品线id列表(代销)，如果没传则表示不开通，且经销和代销的授权产品线列表至少传入一种，同时传入则表示都开通。
        /// </summary>
        public string ProductLineListAgent { get; set; }

        /// <summary>
        /// 当审批通过时需要指定授权产品线id列表(经销)，如果没传则表示不开通，且经销和代销的授权产品线列表至少传入一种，同时传入则表示都开通。
        /// </summary>
        public string ProductLineListDealer { get; set; }

        /// <summary>
        /// 备注
        /// </summary>
        public string Remark { get; set; }

        /// <summary>
        /// 合作申请Id
        /// </summary>
        public Nullable<long> RequisitionId { get; set; }

        #region ITopRequest Members

        public override string GetApiName()
        {
            return "taobao.fenxiao.cooperation.audit";
        }

        public override IDictionary<string, string> GetParameters()
        {
            TopDictionary parameters = new TopDictionary();
            parameters.Add("audit_result", this.AuditResult);
            parameters.Add("product_line_list_agent", this.ProductLineListAgent);
            parameters.Add("product_line_list_dealer", this.ProductLineListDealer);
            parameters.Add("remark", this.Remark);
            parameters.Add("requisition_id", this.RequisitionId);
            if (this.otherParams != null)
            {
                parameters.AddAll(this.otherParams);
            }
            return parameters;
        }

        public override void Validate()
        {
            RequestValidator.ValidateRequired("audit_result", this.AuditResult);
            RequestValidator.ValidateRequired("remark", this.Remark);
            RequestValidator.ValidateRequired("requisition_id", this.RequisitionId);
        }

        #endregion
    }
}
