using System;
using System.Xml.Serialization;
using System.Collections.Generic;

namespace Top.Api.Response
{
    /// <summary>
    /// CainiaoCloudprintCustomareaUpdateResponse.
    /// </summary>
    public class CainiaoCloudprintCustomareaUpdateResponse : TopResponse
    {
        /// <summary>
        /// result
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
	        /// keyName
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
	        /// customAreaId
	        /// </summary>
	        [XmlElement("custom_area_id")]
	        public long CustomAreaId { get; set; }
	
	        /// <summary>
	        /// customAreaUrl
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
	        /// data
	        /// </summary>
	        [XmlElement("data")]
	        public CustomAreaResultDomain Data { get; set; }
	
	        /// <summary>
	        /// errorCode
	        /// </summary>
	        [XmlElement("error_code")]
	        public string ErrorCode { get; set; }
	
	        /// <summary>
	        /// errorMessage
	        /// </summary>
	        [XmlElement("error_message")]
	        public string ErrorMessage { get; set; }
	
	        /// <summary>
	        /// success
	        /// </summary>
	        [XmlElement("success")]
	        public bool Success { get; set; }
}

    }
}
