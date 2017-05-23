using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using Top.Api.Util;

namespace Top.Api.Request
{
    /// <summary>
    /// TOP API: taobao.wlb.wms.item.combination.create
    /// </summary>
    public class WlbWmsItemCombinationCreateRequest : BaseTopRequest<Top.Api.Response.WlbWmsItemCombinationCreateResponse>
    {
        /// <summary>
        /// 组合商品ID
        /// </summary>
        public Nullable<long> ItemId { get; set; }

        /// <summary>
        /// 子货品列表
        /// </summary>
        public string SubItemList { get; set; }

        public List<SubItemListDomain> SubItemList_ { set { this.SubItemList = TopUtils.ObjectToJson(value); } } 

        #region ITopRequest Members

        public override string GetApiName()
        {
            return "taobao.wlb.wms.item.combination.create";
        }

        public override IDictionary<string, string> GetParameters()
        {
            TopDictionary parameters = new TopDictionary();
            parameters.Add("item_id", this.ItemId);
            parameters.Add("sub_item_list", this.SubItemList);
            if (this.otherParams != null)
            {
                parameters.AddAll(this.otherParams);
            }
            return parameters;
        }

        public override void Validate()
        {
            RequestValidator.ValidateRequired("item_id", this.ItemId);
            RequestValidator.ValidateRequired("sub_item_list", this.SubItemList);
            RequestValidator.ValidateObjectMaxListSize("sub_item_list", this.SubItemList, 20);
        }

	/// <summary>
/// SubItemDomain Data Structure.
/// </summary>
[Serializable]
public class SubItemDomain : TopObject
{
	        /// <summary>
	        /// 子货品数量
	        /// </summary>
	        [XmlElement("count")]
	        public Nullable<long> Count { get; set; }
	
	        /// <summary>
	        /// 子货品ID
	        /// </summary>
	        [XmlElement("sub_item_id")]
	        public Nullable<long> SubItemId { get; set; }
}

	/// <summary>
/// SubItemListDomain Data Structure.
/// </summary>
[Serializable]
public class SubItemListDomain : TopObject
{
	        /// <summary>
	        /// 子货品
	        /// </summary>
	        [XmlElement("sub_item")]
	        public SubItemDomain SubItem { get; set; }
}

        #endregion
    }
}
