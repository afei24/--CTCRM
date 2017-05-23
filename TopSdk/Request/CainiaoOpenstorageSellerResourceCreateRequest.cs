using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using Top.Api.Util;

namespace Top.Api.Request
{
    /// <summary>
    /// TOP API: cainiao.openstorage.seller.resource.create
    /// </summary>
    public class CainiaoOpenstorageSellerResourceCreateRequest : BaseTopRequest<Top.Api.Response.CainiaoOpenstorageSellerResourceCreateResponse>
    {
        /// <summary>
        /// 商家创建资源参数
        /// </summary>
        public string ParamCreateSellerResourceRequest { get; set; }

        public CreateSellerResourceRequestDomain ParamCreateSellerResourceRequest_ { set { this.ParamCreateSellerResourceRequest = TopUtils.ObjectToJson(value); } } 

        #region ITopRequest Members

        public override string GetApiName()
        {
            return "cainiao.openstorage.seller.resource.create";
        }

        public override IDictionary<string, string> GetParameters()
        {
            TopDictionary parameters = new TopDictionary();
            parameters.Add("param_create_seller_resource_request", this.ParamCreateSellerResourceRequest);
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
/// CreateSellerResourceRequestDomain Data Structure.
/// </summary>
[Serializable]
public class CreateSellerResourceRequestDomain : TopObject
{
	        /// <summary>
	        /// 父资源id，商家资源只能从isv模板或菜鸟标准模板继承修改，不能单独创建
	        /// </summary>
	        [XmlElement("parent_resource_id")]
	        public Nullable<long> ParentResourceId { get; set; }
	
	        /// <summary>
	        /// 资源内容
	        /// </summary>
	        [XmlElement("resource_data")]
	        public string ResourceData { get; set; }
	
	        /// <summary>
	        /// 资源名称
	        /// </summary>
	        [XmlElement("resource_name")]
	        public string ResourceName { get; set; }
	
	        /// <summary>
	        /// 商家资源类型，共两类：ISV_RESOURCE -- 表示继承自isv的资源；CAINIAO_RESOURCE  -- 表示菜鸟的资源
	        /// </summary>
	        [XmlElement("seller_resource_type")]
	        public string SellerResourceType { get; set; }
}

        #endregion
    }
}
