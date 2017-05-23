using System;
using System.Collections.Generic;
using Top.Api.Util;

namespace Top.Api.Request
{
    /// <summary>
    /// TOP API: taobao.wlb.item.combination.delete
    /// </summary>
    public class WlbItemCombinationDeleteRequest : BaseTopRequest<Top.Api.Response.WlbItemCombinationDeleteResponse>
    {
        /// <summary>
        /// 组合商品的id列表
        /// </summary>
        public string DestItemList { get; set; }

        /// <summary>
        /// 组合关系的商品id
        /// </summary>
        public Nullable<long> ItemId { get; set; }

        #region ITopRequest Members

        public override string GetApiName()
        {
            return "taobao.wlb.item.combination.delete";
        }

        public override IDictionary<string, string> GetParameters()
        {
            TopDictionary parameters = new TopDictionary();
            parameters.Add("dest_item_list", this.DestItemList);
            parameters.Add("item_id", this.ItemId);
            if (this.otherParams != null)
            {
                parameters.AddAll(this.otherParams);
            }
            return parameters;
        }

        public override void Validate()
        {
            RequestValidator.ValidateRequired("dest_item_list", this.DestItemList);
            RequestValidator.ValidateMaxListSize("dest_item_list", this.DestItemList, 20);
            RequestValidator.ValidateRequired("item_id", this.ItemId);
        }

        #endregion
    }
}
