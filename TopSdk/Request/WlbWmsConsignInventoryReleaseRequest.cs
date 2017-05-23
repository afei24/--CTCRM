using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using Top.Api.Util;

namespace Top.Api.Request
{
    /// <summary>
    /// TOP API: taobao.wlb.wms.consign.inventory.release
    /// </summary>
    public class WlbWmsConsignInventoryReleaseRequest : BaseTopRequest<Top.Api.Response.WlbWmsConsignInventoryReleaseResponse>
    {
        /// <summary>
        /// 库存释放
        /// </summary>
        public string Content { get; set; }

        public ContentDomain Content_ { set { this.Content = TopUtils.ObjectToJson(value); } } 

        #region ITopRequest Members

        public override string GetApiName()
        {
            return "taobao.wlb.wms.consign.inventory.release";
        }

        public override IDictionary<string, string> GetParameters()
        {
            TopDictionary parameters = new TopDictionary();
            parameters.Add("content", this.Content);
            if (this.otherParams != null)
            {
                parameters.AddAll(this.otherParams);
            }
            return parameters;
        }

        public override void Validate()
        {
        }

	/// <summary>
/// IteminventoryDomain Data Structure.
/// </summary>
[Serializable]
public class IteminventoryDomain : TopObject
{
	        /// <summary>
	        /// 菜鸟商品编码
	        /// </summary>
	        [XmlElement("item_code")]
	        public string ItemCode { get; set; }
	
	        /// <summary>
	        /// 菜鸟商品ID
	        /// </summary>
	        [XmlElement("item_id")]
	        public string ItemId { get; set; }
	
	        /// <summary>
	        /// 交易编码
	        /// </summary>
	        [XmlElement("order_source_code")]
	        public string OrderSourceCode { get; set; }
	
	        /// <summary>
	        /// 子交易编码
	        /// </summary>
	        [XmlElement("sub_source_code")]
	        public string SubSourceCode { get; set; }
}

	/// <summary>
/// IteminventorylistDomain Data Structure.
/// </summary>
[Serializable]
public class IteminventorylistDomain : TopObject
{
	        /// <summary>
	        /// 订单商品
	        /// </summary>
	        [XmlElement("item_inventory")]
	        public IteminventoryDomain ItemInventory { get; set; }
}

	/// <summary>
/// ContentDomain Data Structure.
/// </summary>
[Serializable]
public class ContentDomain : TopObject
{
	        /// <summary>
	        /// 订单商品列表
	        /// </summary>
	        [XmlArray("item_inventory_list")]
	        [XmlArrayItem("iteminventorylist")]
	        public List<IteminventorylistDomain> ItemInventoryList { get; set; }
	
	        /// <summary>
	        /// ERP订单编码
	        /// </summary>
	        [XmlElement("order_code")]
	        public string OrderCode { get; set; }
	
	        /// <summary>
	        /// 订单来源（213 天猫，201 淘宝，214 京东，202 1688 阿里中文站 ，203 苏宁在线，204 亚马逊中国，205 当当，208 1号店，207 唯品会，209 国美在线，210 拍拍，206 易贝ebay，211 聚美优品，212 乐蜂网，215 邮乐，216 凡客，217 优购，218 银泰，219 易讯，221 聚尚网，222 蘑菇街，223 POS门店，301 其他）
	        /// </summary>
	        [XmlElement("order_source")]
	        public Nullable<long> OrderSource { get; set; }
}

        #endregion
    }
}
