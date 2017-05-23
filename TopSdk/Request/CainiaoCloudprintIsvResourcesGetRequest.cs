using System;
using System.Collections.Generic;
using Top.Api.Util;

namespace Top.Api.Request
{
    /// <summary>
    /// TOP API: cainiao.cloudprint.isv.resources.get
    /// </summary>
    public class CainiaoCloudprintIsvResourcesGetRequest : BaseTopRequest<Top.Api.Response.CainiaoCloudprintIsvResourcesGetResponse>
    {
        /// <summary>
        /// isv资源类型，分为：TEMPLATE（表示模板），PRINT_ITEM（打印项），CUSTOM_AREA（预设自定义区）
        /// </summary>
        public string IsvResourceType { get; set; }

        #region ITopRequest Members

        public override string GetApiName()
        {
            return "cainiao.cloudprint.isv.resources.get";
        }

        public override IDictionary<string, string> GetParameters()
        {
            TopDictionary parameters = new TopDictionary();
            parameters.Add("isv_resource_type", this.IsvResourceType);
            if (this.otherParams != null)
            {
                parameters.AddAll(this.otherParams);
            }
            return parameters;
        }

        public override void Validate()
        {
            RequestValidator.ValidateRequired("isv_resource_type", this.IsvResourceType);
        }

        #endregion
    }
}
