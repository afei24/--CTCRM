using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using Top.Api.Util;

namespace Top.Api.Request
{
    /// <summary>
    /// TOP API: taobao.wlb.waybill.i.print
    /// </summary>
    public class WlbWaybillIPrintRequest : BaseTopRequest<Top.Api.Response.WlbWaybillIPrintResponse>
    {
        /// <summary>
        /// 打印请求
        /// </summary>
        public string WaybillApplyPrintCheckRequest { get; set; }

        public WaybillApplyPrintCheckRequestDomain WaybillApplyPrintCheckRequest_ { set { this.WaybillApplyPrintCheckRequest = TopUtils.ObjectToJson(value); } } 

        #region ITopRequest Members

        public override string GetApiName()
        {
            return "taobao.wlb.waybill.i.print";
        }

        public override IDictionary<string, string> GetParameters()
        {
            TopDictionary parameters = new TopDictionary();
            parameters.Add("waybill_apply_print_check_request", this.WaybillApplyPrintCheckRequest);
            if (this.otherParams != null)
            {
                parameters.AddAll(this.otherParams);
            }
            return parameters;
        }

        public override void Validate()
        {
            RequestValidator.ValidateRequired("waybill_apply_print_check_request", this.WaybillApplyPrintCheckRequest);
        }

	/// <summary>
/// WaybillAddressDomain Data Structure.
/// </summary>
[Serializable]
public class WaybillAddressDomain : TopObject
{
	        /// <summary>
	        /// 详细地址
	        /// </summary>
	        [XmlElement("address_detail")]
	        public string AddressDetail { get; set; }
	
	        /// <summary>
	        /// 区名称（三级地址）
	        /// </summary>
	        [XmlElement("area")]
	        public string Area { get; set; }
	
	        /// <summary>
	        /// 市名称（二级地址）
	        /// </summary>
	        [XmlElement("city")]
	        public string City { get; set; }
	
	        /// <summary>
	        /// 末级地址
	        /// </summary>
	        [XmlElement("division_id")]
	        public Nullable<long> DivisionId { get; set; }
	
	        /// <summary>
	        /// 省名称（一级地址）
	        /// </summary>
	        [XmlElement("province")]
	        public string Province { get; set; }
	
	        /// <summary>
	        /// 街道\镇名称（四级地址）
	        /// </summary>
	        [XmlElement("town")]
	        public string Town { get; set; }
}

	/// <summary>
/// LogisticsServiceDomain Data Structure.
/// </summary>
[Serializable]
public class LogisticsServiceDomain : TopObject
{
	        /// <summary>
	        /// 服务编码
	        /// </summary>
	        [XmlElement("service_code")]
	        public string ServiceCode { get; set; }
	
	        /// <summary>
	        /// 服务类型值，json格式表示
	        /// </summary>
	        [XmlElement("service_value4_json")]
	        public string ServiceValue4Json { get; set; }
}

	/// <summary>
/// PrintCheckInfoDomain Data Structure.
/// </summary>
[Serializable]
public class PrintCheckInfoDomain : TopObject
{
	        /// <summary>
	        /// 收\发货地址
	        /// </summary>
	        [XmlElement("consignee_address")]
	        public WaybillAddressDomain ConsigneeAddress { get; set; }
	
	        /// <summary>
	        /// 收货网点编码
	        /// </summary>
	        [XmlElement("consignee_branch_code")]
	        public string ConsigneeBranchCode { get; set; }
	
	        /// <summary>
	        /// 收货网点信息
	        /// </summary>
	        [XmlElement("consignee_branch_name")]
	        public string ConsigneeBranchName { get; set; }
	
	        /// <summary>
	        /// 收件人姓名
	        /// </summary>
	        [XmlElement("consignee_name")]
	        public string ConsigneeName { get; set; }
	
	        /// <summary>
	        /// consigneePhone
	        /// </summary>
	        [XmlElement("consignee_phone")]
	        public string ConsigneePhone { get; set; }
	
	        /// <summary>
	        /// 物流服务能力集合
	        /// </summary>
	        [XmlArray("logistics_service_list")]
	        [XmlArrayItem("logistics_service")]
	        public List<LogisticsServiceDomain> LogisticsServiceList { get; set; }
	
	        /// <summary>
	        /// 集包地、目的地中心代码。打 印时根据该 code 生成目的地 中心的条码，条码生成的算法 与对应的电子面单条码一致
	        /// </summary>
	        [XmlElement("package_center_code")]
	        public string PackageCenterCode { get; set; }
	
	        /// <summary>
	        /// 集包地、目的地中心名称
	        /// </summary>
	        [XmlElement("package_center_name")]
	        public string PackageCenterName { get; set; }
	
	        /// <summary>
	        /// 打标设置字段，直接传给ali-lodop。不用管具体含义。
	        /// </summary>
	        [XmlElement("print_config")]
	        public string PrintConfig { get; set; }
	
	        /// <summary>
	        /// 快递服务产品类型编码
	        /// </summary>
	        [XmlElement("product_type")]
	        public string ProductType { get; set; }
	
	        /// <summary>
	        /// 使用者ID
	        /// </summary>
	        [XmlElement("real_user_id")]
	        public Nullable<long> RealUserId { get; set; }
	
	        /// <summary>
	        /// 发件人姓名
	        /// </summary>
	        [XmlElement("send_name")]
	        public string SendName { get; set; }
	
	        /// <summary>
	        /// 发件人联系方式
	        /// </summary>
	        [XmlElement("send_phone")]
	        public string SendPhone { get; set; }
	
	        /// <summary>
	        /// 收\发货地址
	        /// </summary>
	        [XmlElement("shipping_address")]
	        public WaybillAddressDomain ShippingAddress { get; set; }
	
	        /// <summary>
	        /// 发货网点编码
	        /// </summary>
	        [XmlElement("shipping_branch_code")]
	        public string ShippingBranchCode { get; set; }
	
	        /// <summary>
	        /// 发货网点信息
	        /// </summary>
	        [XmlElement("shipping_branch_name")]
	        public string ShippingBranchName { get; set; }
	
	        /// <summary>
	        /// 拣货规则（大头笔信息）
	        /// </summary>
	        [XmlElement("short_address")]
	        public string ShortAddress { get; set; }
	
	        /// <summary>
	        /// 包裹体积 单位为ML(毫升)或立方厘米
	        /// </summary>
	        [XmlElement("volume")]
	        public Nullable<long> Volume { get; set; }
	
	        /// <summary>
	        /// 电子面单单号
	        /// </summary>
	        [XmlElement("waybill_code")]
	        public string WaybillCode { get; set; }
	
	        /// <summary>
	        /// 包裹重量 单位为G(克)
	        /// </summary>
	        [XmlElement("weight")]
	        public Nullable<long> Weight { get; set; }
}

	/// <summary>
/// WaybillApplyPrintCheckRequestDomain Data Structure.
/// </summary>
[Serializable]
public class WaybillApplyPrintCheckRequestDomain : TopObject
{
	        /// <summary>
	        /// 物流服务商Code
	        /// </summary>
	        [XmlElement("cp_code")]
	        public string CpCode { get; set; }
	
	        /// <summary>
	        /// 面单详情信息
	        /// </summary>
	        [XmlArray("print_check_info_cols")]
	        [XmlArrayItem("print_check_info")]
	        public List<PrintCheckInfoDomain> PrintCheckInfoCols { get; set; }
}

        #endregion
    }
}
