using System;
using System.Xml.Serialization;
using Top.Api.Domain;
using System.Collections.Generic;
using Top.Api.Util;

namespace Top.Api.Request
{
    /// <summary>
    /// TOP API: taobao.wlb.wms.return.order.notify
    /// </summary>
    public class WlbWmsReturnOrderNotifyRequest : BaseTopRequest<Top.Api.Response.WlbWmsReturnOrderNotifyResponse>
    {
        /// <summary>
        /// 买家昵称
        /// </summary>
        public string BuyerNick { get; set; }

        /// <summary>
        /// 扩展属性, key-value结构，格式要求： 以英文分号“;”分隔每组key-value，以英文冒号“:”分隔key与value。如果value中带有分号，需要转成下划线“_”，如果带有冒号，需要转成中划线“-”
        /// </summary>
        public string ExtendFields { get; set; }

        /// <summary>
        /// ERP单据编码
        /// </summary>
        public string OrderCode { get; set; }

        /// <summary>
        /// ERP订单创建时间
        /// </summary>
        public Nullable<DateTime> OrderCreateTime { get; set; }

        /// <summary>
        /// 用字符串格式来表示订单标记列表：比如VISIT^ SELLER_AFFORD^SYNC_RETURN_BILL 等，中间用“^”来隔开 ----------------------------------------  订单标记list（所有字母全部大写）： 9:VISIT-上门12: SELLER_AFFORD 是否卖家承担运费 默认是，即没 13: SYNC_RETURN_BILL，同时退回发票
        /// </summary>
        public string OrderFlag { get; set; }

        /// <summary>
        /// 商品信息列表
        /// </summary>
        public string OrderItemList { get; set; }

        public List<Orderitemlistwlbwmsreturnordernotify> OrderItemList_ { set { this.OrderItemList = TopUtils.ObjectToJson(value); } } 

        /// <summary>
        /// 订单来源 201 淘宝，202 1688，203 苏宁，204 亚马逊中国，205 当当，206 ebay，207 唯品会，208 1号店，209 国美，210 拍拍，211 聚美优品，212 乐峰，214 京东，301 其他
        /// </summary>
        public string OrderSource { get; set; }

        /// <summary>
        /// 订单类型 501 销退入库
        /// </summary>
        public string OrderType { get; set; }

        /// <summary>
        /// 货主ID
        /// </summary>
        public string OwnerUserId { get; set; }

        /// <summary>
        /// 来源单据号，销售退货时填充原发货的LBX号
        /// </summary>
        public string PrevOrderCode { get; set; }

        /// <summary>
        /// 收件人信息
        /// </summary>
        public string ReceiverInfo { get; set; }

        public Receiverinfowlbwmsreturnordernotify ReceiverInfo_ { set { this.ReceiverInfo = TopUtils.ObjectToJson(value); } } 

        /// <summary>
        /// 备注
        /// </summary>
        public string Remark { get; set; }

        /// <summary>
        /// 销退时请提供退货的原因
        /// </summary>
        public string ReturnReason { get; set; }

        /// <summary>
        /// 发件人信息
        /// </summary>
        public string SenderInfo { get; set; }

        public Senderinfowlbwmsreturnordernotify SenderInfo_ { set { this.SenderInfo = TopUtils.ObjectToJson(value); } } 

        /// <summary>
        /// 仓库编码
        /// </summary>
        public string StoreCode { get; set; }

        /// <summary>
        /// 运单号
        /// </summary>
        public string TmsOrderCode { get; set; }

        /// <summary>
        /// 快递公司编码
        /// </summary>
        public string TmsServiceCode { get; set; }

        /// <summary>
        /// 快递公司名称
        /// </summary>
        public string TmsServiceName { get; set; }

        #region ITopRequest Members

        public override string GetApiName()
        {
            return "taobao.wlb.wms.return.order.notify";
        }

        public override IDictionary<string, string> GetParameters()
        {
            TopDictionary parameters = new TopDictionary();
            parameters.Add("buyer_nick", this.BuyerNick);
            parameters.Add("extend_fields", this.ExtendFields);
            parameters.Add("order_code", this.OrderCode);
            parameters.Add("order_create_time", this.OrderCreateTime);
            parameters.Add("order_flag", this.OrderFlag);
            parameters.Add("order_item_list", this.OrderItemList);
            parameters.Add("order_source", this.OrderSource);
            parameters.Add("order_type", this.OrderType);
            parameters.Add("owner_user_id", this.OwnerUserId);
            parameters.Add("prev_order_code", this.PrevOrderCode);
            parameters.Add("receiver_info", this.ReceiverInfo);
            parameters.Add("remark", this.Remark);
            parameters.Add("return_reason", this.ReturnReason);
            parameters.Add("sender_info", this.SenderInfo);
            parameters.Add("store_code", this.StoreCode);
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
            RequestValidator.ValidateObjectMaxListSize("order_item_list", this.OrderItemList, 50000);
        }

        #endregion
    }
}
