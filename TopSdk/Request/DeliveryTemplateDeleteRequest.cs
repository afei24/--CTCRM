using System;
using System.Collections.Generic;
using Top.Api.Util;

namespace Top.Api.Request
{
    /// <summary>
    /// TOP API: taobao.delivery.template.delete
    /// </summary>
    public class DeliveryTemplateDeleteRequest : BaseTopRequest<Top.Api.Response.DeliveryTemplateDeleteResponse>
    {
        /// <summary>
        /// 运费模板ID
        /// </summary>
        public Nullable<long> TemplateId { get; set; }

        #region ITopRequest Members

        public override string GetApiName()
        {
            return "taobao.delivery.template.delete";
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
