using System;
using System.Xml.Serialization;
using System.Collections.Generic;

namespace Top.Api.Domain
{
    /// <summary>
    /// WaybillApplyFullUpdateRequest Data Structure.
    /// </summary>
    [Serializable]
    public class WaybillApplyFullUpdateRequest : TopObject
    {
        /// <summary>
        /// TOP平台请求的ISV APPKEY
        /// </summary>
        [XmlElement("app_key")]
        public string AppKey { get; set; }

        /// <summary>
        /// 收货地址
        /// </summary>
        [XmlElement("consignee_address")]
        public Top.Api.Domain.WaybillAddress ConsigneeAddress { get; set; }

        /// <summary>
        /// 收件人姓名
        /// </summary>
        [XmlElement("consignee_name")]
        public string ConsigneeName { get; set; }

        /// <summary>
        /// 收件人电话
        /// </summary>
        [XmlElement("consignee_phone")]
        public string ConsigneePhone { get; set; }

        /// <summary>
        /// 快递服务商CODE
        /// </summary>
        [XmlElement("cp_code")]
        public string CpCode { get; set; }

        /// <summary>
        /// 快递服务商的ID
        /// </summary>
        [XmlElement("cp_id")]
        public Nullable<long> CpId { get; set; }

        /// <summary>
        /// 商品名称
        /// </summary>
        [XmlElement("item_name")]
        public string ItemName { get; set; }

        /// <summary>
        /// 物流服务能力集合
        /// </summary>
        [XmlArray("logistics_service_list")]
        [XmlArrayItem("logistics_service")]
        public List<Top.Api.Domain.LogisticsService> LogisticsServiceList { get; set; }

        /// <summary>
        /// 订单渠道类型
        /// </summary>
        [XmlElement("order_channels_type")]
        public string OrderChannelsType { get; set; }

        /// <summary>
        /// 订单类型
        /// </summary>
        [XmlElement("order_type")]
        public Nullable<long> OrderType { get; set; }

        /// <summary>
        /// ERP 订单号或包裹号
        /// </summary>
        [XmlElement("package_id")]
        public string PackageId { get; set; }

        /// <summary>
        /// 包裹内商品类型
        /// </summary>
        [XmlArray("package_items")]
        [XmlArrayItem("package_item")]
        public List<Top.Api.Domain.PackageItem> PackageItems { get; set; }

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
        /// 申请者ID
        /// </summary>
        [XmlElement("seller_id")]
        public Nullable<long> SellerId { get; set; }

        /// <summary>
        /// 发件人姓名
        /// </summary>
        [XmlElement("send_name")]
        public string SendName { get; set; }

        /// <summary>
        /// 发件人联系方式
        /// </summary>
        [XmlElement("send_phone")]
        public string SendPhone { get; set; }

        /// <summary>
        /// 发货地址
        /// </summary>
        [XmlElement("shipping_address")]
        public Top.Api.Domain.WaybillAddress ShippingAddress { get; set; }

        /// <summary>
        /// 交易订单号（组合表示合并订单）
        /// </summary>
        [XmlArray("trade_order_list")]
        [XmlArrayItem("string")]
        public List<string> TradeOrderList { get; set; }

        /// <summary>
        /// 包裹体积 单位为ML(毫升)或立方厘米
        /// </summary>
        [XmlElement("volume")]
        public Nullable<long> Volume { get; set; }

        /// <summary>
        /// 电子面单单号
        /// </summary>
        [XmlElement("waybill_code")]
        public string WaybillCode { get; set; }

        /// <summary>
        /// 包裹重量 单位为G(克)
        /// </summary>
        [XmlElement("weight")]
        public Nullable<long> Weight { get; set; }
    }
}
