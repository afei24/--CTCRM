using System;
using System.Xml.Serialization;
using Top.Api.Domain;
using System.Collections.Generic;
using Top.Api.Util;

namespace Top.Api.Request
{
    /// <summary>
    /// TOP API: tmall.item.outerid.update
    /// </summary>
    public class TmallItemOuteridUpdateRequest : BaseTopRequest<Top.Api.Response.TmallItemOuteridUpdateResponse>
    {
        /// <summary>
        /// 商品ID
        /// </summary>
        public Nullable<long> ItemId { get; set; }

        /// <summary>
        /// 商品维度商家编码，如果不修改可以不传；清空请设置空串
        /// </summary>
        public string OuterId { get; set; }

        /// <summary>
        /// 商品SKU更新OuterId时候用的数据
        /// </summary>
        public string SkuOuters { get; set; }

        public List<UpdateSkuOuterId> SkuOuters_ { set { this.SkuOuters = TopUtils.ObjectToJson(value); } } 

        #region ITopRequest Members

        public override string GetApiName()
        {
            return "tmall.item.outerid.update";
        }

        public override IDictionary<string, string> GetParameters()
        {
            TopDictionary parameters = new TopDictionary();
            parameters.Add("item_id", this.ItemId);
            parameters.Add("outer_id", this.OuterId);
            parameters.Add("sku_outers", this.SkuOuters);
            if (this.otherParams != null)
            {
                parameters.AddAll(this.otherParams);
            }
            return parameters;
        }

        public override void Validate()
        {
            RequestValidator.ValidateRequired("item_id", this.ItemId);
            RequestValidator.ValidateObjectMaxListSize("sku_outers", this.SkuOuters, 2000);
        }

        #endregion
    }
}
