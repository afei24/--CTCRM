using System;
using System.Xml.Serialization;
using Top.Api.Domain;
using System.Collections.Generic;
using Top.Api.Util;

namespace Top.Api.Request
{
    /// <summary>
    /// TOP API: taobao.wlb.wms.stock.in.order.notify
    /// </summary>
    public class WlbWmsStockInOrderNotifyRequest : BaseTopRequest<Top.Api.Response.WlbWmsStockInOrderNotifyResponse>
    {
        /// <summary>
        /// 预期送达结束时间
        /// </summary>
        public string ExpectEndTime { get; set; }

        /// <summary>
        /// 预期送达开始时间
        /// </summary>
        public string ExpectStartTime { get; set; }

        /// <summary>
        /// 扩展属性, key-value结构，格式要求： 以英文分号“;”分隔每组key-value，以英文冒号“:”分隔key与value。如果value中带有分号，需要转成下划线“_”，如果带有冒号，需要转成中划线“-”
        /// </summary>
        public string ExtendFields { get; set; }

        /// <summary>
        /// 可选择性文本透传至WMS，比如加工归还、委外归还、借出归还、内部归还等
        /// </summary>
        public string InboundTypeDesc { get; set; }

        /// <summary>
        /// 入库单据编码
        /// </summary>
        public string OrderCode { get; set; }

        /// <summary>
        /// 单据创建时间
        /// </summary>
        public Nullable<DateTime> OrderCreateTime { get; set; }

        /// <summary>
        /// 订单标记以逗号分隔：  9:上门退货入库 13: 退货时是否收取发票，默认不收取（即没13为多选项，如1,2,8,9）
        /// </summary>
        public string OrderFlag { get; set; }

        /// <summary>
        /// 系统自动生成
        /// </summary>
        public string OrderItemList { get; set; }

        public List<Orderitemlistwlbwmsstockinordernotifywl> OrderItemList_ { set { this.OrderItemList = TopUtils.ObjectToJson(value); } } 

        /// <summary>
        /// 单据类型 601普通入库单、501销退入库单、302 调拨入库单、904其他入库单、306 B2B入库
        /// </summary>
        public Nullable<long> OrderType { get; set; }

        /// <summary>
        /// 来源单据号，如销售退货时填充原销售订单号
        /// </summary>
        public string PrevOrderCode { get; set; }

        /// <summary>
        /// 系统自动生成
        /// </summary>
        public string ReceiverInfo { get; set; }

        public Receiverinfowlbwmsstockinordernotifywl ReceiverInfo_ { set { this.ReceiverInfo = TopUtils.ObjectToJson(value); } } 

        /// <summary>
        /// 备注，销退入库订单需要留言备注填充到此字段
        /// </summary>
        public string Remark { get; set; }

        /// <summary>
        /// 销退时请提供退货的原因
        /// </summary>
        public string ReturnReason { get; set; }

        /// <summary>
        /// 系统自动生成
        /// </summary>
        public string SenderInfo { get; set; }

        public Senderinfowlbwmsstockinordernotifywl SenderInfo_ { set { this.SenderInfo = TopUtils.ObjectToJson(value); } } 

        /// <summary>
        /// 仓库编码
        /// </summary>
        public string StoreCode { get; set; }

        /// <summary>
        /// 供应商编码，往来单位编码
        /// </summary>
        public string SupplierCode { get; set; }

        /// <summary>
        /// 供应商名称 ，往来单位名称
        /// </summary>
        public string SupplierName { get; set; }

        /// <summary>
        /// 运单号&托运单号 1) 入库单支持多运单号录入 2) 销退场景下如果是拒收（非妥投运单）由ERP填充原运单号
        /// </summary>
        public string TmsOrderCode { get; set; }

        /// <summary>
        /// 配送公司编码，拒收（非妥投）的销退订单，由ERP填充原单配送公司编码
        /// </summary>
        public string TmsServiceCode { get; set; }

        /// <summary>
        /// 快递公司名称
        /// </summary>
        public string TmsServiceName { get; set; }

        #region ITopRequest Members

        public override string GetApiName()
        {
            return "taobao.wlb.wms.stock.in.order.notify";
        }

        public override IDictionary<string, string> GetParameters()
        {
            TopDictionary parameters = new TopDictionary();
            parameters.Add("expect_end_time", this.ExpectEndTime);
            parameters.Add("expect_start_time", this.ExpectStartTime);
            parameters.Add("extend_fields", this.ExtendFields);
            parameters.Add("inbound_type_desc", this.InboundTypeDesc);
            parameters.Add("order_code", this.OrderCode);
            parameters.Add("order_create_time", this.OrderCreateTime);
            parameters.Add("order_flag", this.OrderFlag);
            parameters.Add("order_item_list", this.OrderItemList);
            parameters.Add("order_type", this.OrderType);
            parameters.Add("prev_order_code", this.PrevOrderCode);
            parameters.Add("receiver_info", this.ReceiverInfo);
            parameters.Add("remark", this.Remark);
            parameters.Add("return_reason", this.ReturnReason);
            parameters.Add("sender_info", this.SenderInfo);
            parameters.Add("store_code", this.StoreCode);
            parameters.Add("supplier_code", this.SupplierCode);
            parameters.Add("supplier_name", this.SupplierName);
            parameters.Add("tms_order_code", this.TmsOrderCode);
            parameters.Add("tms_service_code", this.TmsServiceCode);
            parameters.Add("tms_service_name", this.TmsServiceName);
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
            RequestValidator.ValidateRequired("order_item_list", this.OrderItemList);
            RequestValidator.ValidateObjectMaxListSize("order_item_list", this.OrderItemList, 5000);
            RequestValidator.ValidateRequired("order_type", this.OrderType);
            RequestValidator.ValidateRequired("store_code", this.StoreCode);
        }

        #endregion
    }
}
