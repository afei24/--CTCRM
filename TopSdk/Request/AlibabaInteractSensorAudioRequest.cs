using System;
using System.Collections.Generic;
using Top.Api.Util;

namespace Top.Api.Request
{
    /// <summary>
    /// TOP API: alibaba.interact.sensor.audio
    /// </summary>
    public class AlibabaInteractSensorAudioRequest : BaseTopRequest<Top.Api.Response.AlibabaInteractSensorAudioResponse>
    {
        #region ITopRequest Members

        public override string GetApiName()
        {
            return "alibaba.interact.sensor.audio";
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
