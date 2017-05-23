using System;
using System.Xml.Serialization;
using System.Collections.Generic;

namespace Top.Api.Domain
{
    /// <summary>
    /// TradeOrderInfo Data Structure.
    /// </summary>
    [Serializable]
    public class TradeOrderInfo : TopObject
    {
        /// <summary>
        /// 是否阿里系订单
        /// </summary>
        [XmlElement("ali_order")]
        public bool AliOrder { get; set; }

        /// <summary>
        /// 收货人地址
        /// </summary>
        [XmlElement("consignee_address")]
        public Top.Api.Domain.WaybillAddress ConsigneeAddress { get; set; }

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
        /// 订单渠道
        /// </summary>
        [XmlElement("order_channels_type")]
        public string OrderChannelsType { get; set; }

        /// <summary>
        /// 订单渠道来源
        /// </summary>
        [XmlElement("order_type")]
        public long OrderType { get; set; }

        /// <summary>
        /// 包裹号(或者ERP订单号)
        /// </summary>
        [XmlElement("package_id")]
        public string PackageId { get; set; }

        /// <summary>
        /// 包裹中的商品类型
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
        public long RealUserId { get; set; }

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
        /// 大头笔
        /// </summary>
        [XmlElement("short_address")]
        public string ShortAddress { get; set; }

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
        public long Volume { get; set; }

        /// <summary>
        /// 面单号
        /// </summary>
        [XmlElement("waybill_code")]
        public string WaybillCode { get; set; }

        /// <summary>
        /// 包裹重量（克）
        /// </summary>
        [XmlElement("weight")]
        public long Weight { get; set; }
    }
}
