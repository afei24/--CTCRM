using System;
using System.Collections.Generic;
using Top.Api.Util;

namespace Top.Api.Request
{
    /// <summary>
    /// TOP API: alibaba.interact.sensor.openwindow
    /// </summary>
    public class AlibabaInteractSensorOpenwindowRequest : BaseTopRequest<Top.Api.Response.AlibabaInteractSensorOpenwindowResponse>
    {
        #region ITopRequest Members

        public override string GetApiName()
        {
            return "alibaba.interact.sensor.openwindow";
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
