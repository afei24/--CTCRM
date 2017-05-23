using System;
using System.Collections.Generic;
using Top.Api.Util;

namespace Top.Api.Request
{
    /// <summary>
    /// TOP API: cainiao.cloudprint.clientinfo.put
    /// </summary>
    public class CainiaoCloudprintClientinfoPutRequest : BaseTopRequest<Top.Api.Response.CainiaoCloudprintClientinfoPutResponse>
    {
        /// <summary>
        /// 收集的数据，json格式
        /// </summary>
        public string JsonData { get; set; }

        #region ITopRequest Members

        public override string GetApiName()
        {
            return "cainiao.cloudprint.clientinfo.put";
        }

        public override IDictionary<string, string> GetParameters()
        {
            TopDictionary parameters = new TopDictionary();
            parameters.Add("json_data", this.JsonData);
            if (this.otherParams != null)
            {
                parameters.AddAll(this.otherParams);
            }
            return parameters;
        }

        public override void Validate()
        {
            RequestValidator.ValidateRequired("json_data", this.JsonData);
        }

        #endregion
    }
}
