using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using Top.Api.Util;

namespace Top.Api.Request
{
    /// <summary>
    /// TOP API: cainiao.openstorage.resource.update
    /// </summary>
    public class CainiaoOpenstorageResourceUpdateRequest : BaseTopRequest<Top.Api.Response.CainiaoOpenstorageResourceUpdateResponse>
    {
        /// <summary>
        /// 入参
        /// </summary>
        public string ParamUpdateResourceRequest { get; set; }

        public UpdateResourceRequestDomain ParamUpdateResourceRequest_ { set { this.ParamUpdateResourceRequest = TopUtils.ObjectToJson(value); } } 

        #region ITopRequest Members

        public override string GetApiName()
        {
            return "cainiao.openstorage.resource.update";
        }

        public override IDictionary<string, string> GetParameters()
        {
            TopDictionary parameters = new TopDictionary();
            parameters.Add("param_update_resource_request", this.ParamUpdateResourceRequest);
            if (this.otherParams != null)
            {
                parameters.AddAll(this.otherParams);
            }
            return parameters;
        }

        public override void Validate()
        {
            RequestValidator.ValidateRequired("param_update_resource_request", this.ParamUpdateResourceRequest);
        }

	/// <summary>
/// UpdateResourceRequestDomain Data Structure.
/// </summary>
[Serializable]
public class UpdateResourceRequestDomain : TopObject
{
	        /// <summary>
	        /// 要更新的资源内容
	        /// </summary>
	        [XmlElement("resource_data")]
	        public string ResourceData { get; set; }
	
	        /// <summary>
	        /// 更新的资源id，必须指定
	        /// </summary>
	        [XmlElement("resource_id")]
	        public Nullable<long> ResourceId { get; set; }
	
	        /// <summary>
	        /// 更新的资源名称，如果不更新名称，只需将原有的资源名称填入即可
	        /// </summary>
	        [XmlElement("resource_name")]
	        public string ResourceName { get; set; }
	
	        /// <summary>
	        /// 资源的所有者，分为"ISV"和"SELLER"两类
	        /// </summary>
	        [XmlElement("resource_owner_type")]
	        public string ResourceOwnerType { get; set; }
}

        #endregion
    }
}
