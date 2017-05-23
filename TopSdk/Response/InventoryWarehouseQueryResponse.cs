using System;
using System.Xml.Serialization;
using System.Collections.Generic;

namespace Top.Api.Response
{
    /// <summary>
    /// InventoryWarehouseQueryResponse.
    /// </summary>
    public class InventoryWarehouseQueryResponse : TopResponse
    {
        /// <summary>
        /// result
        /// </summary>
        [XmlElement("result")]
        public PaginationResultDomain Result { get; set; }

	/// <summary>
/// PaginationResultDomain Data Structure.
/// </summary>
[Serializable]
public class PaginationResultDomain : TopObject
{
	        /// <summary>
	        /// 仓库信息数组
	        /// </summary>
	        [XmlElement("data")]
	        public string Data { get; set; }
	
	        /// <summary>
	        /// 错误码
	        /// </summary>
	        [XmlElement("error_code")]
	        public string ErrorCode { get; set; }
	
	        /// <summary>
	        /// 错误信息
	        /// </summary>
	        [XmlElement("error_msg")]
	        public string ErrorMsg { get; set; }
	
	        /// <summary>
	        /// 页码
	        /// </summary>
	        [XmlElement("page_no")]
	        public long PageNo { get; set; }
	
	        /// <summary>
	        /// 页大小
	        /// </summary>
	        [XmlElement("page_size")]
	        public long PageSize { get; set; }
	
	        /// <summary>
	        /// 是否成功
	        /// </summary>
	        [XmlElement("success")]
	        public bool Success { get; set; }
	
	        /// <summary>
	        /// 总条数
	        /// </summary>
	        [XmlElement("total_count")]
	        public long TotalCount { get; set; }
}

    }
}
