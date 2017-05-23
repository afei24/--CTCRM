using System;
using System.Collections.Generic;
using Top.Api.Util;

namespace Top.Api.Request
{
    /// <summary>
    /// TOP API: taobao.crm.group.delete
    /// </summary>
    public class CrmGroupDeleteRequest : BaseTopRequest<Top.Api.Response.CrmGroupDeleteResponse>
    {
        /// <summary>
        /// 要删除的分组id
        /// </summary>
        public Nullable<long> GroupId { get; set; }

        #region ITopRequest Members

        public override string GetApiName()
        {
            return "taobao.crm.group.delete";
        }

        public override IDictionary<string, string> GetParameters()
        {
            TopDictionary parameters = new TopDictionary();
            parameters.Add("group_id", this.GroupId);
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
        }

        #endregion
    }
}
