using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using Top.Api.Util;

namespace Top.Api.Request
{
    /// <summary>
    /// TOP API: taobao.wlb.wms.inventory.count
    /// </summary>
    public class WlbWmsInventoryCountRequest : BaseTopRequest<Top.Api.Response.WlbWmsInventoryCountResponse>
    {
        /// <summary>
        /// 损益单回传信息
        /// </summary>
        public string Content { get; set; }

        public WlbWmsInventoryCountDomain Content_ { set { this.Content = TopUtils.ObjectToJson(value); } } 

        #region ITopRequest Members

        public override string GetApiName()
        {
            return "taobao.wlb.wms.inventory.count";
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
/// ItemListWlbWmsInventoryCountDomain Data Structure.
/// </summary>
[Serializable]
public class ItemListWlbWmsInventoryCountDomain : TopObject
{
	        /// <summary>
	        /// WMS批次号
	        /// </summary>
	        [XmlElement("batch_code")]
	        public string BatchCode { get; set; }
	
	        /// <summary>
	        /// 商品过期日期YYYY-MM-DD
	        /// </summary>
	        [XmlElement("due_date")]
	        public string DueDate { get; set; }
	
	        /// <summary>
	        /// 库存类型 1 正品，101 残次，102 机损，103 箱损，201 冻结库存，301 在途库存
	        /// </summary>
	        [XmlElement("inventory_type")]
	        public Nullable<long> InventoryType { get; set; }
	
	        /// <summary>
	        /// 后端商品ID
	        /// </summary>
	        [XmlElement("item_id")]
	        public string ItemId { get; set; }
	
	        /// <summary>
	        /// 生产批号
	        /// </summary>
	        [XmlElement("produce_code")]
	        public string ProduceCode { get; set; }
	
	        /// <summary>
	        /// 商品过期日期YYYY-MM-DD
	        /// </summary>
	        [XmlElement("product_date")]
	        public string ProductDate { get; set; }
	
	        /// <summary>
	        /// 商品数量
	        /// </summary>
	        [XmlElement("quantity")]
	        public Nullable<long> Quantity { get; set; }
}

	/// <summary>
/// WlbWmsInventoryCountDomain Data Structure.
/// </summary>
[Serializable]
public class WlbWmsInventoryCountDomain : TopObject
{
	        /// <summary>
	        /// 移库单对应的业务单据号
	        /// </summary>
	        [XmlElement("adjust_biz_key")]
	        public string AdjustBizKey { get; set; }
	
	        /// <summary>
	        /// 调整原因 （仓内多货、 仓内少货、 货权转移、 临保转残、 库内破损、 其他）
	        /// </summary>
	        [XmlElement("adjust_reason_type")]
	        public string AdjustReasonType { get; set; }
	
	        /// <summary>
	        /// 调整类型 1、盘点单 2、移库单（调整单）
	        /// </summary>
	        [XmlElement("adjust_type")]
	        public string AdjustType { get; set; }
	
	        /// <summary>
	        /// 订单商品信息列表
	        /// </summary>
	        [XmlArray("item_list")]
	        [XmlArrayItem("item_list_wlb_wms_inventory_count")]
	        public List<ItemListWlbWmsInventoryCountDomain> ItemList { get; set; }
	
	        /// <summary>
	        /// ERP订单号
	        /// </summary>
	        [XmlElement("order_code")]
	        public string OrderCode { get; set; }
	
	        /// <summary>
	        /// 2013-01-01 10:00:00
	        /// </summary>
	        [XmlElement("order_confirm_time")]
	        public string OrderConfirmTime { get; set; }
	
	        /// <summary>
	        /// 701
	        /// </summary>
	        [XmlElement("order_type")]
	        public Nullable<long> OrderType { get; set; }
	
	        /// <summary>
	        /// 2456
	        /// </summary>
	        [XmlElement("out_biz_code")]
	        public string OutBizCode { get; set; }
	
	        /// <summary>
	        /// --
	        /// </summary>
	        [XmlElement("remark")]
	        public string Remark { get; set; }
	
	        /// <summary>
	        /// 1011
	        /// </summary>
	        [XmlElement("store_code")]
	        public string StoreCode { get; set; }
	
	        /// <summary>
	        /// LBX0001
	        /// </summary>
	        [XmlElement("store_order_code")]
	        public string StoreOrderCode { get; set; }
}

        #endregion
    }
}
