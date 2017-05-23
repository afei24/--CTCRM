using System;
using System.Collections.Generic;
using Top.Api.Util;

namespace Top.Api.Request
{
    /// <summary>
    /// TOP API: taobao.ma.packcode.create
    /// </summary>
    public class MaPackcodeCreateRequest : BaseTopRequest<Top.Api.Response.MaPackcodeCreateResponse>
    {
        #region ITopRequest Members

        public override string GetApiName()
        {
            return "taobao.ma.packcode.create";
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
