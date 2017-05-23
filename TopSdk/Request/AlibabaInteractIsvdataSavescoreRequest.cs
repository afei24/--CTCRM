using System;
using System.Collections.Generic;
using Top.Api.Util;

namespace Top.Api.Request
{
    /// <summary>
    /// TOP API: alibaba.interact.isvdata.savescore
    /// </summary>
    public class AlibabaInteractIsvdataSavescoreRequest : BaseTopRequest<Top.Api.Response.AlibabaInteractIsvdataSavescoreResponse>
    {
        /// <summary>
        /// 互动实例ID
        /// </summary>
        public string InteractId { get; set; }

        /// <summary>
        /// 用户分数
        /// </summary>
        public Nullable<long> Score { get; set; }

        #region ITopRequest Members

        public override string GetApiName()
        {
            return "alibaba.interact.isvdata.savescore";
        }

        public override IDictionary<string, string> GetParameters()
        {
            TopDictionary parameters = new TopDictionary();
            parameters.Add("interact_id", this.InteractId);
            parameters.Add("score", this.Score);
            if (this.otherParams != null)
            {
                parameters.AddAll(this.otherParams);
            }
            return parameters;
        }

        public override void Validate()
        {
            RequestValidator.ValidateRequired("interact_id", this.InteractId);
            RequestValidator.ValidateRequired("score", this.Score);
        }

        #endregion
    }
}
