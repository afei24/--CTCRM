using System;
using System.Xml.Serialization;
using System.Collections.Generic;

namespace Top.Api.Response
{
    /// <summary>
    /// WlbWmsConsignBillGetResponse.
    /// </summary>
    public class WlbWmsConsignBillGetResponse : TopResponse
    {
        /// <summary>
        /// 商品信息列表
        /// </summary>
        [XmlArray("consign_send_info_list")]
        [XmlArrayItem("consignsendinfolist")]
        public List<ConsignsendinfolistDomain> ConsignSendInfoList { get; set; }

	/// <summary>
/// InventoryitemDomain Data Structure.
/// </summary>
[Serializable]
public class InventoryitemDomain : TopObject
{
	        /// <summary>
	        /// 批次号
	        /// </summary>
	        [XmlElement("batch_code")]
	        public string BatchCode { get; set; }
	
	        /// <summary>
	        /// 商品保质期信息，失效日期
	        /// </summary>
	        [XmlElement("due_date")]
	        public string DueDate { get; set; }
	
	        /// <summary>
	        /// 库存类型：1 可销售库存 (正品) 101 类型用来定义残次品 201 冻结类型库存 301 在途库存
	        /// </summary>
	        [XmlElement("inventory_type")]
	        public long InventoryType { get; set; }
	
	        /// <summary>
	        /// 数量
	        /// </summary>
	        [XmlElement("item_qty")]
	        public long ItemQty { get; set; }
	
	        /// <summary>
	        /// 生产地区
	        /// </summary>
	        [XmlElement("produce_area")]
	        public string ProduceArea { get; set; }
	
	        /// <summary>
	        /// 生产编码，同一商品可能因商家不同有不同编码
	        /// </summary>
	        [XmlElement("produce_code")]
	        public string ProduceCode { get; set; }
	
	        /// <summary>
	        /// 商品保质期信息，生产日期
	        /// </summary>
	        [XmlElement("produce_date")]
	        public string ProduceDate { get; set; }
}

	/// <summary>
/// InventoryitemlistDomain Data Structure.
/// </summary>
[Serializable]
public class InventoryitemlistDomain : TopObject
{
	        /// <summary>
	        /// 商品属性列表
	        /// </summary>
	        [XmlElement("inventory_item")]
	        public InventoryitemDomain InventoryItem { get; set; }
}

	/// <summary>
/// OrderitemDomain Data Structure.
/// </summary>
[Serializable]
public class OrderitemDomain : TopObject
{
	        /// <summary>
	        /// 商品属性列表
	        /// </summary>
	        [XmlArray("inventory_item_list")]
	        [XmlArrayItem("inventoryitemlist")]
	        public List<InventoryitemlistDomain> InventoryItemList { get; set; }
	
	        /// <summary>
	        /// 商家编码
	        /// </summary>
	        [XmlElement("item_code")]
	        public string ItemCode { get; set; }
	
	        /// <summary>
	        /// 商品ID
	        /// </summary>
	        [XmlElement("item_id")]
	        public string ItemId { get; set; }
	
	        /// <summary>
	        /// 订单明细行编码
	        /// </summary>
	        [XmlElement("order_item_id")]
	        public string OrderItemId { get; set; }
	
	        /// <summary>
	        /// 交易单号
	        /// </summary>
	        [XmlElement("order_source_code")]
	        public string OrderSourceCode { get; set; }
}

	/// <summary>
/// OrderitemlistDomain Data Structure.
/// </summary>
[Serializable]
public class OrderitemlistDomain : TopObject
{
	        /// <summary>
	        /// 订单商品信息
	        /// </summary>
	        [XmlElement("order_item")]
	        public OrderitemDomain OrderItem { get; set; }
}

	/// <summary>
/// PackagematerialDomain Data Structure.
/// </summary>
[Serializable]
public class PackagematerialDomain : TopObject
{
	        /// <summary>
	        /// 包材的数量
	        /// </summary>
	        [XmlElement("material_quantity")]
	        public string MaterialQuantity { get; set; }
	
	        /// <summary>
	        /// 淘宝指定的包材型号
	        /// </summary>
	        [XmlElement("material_type")]
	        public string MaterialType { get; set; }
}

	/// <summary>
/// PackagemateriallistDomain Data Structure.
/// </summary>
[Serializable]
public class PackagemateriallistDomain : TopObject
{
	        /// <summary>
	        /// 包裹包材信息
	        /// </summary>
	        [XmlElement("package_material")]
	        public PackagematerialDomain PackageMaterial { get; set; }
}

	/// <summary>
/// TmsitemDomain Data Structure.
/// </summary>
[Serializable]
public class TmsitemDomain : TopObject
{
	        /// <summary>
	        /// 商家编码
	        /// </summary>
	        [XmlElement("item_code")]
	        public string ItemCode { get; set; }
	
	        /// <summary>
	        /// ERP商品ID
	        /// </summary>
	        [XmlElement("item_id")]
	        public string ItemId { get; set; }
	
	        /// <summary>
	        /// 此运单里该商品的数量
	        /// </summary>
	        [XmlElement("item_qty")]
	        public long ItemQty { get; set; }
}

	/// <summary>
/// TmsitemlistDomain Data Structure.
/// </summary>
[Serializable]
public class TmsitemlistDomain : TopObject
{
	        /// <summary>
	        /// 包裹里面商品
	        /// </summary>
	        [XmlElement("tms_item")]
	        public TmsitemDomain TmsItem { get; set; }
}

