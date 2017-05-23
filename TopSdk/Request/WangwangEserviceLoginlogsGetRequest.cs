using System;
using System.Collections.Generic;
using Top.Api.Util;

namespace Top.Api.Request
{
    /// <summary>
    /// TOP API: taobao.wangwang.eservice.loginlogs.get
    /// </summary>
    public class WangwangEserviceLoginlogsGetRequest : BaseTopRequest<Top.Api.Response.WangwangEserviceLoginlogsGetResponse>
    {
        /// <summary>
        /// 查询登录日志的结束时间，必须按示例的格式，否则会返回错误
        /// </summary>
        public Nullable<DateTime> EndDate { get; set; }

        /// <summary>
        /// 需要查询登录日志的账号列表
        /// </summary>
        public string ServiceStaffId { get; set; }

        /// <summary>
        /// 查询登录日志的开始日期，必须按示例的格式，否则会返回错误
        /// </summary>
        public Nullable<DateTime> StartDate { get; set; }

        #region ITopRequest Members

        public override string GetApiName()
        {
            return "taobao.wangwang.eservice.loginlogs.get";
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
