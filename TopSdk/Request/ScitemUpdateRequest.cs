using System;
using System.Collections.Generic;
using Top.Api.Util;

namespace Top.Api.Request
{
    /// <summary>
    /// TOP API: taobao.scitem.update
    /// </summary>
    public class ScitemUpdateRequest : BaseTopRequest<Top.Api.Response.ScitemUpdateResponse>
    {
        /// <summary>
        /// 条形码
        /// </summary>
        public string BarCode { get; set; }

        /// <summary>
        /// 品牌id
        /// </summary>
        public Nullable<long> BrandId { get; set; }

        /// <summary>
        /// brand_Name
        /// </summary>
        public string BrandName { get; set; }

        /// <summary>
        /// 高 单位：mm
        /// </summary>
        public Nullable<long> Height { get; set; }

        /// <summary>
        /// 1表示区域销售，0或是空是非区域销售
        /// </summary>
        public Nullable<long> IsAreaSale { get; set; }

        /// <summary>
        /// 是否是贵重品 0:不是 1：是
        /// </summary>
        public Nullable<long> IsCostly { get; set; }

        /// <summary>
        /// 是否危险 0：不是  0：是
        /// </summary>
        public Nullable<long> IsDangerous { get; set; }

        /// <summary>
        /// 是否易碎 0：不是  1：是
        /// </summary>
        public Nullable<long> IsFriable { get; set; }

        /// <summary>
        /// 是否保质期：0:不是 1：是
        /// </summary>
        public Nullable<long> IsWarranty { get; set; }

        /// <summary>
        /// 后端商品ID，跟outer_code必须指定一个
        /// </summary>
        public Nullable<long> ItemId { get; set; }

        /// <summary>
        /// 商品名称
        /// </summary>
        public string ItemName { get; set; }

        /// <summary>
        /// 0.普通供应链商品 1.供应链组合主商品
        /// </summary>
        public Nullable<long> ItemType { get; set; }

        /// <summary>
        /// 长度 单位：mm
        /// </summary>
        public Nullable<long> Length { get; set; }

        /// <summary>
        /// 0:液体，1：粉体，2：固体
        /// </summary>
        public Nullable<long> MatterStatus { get; set; }

        /// <summary>
        /// 商家编码，跟item_id必须指定一个
        /// </summary>
        public string OuterCode { get; set; }

        /// <summary>
        /// price
        /// </summary>
        public Nullable<long> Price { get; set; }

        /// <summary>
        /// remark
        /// </summary>
        public string Remark { get; set; }

        /// <summary>
        /// 移除商品属性P列表,P由系统分配：p1；p2
        /// </summary>
        public string RemoveProperties { get; set; }

        /// <summary>
        /// 淘宝SKU产品级编码CSPU ID
        /// </summary>
        public Nullable<long> SpuId { get; set; }

        /// <summary>
        /// 需要更新的商品属性格式是  p1:v1,p2:v2,p3:v3
        /// </summary>
        public string UpdateProperties { get; set; }

        /// <summary>
        /// 体积：立方厘米
        /// </summary>
        public Nullable<long> Volume { get; set; }

        /// <summary>
        /// weight
        /// </summary>
        public Nullable<long> Weight { get; set; }

        /// <summary>
        /// 宽 单位：mm
        /// </summary>
        public Nullable<long> Width { get; set; }

        /// <summary>
        /// 仓储商编码
        /// </summary>
        public string WmsCode { get; set; }

        #region ITopRequest Members

        public override string GetApiName()
        {
            return "taobao.scitem.update";
        }

        public override IDictionary<string, string> GetParameters()
        {
            TopDictionary parameters = new TopDictionary();
            parameters.Add("bar_code", this.BarCode);
            parameters.Add("brand_id", this.BrandId);
            parameters.Add("brand_name", this.BrandName);
            parameters.Add("height", this.Height);
            parameters.Add("is_area_sale", this.IsAreaSale);
            parameters.Add("is_costly", this.IsCostly);
            parameters.Add("is_dangerous", this.IsDangerous);
            parameters.Add("is_friable", this.IsFriable);
            parameters.Add("is_warranty", this.IsWarranty);
            parameters.Add("item_id", this.ItemId);
            parameters.Add("item_name", this.ItemName);
            parameters.Add("item_type", this.ItemType);
            parameters.Add("length", this.Length);
            parameters.Add("matter_status", this.MatterStatus);
            parameters.Add("outer_code", this.OuterCode);
            parameters.Add("price", this.Price);
            parameters.Add("remark", this.Remark);
            parameters.Add("remove_properties", this.RemoveProperties);
            parameters.Add("spu_id", this.SpuId);
            parameters.Add("update_properties", this.UpdateProperties);
            parameters.Add("volume", this.Volume);
            parameters.Add("weight", this.Weight);
            parameters.Add("width", this.Width);
            parameters.Add("wms_code", this.WmsCode);
            if (this.otherParams != null)
            {
                parameters.AddAll(this.otherParams);
            }
            return parameters;
        }

        public override void Validate()
        {
        }

        #endregion
    }
}
