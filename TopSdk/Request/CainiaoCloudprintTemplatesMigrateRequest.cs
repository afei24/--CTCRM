using System;
using System.Collections.Generic;
using Top.Api.Util;

namespace Top.Api.Request
{
    /// <summary>
    /// TOP API: cainiao.cloudprint.templates.migrate
    /// </summary>
    public class CainiaoCloudprintTemplatesMigrateRequest : BaseTopRequest<Top.Api.Response.CainiaoCloudprintTemplatesMigrateResponse>
    {
        /// <summary>
        /// 自定义区内容
        /// </summary>
        public string CustomAreaContent { get; set; }

        /// <summary>
        /// 自定义区名称
        /// </summary>
        public string CustomAreaName { get; set; }

        /// <summary>
        /// 标准电子面单模板的id
        /// </summary>
        public Nullable<long> TempalteId { get; set; }

        #region ITopRequest Members

        public override string GetApiName()
        {
            return "cainiao.cloudprint.templates.migrate";
        }

        public override IDictionary<string, string> GetParameters()
        {
            TopDictionary parameters = new TopDictionary();
            parameters.Add("custom_area_content", this.CustomAreaContent);
            parameters.Add("custom_area_name", this.CustomAreaName);
            parameters.Add("tempalte_id", this.TempalteId);
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
