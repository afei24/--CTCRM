using System;
using System.Collections.Generic;
using Top.Api.Util;

namespace Top.Api.Request
{
    /// <summary>
    /// TOP API: taobao.wlb.item.combination.create
    /// </summary>
    public class WlbItemCombinationCreateRequest : BaseTopRequest<Top.Api.Response.WlbItemCombinationCreateResponse>
    {
        /// <summary>
        /// 组合商品的id列表
        /// </summary>
        public string DestItemList { get; set; }

        /// <summary>
        /// 要建立组合关系的商品id
        /// </summary>
        public Nullable<long> ItemId { get; set; }

        /// <summary>
        /// 组成组合商品的比例列表，描述组合商品的组合比例，默认为1,1,1
        /// </summary>
        public string ProportionList { get; set; }

        #region ITopRequest Members

        public override string GetApiName()
        {
            return "taobao.wlb.item.combination.create";
        }

        public override IDictionary<string, string> GetParameters()
        {
            TopDictionary parameters = new TopDictionary();
            parameters.Add("dest_item_list", this.DestItemList);
            parameters.Add("item_id", this.ItemId);
            parameters.Add("proportion_list", this.ProportionList);
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
            RequestValidator.ValidateMaxListSize("proportion_list", this.ProportionList, 20);
        }

        #endregion
    }
}
