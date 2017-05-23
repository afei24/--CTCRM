using System;
using System.Collections.Generic;
using Top.Api.Util;

namespace Top.Api.Request
{
    /// <summary>
    /// TOP API: cainiao.cloudprint.customarea.update
    /// </summary>
    public class CainiaoCloudprintCustomareaUpdateRequest : BaseTopRequest<Top.Api.Response.CainiaoCloudprintCustomareaUpdateResponse>
    {
        /// <summary>
        /// 自定义区内容（可修改）
        /// </summary>
        public string CustomAreaContent { get; set; }

        /// <summary>
        /// 自定义区id（不可修改）
        /// </summary>
        public Nullable<long> CustomAreaId { get; set; }

        /// <summary>
        /// 自定义区名称（可修改）
        /// </summary>
        public string CustomAreaName { get; set; }

        #region ITopRequest Members

        public override string GetApiName()
        {
            return "cainiao.cloudprint.customarea.update";
        }

        public override IDictionary<string, string> GetParameters()
        {
            TopDictionary parameters = new TopDictionary();
            parameters.Add("custom_area_content", this.CustomAreaContent);
            parameters.Add("custom_area_id", this.CustomAreaId);
            parameters.Add("custom_area_name", this.CustomAreaName);
            if (this.otherParams != null)
            {
                parameters.AddAll(this.otherParams);
            }
            return parameters;
        }

        public override void Validate()
        {
            RequestValidator.ValidateRequired("custom_area_content", this.CustomAreaContent);
            RequestValidator.ValidateRequired("custom_area_id", this.CustomAreaId);
            RequestValidator.ValidateRequired("custom_area_name", this.CustomAreaName);
        }

        #endregion
    }
}
