using System;
using System.Collections.Generic;
using Top.Api.Util;

namespace Top.Api.Request
{
    /// <summary>
    /// TOP API: taobao.pamirsathena.solution.upgrade
    /// </summary>
    public class PamirsathenaSolutionUpgradeRequest : BaseTopRequest<Top.Api.Response.PamirsathenaSolutionUpgradeResponse>
    {
        /// <summary>
        /// 升级至云端
        /// </summary>
        public string RegisterStatus { get; set; }

        #region ITopRequest Members

        public override string GetApiName()
        {
            return "taobao.pamirsathena.solution.upgrade";
        }

        public override IDictionary<string, string> GetParameters()
        {
            TopDictionary parameters = new TopDictionary();
            parameters.Add("register_status", this.RegisterStatus);
            if (this.otherParams != null)
            {
                parameters.AddAll(this.otherParams);
            }
            return parameters;
        }

        public override void Validate()
        {
        }

        #endregion
    }
}
