using System;
using System.Collections.Generic;
using Top.Api.Util;

namespace Top.Api.Request
{
    /// <summary>
    /// TOP API: cainiao.waybill.ii.search
    /// </summary>
    public class CainiaoWaybillIiSearchRequest : BaseTopRequest<Top.Api.Response.CainiaoWaybillIiSearchResponse>
    {
        /// <summary>
        /// 物流公司code
        /// </summary>
        public string CpCode { get; set; }

        #region ITopRequest Members

        public override string GetApiName()
        {
            return "cainiao.waybill.ii.search";
        }

        public override IDictionary<string, string> GetParameters()
        {
            TopDictionary parameters = new TopDictionary();
            parameters.Add("cp_code", this.CpCode);
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
