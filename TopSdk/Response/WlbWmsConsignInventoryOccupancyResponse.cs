using System;
using System.Xml.Serialization;
using System.Collections.Generic;

namespace Top.Api.Response
{
    /// <summary>
    /// WlbWmsConsignInventoryOccupancyResponse.
    /// </summary>
    public class WlbWmsConsignInventoryOccupancyResponse : TopResponse
    {
        /// <summary>
        /// 返回失败时，是否需求重试，为true时，建议系统自动重试
        /// </summary>
        [XmlElement("is_retry")]
        public bool IsRetry { get; set; }

        /// <summary>
        /// 库存占用明细列表
        /// </summary>
        [XmlArray("item_inventory_list")]
        [XmlArrayItem("iteminventorylist")]
        public List<IteminventorylistDomain> ItemInventoryList { get; set; }

        /// <summary>
        /// ERP订单编码
        /// </summary>
        [XmlElement("order_code")]
        public string OrderCode { get; set; }

        /// <summary>
        /// 错误码
        /// </summary>
        [XmlElement("wl_error_code")]
        public string WlErrorCode { get; set; }

        /// <summary>
        /// 错误信息
        /// </summary>
        [XmlElement("wl_error_msg")]
        public string WlErrorMsg { get; set; }

        /// <summary>
        /// 是否成功
        /// </summary>
        [XmlElement("wl_success")]
        public string WlSuccess { get; set; }

	/// <summary>
/// IteminventoryDomain Data Structure.
/// </summary>
[Serializable]
public class IteminventoryDomain : TopObject
{
	        /// <summary>
	        /// 菜鸟组合货品ID
	        /// </summary>
	        [XmlElement("comb_item_id")]
	        public string CombItemId { get; set; }
	
	        /// <summary>
	        /// 错误码
	        /// </summary>
	        [XmlElement("error_code")]
	        public string ErrorCode { get; set; }
	
	        /// <summary>
	        /// 错误信息
	        /// </summary>
	        [XmlElement("error_msg")]
	        public string ErrorMsg { get; set; }
	
	        /// <summary>
	        /// 菜鸟货品编码
	        /// </summary>
	        [XmlElement("item_code")]
	        public string ItemCode { get; set; }
	
	        /// <summary>
	        /// 菜鸟货品ID
	        /// </summary>
	        [XmlElement("item_id")]
	        public string ItemId { get; set; }
	
	        /// <summary>
	        /// 占用库存数量
	        /// </summary>
	        [XmlElement("item_ocpy_qty")]
	        public long ItemOcpyQty { get; set; }
	
	        /// <summary>
	        /// 交易编码
	        /// </summary>
	        [XmlElement("order_source_code")]
	        public string OrderSourceCode { get; set; }
	
	        /// <summary>
	        /// 仓库编码
	        /// </summary>
	        [XmlElement("store_code")]
	        public string StoreCode { get; set; }
	
	        /// <summary>
	        /// 子交易编码
	        /// </summary>
	        [XmlElement("sub_source_code")]
	        public string SubSourceCode { get; set; }
	
	        /// <summary>
	        /// 是否成功
	        /// </summary>
	        [XmlElement("success")]
	        public bool Success { get; set; }
}

	/// <summary>
/// IteminventorylistDomain Data Structure.
/// </summary>
[Serializable]
public class IteminventorylistDomain : TopObject
{
	        /// <summary>
	        /// 库存占用明细
	        /// </summary>
	        [XmlElement("item_inventory")]
	        public IteminventoryDomain ItemInventory { get; set; }
}

    }
}
