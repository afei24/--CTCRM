using System;
using System.Collections.Generic;
using Top.Api.Util;

namespace Top.Api.Request
{
    /// <summary>
    /// TOP API: taobao.crm.group.update
    /// </summary>
    public class CrmGroupUpdateRequest : BaseTopRequest<Top.Api.Response.CrmGroupUpdateResponse>
    {
        /// <summary>
        /// 分组的id
        /// </summary>
        public Nullable<long> GroupId { get; set; }

        /// <summary>
        /// 新的分组名，分组名称不能包含|或者：
        /// </summary>
        public string NewGroupName { get; set; }

        #region ITopRequest Members

        public override string GetApiName()
        {
            return "taobao.crm.group.update";
        }

        public override IDictionary<string, string> GetParameters()
        {
            TopDictionary parameters = new TopDictionary();
            parameters.Add("group_id", this.GroupId);
            parameters.Add("new_group_name", this.NewGroupName);
            if (this.otherParams != null)
            {
                parameters.AddAll(this.otherParams);
            }
            return parameters;
        }

        public override void Validate()
        {
            RequestValidator.ValidateRequired("group_id", this.GroupId);
            RequestValidator.ValidateMinValue("group_id", this.GroupId, 1);
            RequestValidator.ValidateRequired("new_group_name", this.NewGroupName);
            RequestValidator.ValidateMaxLength("new_group_name", this.NewGroupName, 15);
        }

        #endregion
    }
}
