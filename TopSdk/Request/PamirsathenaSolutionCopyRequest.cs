using System;
using System.Collections.Generic;
using Top.Api.Util;

namespace Top.Api.Request
{
    /// <summary>
    /// TOP API: taobao.pamirsathena.solution.copy
    /// </summary>
    public class PamirsathenaSolutionCopyRequest : BaseTopRequest<Top.Api.Response.PamirsathenaSolutionCopyResponse>
    {
        /// <summary>
        /// 要拷贝数字的用户
        /// </summary>
        public Nullable<long> OtherUserId { get; set; }

        #region ITopRequest Members

        public override string GetApiName()
        {
            return "taobao.pamirsathena.solution.copy";
        }

        public override IDictionary<string, string> GetParameters()
        {
            TopDictionary parameters = new TopDictionary();
            parameters.Add("other_user_id", this.OtherUserId);
            if (this.otherParams != null)
            {
                parameters.AddAll(this.otherParams);
            }
            return parameters;
        }

        public override void Validate()
        {
            RequestValidator.ValidateRequired("other_user_id", this.OtherUserId);
        }

        #endregion
    }
}
