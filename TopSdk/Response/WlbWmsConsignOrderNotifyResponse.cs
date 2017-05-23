using System;
using System.Xml.Serialization;
using System.Collections.Generic;

namespace Top.Api.Response
{
    /// <summary>
    /// WlbWmsConsignOrderNotifyResponse.
    /// </summary>
    public class WlbWmsConsignOrderNotifyResponse : TopResponse
    {
        /// <summary>
        /// 系统自动生成
        /// </summary>
        [XmlArray("consign_order_list")]
        [XmlArrayItem("consignorderlist")]
        public List<ConsignorderlistDomain> ConsignOrderList { get; set; }

        /// <summary>
        /// 订单编码
        /// </summary>
        [XmlElement("order_code")]
        public string OrderCode { get; set; }

        /// <summary>
        /// 错误编码
        /// </summary>
        [XmlElement("wl_error_code")]
        public string WlErrorCode { get; set; }

        /// <summary>
        /// 错误详细
        /// </summary>
        [XmlElement("wl_error_msg")]
        public string WlErrorMsg { get; set; }

        /// <summary>
        /// 是否成功
        /// </summary>
        [XmlElement("wl_success")]
        public bool WlSuccess { get; set; }

	/// <summary>
/// ConsignorderitemDomain Data Structure.
/// </summary>
[Serializable]
public class ConsignorderitemDomain : TopObject
{
	        /// <summary>
	        /// 商品编码
	        /// </summary>
	        [XmlElement("item_code")]
	        public string ItemCode { get; set; }
	
	        /// <summary>
	        /// 商品ID
	        /// </summary>
	        [XmlElement("item_id")]
	        public string ItemId { get; set; }
	
	        /// <summary>
	        /// 商品数量
	        /// </summary>
	        [XmlElement("item_quantity")]
	        public long ItemQuantity { get; set; }
	
	        /// <summary>
	        /// ERP订单明细行号ID
	        /// </summary>
	        [XmlElement("order_item_id")]
	        public string OrderItemId { get; set; }
}

	/// <summary>
/// ConsignorderitemlistDomain Data Structure.
/// </summary>
[Serializable]
public class ConsignorderitemlistDomain : TopObject
{
	        /// <summary>
	        /// 仓库物流订单信息列表
	        /// </summary>
	        [XmlElement("consign_order_item")]
	        public ConsignorderitemDomain ConsignOrderItem { get; set; }
}

	/// <summary>
/// ConsignorderDomain Data Structure.
/// </summary>
[Serializable]
public class ConsignorderDomain : TopObject
{
	        /// <summary>
	        /// 仓库物流订单信息列表
	        /// </summary>
	        [XmlArray("consign_order_item_list")]
	        [XmlArrayItem("consignorderitemlist")]
	        public List<ConsignorderitemlistDomain> ConsignOrderItemList { get; set; }
	
	        /// <summary>
	        /// 错误编码
	        /// </summary>
	        [XmlElement("error_code")]
	        public string ErrorCode { get; set; }
	
	        /// <summary>
	        /// 错误信息
	        /// </summary>
	        [XmlElement("error_msg")]
	        public string ErrorMsg { get; set; }
	
	        /// <summary>
	        /// 仓库编码
	        /// </summary>
	        [XmlElement("store_code")]
	        public string StoreCode { get; set; }
	
	        /// <summary>
	        /// 仓库订单编码
	        /// </summary>
	        [XmlElement("store_order_code")]
	        public string StoreOrderCode { get; set; }
	
	        /// <summary>
	        /// 是否成功
	        /// </summary>
	        [XmlElement("success")]
	        public bool Success { get; set; }
	
	        /// <summary>
	        /// 配送编码
	        /// </summary>
	        [XmlElement("tms_code")]
	        public string TmsCode { get; set; }
}

	/// <summary>
/// ConsignorderlistDomain Data Structure.
/// </summary>
[Serializable]
public class ConsignorderlistDomain : TopObject
{
	        /// <summary>
	        /// 发货订单信息
	        /// </summary>
	        [XmlElement("consign_order")]
	        public ConsignorderDomain ConsignOrder { get; set; }
}

    }
}
