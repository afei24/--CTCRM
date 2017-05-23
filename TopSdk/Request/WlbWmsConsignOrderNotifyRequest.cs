using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using Top.Api.Util;

namespace Top.Api.Request
{
    /// <summary>
    /// TOP API: taobao.wlb.wms.consign.order.notify
    /// </summary>
    public class WlbWmsConsignOrderNotifyRequest : BaseTopRequest<Top.Api.Response.WlbWmsConsignOrderNotifyResponse>
    {
        /// <summary>
        /// 废弃，支付宝交易号
        /// </summary>
        public string AlipayNo { get; set; }

        /// <summary>
        /// 订单应收金额，消费者还需要付的金额，单位分
        /// </summary>
        public Nullable<long> ArAmount { get; set; }

        /// <summary>
        /// 废弃，车牌号
        /// </summary>
        public string CarNo { get; set; }

        /// <summary>
        /// 废弃，承运商名称
        /// </summary>
        public string CarriersName { get; set; }

        /// <summary>
        /// 配送要求
        /// </summary>
        public string DeliverRequirements { get; set; }

        public DeliverrequirementswlbwmsconsignordernotifyDomain DeliverRequirements_ { set { this.DeliverRequirements = TopUtils.ObjectToJson(value); } } 

        /// <summary>
        /// 订单优惠金额，整单优惠金额，单位分
        /// </summary>
        public Nullable<long> DiscountAmount { get; set; }

        /// <summary>
        /// 拓展属性
        /// </summary>
        public string ExtendFields { get; set; }

        /// <summary>
        /// 订单已付金额，消费者已经支付的金额，单位分
        /// </summary>
        public Nullable<long> GotAmount { get; set; }

        /// <summary>
        /// 发票信息列表
        /// </summary>
        public string InvoiceInfoList { get; set; }

        public List<InvoicelistwlbwmsconsignordernotifyDomain> InvoiceInfoList_ { set { this.InvoiceInfoList = TopUtils.ObjectToJson(value); } } 

        /// <summary>
        /// 订单总金额,=总商品金额-订单优惠金额+快递费用，单位分
        /// </summary>
        public Nullable<long> OrderAmount { get; set; }

        /// <summary>
        /// ERP订单号
        /// </summary>
        public string OrderCode { get; set; }

        /// <summary>
        /// 订单创建时间,ERP创建订单时间
        /// </summary>
        public Nullable<DateTime> OrderCreateTime { get; set; }

        /// <summary>
        /// 订单审核时间,ERP创建支付时间
        /// </summary>
        public Nullable<DateTime> OrderExaminationTime { get; set; }

        /// <summary>
        /// 订单标识 (1: cod –货到付款，4:invoiceinfo-需要发票)
        /// </summary>
        public string OrderFlag { get; set; }

        /// <summary>
        /// 订单商品信息列表
        /// </summary>
        public string OrderItemList { get; set; }

        public List<OrderitemlistwlbwmsconsignordernotifyDomain> OrderItemList_ { set { this.OrderItemList = TopUtils.ObjectToJson(value); } } 

        /// <summary>
        /// 订单支付时间
        /// </summary>
        public Nullable<DateTime> OrderPayTime { get; set; }

        /// <summary>
        /// 废弃，订单优先级0 -10，根据订单作业优先级设置，数字越大，优先级越高
        /// </summary>
        public Nullable<long> OrderPriority { get; set; }

        /// <summary>
        /// 下单时间，订单在交易平台创建时间
        /// </summary>
        public Nullable<DateTime> OrderShopCreateTime { get; set; }

        /// <summary>
        /// 订单来源（213 天猫，201 淘宝，214 京东，202 1688 阿里中文站 ，203 苏宁在线，204 亚马逊中国，205 当当，208 1号店，207 唯品会，209 国美在线，210 拍拍，206 易贝ebay，211 聚美优品，212 乐蜂网，215 邮乐，216 凡客，217 优购，218 银泰，219 易讯，221 聚尚网，222 蘑菇街，223 POS门店，301 其他）
        /// </summary>
        public Nullable<long> OrderSource { get; set; }

        /// <summary>
        /// 废弃，交易内部来源，文本透传 WAP(手机);HITAO(嗨淘);TOP(TOP平台);TAOBAO(普通淘宝);JHS(聚划算) 一笔订单可能同时有以上多个标记，则以逗号分隔
        /// </summary>
        public string OrderSubSource { get; set; }

