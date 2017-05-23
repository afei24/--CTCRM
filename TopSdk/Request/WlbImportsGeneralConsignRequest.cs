using System;
using System.Collections.Generic;
using Top.Api.Util;

namespace Top.Api.Request
{
    /// <summary>
    /// TOP API: taobao.wlb.imports.general.consign
    /// </summary>
    public class WlbImportsGeneralConsignRequest : BaseTopRequest<Top.Api.Response.WlbImportsGeneralConsignResponse>
    {
        /// <summary>
        /// 卖家退货地址库ID；不填写的话取默认退货地址；如果填写的cancelId对应多个地址，取第一个
        /// </summary>
        public Nullable<long> CancelId { get; set; }

        /// <summary>
        /// 第1段物流承运商
        /// </summary>
        public string FirstLogistics { get; set; }

        /// <summary>
        /// 第1段物流运单号
        /// </summary>
        public string FirstWaybillno { get; set; }

        /// <summary>
        /// 物流资源ID
        /// </summary>
        public Nullable<long> ResourceId { get; set; }

        /// <summary>
        /// 卖家发货地址库ID；不填的话取默认发货地址；如果填写的senderId对应多个地址，取第一个
        /// </summary>
        public Nullable<long> SenderId { get; set; }

        /// <summary>
        /// 仓库编码
        /// </summary>
        public string StoreCode { get; set; }

        /// <summary>
        /// 交易订单id
        /// </summary>
        public Nullable<long> TradeOrderId { get; set; }

        #region ITopRequest Members

        public override string GetApiName()
        {
            return "taobao.wlb.imports.general.consign";
        }

        public override IDictionary<string, string> GetParameters()
        {
            TopDictionary parameters = new TopDictionary();
            parameters.Add("cancel_id", this.CancelId);
            parameters.Add("first_logistics", this.FirstLogistics);
            parameters.Add("first_waybillno", this.FirstWaybillno);
            parameters.Add("resource_id", this.ResourceId);
            parameters.Add("sender_id", this.SenderId);
            parameters.Add("store_code", this.StoreCode);
            parameters.Add("trade_order_id", this.TradeOrderId);
            if (this.otherParams != null)
            {
                parameters.AddAll(this.otherParams);
            }
            return parameters;
        }

        public override void Validate()
        {
            RequestValidator.ValidateRequired("first_logistics", this.FirstLogistics);
            RequestValidator.ValidateRequired("first_waybillno", this.FirstWaybillno);
            RequestValidator.ValidateRequired("resource_id", this.ResourceId);
            RequestValidator.ValidateRequired("store_code", this.StoreCode);
            RequestValidator.ValidateRequired("trade_order_id", this.TradeOrderId);
        }

        #endregion
    }
}
