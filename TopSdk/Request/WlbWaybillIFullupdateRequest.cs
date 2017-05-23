using System;
using System.Xml.Serialization;
using Top.Api.Domain;
using System.Collections.Generic;
using Top.Api.Util;

namespace Top.Api.Request
{
    /// <summary>
    /// TOP API: taobao.wlb.waybill.i.fullupdate
    /// </summary>
    public class WlbWaybillIFullupdateRequest : BaseTopRequest<Top.Api.Response.WlbWaybillIFullupdateResponse>
    {
        /// <summary>
        /// 更新面单信息请求
        /// </summary>
        public string WaybillApplyFullUpdateRequest { get; set; }

        public WaybillApplyFullUpdateRequest WaybillApplyFullUpdateRequest_ { set { this.WaybillApplyFullUpdateRequest = TopUtils.ObjectToJson(value); } } 

        #region ITopRequest Members

        public override string GetApiName()
        {
            return "taobao.wlb.waybill.i.fullupdate";
        }

        public override IDictionary<string, string> GetParameters()
        {
            TopDictionary parameters = new TopDictionary();
            parameters.Add("waybill_apply_full_update_request", this.WaybillApplyFullUpdateRequest);
            if (this.otherParams != null)
            {
                parameters.AddAll(this.otherParams);
            }
            return parameters;
        }

        public override void Validate()
        {
            RequestValidator.ValidateRequired("waybill_apply_full_update_request", this.WaybillApplyFullUpdateRequest);
        }

        #endregion
    }
}
