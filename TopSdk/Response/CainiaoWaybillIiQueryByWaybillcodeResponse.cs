using System;
using System.Xml.Serialization;
using System.Collections.Generic;

namespace Top.Api.Response
{
    /// <summary>
    /// CainiaoWaybillIiQueryByWaybillcodeResponse.
    /// </summary>
    public class CainiaoWaybillIiQueryByWaybillcodeResponse : TopResponse
    {
        /// <summary>
        /// 查询返回值
        /// </summary>
        [XmlArray("modules")]
        [XmlArrayItem("waybill_cloud_print_with_result_desc_response")]
        public List<WaybillCloudPrintWithResultDescResponseDomain> Modules { get; set; }

	/// <summary>
/// WaybillCloudPrintResponseDomain Data Structure.
/// </summary>
[Serializable]
public class WaybillCloudPrintResponseDomain : TopObject
{
	        /// <summary>
	        /// 面单信息
	        /// </summary>
	        [XmlElement("print_data")]
	        public string PrintData { get; set; }
	
	        /// <summary>
	        /// 面单号
	        /// </summary>
	        [XmlElement("waybill_code")]
	        public string WaybillCode { get; set; }
}

	/// <summary>
/// WaybillCloudPrintWithResultDescResponseDomain Data Structure.
/// </summary>
[Serializable]
public class WaybillCloudPrintWithResultDescResponseDomain : TopObject
{
	        /// <summary>
	        /// 错误码
	        /// </summary>
	        [XmlElement("error_code")]
	        public string ErrorCode { get; set; }
	
	        /// <summary>
	        /// 错误信息
	        /// </summary>
	        [XmlElement("error_message")]
	        public string ErrorMessage { get; set; }
	
	        /// <summary>
	        /// 请求id
	        /// </summary>
	        [XmlElement("object_id")]
	        public string ObjectId { get; set; }
	
	        /// <summary>
	        /// 请求成功
	        /// </summary>
	        [XmlElement("success")]
	        public bool Success { get; set; }
	
	        /// <summary>
	        /// 面单查询结构体
	        /// </summary>
	        [XmlElement("waybill_cloud_print_response")]
	        public WaybillCloudPrintResponseDomain WaybillCloudPrintResponse { get; set; }
}

    }
}
