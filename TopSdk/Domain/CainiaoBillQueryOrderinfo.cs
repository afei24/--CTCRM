using System;
using System.Xml.Serialization;
using System.Collections.Generic;

namespace Top.Api.Domain
{
    /// <summary>
    /// CainiaoBillQueryOrderinfo Data Structure.
    /// </summary>
    [Serializable]
    public class CainiaoBillQueryOrderinfo : TopObject
    {
        /// <summary>
        /// 菜鸟订单编码
        /// </summary>
        [XmlElement("cn_order_code")]
        public string CnOrderCode { get; set; }

        /// <summary>
        /// 订单最后修改时间
        /// </summary>
        [XmlElement("modified_time")]
        public string ModifiedTime { get; set; }

        /// <summary>
        /// ERP订单号
        /// </summary>
        [XmlElement("order_code")]
        public string OrderCode { get; set; }

        /// <summary>
        /// 订单来源（213 天猫，201 淘宝，214 京东，202 1688 阿里中文站 ，203 苏宁在线，204 亚马逊中国，205 当当，208 1号店，207 唯品会，209 国美在线，210 拍拍，206 易贝ebay，211 聚美优品，212 乐蜂网，215 邮乐，216 凡客，217 优购，218 银泰，219 易讯，221 聚尚网，222 蘑菇街，223 POS门店，301 其他）
        /// </summary>
        [XmlElement("order_source")]
        public string OrderSource { get; set; }

        /// <summary>
        /// 交易订单号
        /// </summary>
        [XmlArray("order_source_codes")]
        [XmlArrayItem("string")]
        public List<string> OrderSourceCodes { get; set; }

        /// <summary>
        /// 单据类型 201 销售出库 501 退货入库 502 换货出库 503 补发出库 904 普通入库 903 普通出库单 306 B2B入库单 305 B2B出库单 601 采购入库 901 退供出库单 701 盘点出库 702 盘点入库 711 库存异动单
        /// </summary>
        [XmlElement("order_type")]
        public long OrderType { get; set; }

        /// <summary>
        /// 备注
        /// </summary>
        [XmlElement("remark")]
        public string Remark { get; set; }

        /// <summary>
        /// 单据状态 WMS_ACCEPT 接单成功 WMS_REJECT 接单失败 WMS_CONFIRMED 仓库生产完成，注：此状态表示单据已经在WMS处理完成，可能通过获取单据详情接口获取单据详细信息。 WMS_CANCEL 取消仓库发货  -- WMS_FAILED 订单发货失败 TMS_SIGN 买家签收 TMS_REJECT 买家拒签 TMS_CANCEL 拦截派送
        /// </summary>
        [XmlElement("status")]
        public string Status { get; set; }

        /// <summary>
        /// 仓库编码
        /// </summary>
        [XmlElement("store_code")]
        public string StoreCode { get; set; }
    }
}
