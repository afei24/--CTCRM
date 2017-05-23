using System;
using System.Xml.Serialization;
using Top.Api.Domain;
using System.Collections.Generic;
using Top.Api.Util;

namespace Top.Api.Request
{
    /// <summary>
    /// TOP API: taobao.wlb.waybill.i.product
    /// </summary>
    public class WlbWaybillIProductRequest : BaseTopRequest<Top.Api.Response.WlbWaybillIProductResponse>
    {
        /// <summary>
        /// 查询物流商电子面单产品类型入参
        /// </summary>
        public string WaybillProductTypeRequest { get; set; }

        public WaybillProductTypeRequest WaybillProductTypeRequest_ { set { this.WaybillProductTypeRequest = TopUtils.ObjectToJson(value); } } 

        #region ITopRequest Members

        public override string GetApiName()
        {
            return "taobao.wlb.waybill.i.product";
        }

        public override IDictionary<string, string> GetParameters()
        {
            TopDictionary parameters = new TopDictionary();
            parameters.Add("waybill_product_type_request", this.WaybillProductTypeRequest);
            if (this.otherParams != null)
            {
                parameters.AddAll(this.otherParams);
            }
            return parameters;
        }

        public override void Validate()
        {
            RequestValidator.ValidateRequired("waybill_product_type_request", this.WaybillProductTypeRequest);
        }

        #endregion
    }
}
