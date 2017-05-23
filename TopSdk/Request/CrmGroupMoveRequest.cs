using System;
using System.Collections.Generic;
using Top.Api.Util;

namespace Top.Api.Request
{
    /// <summary>
    /// TOP API: taobao.crm.group.move
    /// </summary>
    public class CrmGroupMoveRequest : BaseTopRequest<Top.Api.Response.CrmGroupMoveResponse>
    {
        /// <summary>
        /// 需要移动的分组
        /// </summary>
        public Nullable<long> FromGroupId { get; set; }

        /// <summary>
        /// 目的分组
        /// </summary>
        public Nullable<long> ToGroupId { get; set; }

        #region ITopRequest Members

        public override string GetApiName()
        {
            return "taobao.crm.group.move";
        }

        public override IDictionary<string, string> GetParameters()
        {
            TopDictionary parameters = new TopDictionary();
            parameters.Add("from_group_id", this.FromGroupId);
            parameters.Add("to_group_id", this.ToGroupId);
            if (this.otherParams != null)
            {
                parameters.AddAll(this.otherParams);
            }
            return parameters;
        }

        public override void Validate()
        {
            RequestValidator.ValidateRequired("from_group_id", this.FromGroupId);
            RequestValidator.ValidateMinValue("from_group_id", this.FromGroupId, 1);
            RequestValidator.ValidateRequired("to_group_id", this.ToGroupId);
            RequestValidator.ValidateMinValue("to_group_id", this.ToGroupId, 1);
        }

        #endregion
    }
}
