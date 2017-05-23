using System;
using System.Xml.Serialization;
using Top.Api.Domain;
using System.Collections.Generic;
using Top.Api.Util;

namespace Top.Api.Request
{
    /// <summary>
    /// TOP API: taobao.wlb.waybill.i.search
    /// </summary>
    public class WlbWaybillISearchRequest : BaseTopRequest<Top.Api.Response.WlbWaybillISearchResponse>
    {
        /// <summary>
        /// 查询网点信息
        /// </summary>
        public string WaybillApplyRequest { get; set; }

        public WaybillApplyRequest WaybillApplyRequest_ { set { this.WaybillApplyRequest = TopUtils.ObjectToJson(value); } } 

        #region ITopRequest Members

        public override string GetApiName()
        {
            return "taobao.wlb.waybill.i.search";
        }

        public override IDictionary<string, string> GetParameters()
        {
            TopDictionary parameters = new TopDictionary();
            parameters.Add("waybill_apply_request", this.WaybillApplyRequest);
            if (this.otherParams != null)
            {
                parameters.AddAll(this.otherParams);
            }
            return parameters;
        }

        public override void Validate()
        {
            RequestValidator.ValidateRequired("waybill_apply_request", this.WaybillApplyRequest);
        }

        #endregion
    }
}
