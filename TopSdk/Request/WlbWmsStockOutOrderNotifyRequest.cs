using System;
using System.Xml.Serialization;
using Top.Api.Domain;
using System.Collections.Generic;
using Top.Api.Util;

namespace Top.Api.Request
{
    /// <summary>
    /// TOP API: taobao.wlb.wms.stock.out.order.notify
    /// </summary>
    public class WlbWmsStockOutOrderNotifyRequest : BaseTopRequest<Top.Api.Response.WlbWmsStockOutOrderNotifyResponse>
    {
        /// <summary>
        /// 车牌号
        /// </summary>
        public string CarNo { get; set; }

        /// <summary>
        /// 承运商名称
        /// </summary>
        public string CarriersName { get; set; }

        /// <summary>
        /// 拓展属性
        /// </summary>
        public string ExtendFields { get; set; }

        /// <summary>
        /// ERP单据ID
        /// </summary>
        public string OrderCode { get; set; }

        /// <summary>
        /// 订单创建时间
        /// </summary>
        public Nullable<DateTime> OrderCreateTime { get; set; }

        /// <summary>
        /// 订单商品信息列表
        /// </summary>
        public string OrderItemList { get; set; }

        public List<Orderitemlistwlbwmsstockoutordernotify> OrderItemList_ { set { this.OrderItemList = TopUtils.ObjectToJson(value); } } 

        /// <summary>
        /// 单据类型 301 调拨出库单、901普通出库单、903 其他出库单 305 B2B出库
        /// </summary>
        public Nullable<long> OrderType { get; set; }

        /// <summary>
        /// ERP可选择性文本透传至WMS
        /// </summary>
        public string OutboundTypeDesc { get; set; }

        /// <summary>
        /// 取件人电话
        /// </summary>
        public string PickCall { get; set; }

        /// <summary>
        /// 取件人身份证ID
        /// </summary>
        public string PickId { get; set; }

        /// <summary>
        /// 取件人姓名
        /// </summary>
        public string PickName { get; set; }

        /// <summary>
        /// 前物流订单号，如退货入库单可能会用到
        /// </summary>
        public string PrevOrderCode { get; set; }

        /// <summary>
        /// 收件人信息
        /// </summary>
        public string ReceiverInfo { get; set; }

        public Receiverwlbwmsstockoutordernotify ReceiverInfo_ { set { this.ReceiverInfo = TopUtils.ObjectToJson(value); } } 

        /// <summary>
        /// 备注
        /// </summary>
        public string Remark { get; set; }

        /// <summary>
        /// 要求出库日期
        /// </summary>
        public Nullable<DateTime> SendTime { get; set; }

        /// <summary>
        /// 发货方信息
        /// </summary>
        public string SenderInfo { get; set; }

        public Senderwlbwmsstockoutordernotify SenderInfo_ { set { this.SenderInfo = TopUtils.ObjectToJson(value); } } 

        /// <summary>
        /// 仓储编码
        /// </summary>
        public string StoreCode { get; set; }

        /// <summary>
        /// 出库方式
        /// </summary>
        public string TransportMode { get; set; }

        #region ITopRequest Members

        public override string GetApiName()
        {
            return "taobao.wlb.wms.stock.out.order.notify";
        }

        public override IDictionary<string, string> GetParameters()
        {
            TopDictionary parameters = new TopDictionary();
            parameters.Add("car_no", this.CarNo);
            parameters.Add("carriers_name", this.CarriersName);
            parameters.Add("extend_fields", this.ExtendFields);
            parameters.Add("order_code", this.OrderCode);
            parameters.Add("order_create_time", this.OrderCreateTime);
            parameters.Add("order_item_list", this.OrderItemList);
            parameters.Add("order_type", this.OrderType);
            parameters.Add("outbound_type_desc", this.OutboundTypeDesc);
            parameters.Add("pick_call", this.PickCall);
            parameters.Add("pick_id", this.PickId);
            parameters.Add("pick_name", this.PickName);
            parameters.Add("prev_order_code", this.PrevOrderCode);
            parameters.Add("receiver_info", this.ReceiverInfo);
            parameters.Add("remark", this.Remark);
            parameters.Add("send_time", this.SendTime);
            parameters.Add("sender_info", this.SenderInfo);
            parameters.Add("store_code", this.StoreCode);
            parameters.Add("transport_mode", this.TransportMode);
            if (this.otherParams != null)
            {
                parameters.AddAll(this.otherParams);
            }
            return parameters;
        }

        public override void Validate()
        {
            RequestValidator.ValidateRequired("order_code", this.OrderCode);
            RequestValidator.ValidateRequired("order_create_time", this.OrderCreateTime);
            RequestValidator.ValidateObjectMaxListSize("order_item_list", this.OrderItemList, 5000);
            RequestValidator.ValidateRequired("order_type", this.OrderType);
            RequestValidator.ValidateRequired("store_code", this.StoreCode);
        }

        #endregion
    }
}
