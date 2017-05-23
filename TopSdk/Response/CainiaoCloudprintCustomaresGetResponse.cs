using System;
using System.Xml.Serialization;
using System.Collections.Generic;

namespace Top.Api.Response
{
    /// <summary>
    /// CainiaoCloudprintCustomaresGetResponse.
    /// </summary>
    public class CainiaoCloudprintCustomaresGetResponse : TopResponse
    {
        /// <summary>
        /// 结果
        /// </summary>
        [XmlElement("result")]
        public CloudPrintBaseResultDomain Result { get; set; }

	/// <summary>
/// KeyResultDomain Data Structure.
/// </summary>
[Serializable]
public class KeyResultDomain : TopObject
{
	        /// <summary>
	        /// key名称
	        /// </summary>
	        [XmlElement("key_name")]
	        public string KeyName { get; set; }
}

	/// <summary>
/// CustomAreaResultDomain Data Structure.
/// </summary>
[Serializable]
public class CustomAreaResultDomain : TopObject
{
	        /// <summary>
	        /// 自定义区id
	        /// </summary>
	        [XmlElement("custom_area_id")]
	        public long CustomAreaId { get; set; }
	
	        /// <summary>
	        /// 自定义区url
	        /// </summary>
	        [XmlElement("custom_area_url")]
	        public string CustomAreaUrl { get; set; }
	
	        /// <summary>
	        /// keys
	        /// </summary>
	        [XmlArray("keys")]
	        [XmlArrayItem("key_result")]
	        public List<KeyResultDomain> Keys { get; set; }
}

	/// <summary>
/// CloudPrintBaseResultDomain Data Structure.
/// </summary>
[Serializable]
public class CloudPrintBaseResultDomain : TopObject
{
	        /// <summary>
	        /// 数据
	        /// </summary>
	        [XmlArray("datas")]
	        [XmlArrayItem("custom_area_result")]
	        public List<CustomAreaResultDomain> Datas { get; set; }
	
	        /// <summary>
	        /// 系统自动生成
	        /// </summary>
	        [XmlElement("error_code")]
	        public string ErrorCode { get; set; }
	
	        /// <summary>
	        /// 系统自动生成
	        /// </summary>
	        [XmlElement("error_message")]
	        public string ErrorMessage { get; set; }
	
	        /// <summary>
	        /// 系统自动生成
	        /// </summary>
	        [XmlElement("success")]
	        public bool Success { get; set; }
}

    }
}