	/// <summary>
/// TmsorderDomain Data Structure.
/// </summary>
[Serializable]
public class TmsorderDomain : TopObject
{
	        /// <summary>
	        /// 包裹号
	        /// </summary>
	        [XmlElement("package_code")]
	        public string PackageCode { get; set; }
	
	        /// <summary>
	        /// 包裹高度，单位：毫米
	        /// </summary>
	        [XmlElement("package_height")]
	        public long PackageHeight { get; set; }
	
	        /// <summary>
	        /// 包裹长度，单位：毫米
	        /// </summary>
	        [XmlElement("package_length")]
	        public long PackageLength { get; set; }
	
	        /// <summary>
	        /// 包材信息
	        /// </summary>
	        [XmlArray("package_material_list")]
	        [XmlArrayItem("packagemateriallist")]
	        public List<PackagemateriallistDomain> PackageMaterialList { get; set; }
	
	        /// <summary>
	        /// 包裹重量，单位：克
	        /// </summary>
	        [XmlElement("package_weight")]
	        public long PackageWeight { get; set; }
	
	        /// <summary>
	        /// 包裹宽度，单位：毫米
	        /// </summary>
	        [XmlElement("package_width")]
	        public long PackageWidth { get; set; }
	
	        /// <summary>
	        /// 快递公司服务编码
	        /// </summary>
	        [XmlElement("tms_code")]
	        public string TmsCode { get; set; }
	
	        /// <summary>
	        /// 包裹里面的商品信息列表
	        /// </summary>
	        [XmlArray("tms_item_list")]
	        [XmlArrayItem("tmsitemlist")]
	        public List<TmsitemlistDomain> TmsItemList { get; set; }
	
	        /// <summary>
	        /// 运单编码
	        /// </summary>
	        [XmlElement("tms_order_code")]
	        public string TmsOrderCode { get; set; }
}

	/// <summary>
/// TmsorderlistDomain Data Structure.
/// </summary>
[Serializable]
public class TmsorderlistDomain : TopObject
{
	        /// <summary>
	        /// 运单信息列表
	        /// </summary>
	        [XmlElement("tms_order")]
	        public TmsorderDomain TmsOrder { get; set; }
}

	/// <summary>
/// InvoinceconfirmDomain Data Structure.
/// </summary>
[Serializable]
public class InvoinceconfirmDomain : TopObject
{
	        /// <summary>
	        /// Erp发票ID
	        /// </summary>
	        [XmlElement("bill_id")]
	        public string BillId { get; set; }
	
	        /// <summary>
	        /// 发票代码
	        /// </summary>
	        [XmlElement("invoice_code")]
	        public string InvoiceCode { get; set; }
	
	        /// <summary>
	        /// 发票号
	        /// </summary>
	        [XmlElement("invoice_number")]
	        public string InvoiceNumber { get; set; }
}

	/// <summary>
/// InvoinceconfirmlistDomain Data Structure.
/// </summary>
[Serializable]
public class InvoinceconfirmlistDomain : TopObject
{
	        /// <summary>
	        /// 发票确认信息
	        /// </summary>
	        [XmlElement("invoince_confirm")]
	        public InvoinceconfirmDomain InvoinceConfirm { get; set; }
}

	/// <summary>
/// ConsignsendinfoDomain Data Structure.
/// </summary>
[Serializable]
public class ConsignsendinfoDomain : TopObject
{
	        /// <summary>
	        /// 菜鸟订单编码
	        /// </summary>
	        [XmlElement("cn_order_code")]
	        public string CnOrderCode { get; set; }
	
	        /// <summary>
	        /// 仓库订单完成时间
	        /// </summary>
	        [XmlElement("confirm_time")]
	        public string ConfirmTime { get; set; }
	
	        /// <summary>
	        /// 发票确认信息列表
	        /// </summary>
	        [XmlArray("invoince_confirm_list")]
	        [XmlArrayItem("invoinceconfirmlist")]
	        public List<InvoinceconfirmlistDomain> InvoinceConfirmList { get; set; }
	
	        /// <summary>
	        /// ERP订单编码
	        /// </summary>
	        [XmlElement("order_code")]
	        public string OrderCode { get; set; }
	
	        /// <summary>
	        /// 订单信息
	        /// </summary>
	        [XmlArray("order_item_list")]
	        [XmlArrayItem("orderitemlist")]
	        public List<OrderitemlistDomain> OrderItemList { get; set; }
	
	        /// <summary>
	        /// 订单类型 201 销售出库 502 换货出库 503 补发出库
	        /// </summary>
	        [XmlElement("order_type")]
	        public long OrderType { get; set; }
	
	        /// <summary>
	        /// 订单状态 WMS_ACCEPT 接单成功 WMS_REJECT 接单失败 WMS_CONFIRMED 仓库生产完成
	        /// </summary>
	        [XmlElement("status")]
	        public string Status { get; set; }
	
	        /// <summary>
	        /// 仓储编码
	        /// </summary>
	        [XmlElement("store_code")]
	        public string StoreCode { get; set; }
	
	        /// <summary>
	        /// 运单信息
	        /// </summary>
	        [XmlArray("tms_order_list")]
	        [XmlArrayItem("tmsorderlist")]
	        public List<TmsorderlistDomain> TmsOrderList { get; set; }
}

	/// <summary>
/// ConsignsendinfolistDomain Data Structure.
/// </summary>
[Serializable]
public class ConsignsendinfolistDomain : TopObject
{
	        /// <summary>
	        /// 物流订单发货信息
	        /// </summary>
	        [XmlElement("consign_send_info")]
	        public ConsignsendinfoDomain ConsignSendInfo { get; set; }
}

    }
}