        /// <summary>
        /// 单据类型 201 一般交易出库单 202 B2B交易出库单 502 换货出库单 503 补发出库单
        /// </summary>
        public Nullable<long> OrderType { get; set; }

        /// <summary>
        /// 废弃，取件人电话
        /// </summary>
        public string PickerCall { get; set; }

        /// <summary>
        /// 废弃，取件人身份证
        /// </summary>
        public string PickerId { get; set; }

        /// <summary>
        /// 废弃，取件人姓名
        /// </summary>
        public string PickerName { get; set; }

        /// <summary>
        /// 快递费用，单位分
        /// </summary>
        public Nullable<long> Postfee { get; set; }

        /// <summary>
        /// 前物流订单号，订单类型为502 换货出库单 503 补发出库单时，需求传入此内容
        /// </summary>
        public string PrevOrderCode { get; set; }

        /// <summary>
        /// 收件人信息
        /// </summary>
        public string ReceiverInfo { get; set; }

        public ReceiverwlbwmsconsignordernotifyDomain ReceiverInfo_ { set { this.ReceiverInfo = TopUtils.ObjectToJson(value); } } 

        /// <summary>
        /// 备注
        /// </summary>
        public string Remark { get; set; }

        /// <summary>
        /// 发货方信息
        /// </summary>
        public string SenderInfo { get; set; }

        public SenderwlbwmsconsignordernotifyDomain SenderInfo_ { set { this.SenderInfo = TopUtils.ObjectToJson(value); } } 

        /// <summary>
        /// COD服务费，单位分
        /// </summary>
        public Nullable<long> ServiceFee { get; set; }

        /// <summary>
        /// 仓库编码，此字段为空时，由菜鸟路由仓库发货
        /// </summary>
        public string StoreCode { get; set; }

        /// <summary>
        /// 快递公司编码，此字段为空时，由菜鸟选择快递配送
        /// </summary>
        public string TmsServiceCode { get; set; }

        /// <summary>
        /// 快递公司名称
        /// </summary>
        public string TmsServiceName { get; set; }

        /// <summary>
        /// 废弃，出库方式（自提，快递，销毁）
        /// </summary>
        public string TransportMode { get; set; }

        #region ITopRequest Members

        public override string GetApiName()
        {
            return "taobao.wlb.wms.consign.order.notify";
        }

        public override IDictionary<string, string> GetParameters()
        {
            TopDictionary parameters = new TopDictionary();
            parameters.Add("alipay_no", this.AlipayNo);
            parameters.Add("ar_amount", this.ArAmount);
            parameters.Add("car_no", this.CarNo);
            parameters.Add("carriers_name", this.CarriersName);
            parameters.Add("deliver_requirements", this.DeliverRequirements);
            parameters.Add("discount_amount", this.DiscountAmount);
            parameters.Add("extend_fields", this.ExtendFields);
            parameters.Add("got_amount", this.GotAmount);
            parameters.Add("invoice_info_list", this.InvoiceInfoList);
            parameters.Add("order_amount", this.OrderAmount);
            parameters.Add("order_code", this.OrderCode);
            parameters.Add("order_create_time", this.OrderCreateTime);
            parameters.Add("order_examination_time", this.OrderExaminationTime);
            parameters.Add("order_flag", this.OrderFlag);
            parameters.Add("order_item_list", this.OrderItemList);
            parameters.Add("order_pay_time", this.OrderPayTime);
            parameters.Add("order_priority", this.OrderPriority);
            parameters.Add("order_shop_create_time", this.OrderShopCreateTime);
            parameters.Add("order_source", this.OrderSource);
            parameters.Add("order_sub_source", this.OrderSubSource);
            parameters.Add("order_type", this.OrderType);
            parameters.Add("picker_call", this.PickerCall);
            parameters.Add("picker_id", this.PickerId);
            parameters.Add("picker_name", this.PickerName);
            parameters.Add("postfee", this.Postfee);
            parameters.Add("prev_order_code", this.PrevOrderCode);
            parameters.Add("receiver_info", this.ReceiverInfo);
            parameters.Add("remark", this.Remark);
            parameters.Add("sender_info", this.SenderInfo);
            parameters.Add("service_fee", this.ServiceFee);
            parameters.Add("store_code", this.StoreCode);
            parameters.Add("tms_service_code", this.TmsServiceCode);
            parameters.Add("tms_service_name", this.TmsServiceName);
            parameters.Add("transport_mode", this.TransportMode);
            if (this.otherParams != null)
            {
                parameters.AddAll(this.otherParams);
            }
            return parameters;
        }

