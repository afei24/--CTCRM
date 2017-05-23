using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using Top.Api.Util;

namespace Top.Api.Request
{
    /// <summary>
    /// TOP API: taobao.wlb.wms.consign.order.confirm
    /// </summary>
    public class WlbWmsConsignOrderConfirmRequest : BaseTopRequest<Top.Api.Response.WlbWmsConsignOrderConfirmResponse>
    {
        /// <summary>
        /// 发货订单信息
        /// </summary>
        public string Content { get; set; }

        public WlbWmsConsignOrderConfirmDomain Content_ { set { this.Content = TopUtils.ObjectToJson(value); } } 

        #region ITopRequest Members

        public override string GetApiName()
        {
            return "taobao.wlb.wms.consign.order.confirm";
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

	/// <summary>
/// TmsItemsWlbWmsConsignOrderConfirmDomain Data Structure.
/// </summary>
[Serializable]
public class TmsItemsWlbWmsConsignOrderConfirmDomain : TopObject
{
	        /// <summary>
	        /// 批次编号
	        /// </summary>
	        [XmlElement("batch_code")]
	        public string BatchCode { get; set; }
	
	        /// <summary>
	        /// 商品过期日期
	        /// </summary>
	        [XmlElement("due_date")]
	        public string DueDate { get; set; }
	
	        /// <summary>
	        /// 后端商品ID
	        /// </summary>
	        [XmlElement("item_id")]
	        public string ItemId { get; set; }
	
	        /// <summary>
	        /// 商品数量，此包裹内商品的数量
	        /// </summary>
	        [XmlElement("item_quantity")]
	        public Nullable<long> ItemQuantity { get; set; }
	
	        /// <summary>
	        /// ERP订单明细行号ID
	        /// </summary>
	        [XmlElement("order_item_id")]
	        public string OrderItemId { get; set; }
	
	        /// <summary>
	        /// 商品生产批号
	        /// </summary>
	        [XmlElement("produce_code")]
	        public string ProduceCode { get; set; }
	
	        /// <summary>
	        /// 商品生产日期
	        /// </summary>
	        [XmlElement("product_date")]
	        public string ProductDate { get; set; }
}

	/// <summary>
/// PackageMaterialListWlbWmsConsignOrderConfirmDomain Data Structure.
/// </summary>
[Serializable]
public class PackageMaterialListWlbWmsConsignOrderConfirmDomain : TopObject
{
	        /// <summary>
	        /// 包材的数量
	        /// </summary>
	        [XmlElement("material_quantity")]
	        public Nullable<long> MaterialQuantity { get; set; }
	
	        /// <summary>
	        /// 包材型号
	        /// </summary>
	        [XmlElement("material_type")]
	        public string MaterialType { get; set; }
}

	/// <summary>
/// TmsOrdersWlbWmsConsignOrderConfirmDomain Data Structure.
/// </summary>
[Serializable]
public class TmsOrdersWlbWmsConsignOrderConfirmDomain : TopObject
{
	        /// <summary>
	        /// 包裹编号
	        /// </summary>
	        [XmlElement("package_code")]
	        public string PackageCode { get; set; }
	
	        /// <summary>
	        /// 包裹高度，单位：毫米
	        /// </summary>
	        [XmlElement("package_height")]
	        public Nullable<long> PackageHeight { get; set; }
	
	        /// <summary>
	        /// 包裹长度，单位：毫米
	        /// </summary>
	        [XmlElement("package_length")]
	        public Nullable<long> PackageLength { get; set; }
	
	        /// <summary>
	        /// 系统自动生成
	        /// </summary>
	        [XmlArray("package_material_list")]
	        [XmlArrayItem("package_material_list_wlb_wms_consign_order_confirm")]
	        public List<PackageMaterialListWlbWmsConsignOrderConfirmDomain> PackageMaterialList { get; set; }
	
	        /// <summary>
	        /// 包裹重量，单位：克
	        /// </summary>
	        [XmlElement("package_weight")]
	        public Nullable<long> PackageWeight { get; set; }
	
	        /// <summary>
	        /// 包裹宽度，单位：毫米
	        /// </summary>
	        [XmlElement("package_width")]
	        public Nullable<long> PackageWidth { get; set; }
	
	        /// <summary>
	        /// 快递公司编码
	        /// </summary>
	        [XmlElement("tms_code")]
	        public string TmsCode { get; set; }
	
	        /// <summary>
	        /// 系统自动生成
	        /// </summary>
	        [XmlArray("tms_items")]
	        [XmlArrayItem("tms_items_wlb_wms_consign_order_confirm")]
	        public List<TmsItemsWlbWmsConsignOrderConfirmDomain> TmsItems { get; set; }
	
	        /// <summary>
	        /// 运单号
	        /// </summary>
	        [XmlElement("tms_order_code")]
	        public string TmsOrderCode { get; set; }
}

	/// <summary>
/// InvoinceConfirmsWlbWmsConsignOrderConfirmDomain Data Structure.
/// </summary>
[Serializable]
public class InvoinceConfirmsWlbWmsConsignOrderConfirmDomain : TopObject
{
	        /// <summary>
	        /// ERP发票ID
	        /// </summary>
	        [XmlElement("bill_id")]
	        public Nullable<long> BillId { get; set; }
	
	        /// <summary>
	        /// 发票代码
	        /// </summary>
	        [XmlElement("invoice_code")]
	        public string InvoiceCode { get; set; }
	
	        /// <summary>
	        /// 发票号码
	        /// </summary>
	        [XmlElement("invoice_number")]
	        public string InvoiceNumber { get; set; }
	
	        /// <summary>
	        /// 交易号
	        /// </summary>
	        [XmlElement("trade_number")]
	        public string TradeNumber { get; set; }
}

	/// <summary>
/// WlbWmsConsignOrderConfirmDomain Data Structure.
/// </summary>
[Serializable]
public class WlbWmsConsignOrderConfirmDomain : TopObject
{
	        /// <summary>
	        /// 支持出入库单多次确认 0 最后一次确认或是一次性确认； 1 多次确认；当多次确认时，确认的ITEM种类全部被确认时，确认完成默认值为 0 例如输入2认为是0
	        /// </summary>
	        [XmlElement("confirm_type")]
	        public Nullable<long> ConfirmType { get; set; }
	
	        /// <summary>
	        /// 系统自动生成
	        /// </summary>
	        [XmlArray("invoince_confirms")]
	        [XmlArrayItem("invoince_confirms_wlb_wms_consign_order_confirm")]
	        public List<InvoinceConfirmsWlbWmsConsignOrderConfirmDomain> InvoinceConfirms { get; set; }
	
	        /// <summary>
	        /// 商家订单编码
	        /// </summary>
	        [XmlElement("order_code")]
	        public string OrderCode { get; set; }
	
	        /// <summary>
	        /// 订单出库完成时间
	        /// </summary>
	        [XmlElement("order_confirm_time")]
	        public string OrderConfirmTime { get; set; }
	
	        /// <summary>
	        /// 拆合单信息，如果仓库合并ERP订单后，将多个ERP订单合并在这个字段中；
	        /// </summary>
	        [XmlElement("order_join")]
	        public string OrderJoin { get; set; }
	
	        /// <summary>
	        /// 单据类型 201 一般交易出库单 202 B2B交易出库单 502 换货出库单 503 补发出库单
	        /// </summary>
	        [XmlElement("order_type")]
	        public Nullable<long> OrderType { get; set; }
	
	        /// <summary>
	        /// 外部业务编码，消息ID，用于去重，一个合作伙伴中要求唯一，多次确认时，每次传入要求唯一
	        /// </summary>
	        [XmlElement("out_biz_code")]
	        public string OutBizCode { get; set; }
	
	        /// <summary>
	        /// 仓储订单编码
	        /// </summary>
	        [XmlElement("store_order_code")]
	        public string StoreOrderCode { get; set; }
	
	        /// <summary>
	        /// 系统自动生成
	        /// </summary>
	        [XmlArray("tms_orders")]
	        [XmlArrayItem("tms_orders_wlb_wms_consign_order_confirm")]
	        public List<TmsOrdersWlbWmsConsignOrderConfirmDomain> TmsOrders { get; set; }
}

        #endregion
    }
}
