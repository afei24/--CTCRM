using System;
using System.Collections.Generic;
using Top.Api.Util;

namespace Top.Api.Request
{
    /// <summary>
    /// TOP API: taobao.crm.group.add
    /// </summary>
    public class CrmGroupAddRequest : BaseTopRequest<Top.Api.Response.CrmGroupAddResponse>
    {
        /// <summary>
        /// 分组名称，每个卖家最多可以拥有100个分组
        /// </summary>
        public string GroupName { get; set; }

        #region ITopRequest Members

        public override string GetApiName()
        {
            return "taobao.crm.group.add";
        }

        public override IDictionary<string, string> GetParameters()
        {
            TopDictionary parameters = new TopDictionary();
            parameters.Add("group_name", this.GroupName);
            if (this.otherParams != null)
            {
                parameters.AddAll(this.otherParams);
            }
            return parameters;
        }

        public override void Validate()
        {
            RequestValidator.ValidateRequired("group_name", this.GroupName);
            RequestValidator.ValidateMaxLength("group_name", this.GroupName, 15);
        }

        #endregion
    }
}
