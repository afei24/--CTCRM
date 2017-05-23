using System;
using System.Collections.Generic;
using Top.Api.Util;

namespace Top.Api.Request
{
    /// <summary>
    /// TOP API: taobao.wangwang.eservice.groupmember.get
    /// </summary>
    public class WangwangEserviceGroupmemberGetRequest : BaseTopRequest<Top.Api.Response.WangwangEserviceGroupmemberGetResponse>
    {
        /// <summary>
        /// 主帐号ID：cntaobao+淘宝nick，例如cntaobaotest
        /// </summary>
        public string ManagerId { get; set; }

        #region ITopRequest Members

        public override string GetApiName()
        {
            return "taobao.wangwang.eservice.groupmember.get";
        }

        public override IDictionary<string, string> GetParameters()
        {
            TopDictionary parameters = new TopDictionary();
            parameters.Add("manager_id", this.ManagerId);
            if (this.otherParams != null)
            {
                parameters.AddAll(this.otherParams);
            }
            return parameters;
        }

        public override void Validate()
        {
            RequestValidator.ValidateRequired("manager_id", this.ManagerId);
            RequestValidator.ValidateMaxLength("manager_id", this.ManagerId, 128);
        }

        #endregion
    }
}
