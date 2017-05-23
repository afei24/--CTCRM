using System;
using System.Xml.Serialization;
using Top.Api.Domain;
using System.Collections.Generic;
using Top.Api.Util;

namespace Top.Api.Request
{
    /// <summary>
    /// TOP API: taobao.fuwu.purchase.order.confirm
    /// </summary>
    public class FuwuPurchaseOrderConfirmRequest : BaseTopRequest<Top.Api.Response.FuwuPurchaseOrderConfirmResponse>
    {
        /// <summary>
        /// 内购服务下单接口参数
        /// </summary>
        public string ParamOrderConfirmQueryDTO { get; set; }

        public OrderConfirmQueryDto ParamOrderConfirmQueryDTO_ { set { this.ParamOrderConfirmQueryDTO = TopUtils.ObjectToJson(value); } } 

        #region ITopRequest Members

        public override string GetApiName()
        {
            return "taobao.fuwu.purchase.order.confirm";
        }

        public override IDictionary<string, string> GetParameters()
        {
            TopDictionary parameters = new TopDictionary();
            parameters.Add("param_order_confirm_query_d_t_o", this.ParamOrderConfirmQueryDTO);
            if (this.otherParams != null)
            {
                parameters.AddAll(this.otherParams);
            }
            return parameters;
        }

        public override void Validate()
        {
            RequestValidator.ValidateRequired("param_order_confirm_query_d_t_o", this.ParamOrderConfirmQueryDTO);
        }

        #endregion
    }
}
