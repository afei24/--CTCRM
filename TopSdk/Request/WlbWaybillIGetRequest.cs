using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using Top.Api.Util;

namespace Top.Api.Request
{
    /// <summary>
    /// TOP API: taobao.wlb.waybill.i.get
    /// </summary>
    public class WlbWaybillIGetRequest : BaseTopRequest<Top.Api.Response.WlbWaybillIGetResponse>
    {
        /// <summary>
        /// 面单申请
        /// </summary>
        public string WaybillApplyNewRequest { get; set; }

        public WaybillApplyNewRequestDomain WaybillApplyNewRequest_ { set { this.WaybillApplyNewRequest = TopUtils.ObjectToJson(value); } } 

        #region ITopRequest Members

        public override string GetApiName()
        {
            return "taobao.wlb.waybill.i.get";
        }

        public override IDictionary<string, string> GetParameters()
        {
            TopDictionary parameters = new TopDictionary();
            parameters.Add("waybill_apply_new_request", this.WaybillApplyNewRequest);
            if (this.otherParams != null)
            {
                parameters.AddAll(this.otherParams);
            }
            return parameters;
        }

        public override void Validate()
        {
            RequestValidator.ValidateRequired("waybill_apply_new_request", this.WaybillApplyNewRequest);
        }

	/// <summary>
/// WaybillAddressDomain Data Structure.
/// </summary>
[Serializable]
public class WaybillAddressDomain : TopObject
{
	        /// <summary>
	        /// 详细地址
	        /// </summary>
	        [XmlElement("address_detail")]
	        public string AddressDetail { get; set; }
	
	        /// <summary>
	        /// 区名称（三级地址）
	        /// </summary>
	        [XmlElement("area")]
	        public string Area { get; set; }
	
	        /// <summary>
	        /// 市名称（二级地址）
	        /// </summary>
	        [XmlElement("city")]
	        public string City { get; set; }
	
	        /// <summary>
	        /// 省名称（一级地址）
	        /// </summary>
	        [XmlElement("province")]
	        public string Province { get; set; }
	
	        /// <summary>
	        /// 街道\镇名称（四级地址）
	        /// </summary>
	        [XmlElement("town")]
	        public string Town { get; set; }
}

	/// <summary>
/// PackageItemDomain Data Structure.
/// </summary>
[Serializable]
public class PackageItemDomain : TopObject
{
	        /// <summary>
	        /// 商品数量
	        /// </summary>
	        [XmlElement("count")]
	        public Nullable<long> Count { get; set; }
	
	        /// <summary>
	        /// 商品名称
	        /// </summary>
	        [XmlElement("item_name")]
	        public string ItemName { get; set; }
}

	/// <summary>
/// LogisticsServiceDomain Data Structure.
/// </summary>
[Serializable]
public class LogisticsServiceDomain : TopObject
{
	        /// <summary>
	        /// 服务编码
	        /// </summary>
	        [XmlElement("service_code")]
	        public string ServiceCode { get; set; }
	
	        /// <summary>
	        /// 服务类型值，json格式表示
	        /// </summary>
	        [XmlElement("service_value4_json")]
	        public string ServiceValue4Json { get; set; }
}

	/// <summary>
/// TradeOrderInfoDomain Data Structure.
/// </summary>
[Serializable]
public class TradeOrderInfoDomain : TopObject
{
	        /// <summary>
	        /// 收\发货地址
	        /// </summary>
	        [XmlElement("consignee_address")]
	        public WaybillAddressDomain ConsigneeAddress { get; set; }
	
	        /// <summary>
	        /// 收货人
	        /// </summary>
	        [XmlElement("consignee_name")]
	        public string ConsigneeName { get; set; }
	
	        /// <summary>
	        /// 收货人联系方式
	        /// </summary>
	        [XmlElement("consignee_phone")]
	        public string ConsigneePhone { get; set; }
	
	        /// <summary>
	        /// 物流服务能力集合
	        /// </summary>
	        [XmlArray("logistics_service_list")]
	        [XmlArrayItem("logistics_service")]
	        public List<LogisticsServiceDomain> LogisticsServiceList { get; set; }
	
	        /// <summary>
	        /// 订单渠道
	        /// </summary>
	        [XmlElement("order_channels_type")]
	        public string OrderChannelsType { get; set; }
	
	        /// <summary>
	        /// 包裹号(或者ERP订单号)
	        /// </summary>
	        [XmlElement("package_id")]
	        public string PackageId { get; set; }
	
	        /// <summary>
	        /// 包裹里面的商品名称
	        /// </summary>
	        [XmlArray("package_items")]
	        [XmlArrayItem("package_item")]
	        public List<PackageItemDomain> PackageItems { get; set; }
	
	        /// <summary>
	        /// 快递服务产品类型编码
	        /// </summary>
	        [XmlElement("product_type")]
	        public string ProductType { get; set; }
	
	        /// <summary>
	        /// 使用者ID
	        /// </summary>
	        [XmlElement("real_user_id")]
	        public Nullable<long> RealUserId { get; set; }
	
	        /// <summary>
	        /// 发货人姓名
	        /// </summary>
	        [XmlElement("send_name")]
	        public string SendName { get; set; }
	
	        /// <summary>
	        /// 发货人联系方式
	        /// </summary>
	        [XmlElement("send_phone")]
	        public string SendPhone { get; set; }
	
	        /// <summary>
	        /// 交易订单列表
	        /// </summary>
	        [XmlArray("trade_order_list")]
	        [XmlArrayItem("string")]
	        public List<string> TradeOrderList { get; set; }
	
	        /// <summary>
	        /// 包裹体积（立方厘米）
	        /// </summary>
	        [XmlElement("volume")]
	        public Nullable<long> Volume { get; set; }
	
	        /// <summary>
	        /// 包裹重量（克）
	        /// </summary>
	        [XmlElement("weight")]
	        public Nullable<long> Weight { get; set; }
}

	/// <summary>
/// WaybillApplyNewRequestDomain Data Structure.
/// </summary>
[Serializable]
public class WaybillApplyNewRequestDomain : TopObject
{
	        /// <summary>
	        /// 物流服务商编码
	        /// </summary>
	        [XmlElement("cp_code")]
	        public string CpCode { get; set; }
	
	        /// <summary>
	        /// 收\发货地址
	        /// </summary>
	        [XmlElement("shipping_address")]
	        public WaybillAddressDomain ShippingAddress { get; set; }
	
	        /// <summary>
	        /// 订单数据
	        /// </summary>
	        [XmlArray("trade_order_info_cols")]
	        [XmlArrayItem("trade_order_info")]
	        public List<TradeOrderInfoDomain> TradeOrderInfoCols { get; set; }
}

        #endregion
    }
}
