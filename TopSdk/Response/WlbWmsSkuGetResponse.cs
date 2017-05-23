using System;
using System.Xml.Serialization;
using System.Collections.Generic;

namespace Top.Api.Response
{
    /// <summary>
    /// WlbWmsSkuGetResponse.
    /// </summary>
    public class WlbWmsSkuGetResponse : TopResponse
    {
        /// <summary>
        /// 保质期预警天数
        /// </summary>
        [XmlElement("advent_lifecycle")]
        public long AdventLifecycle { get; set; }

        /// <summary>
        /// 批准文号
        /// </summary>
        [XmlElement("approval_number")]
        public string ApprovalNumber { get; set; }

        /// <summary>
        /// 条形码，多条码请用”;”分隔；
        /// </summary>
        [XmlElement("bar_code")]
        public string BarCode { get; set; }

        /// <summary>
        /// 品牌编码
        /// </summary>
        [XmlElement("brand")]
        public string Brand { get; set; }

        /// <summary>
        /// 品牌名称
        /// </summary>
        [XmlElement("brand_name")]
        public string BrandName { get; set; }

        /// <summary>
        /// 商品类别编码（外部系统类别）
        /// </summary>
        [XmlElement("category")]
        public string Category { get; set; }

        /// <summary>
        /// 商品类别名称
        /// </summary>
        [XmlElement("category_name")]
        public string CategoryName { get; set; }

        /// <summary>
        /// 颜色
        /// </summary>
        [XmlElement("color")]
        public string Color { get; set; }

        /// <summary>
        /// 成本价，单位分
        /// </summary>
        [XmlElement("cost_price")]
        public long CostPrice { get; set; }

        /// <summary>
        /// 拓展属性, key-value结构，格式要求： 以英文分号“;”分隔每组key-value，以英文冒号“:”分隔key与value。如果value中带有分号，需要转成下划线“_”，如果带有冒号，需要转成中划线“-”
        /// </summary>
        [XmlElement("extend_fields")]
        public string ExtendFields { get; set; }

        /// <summary>
        /// 毛重，单位克
        /// </summary>
        [XmlElement("gross_weight")]
        public long GrossWeight { get; set; }

        /// <summary>
        /// 高度，单位毫米
        /// </summary>
        [XmlElement("height")]
        public long Height { get; set; }

        /// <summary>
        /// 商家商品编码,与itemid必须有一个值不为空
        /// </summary>
        [XmlElement("iitem_code")]
        public string IitemCode { get; set; }

        /// <summary>
        /// 是否区域销售
        /// </summary>
        [XmlElement("is_area_sale")]
        public bool IsAreaSale { get; set; }

        /// <summary>
        /// 是否启用批次管理
        /// </summary>
        [XmlElement("is_batch_mgt")]
        public bool IsBatchMgt { get; set; }

        /// <summary>
        /// 是否危险品
        /// </summary>
        [XmlElement("is_danger")]
        public bool IsDanger { get; set; }

        /// <summary>
        /// 是否易碎品
        /// </summary>
        [XmlElement("is_hygroscopic")]
        public bool IsHygroscopic { get; set; }

        /// <summary>
        /// 是否启用保质期管理
        /// </summary>
        [XmlElement("is_shelflife")]
        public bool IsShelflife { get; set; }

        /// <summary>
        /// 是否启用序列号管理
        /// </summary>
        [XmlElement("is_sn_mgt")]
        public bool IsSnMgt { get; set; }

        /// <summary>
        /// 菜鸟商品ID,与itemcode必须有一个值不为空
        /// </summary>
        [XmlElement("item_id")]
        public string ItemId { get; set; }

        /// <summary>
        /// 零售价，单位分
        /// </summary>
        [XmlElement("item_price")]
        public long ItemPrice { get; set; }

        /// <summary>
        /// 长度，单位毫米
        /// </summary>
        [XmlElement("length")]
        public long Length { get; set; }

        /// <summary>
        /// 保质期天数
        /// </summary>
        [XmlElement("lifecycle")]
        public long Lifecycle { get; set; }

        /// <summary>
        /// 保质期禁售天数
        /// </summary>
        [XmlElement("lockup_lifecycle")]
        public long LockupLifecycle { get; set; }

        /// <summary>
        /// 商品名称
        /// </summary>
        [XmlElement("name")]
        public string Name { get; set; }

        /// <summary>
        /// 净重，单位克
        /// </summary>
        [XmlElement("net_weight")]
        public long NetWeight { get; set; }

        /// <summary>
        /// 场地
        /// </summary>
        [XmlElement("origin_address")]
        public long OriginAddress { get; set; }

        /// <summary>
        /// 箱规
        /// </summary>
        [XmlElement("pcs")]
        public long Pcs { get; set; }

        /// <summary>
        /// 保质期禁收天数
        /// </summary>
        [XmlElement("reject_lifecycle")]
        public long RejectLifecycle { get; set; }

        /// <summary>
        /// 尺寸
        /// </summary>
        [XmlElement("size")]
        public string Size { get; set; }

        /// <summary>
        /// 规格
        /// </summary>
        [XmlElement("specification")]
        public string Specification { get; set; }

        /// <summary>
        /// 吊牌价，单位分
        /// </summary>
        [XmlElement("tag_price")]
        public long TagPrice { get; set; }

        /// <summary>
        /// 商品标题
        /// </summary>
        [XmlElement("title")]
        public string Title { get; set; }

        /// <summary>
        /// 商品类别 NORMAL：普通商品、 COMBINE：组合商品、 DISTRIBUTION：分销商品
        /// </summary>
        [XmlElement("type")]
        public string Type { get; set; }

        /// <summary>
        /// 启用标识
        /// </summary>
        [XmlElement("use_yn")]
        public bool UseYn { get; set; }

        /// <summary>
        /// 体积，单位立方厘米
        /// </summary>
        [XmlElement("volume")]
        public long Volume { get; set; }

        /// <summary>
        /// 宽度，单位毫米
        /// </summary>
        [XmlElement("width")]
        public long Width { get; set; }

        /// <summary>
        /// 错误编码
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
        public bool WlSuccess { get; set; }

    }
}
