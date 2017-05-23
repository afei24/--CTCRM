using System;
using System.Collections.Generic;
using Top.Api.Util;

namespace Top.Api.Request
{
    /// <summary>
    /// TOP API: alibaba.interact.isvadmin.getpondbyinteract
    /// </summary>
    public class AlibabaInteractIsvadminGetpondbyinteractRequest : BaseTopRequest<Top.Api.Response.AlibabaInteractIsvadminGetpondbyinteractResponse>
    {
        /// <summary>
        /// 互动实例ID
        /// </summary>
        public string InteractId { get; set; }

        #region ITopRequest Members

        public override string GetApiName()
        {
            return "alibaba.interact.isvadmin.getpondbyinteract";
        }

        public override IDictionary<string, string> GetParameters()
        {
            TopDictionary parameters = new TopDictionary();
            parameters.Add("interact_id", this.InteractId);
            if (this.otherParams != null)
            {
                parameters.AddAll(this.otherParams);
            }
            return parameters;
        }

        public override void Validate()
        {
            RequestValidator.ValidateRequired("interact_id", this.InteractId);
        }

        #endregion
    }
}
