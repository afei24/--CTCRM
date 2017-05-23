using System;
using System.Xml.Serialization;
using Top.Api.Domain;
using System.Collections.Generic;
using Top.Api.Util;

namespace Top.Api.Request
{
    /// <summary>
    /// TOP API: taobao.wlb.waybill.i.cancel
    /// </summary>
    public class WlbWaybillICancelRequest : BaseTopRequest<Top.Api.Response.WlbWaybillICancelResponse>
    {
        /// <summary>
        /// 取消接口入参
        /// </summary>
        public string WaybillApplyCancelRequest { get; set; }

        public WaybillApplyCancelRequest WaybillApplyCancelRequest_ { set { this.WaybillApplyCancelRequest = TopUtils.ObjectToJson(value); } } 

        #region ITopRequest Members

        public override string GetApiName()
        {
            return "taobao.wlb.waybill.i.cancel";
        }

        public override IDictionary<string, string> GetParameters()
        {
            TopDictionary parameters = new TopDictionary();
            parameters.Add("waybill_apply_cancel_request", this.WaybillApplyCancelRequest);
            if (this.otherParams != null)
            {
                parameters.AddAll(this.otherParams);
            }
            return parameters;
        }

        public override void Validate()
        {
            RequestValidator.ValidateRequired("waybill_apply_cancel_request", this.WaybillApplyCancelRequest);
        }

        #endregion
    }
}
