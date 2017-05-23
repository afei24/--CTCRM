using System;
using System.Collections.Generic;
using Top.Api.Util;

namespace Top.Api.Request
{
    /// <summary>
    /// TOP API: taobao.crm.members.group.batchadd
    /// </summary>
    public class CrmMembersGroupBatchaddRequest : BaseTopRequest<Top.Api.Response.CrmMembersGroupBatchaddResponse>
    {
        /// <summary>
        /// 买家昵称列表
        /// </summary>
        public string BuyerNicks { get; set; }

        /// <summary>
        /// 分组id
        /// </summary>
        public string GroupIds { get; set; }

        #region ITopRequest Members

        public override string GetApiName()
        {
            return "taobao.crm.members.group.batchadd";
        }

        public override IDictionary<string, string> GetParameters()
        {
            TopDictionary parameters = new TopDictionary();
            parameters.Add("buyer_nicks", this.BuyerNicks);
            parameters.Add("group_ids", this.GroupIds);
            if (this.otherParams != null)
            {
                parameters.AddAll(this.otherParams);
            }
            return parameters;
        }

        public override void Validate()
        {
            RequestValidator.ValidateRequired("buyer_nicks", this.BuyerNicks);
            RequestValidator.ValidateMaxListSize("buyer_nicks", this.BuyerNicks, 20);
            RequestValidator.ValidateRequired("group_ids", this.GroupIds);
            RequestValidator.ValidateMaxListSize("group_ids", this.GroupIds, 10);
        }

        #endregion
    }
}
