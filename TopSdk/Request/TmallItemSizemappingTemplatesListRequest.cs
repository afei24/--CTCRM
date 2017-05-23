using System;
using System.Collections.Generic;
using Top.Api.Util;

namespace Top.Api.Request
{
    /// <summary>
    /// TOP API: tmall.item.sizemapping.templates.list
    /// </summary>
    public class TmallItemSizemappingTemplatesListRequest : BaseTopRequest<Top.Api.Response.TmallItemSizemappingTemplatesListResponse>
    {
        #region ITopRequest Members

        public override string GetApiName()
        {
            return "tmall.item.sizemapping.templates.list";
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
