using System;
using System.Xml.Serialization;
using Top.Api.Domain;
using System.Collections.Generic;
using Top.Api.Util;

namespace Top.Api.Request
{
    /// <summary>
    /// TOP API: taobao.wlb.waybill.i.querydetail
    /// </summary>
    public class WlbWaybillIQuerydetailRequest : BaseTopRequest<Top.Api.Response.WlbWaybillIQuerydetailResponse>
    {
        /// <summary>
        /// 面单查询请求
        /// </summary>
        public string WaybillDetailQueryRequest { get; set; }

        public WaybillDetailQueryRequest WaybillDetailQueryRequest_ { set { this.WaybillDetailQueryRequest = TopUtils.ObjectToJson(value); } } 

        #region ITopRequest Members

        public override string GetApiName()
        {
            return "taobao.wlb.waybill.i.querydetail";
        }

        public override IDictionary<string, string> GetParameters()
        {
            TopDictionary parameters = new TopDictionary();
            parameters.Add("waybill_detail_query_request", this.WaybillDetailQueryRequest);
            if (this.otherParams != null)
            {
                parameters.AddAll(this.otherParams);
            }
            return parameters;
        }

        public override void Validate()
        {
            RequestValidator.ValidateRequired("waybill_detail_query_request", this.WaybillDetailQueryRequest);
        }

        #endregion
    }
}
