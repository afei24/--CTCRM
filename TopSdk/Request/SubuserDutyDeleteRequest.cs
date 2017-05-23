using System;
using System.Collections.Generic;
using Top.Api.Util;

namespace Top.Api.Request
{
    /// <summary>
    /// TOP API: taobao.subuser.duty.delete
    /// </summary>
    public class SubuserDutyDeleteRequest : BaseTopRequest<Top.Api.Response.SubuserDutyDeleteResponse>
    {
        /// <summary>
        /// 职务ID
        /// </summary>
        public Nullable<long> DutyId { get; set; }

        /// <summary>
        /// 主账号用户名
        /// </summary>
        public string UserNick { get; set; }

        #region ITopRequest Members

        public override string GetApiName()
        {
            return "taobao.subuser.duty.delete";
        }

        public override IDictionary<string, string> GetParameters()
        {
            TopDictionary parameters = new TopDictionary();
            parameters.Add("duty_id", this.DutyId);
            parameters.Add("user_nick", this.UserNick);
            if (this.otherParams != null)
            {
                parameters.AddAll(this.otherParams);
            }
            return parameters;
        }

        public override void Validate()
        {
            RequestValidator.ValidateRequired("duty_id", this.DutyId);
            RequestValidator.ValidateRequired("user_nick", this.UserNick);
        }

        #endregion
    }
}
