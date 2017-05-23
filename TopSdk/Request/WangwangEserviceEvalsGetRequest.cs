using System;
using System.Collections.Generic;
using Top.Api.Util;

namespace Top.Api.Request
{
    /// <summary>
    /// TOP API: taobao.wangwang.eservice.evals.get
    /// </summary>
    public class WangwangEserviceEvalsGetRequest : BaseTopRequest<Top.Api.Response.WangwangEserviceEvalsGetResponse>
    {
        /// <summary>
        /// 结束时间。结束时间和开始时间间隔必须在7天内
        /// </summary>
        public Nullable<DateTime> EndDate { get; set; }

        /// <summary>
        /// 想要查询的账号列表
        /// </summary>
        public string ServiceStaffId { get; set; }

        /// <summary>
        /// 开始时间。查询的开始时间和当前时间比，不能超过14天。且开始时间和结束时间间隔，必须在7天内。
        /// </summary>
        public Nullable<DateTime> StartDate { get; set; }

        #region ITopRequest Members

        public override string GetApiName()
        {
            return "taobao.wangwang.eservice.evals.get";
        }

        public override IDictionary<string, string> GetParameters()
        {
            TopDictionary parameters = new TopDictionary();
            parameters.Add("end_date", this.EndDate);
            parameters.Add("service_staff_id", this.ServiceStaffId);
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
            RequestValidator.ValidateRequired("service_staff_id", this.ServiceStaffId);
            RequestValidator.ValidateMaxListSize("service_staff_id", this.ServiceStaffId, 30);
            RequestValidator.ValidateRequired("start_date", this.StartDate);
        }

        #endregion
    }
}
