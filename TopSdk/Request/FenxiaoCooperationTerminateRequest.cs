using System;
using System.Collections.Generic;
using Top.Api.Util;

namespace Top.Api.Request
{
    /// <summary>
    /// TOP API: taobao.fenxiao.cooperation.terminate
    /// </summary>
    public class FenxiaoCooperationTerminateRequest : BaseTopRequest<Top.Api.Response.FenxiaoCooperationTerminateResponse>
    {
        /// <summary>
        /// 合作编号
        /// </summary>
        public Nullable<long> CooperateId { get; set; }

        /// <summary>
        /// 终止天数，可选1,2,3,5,7,15，在多少天数内终止
        /// </summary>
        public Nullable<long> EndRemainDays { get; set; }

        /// <summary>
        /// 终止说明（5-2000字）
        /// </summary>
        public string EndRemark { get; set; }

        #region ITopRequest Members

        public override string GetApiName()
        {
            return "taobao.fenxiao.cooperation.terminate";
        }

        public override IDictionary<string, string> GetParameters()
        {
            TopDictionary parameters = new TopDictionary();
            parameters.Add("cooperate_id", this.CooperateId);
            parameters.Add("end_remain_days", this.EndRemainDays);
            parameters.Add("end_remark", this.EndRemark);
            if (this.otherParams != null)
            {
                parameters.AddAll(this.otherParams);
            }
            return parameters;
        }

        public override void Validate()
        {
            RequestValidator.ValidateRequired("cooperate_id", this.CooperateId);
            RequestValidator.ValidateRequired("end_remain_days", this.EndRemainDays);
            RequestValidator.ValidateRequired("end_remark", this.EndRemark);
            RequestValidator.ValidateMaxLength("end_remark", this.EndRemark, 2000);
        }

        #endregion
    }
}
