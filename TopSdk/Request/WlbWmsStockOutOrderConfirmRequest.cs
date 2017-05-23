using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using Top.Api.Util;

namespace Top.Api.Request
{
    /// <summary>
    /// TOP API: taobao.wlb.wms.stock.out.order.confirm
    /// </summary>
    public class WlbWmsStockOutOrderConfirmRequest : BaseTopRequest<Top.Api.Response.WlbWmsStockOutOrderConfirmResponse>
    {
        /// <summary>
        /// 出库订单确认信息
        /// </summary>
        public string Content { get; set; }

        public WlbWmsStockOutOrderConfirmDomain Content_ { set { this.Content = TopUtils.ObjectToJson(value); } } 

        #region ITopRequest Members

        public override string GetApiName()
        {
            return "taobao.wlb.wms.stock.out.order.confirm";
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
/// ItemsWlbWmsStockOutOrderConfirmDomain Data Structure.
/// </summary>
[Serializable]
public class ItemsWlbWmsStockOutOrderConfirmDomain : TopObject
{
	        /// <summary>
	        /// 批次号
	        /// </summary>
	        [XmlElement("batch_code")]
	        public string BatchCode { get; set; }
	
	        /// <summary>
	        /// 失效日期
	        /// </summary>
	        [XmlElement("due_date")]
	        public string DueDate { get; set; }
	
	        /// <summary>
	        /// 库存类型 1 可销售库存  101 类型用来定义残次品  201  冻结类型库存 301 在途库存
	        /// </summary>
	        [XmlElement("inventory_type")]
	        public Nullable<long> InventoryType { get; set; }
	
	        /// <summary>
	        /// 生产批号
	        /// </summary>
	        [XmlElement("produce_code")]
	        public string ProduceCode { get; set; }
	
	        /// <summary>
	        /// 生产日期
	        /// </summary>
	        [XmlElement("produce_date")]
	        public string ProduceDate { get; set; }
	
	        /// <summary>
	        /// 数量
	        /// </summary>
	        [XmlElement("quantity")]
	        public Nullable<long> Quantity { get; set; }
}

	/// <summary>
/// OrderItemsWlbWmsStockOutOrderConfirmDomain Data Structure.
/// </summary>
[Serializable]
public class OrderItemsWlbWmsStockOutOrderConfirmDomain : TopObject
{
	        /// <summary>
	        /// 是否完成
	        /// </summary>
	        [XmlElement("is_completed")]
	        public Nullable<bool> IsCompleted { get; set; }
	
	        /// <summary>
	        /// 商品码
	        /// </summary>
	        [XmlElement("item_code")]
	        public string ItemCode { get; set; }
	
	        /// <summary>
	        /// 商品ID
	        /// </summary>
	        [XmlElement("item_id")]
	        public string ItemId { get; set; }
	
	        /// <summary>
	        /// 系统自动生成
	        /// </summary>
	        [XmlArray("items")]
	        [XmlArrayItem("items_wlb_wms_stock_out_order_confirm")]
	        public List<ItemsWlbWmsStockOutOrderConfirmDomain> Items { get; set; }
	
	        /// <summary>
	        /// ERP订单明细行号ID
	        /// </summary>
	        [XmlElement("order_item_id")]
	        public string OrderItemId { get; set; }
}

	/// <summary>
/// PackageItemItemsWlbWmsStockOutOrderConfirmDomain Data Structure.
/// </summary>
[Serializable]
public class PackageItemItemsWlbWmsStockOutOrderConfirmDomain : TopObject
{
	        /// <summary>
	        /// 后端商品ID
	        /// </summary>
	        [XmlElement("item_id")]
	        public string ItemId { get; set; }
	
	        /// <summary>
	        /// 此包裹里该商品的数量
	        /// </summary>
	        [XmlElement("item_quantity")]
	        public Nullable<long> ItemQuantity { get; set; }
}

	/// <summary>
/// PackageInfosWlbWmsStockOutOrderConfirmDomain Data Structure.
/// </summary>
[Serializable]
public class PackageInfosWlbWmsStockOutOrderConfirmDomain : TopObject
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
	        /// 系统自动生成
	        /// </summary>
	        [XmlArray("package_item_items")]
	        [XmlArrayItem("package_item_items_wlb_wms_stock_out_order_confirm")]
	        public List<PackageItemItemsWlbWmsStockOutOrderConfirmDomain> PackageItemItems { get; set; }
	
	        /// <summary>
	        /// 包裹长度，单位：毫米
	        /// </summary>
	        [XmlElement("package_length")]
	        public Nullable<long> PackageLength { get; set; }
	
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
	        /// 运单号
	        /// </summary>
	        [XmlElement("tms_order_code")]
	        public string TmsOrderCode { get; set; }
}

