using System;
using System.Collections.Generic;
using Top.Api.Util;

namespace Top.Api.Request
{
    /// <summary>
    /// TOP API: taobao.item.templates.get
    /// </summary>
    public class ItemTemplatesGetRequest : BaseTopRequest<Top.Api.Response.ItemTemplatesGetResponse>
    {
        #region ITopRequest Members

        public override string GetApiName()
        {
            return "taobao.item.templates.get";
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