        public override void Validate()
        {
            RequestValidator.ValidateMinValue("ar_amount", this.ArAmount, 0);
            RequestValidator.ValidateMinValue("got_amount", this.GotAmount, 0);
            RequestValidator.ValidateObjectMaxListSize("invoice_info_list", this.InvoiceInfoList, 1000);
            RequestValidator.ValidateMinValue("order_amount", this.OrderAmount, 0);
            RequestValidator.ValidateRequired("order_code", this.OrderCode);
            RequestValidator.ValidateObjectMaxListSize("order_item_list", this.OrderItemList, 1000);
            RequestValidator.ValidateRequired("order_type", this.OrderType);
            RequestValidator.ValidateMinValue("service_fee", this.ServiceFee, 0);
        }

	/// <summary>
/// DeliverrequirementswlbwmsconsignordernotifyDomain Data Structure.
/// </summary>
[Serializable]
public class DeliverrequirementswlbwmsconsignordernotifyDomain : TopObject
{
	        /// <summary>
	        /// 配送类型： PTPS-常温配送 LLPS-冷链配送
	        /// </summary>
	        [XmlElement("delivery_type")]
	        public string DeliveryType { get; set; }
	
	        /// <summary>
	        /// 送达日期
	        /// </summary>
	        [XmlElement("schedule_day")]
	        public string ScheduleDay { get; set; }
	
	        /// <summary>
	        /// 送达结束时间
	        /// </summary>
	        [XmlElement("schedule_end")]
	        public string ScheduleEnd { get; set; }
	
	        /// <summary>
	        /// 送达开始时间
	        /// </summary>
	        [XmlElement("schedule_start")]
	        public string ScheduleStart { get; set; }
	
	        /// <summary>
	        /// 投递时延要求:  1-工作日 2-节假日 101,当日达102次晨达103次日达 111 活动标  104 预约达
	        /// </summary>
	        [XmlElement("schedule_type")]
	        public Nullable<long> ScheduleType { get; set; }
}

	/// <summary>
/// ReceiverwlbwmsconsignordernotifyDomain Data Structure.
/// </summary>
[Serializable]
public class ReceiverwlbwmsconsignordernotifyDomain : TopObject
{
	        /// <summary>
	        /// 收件方地址
	        /// </summary>
	        [XmlElement("receiver_address")]
	        public string ReceiverAddress { get; set; }
	
	        /// <summary>
	        /// 收件方区县
	        /// </summary>
	        [XmlElement("receiver_area")]
	        public string ReceiverArea { get; set; }
	
	        /// <summary>
	        /// 收件方城市
	        /// </summary>
	        [XmlElement("receiver_city")]
	        public string ReceiverCity { get; set; }
	
	        /// <summary>
	        /// 收件人手机
	        /// </summary>
	        [XmlElement("receiver_mobile")]
	        public string ReceiverMobile { get; set; }
	
	        /// <summary>
	        /// 收件人名称
	        /// </summary>
	        [XmlElement("receiver_name")]
	        public string ReceiverName { get; set; }
	
	        /// <summary>
	        /// 收件人Nick
	        /// </summary>
	        [XmlElement("receiver_nick")]
	        public string ReceiverNick { get; set; }
	
	        /// <summary>
	        /// 收件人电话
	        /// </summary>
	        [XmlElement("receiver_phone")]
	        public string ReceiverPhone { get; set; }
	
	        /// <summary>
	        /// 收件方省份
	        /// </summary>
	        [XmlElement("receiver_province")]
	        public string ReceiverProvince { get; set; }
	
	        /// <summary>
	        /// 收件方街道
	        /// </summary>
	        [XmlElement("receiver_town")]
	        public string ReceiverTown { get; set; }
	
	        /// <summary>
	        /// 收件方邮编
	        /// </summary>
	        [XmlElement("receiver_zip_code")]
	        public string ReceiverZipCode { get; set; }
}

