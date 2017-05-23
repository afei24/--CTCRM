using System;
using System.Collections.Generic;
using Top.Api.Util;

namespace Top.Api.Request
{
    /// <summary>
    /// TOP API: taobao.scitem.map.add
    /// </summary>
    public class ScitemMapAddRequest : BaseTopRequest<Top.Api.Response.ScitemMapAddResponse>
    {
        /// <summary>
        /// 前台ic商品id
        /// </summary>
        public Nullable<long> ItemId { get; set; }

        /// <summary>
        /// 默认值为false  true:进行高级校验,前端商品或SKU的商家编码必须与后端商品的商家编码一致，否则会拒绝关联  false:不进行高级校验
        /// </summary>
        public Nullable<bool> NeedCheck { get; set; }

        /// <summary>
        /// sc_item_id和outer_code 其中一个不能为空
        /// </summary>
        public string OuterCode { get; set; }

        /// <summary>
        /// sc_item_id和outer_code 其中一个不能为空
        /// </summary>
        public Nullable<long> ScItemId { get; set; }

        /// <summary>
        /// 前台ic商品skuid
        /// </summary>
        public Nullable<long> SkuId { get; set; }

        #region ITopRequest Members

        public override string GetApiName()
        {
            return "taobao.scitem.map.add";
        }

        public override IDictionary<string, string> GetParameters()
        {
            TopDictionary parameters = new TopDictionary();
            parameters.Add("item_id", this.ItemId);
            parameters.Add("need_check", this.NeedCheck);
            parameters.Add("outer_code", this.OuterCode);
            parameters.Add("sc_item_id", this.ScItemId);
            parameters.Add("sku_id", this.SkuId);
            if (this.otherParams != null)
            {
                parameters.AddAll(this.otherParams);
            }
            return parameters;
        }

        public override void Validate()
        {
            RequestValidator.ValidateRequired("item_id", this.ItemId);
        }

        #endregion
    }
}
