using System;
using System.Collections.Generic;
using Top.Api.Util;

namespace Top.Api.Request
{
    /// <summary>
    /// TOP API: alibaba.interact.sensor.social
    /// </summary>
    public class AlibabaInteractSensorSocialRequest : BaseTopRequest<Top.Api.Response.AlibabaInteractSensorSocialResponse>
    {
        /// <summary>
        /// 系统自动生成
        /// </summary>
        public string Id { get; set; }

        #region ITopRequest Members

        public override string GetApiName()
        {
            return "alibaba.interact.sensor.social";
        }

        public override IDictionary<string, string> GetParameters()
        {
            TopDictionary parameters = new TopDictionary();
            parameters.Add("id", this.Id);
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