	/// <summary>
/// SenderwlbwmsconsignordernotifyDomain Data Structure.
/// </summary>
[Serializable]
public class SenderwlbwmsconsignordernotifyDomain : TopObject
{
	        /// <summary>
	        /// 发件方地址
	        /// </summary>
	        [XmlElement("sender_address")]
	        public string SenderAddress { get; set; }
	
	        /// <summary>
	        /// 发件方区县
	        /// </summary>
	        [XmlElement("sender_area")]
	        public string SenderArea { get; set; }
	
	        /// <summary>
	        /// 发件方城市
	        /// </summary>
	        [XmlElement("sender_city")]
	        public string SenderCity { get; set; }
	
	        /// <summary>
	        /// 发件方手机
	        /// </summary>
	        [XmlElement("sender_mobile")]
	        public string SenderMobile { get; set; }
	
	        /// <summary>
	        /// 发件方名称
	        /// </summary>
	        [XmlElement("sender_name")]
	        public string SenderName { get; set; }
	
	        /// <summary>
	        /// 发件方电话
	        /// </summary>
	        [XmlElement("sender_phone")]
	        public string SenderPhone { get; set; }
	
	        /// <summary>
	        /// 发件方省份
	        /// </summary>
	        [XmlElement("sender_province")]
	        public string SenderProvince { get; set; }
	
	        /// <summary>
	        /// 发件方镇
	        /// </summary>
	        [XmlElement("sender_town")]
	        public string SenderTown { get; set; }
	
	        /// <summary>
	        /// 发件方邮编
	        /// </summary>
	        [XmlElement("sender_zip_code")]
	        public string SenderZipCode { get; set; }
}

	/// <summary>
/// OrderitemwlbwmsconsignordernotifyDomain Data Structure.
/// </summary>
[Serializable]
public class OrderitemwlbwmsconsignordernotifyDomain : TopObject
{
	        /// <summary>
	        /// 商品成交价格=销售价格-优惠金额
	        /// </summary>
	        [XmlElement("actual_price")]
	        public Nullable<long> ActualPrice { get; set; }
	
	        /// <summary>
	        /// 商品优惠金额
	        /// </summary>
	        [XmlElement("discount_amount")]
	        public Nullable<long> DiscountAmount { get; set; }
	
	        /// <summary>
	        /// 订单商品拓展属性数据
	        /// </summary>
	        [XmlElement("extend_fields")]
	        public string ExtendFields { get; set; }
	
	        /// <summary>
	        /// 库存类型
	        /// </summary>
	        [XmlElement("inventory_type")]
	        public Nullable<long> InventoryType { get; set; }
	
	        /// <summary>
	        /// 交易平台商品编码
	        /// </summary>
	        [XmlElement("item_ext_code")]
	        public string ItemExtCode { get; set; }
	
	        /// <summary>
	        /// ERP商品ID
	        /// </summary>
	        [XmlElement("item_id")]
	        public string ItemId { get; set; }
	
	        /// <summary>
	        /// 商品名称
	        /// </summary>
	        [XmlElement("item_name")]
	        public string ItemName { get; set; }
	
	        /// <summary>
	        /// 销售价格
	        /// </summary>
	        [XmlElement("item_price")]
	        public Nullable<long> ItemPrice { get; set; }
	
	        /// <summary>
	        /// 商品数量
	        /// </summary>
	        [XmlElement("item_quantity")]
	        public Nullable<long> ItemQuantity { get; set; }
	
	        /// <summary>
	        /// ERP订单明细行号ID，数字类型
	        /// </summary>
	        [XmlElement("order_item_id")]
	        public string OrderItemId { get; set; }
	
	        /// <summary>
	        /// 平台交易订单编码，如果不传入淘系交易订单，子订单系统自动标示此商品为赠品；
	        /// </summary>
	        [XmlElement("order_source_code")]
	        public string OrderSourceCode { get; set; }
	
	        /// <summary>
	        /// 货主ID
	        /// </summary>
	        [XmlElement("owner_user_id")]
	        public string OwnerUserId { get; set; }
	
	        /// <summary>
	        /// 货主名称
	        /// </summary>
	        [XmlElement("owner_user_name")]
	        public string OwnerUserName { get; set; }
	
