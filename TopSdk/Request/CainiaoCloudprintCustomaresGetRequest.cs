using System;
using System.Collections.Generic;
using Top.Api.Util;

namespace Top.Api.Request
{
    /// <summary>
    /// TOP API: cainiao.cloudprint.customares.get
    /// </summary>
    public class CainiaoCloudprintCustomaresGetRequest : BaseTopRequest<Top.Api.Response.CainiaoCloudprintCustomaresGetResponse>
    {
        /// <summary>
        /// 用户使用的标准模板id
        /// </summary>
        public Nullable<long> TemplateId { get; set; }

        #region ITopRequest Members

        public override string GetApiName()
        {
            return "cainiao.cloudprint.customares.get";
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
