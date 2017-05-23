using System;
using System.Collections.Generic;
using Top.Api.Util;

namespace Top.Api.Request
{
    /// <summary>
    /// TOP API: taobao.ecloud.top.file.getjangocode
    /// </summary>
    public class EcloudTopFileGetjangocodeRequest : BaseTopRequest<Top.Api.Response.EcloudTopFileGetjangocodeResponse>
    {
        #region ITopRequest Members

        public override string GetApiName()
        {
            return "taobao.ecloud.top.file.getjangocode";
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
