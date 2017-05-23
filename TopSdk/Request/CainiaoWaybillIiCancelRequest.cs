using System;
using System.Collections.Generic;
using Top.Api.Util;

namespace Top.Api.Request
{
    /// <summary>
    /// TOP API: cainiao.waybill.ii.cancel
    /// </summary>
    public class CainiaoWaybillIiCancelRequest : BaseTopRequest<Top.Api.Response.CainiaoWaybillIiCancelResponse>
    {
        /// <summary>
        /// 快递公司code
        /// </summary>
        public string CpCode { get; set; }

        /// <summary>
        /// 电子面单号
        /// </summary>
        public string WaybillCode { get; set; }

        #region ITopRequest Members

        public override string GetApiName()
        {
            return "cainiao.waybill.ii.cancel";
        }

        public override IDictionary<string, string> GetParameters()
        {
            TopDictionary parameters = new TopDictionary();
            parameters.Add("cp_code", this.CpCode);
            parameters.Add("waybill_code", this.WaybillCode);
            if (this.otherParams != null)
            {
                parameters.AddAll(this.otherParams);
            }
            return parameters;
        }

        public override void Validate()
        {
            RequestValidator.ValidateRequired("cp_code", this.CpCode);
            RequestValidator.ValidateRequired("waybill_code", this.WaybillCode);
        }

        #endregion
    }
}
