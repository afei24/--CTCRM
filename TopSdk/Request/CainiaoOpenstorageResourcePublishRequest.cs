using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using Top.Api.Util;

namespace Top.Api.Request
{
    /// <summary>
    /// TOP API: cainiao.openstorage.resource.publish
    /// </summary>
    public class CainiaoOpenstorageResourcePublishRequest : BaseTopRequest<Top.Api.Response.CainiaoOpenstorageResourcePublishResponse>
    {
        /// <summary>
        /// 资源发布参数
        /// </summary>
        public string ParamPublishResourceRequest { get; set; }

        public PublishResourceRequestDomain ParamPublishResourceRequest_ { set { this.ParamPublishResourceRequest = TopUtils.ObjectToJson(value); } } 

        #region ITopRequest Members

        public override string GetApiName()
        {
            return "cainiao.openstorage.resource.publish";
        }

        public override IDictionary<string, string> GetParameters()
        {
            TopDictionary parameters = new TopDictionary();
            parameters.Add("param_publish_resource_request", this.ParamPublishResourceRequest);
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
/// PublishResourceRequestDomain Data Structure.
/// </summary>
[Serializable]
public class PublishResourceRequestDomain : TopObject
{
	        /// <summary>
	        /// 要发布的资源id
	        /// </summary>
	        [XmlElement("resource_id")]
	        public Nullable<long> ResourceId { get; set; }
	
	        /// <summary>
	        /// 资源所有者，分为"ISV"和"SELLER"两类
	        /// </summary>
	        [XmlElement("resource_owner_type")]
	        public string ResourceOwnerType { get; set; }
}

        #endregion
    }
}
