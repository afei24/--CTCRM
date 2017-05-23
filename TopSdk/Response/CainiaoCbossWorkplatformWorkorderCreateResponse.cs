using System;
using System.Xml.Serialization;
using System.Collections.Generic;

namespace Top.Api.Response
{
    /// <summary>
    /// CainiaoCbossWorkplatformWorkorderCreateResponse.
    /// </summary>
    public class CainiaoCbossWorkplatformWorkorderCreateResponse : TopResponse
    {
        /// <summary>
        /// 接口返回model
        /// </summary>
        [XmlElement("result")]
        public ResultDomain Result { get; set; }

	/// <summary>
/// ResultDomain Data Structure.
/// </summary>
[Serializable]
public class ResultDomain : TopObject
{
	        /// <summary>
	        /// 错误码
	        /// </summary>
	        [XmlElement("res_error_code")]
	        public string ResErrorCode { get; set; }
	
	        /// <summary>
	        /// 错误信息
	        /// </summary>
	        [XmlElement("res_error_msg")]
	        public string ResErrorMsg { get; set; }
	
	        /// <summary>
	        /// 是否成功
	        /// </summary>
	        [XmlElement("res_success")]
	        public bool ResSuccess { get; set; }
	
	        /// <summary>
	        /// workOrderId
	        /// </summary>
	        [XmlElement("work_order_id")]
	        public string WorkOrderId { get; set; }
}

    }
}
