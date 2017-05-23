using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using Top.Api.Util;

namespace Top.Api.Request
{
    /// <summary>
    /// TOP API: cainiao.openstorage.isv.resource.create
    /// </summary>
    public class CainiaoOpenstorageIsvResourceCreateRequest : BaseTopRequest<Top.Api.Response.CainiaoOpenstorageIsvResourceCreateResponse>
    {
        /// <summary>
        /// isv创建资源的参数
        /// </summary>
        public string ParamCreateIsvResourceRequest { get; set; }

        public CreateIsvResourceRequestDomain ParamCreateIsvResourceRequest_ { set { this.ParamCreateIsvResourceRequest = TopUtils.ObjectToJson(value); } } 

        #region ITopRequest Members

        public override string GetApiName()
        {
            return "cainiao.openstorage.isv.resource.create";
        }

        public override IDictionary<string, string> GetParameters()
        {
            TopDictionary parameters = new TopDictionary();
            parameters.Add("param_create_isv_resource_request", this.ParamCreateIsvResourceRequest);
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
/// CreateIsvResourceRequestDomain Data Structure.
/// </summary>
[Serializable]
public class CreateIsvResourceRequestDomain : TopObject
{
	        /// <summary>
	        /// isv资源类型，"TEMPLATE"表示模板资源，"PRINT_ITEM"表示打印项
	        /// </summary>
	        [XmlElement("isv_resource_type")]
	        public string IsvResourceType { get; set; }
	
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
}

        #endregion
    }
}
