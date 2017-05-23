using System;
using System.Xml.Serialization;
using Top.Api.Domain;
using System.Collections.Generic;
using Top.Api.Util;

namespace Top.Api.Request
{
    /// <summary>
    /// TOP API: taobao.wlb.wms.stock.in.order.confirm
    /// </summary>
    public class WlbWmsStockInOrderConfirmRequest : BaseTopRequest<Top.Api.Response.WlbWmsStockInOrderConfirmResponse>
    {
        /// <summary>
        /// 入库订单确认请求
        /// </summary>
        public string Content { get; set; }

        public Requestwlbwmsstockinorderconfirm Content_ { set { this.Content = TopUtils.ObjectToJson(value); } } 

        #region ITopRequest Members

        public override string GetApiName()
        {
            return "taobao.wlb.wms.stock.in.order.confirm";
        }

        public override IDictionary<string, string> GetParameters()
        {
            TopDictionary parameters = new TopDictionary();
            parameters.Add("content", this.Content);
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
