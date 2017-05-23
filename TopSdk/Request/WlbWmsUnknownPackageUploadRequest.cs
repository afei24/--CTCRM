using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using Top.Api.Util;

namespace Top.Api.Request
{
    /// <summary>
    /// TOP API: taobao.wlb.wms.unknown.package.upload
    /// </summary>
    public class WlbWmsUnknownPackageUploadRequest : BaseTopRequest<Top.Api.Response.WlbWmsUnknownPackageUploadResponse>
    {
        /// <summary>
        /// WlbWmsUnknownPackageUpload
        /// </summary>
        public string Content { get; set; }

        public WlbWmsUnknownPackageUploadDomain Content_ { set { this.Content = TopUtils.ObjectToJson(value); } } 

        #region ITopRequest Members

        public override string GetApiName()
        {
            return "taobao.wlb.wms.unknown.package.upload";
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
            RequestValidator.ValidateRequired("content", this.Content);
        }

	/// <summary>
/// PackageItemDomain Data Structure.
/// </summary>
[Serializable]
public class PackageItemDomain : TopObject
{
	        /// <summary>
	        /// 商家商品编码
	        /// </summary>
	        [XmlElement("item_code")]
	        public string ItemCode { get; set; }
	
	        /// <summary>
	        /// 货品ID
	        /// </summary>
	        [XmlElement("item_id")]
	        public string ItemId { get; set; }
	
	        /// <summary>
	        /// 包裹内商品数量
	        /// </summary>
	        [XmlElement("item_qty")]
	        public string ItemQty { get; set; }
}

	/// <summary>
/// WlbWmsUnknownPackageUploadDomain Data Structure.
/// </summary>
[Serializable]
public class WlbWmsUnknownPackageUploadDomain : TopObject
{
	        /// <summary>
	        /// 创建时间
	        /// </summary>
	        [XmlElement("create_time")]
	        public string CreateTime { get; set; }
	
	        /// <summary>
	        /// 发货的运单号
	        /// </summary>
	        [XmlElement("mail_no")]
	        public string MailNo { get; set; }
	
	        /// <summary>
	        /// 包裹对应的原ERP订单号
	        /// </summary>
	        [XmlElement("order_code")]
	        public string OrderCode { get; set; }
	
	        /// <summary>
	        /// 消息唯一标识
	        /// </summary>
	        [XmlElement("package_id")]
	        public string PackageId { get; set; }
	
	        /// <summary>
	        /// 包裹商品列表
	        /// </summary>
	        [XmlArray("package_item_list")]
	        [XmlArrayItem("package_item")]
	        public List<PackageItemDomain> PackageItemList { get; set; }
	
	        /// <summary>
	        /// 收到包裹仓库的仓库编码
	        /// </summary>
	        [XmlElement("store_code")]
	        public string StoreCode { get; set; }
	
	        /// <summary>
	        /// 包裹对应的原仓库作业订单
	        /// </summary>
	        [XmlElement("store_order_code")]
	        public string StoreOrderCode { get; set; }
	
	        /// <summary>
	        /// 发货的配送公司
	        /// </summary>
	        [XmlElement("tms_code")]
	        public string TmsCode { get; set; }
}

        #endregion
    }
}
