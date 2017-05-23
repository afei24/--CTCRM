using System;
using System.Collections.Generic;
using Top.Api.Util;

namespace Top.Api.Request
{
    /// <summary>
    /// TOP API: tmall.item.sizemapping.template.get
    /// </summary>
    public class TmallItemSizemappingTemplateGetRequest : BaseTopRequest<Top.Api.Response.TmallItemSizemappingTemplateGetResponse>
    {
        /// <summary>
        /// 尺码表模板ID
        /// </summary>
        public Nullable<long> TemplateId { get; set; }

        #region ITopRequest Members

        public override string GetApiName()
        {
            return "tmall.item.sizemapping.template.get";
        }

        public override IDictionary<string, string> GetParameters()
        {
            TopDictionary parameters = new TopDictionary();
            parameters.Add("template_id", this.TemplateId);
            if (this.otherParams != null)
            {
                parameters.AddAll(this.otherParams);
            }
            return parameters;
        }

        public override void Validate()
        {
            RequestValidator.ValidateRequired("template_id", this.TemplateId);
        }

        #endregion
    }
}
