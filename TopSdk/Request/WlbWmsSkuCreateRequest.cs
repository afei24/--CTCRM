using System;
using System.Collections.Generic;
using Top.Api.Util;

namespace Top.Api.Request
{
    /// <summary>
    /// TOP API: taobao.wlb.wms.sku.create
    /// </summary>
    public class WlbWmsSkuCreateRequest : BaseTopRequest<Top.Api.Response.WlbWmsSkuCreateResponse>
    {
        /// <summary>
        /// 保质期预警天数
        /// </summary>
        public Nullable<long> AdventLifecycle { get; set; }

        /// <summary>
        /// 批准文号
        /// </summary>
        public string ApprovalNumber { get; set; }

        /// <summary>
        /// 条形码，多条码请用”；”分隔；
        /// </summary>
        public string BarCode { get; set; }

        /// <summary>
        /// 品牌编码
        /// </summary>
        public string Brand { get; set; }

        /// <summary>
        /// 品牌名称
        /// </summary>
        public string BrandName { get; set; }

        /// <summary>
        /// 商品类别编码（外部系统类别）
        /// </summary>
        public string Category { get; set; }

        /// <summary>
        /// 商品类别名称
        /// </summary>
        public string CategoryName { get; set; }

        /// <summary>
        /// 颜色
        /// </summary>
        public string Color { get; set; }

        /// <summary>
        /// 成本价，单位分
        /// </summary>
        public Nullable<long> CostPrice { get; set; }

        /// <summary>
        /// 拓展属性
        /// </summary>
        public string ExtendFields { get; set; }

        /// <summary>
        /// 毛重，单位克
        /// </summary>
        public Nullable<long> GrossWeight { get; set; }

        /// <summary>
        /// 高度，单位毫米
        /// </summary>
        public Nullable<long> Height { get; set; }

        /// <summary>
        /// 是否区域销售
        /// </summary>
        public Nullable<bool> IsAreaSale { get; set; }

        /// <summary>
        /// 是否启用批次管理
        /// </summary>
        public Nullable<bool> IsBatchMgt { get; set; }

        /// <summary>
        /// 是否危险品
        /// </summary>
        public Nullable<bool> IsDanger { get; set; }

        /// <summary>
        /// 是否易碎品
        /// </summary>
        public Nullable<bool> IsHygroscopic { get; set; }

        /// <summary>
        /// 是否启用保质期管理
        /// </summary>
        public Nullable<bool> IsShelflife { get; set; }

        /// <summary>
        /// 是否启用序列号管理
        /// </summary>
        public Nullable<bool> IsSnMgt { get; set; }

        /// <summary>
        /// 商家商品编码
        /// </summary>
        public string ItemCode { get; set; }

        /// <summary>
        /// 商家商品ID
        /// </summary>
        public string ItemId { get; set; }

        /// <summary>
        /// 零售价，单位分
        /// </summary>
        public Nullable<long> ItemPrice { get; set; }

        /// <summary>
        /// 长度，单位毫米
        /// </summary>
        public Nullable<long> Length { get; set; }

        /// <summary>
        /// 商品保质期天数
        /// </summary>
        public Nullable<long> Lifecycle { get; set; }

        /// <summary>
        /// 保质期禁售天数
        /// </summary>
        public Nullable<long> LockupLifecycle { get; set; }

        /// <summary>
        /// 商品名称
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 净重，单位克
        /// </summary>
        public Nullable<long> NetWeight { get; set; }

        /// <summary>
        /// 产地
        /// </summary>
        public Nullable<long> OriginAddress { get; set; }

        /// <summary>
        /// 箱规
        /// </summary>
        public Nullable<long> Pcs { get; set; }

        /// <summary>
        /// 保质期禁收天数
        /// </summary>
        public Nullable<long> RejectLifecycle { get; set; }

        /// <summary>
        /// 尺码
        /// </summary>
        public string Size { get; set; }

        /// <summary>
        /// 规格
        /// </summary>
        public string Specification { get; set; }

        /// <summary>
        /// 仓库编码
        /// </summary>
        public string StoreCode { get; set; }

        /// <summary>
        /// 吊牌价，单位分
        /// </summary>
        public Nullable<long> TagPrice { get; set; }

        /// <summary>
        /// 商品标题
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// 商品类别NORMAL：普通商品、COMBINE：组合商品、DISTRIBUTION：分销商品、HAOCAI耗材、FUSHUPIN附属品、BAOCAI 包材、XUNI虚拟商品、QITA其他)
        /// </summary>
        public string Type { get; set; }

        /// <summary>
        /// 启用标识
        /// </summary>
        public Nullable<bool> UseYn { get; set; }

        /// <summary>
        /// 体积，单位立方厘米
        /// </summary>
        public Nullable<long> Volume { get; set; }

        /// <summary>
        /// 宽度，单位毫米
        /// </summary>
        public Nullable<long> Width { get; set; }

        #region ITopRequest Members

        public override string GetApiName()
        {
            return "taobao.wlb.wms.sku.create";
        }

        public override IDictionary<string, string> GetParameters()
        {
            TopDictionary parameters = new TopDictionary();
            parameters.Add("advent_lifecycle", this.AdventLifecycle);
            parameters.Add("approval_number", this.ApprovalNumber);
            parameters.Add("bar_code", this.BarCode);
            parameters.Add("brand", this.Brand);
            parameters.Add("brand_name", this.BrandName);
            parameters.Add("category", this.Category);
            parameters.Add("category_name", this.CategoryName);
            parameters.Add("color", this.Color);
            parameters.Add("cost_price", this.CostPrice);
            parameters.Add("extend_fields", this.ExtendFields);
            parameters.Add("gross_weight", this.GrossWeight);
            parameters.Add("height", this.Height);
            parameters.Add("is_area_sale", this.IsAreaSale);
            parameters.Add("is_batch_mgt", this.IsBatchMgt);
            parameters.Add("is_danger", this.IsDanger);
            parameters.Add("is_hygroscopic", this.IsHygroscopic);
            parameters.Add("is_shelflife", this.IsShelflife);
            parameters.Add("is_sn_mgt", this.IsSnMgt);
            parameters.Add("item_code", this.ItemCode);
            parameters.Add("item_id", this.ItemId);
            parameters.Add("item_price", this.ItemPrice);
            parameters.Add("length", this.Length);
            parameters.Add("lifecycle", this.Lifecycle);
            parameters.Add("lockup_lifecycle", this.LockupLifecycle);
            parameters.Add("name", this.Name);
            parameters.Add("net_weight", this.NetWeight);
            parameters.Add("origin_address", this.OriginAddress);
            parameters.Add("pcs", this.Pcs);
            parameters.Add("reject_lifecycle", this.RejectLifecycle);
            parameters.Add("size", this.Size);
            parameters.Add("specification", this.Specification);
            parameters.Add("store_code", this.StoreCode);
            parameters.Add("tag_price", this.TagPrice);
            parameters.Add("title", this.Title);
            parameters.Add("type", this.Type);
            parameters.Add("use_yn", this.UseYn);
            parameters.Add("volume", this.Volume);
            parameters.Add("width", this.Width);
            if (this.otherParams != null)
            {
                parameters.AddAll(this.otherParams);
            }
            return parameters;
        }

        public override void Validate()
        {
            RequestValidator.ValidateRequired("item_code", this.ItemCode);
            RequestValidator.ValidateRequired("name", this.Name);
            RequestValidator.ValidateRequired("type", this.Type);
            RequestValidator.ValidateRequired("use_yn", this.UseYn);
        }

        #endregion
    }
}
