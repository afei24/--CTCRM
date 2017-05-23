using System;
using System.Collections.Generic;
using Top.Api.Util;

namespace Top.Api.Request
{
    /// <summary>
    /// TOP API: alibaba.interact.sensor.makeup
    /// </summary>
    public class AlibabaInteractSensorMakeupRequest : BaseTopRequest<Top.Api.Response.AlibabaInteractSensorMakeupResponse>
    {
        #region ITopRequest Members

        public override string GetApiName()
        {
            return "alibaba.interact.sensor.makeup";
        }

        public override IDictionary<string, string> GetParameters()
        {
            TopDictionary parameters = new TopDictionary();
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