	/// <summary>
/// WlbWmsStockOutOrderConfirmDomain Data Structure.
/// </summary>
[Serializable]
public class WlbWmsStockOutOrderConfirmDomain : TopObject
{
	        /// <summary>
	        /// 运输公司名称
	        /// </summary>
	        [XmlElement("carriers_name")]
	        public string CarriersName { get; set; }
	
	        /// <summary>
	        /// 支持出入库单多次确认 0 最后一次确认或是一次性确认；1 多次确认；当多次确认时，确认的ITEM种类全部被确认时，确认完成默  认值为 0 例如输入2认为是0
	        /// </summary>
	        [XmlElement("confirm_type")]
	        public Nullable<long> ConfirmType { get; set; }
	
	        /// <summary>
	        /// 仓库订单编码
	        /// </summary>
	        [XmlElement("order_code")]
	        public string OrderCode { get; set; }
	
	        /// <summary>
	        /// 订单出库时间
	        /// </summary>
	        [XmlElement("order_confirm_time")]
	        public string OrderConfirmTime { get; set; }
	
	        /// <summary>
	        /// 订单商品信息列表
	        /// </summary>
	        [XmlArray("order_items")]
	        [XmlArrayItem("order_items_wlb_wms_stock_out_order_confirm")]
	        public List<OrderItemsWlbWmsStockOutOrderConfirmDomain> OrderItems { get; set; }
	
	        /// <summary>
	        /// 单据类型 301 调拨出库单、901普通出库单、903 其他出库单、305 B2B出库单
	        /// </summary>
	        [XmlElement("order_type")]
	        public Nullable<long> OrderType { get; set; }
	
	        /// <summary>
	        /// 外部业务编码
	        /// </summary>
	        [XmlElement("out_biz_code")]
	        public string OutBizCode { get; set; }
	
	        /// <summary>
	        /// 包裹信息列表
	        /// </summary>
	        [XmlArray("package_infos")]
	        [XmlArrayItem("package_infos_wlb_wms_stock_out_order_confirm")]
	        public List<PackageInfosWlbWmsStockOutOrderConfirmDomain> PackageInfos { get; set; }
	
	        /// <summary>
	        /// 仓配订单编码
	        /// </summary>
	        [XmlElement("store_order_code")]
	        public string StoreOrderCode { get; set; }
	
	        /// <summary>
	        /// 运单号&托运单号
	        /// </summary>
	        [XmlElement("tms_order_code")]
	        public string TmsOrderCode { get; set; }
	
	        /// <summary>
	        /// 总包裹数
	        /// </summary>
	        [XmlElement("total_package_qty")]
	        public Nullable<long> TotalPackageQty { get; set; }
	
	        /// <summary>
	        /// 总体积，单位立方厘米
	        /// </summary>
	        [XmlElement("total_package_volume")]
	        public Nullable<long> TotalPackageVolume { get; set; }
	
	        /// <summary>
	        /// 总重量，单位克
	        /// </summary>
	        [XmlElement("total_package_weight")]
	        public Nullable<long> TotalPackageWeight { get; set; }
}

        #endregion
    }
}
