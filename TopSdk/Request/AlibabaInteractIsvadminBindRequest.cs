using System;
using System.Collections.Generic;
using Top.Api.Util;

namespace Top.Api.Request
{
    /// <summary>
    /// TOP API: alibaba.interact.isvadmin.bind
    /// </summary>
    public class AlibabaInteractIsvadminBindRequest : BaseTopRequest<Top.Api.Response.AlibabaInteractIsvadminBindResponse>
    {
        /// <summary>
        /// 互动结束时间
        /// </summary>
        public Nullable<DateTime> EndTime { get; set; }

        /// <summary>
        /// 互动实例名称
        /// </summary>
        public string InstanceName { get; set; }

        /// <summary>
        /// 描述信息
        /// </summary>
        public string InteractDescription { get; set; }

        /// <summary>
        /// 奖池ID
        /// </summary>
        public string LotteryCode { get; set; }

        /// <summary>
        /// 互动开始时间
        /// </summary>
        public Nullable<DateTime> StartTime { get; set; }

        #region ITopRequest Members

        public override string GetApiName()
        {
            return "alibaba.interact.isvadmin.bind";
        }

        public override IDictionary<string, string> GetParameters()
        {
            TopDictionary parameters = new TopDictionary();
            parameters.Add("end_time", this.EndTime);
            parameters.Add("instance_name", this.InstanceName);
            parameters.Add("interact_description", this.InteractDescription);
            parameters.Add("lottery_code", this.LotteryCode);
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
            RequestValidator.ValidateRequired("instance_name", this.InstanceName);
            RequestValidator.ValidateRequired("interact_description", this.InteractDescription);
            RequestValidator.ValidateRequired("lottery_code", this.LotteryCode);
            RequestValidator.ValidateRequired("start_time", this.StartTime);
        }

        #endregion
    }
}
