using System;
using System.Collections.Generic;
using Top.Api.Util;

namespace Top.Api.Request
{
    /// <summary>
    /// TOP API: taobao.wangwang.eservice.streamweigths.get
    /// </summary>
    public class WangwangEserviceStreamweigthsGetRequest : BaseTopRequest<Top.Api.Response.WangwangEserviceStreamweigthsGetResponse>
    {
        #region ITopRequest Members

        public override string GetApiName()
        {
            return "taobao.wangwang.eservice.streamweigths.get";
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
