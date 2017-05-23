using System;
using System.Collections.Generic;
using Top.Api.Util;

namespace Top.Api.Request
{
    /// <summary>
    /// TOP API: taobao.crm.grouptask.check
    /// </summary>
    public class CrmGrouptaskCheckRequest : BaseTopRequest<Top.Api.Response.CrmGrouptaskCheckResponse>
    {
        /// <summary>
        /// 分组id
        /// </summary>
        public Nullable<long> GroupId { get; set; }

        #region ITopRequest Members

        public override string GetApiName()
        {
            return "taobao.crm.grouptask.check";
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
        }

        #endregion
    }
}
