using System;
using System.Xml.Serialization;
using System.Collections.Generic;

namespace Top.Api.Response
{
    /// <summary>
    /// InventoryWarehouseGetResponse.
    /// </summary>
    public class InventoryWarehouseGetResponse : TopResponse
    {
        /// <summary>
        /// result
        /// </summary>
        [XmlElement("result")]
        public BaseResultDomain Result { get; set; }

	/// <summary>
/// WareHouseDtoDomain Data Structure.
/// </summary>
[Serializable]
public class WareHouseDtoDomain : TopObject
{
	        /// <summary>
	        /// 详细地址
	        /// </summary>
	        [XmlElement("address")]
	        public string Address { get; set; }
	
	        /// <summary>
	        /// 仓库地址, 到三级区域
	        /// </summary>
	        [XmlElement("address_area_name")]
	        public string AddressAreaName { get; set; }
	
	        /// <summary>
	        /// 仓库别名
	        /// </summary>
	        [XmlElement("alias_name")]
	        public string AliasName { get; set; }
	
	        /// <summary>
	        /// 联系人
	        /// </summary>
	        [XmlElement("contact")]
	        public string Contact { get; set; }
	
	        /// <summary>
	        /// 电话号码
	        /// </summary>
	        [XmlElement("phone")]
	        public string Phone { get; set; }
	
	        /// <summary>
	        /// 邮编
	        /// </summary>
	        [XmlElement("post_code")]
	        public string PostCode { get; set; }
	
	        /// <summary>
	        /// 仓库编码
	        /// </summary>
	        [XmlElement("store_code")]
	        public string StoreCode { get; set; }
	
	        /// <summary>
	        /// 仓库名
	        /// </summary>
	        [XmlElement("store_name")]
	        public string StoreName { get; set; }
}

	/// <summary>
/// BaseResultDomain Data Structure.
/// </summary>
[Serializable]
public class BaseResultDomain : TopObject
{
	        /// <summary>
	        /// 仓传输值
	        /// </summary>
	        [XmlElement("data")]
	        public WareHouseDtoDomain Data { get; set; }
	
	        /// <summary>
	        /// 错误编码
	        /// </summary>
	        [XmlElement("error_code")]
	        public string ErrorCode { get; set; }
	
	        /// <summary>
	        /// 错误信息
	        /// </summary>
	        [XmlElement("error_msg")]
	        public string ErrorMsg { get; set; }
	
	        /// <summary>
	        /// 是否成功
	        /// </summary>
	        [XmlElement("success")]
	        public bool Success { get; set; }
}

    }
}
