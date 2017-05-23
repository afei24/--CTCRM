using System;
using System.Xml.Serialization;
using System.Collections.Generic;

namespace Top.Api.Response
{
    /// <summary>
    /// CainiaoWaybillIiGetResponse.
    /// </summary>
    public class CainiaoWaybillIiGetResponse : TopResponse
    {
        /// <summary>
        /// 系统自动生成
        /// </summary>
        [XmlArray("modules")]
        [XmlArrayItem("waybill_cloud_print_response")]
        public List<WaybillCloudPrintResponseDomain> Modules { get; set; }

	/// <summary>
/// WaybillCloudPrintResponseDomain Data Structure.
/// </summary>
[Serializable]
public class WaybillCloudPrintResponseDomain : TopObject
{
	        /// <summary>
	        /// 请求id
	        /// </summary>
	        [XmlElement("object_id")]
	        public string ObjectId { get; set; }
	
	        /// <summary>
	        /// 模板内容,具体解释见<a href="http://open.taobao.com/doc2/detail.htm?spm=a219a.7629140.0.0.8cf9Nj&treeId=17&articleId=105085&docType=1#12">链接</a>
	        /// </summary>
	        [XmlElement("print_data")]
	        public string PrintData { get; set; }
	
	        /// <summary>
	        /// 面单号
	        /// </summary>
	        [XmlElement("waybill_code")]
	        public string WaybillCode { get; set; }
}

    }
}
