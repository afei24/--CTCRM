using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using Top.Api.Util;

namespace Top.Api.Request
{
    /// <summary>
    /// TOP API: taobao.inventory.warehouse.manage
    /// </summary>
    public class InventoryWarehouseManageRequest : BaseTopRequest<Top.Api.Response.InventoryWarehouseManageResponse>
    {
        /// <summary>
        /// 仓库信息
        /// </summary>
        public string WareHouseDto { get; set; }

        public WareHouseDtoDomain WareHouseDto_ { set { this.WareHouseDto = TopUtils.ObjectToJson(value); } } 

        #region ITopRequest Members

        public override string GetApiName()
        {
            return "taobao.inventory.warehouse.manage";
        }

        public override IDictionary<string, string> GetParameters()
        {
            TopDictionary parameters = new TopDictionary();
            parameters.Add("ware_house_dto", this.WareHouseDto);
            if (this.otherParams != null)
            {
                parameters.AddAll(this.otherParams);
            }
            return parameters;
        }

        public override void Validate()
        {
            RequestValidator.ValidateRequired("ware_house_dto", this.WareHouseDto);
        }

	/// <summary>
/// WareHouseDtoDomain Data Structure.
/// </summary>
[Serializable]
public class WareHouseDtoDomain : TopObject
{
	        /// <summary>
	        /// 详细地址描述
	        /// </summary>
	        [XmlElement("address")]
	        public string Address { get; set; }
	
	        /// <summary>
	        /// 仓库地址信息,格式 :省~市~区县
	        /// </summary>
	        [XmlElement("address_area_name")]
	        public string AddressAreaName { get; set; }
	
	        /// <summary>
	        /// 别名
	        /// </summary>
	        [XmlElement("alias_name")]
	        public string AliasName { get; set; }
	
	        /// <summary>
	        /// 联系人
	        /// </summary>
	        [XmlElement("contact")]
	        public string Contact { get; set; }
	
	        /// <summary>
	        /// 操作类型，新增:ADD;修改:UPDATE
	        /// </summary>
	        [XmlElement("operate_type")]
	        public string OperateType { get; set; }
	
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
	        /// 仓库编码，仅允许使用字母、数字、下划线，并且在6-30个字符内
	        /// </summary>
	        [XmlElement("store_code")]
	        public string StoreCode { get; set; }
	
	        /// <summary>
	        /// 仓库名称
	        /// </summary>
	        [XmlElement("store_name")]
	        public string StoreName { get; set; }
}

        #endregion
    }
}
