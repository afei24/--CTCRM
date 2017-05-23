using System;
using System.Collections.Generic;
using Top.Api.Util;

namespace Top.Api.Request
{
    /// <summary>
    /// TOP API: alibaba.interact.sensor.gutil
    /// </summary>
    public class AlibabaInteractSensorGutilRequest : BaseTopRequest<Top.Api.Response.AlibabaInteractSensorGutilResponse>
    {
        #region ITopRequest Members

        public override string GetApiName()
        {
            return "alibaba.interact.sensor.gutil";
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
