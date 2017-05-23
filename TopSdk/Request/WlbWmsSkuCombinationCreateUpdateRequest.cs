using System;
using System.Xml.Serialization;
using Top.Api.Domain;
using System.Collections.Generic;
using Top.Api.Util;

namespace Top.Api.Request
{
    /// <summary>
    /// TOP API: taobao.wlb.wms.sku.combination.create.update
    /// </summary>
    public class WlbWmsSkuCombinationCreateUpdateRequest : BaseTopRequest<Top.Api.Response.WlbWmsSkuCombinationCreateUpdateResponse>
    {
        /// <summary>
        /// 组合子商品列表
        /// </summary>
        public string DestItem { get; set; }

        public List<Destitemlistwlbwmsskucombinationcreateupdate> DestItem_ { set { this.DestItem = TopUtils.ObjectToJson(value); } } 

        /// <summary>
        /// 需要创建组合关系的商品外部系统ID
        /// </summary>
        public string ItemId { get; set; }

        /// <summary>
        /// 货主编码
        /// </summary>
        public string OwnerUserId { get; set; }

        /// <summary>
        /// 组成组合商品比例
        /// </summary>
        public string Proportion { get; set; }

        #region ITopRequest Members

        public override string GetApiName()
        {
            return "taobao.wlb.wms.sku.combination.create.update";
        }

        public override IDictionary<string, string> GetParameters()
        {
            TopDictionary parameters = new TopDictionary();
            parameters.Add("dest_item", this.DestItem);
            parameters.Add("item_id", this.ItemId);
            parameters.Add("owner_user_id", this.OwnerUserId);
            parameters.Add("proportion", this.Proportion);
            if (this.otherParams != null)
            {
                parameters.AddAll(this.otherParams);
            }
            return parameters;
        }

        public override void Validate()
        {
            RequestValidator.ValidateRequired("dest_item", this.DestItem);
            RequestValidator.ValidateObjectMaxListSize("dest_item", this.DestItem, 20);
            RequestValidator.ValidateRequired("item_id", this.ItemId);
            RequestValidator.ValidateRequired("owner_user_id", this.OwnerUserId);
            RequestValidator.ValidateRequired("proportion", this.Proportion);
            RequestValidator.ValidateMaxListSize("proportion", this.Proportion, 20);
        }

        #endregion
    }
}
