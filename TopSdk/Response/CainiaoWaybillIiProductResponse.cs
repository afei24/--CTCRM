using System;
using System.Xml.Serialization;
using System.Collections.Generic;

namespace Top.Api.Response
{
    /// <summary>
    /// CainiaoWaybillIiProductResponse.
    /// </summary>
    public class CainiaoWaybillIiProductResponse : TopResponse
    {
        /// <summary>
        /// 返回值
        /// </summary>
        [XmlArray("product_types")]
        [XmlArrayItem("waybill_product_type")]
        public List<WaybillProductTypeDomain> ProductTypes { get; set; }

	/// <summary>
/// WaybillServiceTypeDomain Data Structure.
/// </summary>
[Serializable]
public class WaybillServiceTypeDomain : TopObject
{
	        /// <summary>
	        /// code
	        /// </summary>
	        [XmlElement("code")]
	        public string Code { get; set; }
	
	        /// <summary>
	        /// name
	        /// </summary>
	        [XmlElement("name")]
	        public string Name { get; set; }
}

	/// <summary>
/// WaybillProductTypeDomain Data Structure.
/// </summary>
[Serializable]
public class WaybillProductTypeDomain : TopObject
{
	        /// <summary>
	        /// 产品code
	        /// </summary>
	        [XmlElement("code")]
	        public string Code { get; set; }
	
	        /// <summary>
	        /// 产品名称
	        /// </summary>
	        [XmlElement("name")]
	        public string Name { get; set; }
	
	        /// <summary>
	        /// 物流服务
	        /// </summary>
	        [XmlArray("service_types")]
	        [XmlArrayItem("waybill_service_type")]
	        public List<WaybillServiceTypeDomain> ServiceTypes { get; set; }
}

    }
}