	        /// <summary>
	        /// ERP店铺编码
	        /// </summary>
	        [XmlElement("shop_code")]
	        public string ShopCode { get; set; }
	
	        /// <summary>
	        /// 平台子交易编码
	        /// </summary>
	        [XmlElement("sub_source_code")]
	        public string SubSourceCode { get; set; }
	
	        /// <summary>
	        /// 店铺ID
	        /// </summary>
	        [XmlElement("user_id")]
	        public string UserId { get; set; }
	
	        /// <summary>
	        /// 店铺名称
	        /// </summary>
	        [XmlElement("user_name")]
	        public string UserName { get; set; }
}

	/// <summary>
/// OrderitemlistwlbwmsconsignordernotifyDomain Data Structure.
/// </summary>
[Serializable]
public class OrderitemlistwlbwmsconsignordernotifyDomain : TopObject
{
	        /// <summary>
	        /// 订单商品信息
	        /// </summary>
	        [XmlElement("order_item")]
	        public OrderitemwlbwmsconsignordernotifyDomain OrderItem { get; set; }
}

	/// <summary>
/// ItemdetailwlbwmsconsignordernotifyDomain Data Structure.
/// </summary>
[Serializable]
public class ItemdetailwlbwmsconsignordernotifyDomain : TopObject
{
	        /// <summary>
	        /// 金额
	        /// </summary>
	        [XmlElement("amount")]
	        public string Amount { get; set; }
	
	        /// <summary>
	        /// 商品名称
	        /// </summary>
	        [XmlElement("item_name")]
	        public string ItemName { get; set; }
	
	        /// <summary>
	        /// 商品价格
	        /// </summary>
	        [XmlElement("price")]
	        public string Price { get; set; }
	
	        /// <summary>
	        /// 商品数量
	        /// </summary>
	        [XmlElement("quantity")]
	        public Nullable<long> Quantity { get; set; }
	
	        /// <summary>
	        /// 单位
	        /// </summary>
	        [XmlElement("unit")]
	        public string Unit { get; set; }
}

	/// <summary>
/// DetaillistwlbwmsconsignordernotifyDomain Data Structure.
/// </summary>
[Serializable]
public class DetaillistwlbwmsconsignordernotifyDomain : TopObject
{
	        /// <summary>
	        /// 发票信息
	        /// </summary>
	        [XmlElement("item_detail")]
	        public ItemdetailwlbwmsconsignordernotifyDomain ItemDetail { get; set; }
}

	/// <summary>
/// InvoicewlbwmsconsignordernotifyDomain Data Structure.
/// </summary>
[Serializable]
public class InvoicewlbwmsconsignordernotifyDomain : TopObject
{
	        /// <summary>
	        /// 发票金额
	        /// </summary>
	        [XmlElement("bill_account")]
	        public string BillAccount { get; set; }
	
	        /// <summary>
	        /// 发票内容
	        /// </summary>
	        [XmlElement("bill_content")]
	        public string BillContent { get; set; }
	
	        /// <summary>
	        /// Erp发票ID
	        /// </summary>
	        [XmlElement("bill_id")]
	        public Nullable<long> BillId { get; set; }
	
	        /// <summary>
	        /// 发票抬头
	        /// </summary>
	        [XmlElement("bill_title")]
	        public string BillTitle { get; set; }
	
	        /// <summary>
	        /// 发票类型(VINVOICE - 增值税普通发票， EVINVOICE - 电子增票，电子发票仓库不打印)
	        /// </summary>
	        [XmlElement("bill_type")]
	        public string BillType { get; set; }
	
	        /// <summary>
	        /// 发票明细列表
	        /// </summary>
	        [XmlArray("detail_list")]
	        [XmlArrayItem("detaillistwlbwmsconsignordernotify")]
	        public List<DetaillistwlbwmsconsignordernotifyDomain> DetailList { get; set; }
}

	/// <summary>
/// InvoicelistwlbwmsconsignordernotifyDomain Data Structure.
/// </summary>
[Serializable]
public class InvoicelistwlbwmsconsignordernotifyDomain : TopObject
{
	        /// <summary>
	        /// 发票信息
	        /// </summary>
	        [XmlElement("invoice_info")]
	        public InvoicewlbwmsconsignordernotifyDomain InvoiceInfo { get; set; }
}

        #endregion
    }
}
