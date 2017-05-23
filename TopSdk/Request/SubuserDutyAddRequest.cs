using System;
using System.Collections.Generic;
using Top.Api.Util;

namespace Top.Api.Request
{
    /// <summary>
    /// TOP API: taobao.subuser.duty.add
    /// </summary>
    public class SubuserDutyAddRequest : BaseTopRequest<Top.Api.Response.SubuserDutyAddResponse>
    {
        /// <summary>
        /// 职务级别
        /// </summary>
        public Nullable<long> DutyLevel { get; set; }

        /// <summary>
        /// 职务名称
        /// </summary>
        public string DutyName { get; set; }

        /// <summary>
        /// 主账号用户名
        /// </summary>
        public string UserNick { get; set; }

        #region ITopRequest Members

        public override string GetApiName()
        {
            return "taobao.subuser.duty.add";
        }

        public override IDictionary<string, string> GetParameters()
        {
            TopDictionary parameters = new TopDictionary();
            parameters.Add("duty_level", this.DutyLevel);
            parameters.Add("duty_name", this.DutyName);
            parameters.Add("user_nick", this.UserNick);
            if (this.otherParams != null)
            {
                parameters.AddAll(this.otherParams);
            }
            return parameters;
        }

        public override void Validate()
        {
            RequestValidator.ValidateRequired("duty_level", this.DutyLevel);
            RequestValidator.ValidateRequired("duty_name", this.DutyName);
            RequestValidator.ValidateRequired("user_nick", this.UserNick);
        }

        #endregion
    }
}
