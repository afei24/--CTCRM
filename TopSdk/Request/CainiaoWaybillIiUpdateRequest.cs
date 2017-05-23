using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using Top.Api.Util;

namespace Top.Api.Request
{
    /// <summary>
    /// TOP API: cainiao.waybill.ii.update
    /// </summary>
    public class CainiaoWaybillIiUpdateRequest : BaseTopRequest<Top.Api.Response.CainiaoWaybillIiUpdateResponse>
    {
        /// <summary>
        /// 更新请求信息
        /// </summary>
        public string ParamWaybillCloudPrintUpdateRequest { get; set; }

        public WaybillCloudPrintUpdateRequestDomain ParamWaybillCloudPrintUpdateRequest_ { set { this.ParamWaybillCloudPrintUpdateRequest = TopUtils.ObjectToJson(value); } } 

        #region ITopRequest Members

        public override string GetApiName()
        {
            return "cainiao.waybill.ii.update";
        }

        public override IDictionary<string, string> GetParameters()
        {
            TopDictionary parameters = new TopDictionary();
            parameters.Add("param_waybill_cloud_print_update_request", this.ParamWaybillCloudPrintUpdateRequest);
            if (this.otherParams != null)
            {
                parameters.AddAll(this.otherParams);
            }
            return parameters;
        }

        public override void Validate()
        {
            RequestValidator.ValidateRequired("param_waybill_cloud_print_update_request", this.ParamWaybillCloudPrintUpdateRequest);
        }

	/// <summary>
/// ItemDomain Data Structure.
/// </summary>
[Serializable]
public class ItemDomain : TopObject
{
	        /// <summary>
	        /// 数量
	        /// </summary>
	        [XmlElement("count")]
	        public Nullable<long> Count { get; set; }
	
	        /// <summary>
	        /// 名称
	        /// </summary>
	        [XmlElement("name")]
	        public string Name { get; set; }
}

	/// <summary>
/// PackageInfoDtoDomain Data Structure.
/// </summary>
[Serializable]
public class PackageInfoDtoDomain : TopObject
{
	        /// <summary>
	        /// 商品
	        /// </summary>
	        [XmlArray("items")]
	        [XmlArrayItem("item")]
	        public List<ItemDomain> Items { get; set; }
	
	        /// <summary>
	        /// 体积
	        /// </summary>
	        [XmlElement("volume")]
	        public Nullable<long> Volume { get; set; }
	
	        /// <summary>
	        /// 重量
	        /// </summary>
	        [XmlElement("weight")]
	        public Nullable<long> Weight { get; set; }
}

	/// <summary>
/// AddressDtoDomain Data Structure.
/// </summary>
[Serializable]
public class AddressDtoDomain : TopObject
{
	        /// <summary>
	        /// 城市
	        /// </summary>
	        [XmlElement("city")]
	        public string City { get; set; }
	
	        /// <summary>
	        /// 详细地址
	        /// </summary>
	        [XmlElement("detail")]
	        public string Detail { get; set; }
	
	        /// <summary>
	        /// 区地址
	        /// </summary>
	        [XmlElement("district")]
	        public string District { get; set; }
	
	        /// <summary>
	        /// 省
	        /// </summary>
	        [XmlElement("province")]
	        public string Province { get; set; }
	
	        /// <summary>
	        /// 街道
	        /// </summary>
	        [XmlElement("town")]
	        public string Town { get; set; }
}

	/// <summary>
/// UserInfoDtoDomain Data Structure.
/// </summary>
[Serializable]
public class UserInfoDtoDomain : TopObject
{
	        /// <summary>
	        /// 地址
	        /// </summary>
	        [XmlElement("address")]
	        public AddressDtoDomain Address { get; set; }
	
	        /// <summary>
	        /// 手机号码
	        /// </summary>
	        [XmlElement("mobile")]
	        public string Mobile { get; set; }
	
	        /// <summary>
	        /// 姓名
	        /// </summary>
	        [XmlElement("name")]
	        public string Name { get; set; }
	
	        /// <summary>
	        /// 固定电话
	        /// </summary>
	        [XmlElement("phone")]
	        public string Phone { get; set; }
}

	/// <summary>
/// WaybillCloudPrintUpdateRequestDomain Data Structure.
/// </summary>
[Serializable]
public class WaybillCloudPrintUpdateRequestDomain : TopObject
{
	        /// <summary>
	        /// 物流公司CODE
	        /// </summary>
	        [XmlElement("cp_code")]
	        public string CpCode { get; set; }
	
	        /// <summary>
	        /// 物流服务内容<a href="http://open.taobao.com/doc2/detail.htm?spm=a219a.7629140.0.0.eK8aZm&treeId=17&articleId=26765&docType=2">链接</a>
	        /// </summary>
	        [XmlElement("logistics_services")]
	        public string LogisticsServices { get; set; }
	
	        /// <summary>
	        /// 请求表示id
	        /// </summary>
	        [XmlElement("object_id")]
	        public string ObjectId { get; set; }
	
	        /// <summary>
	        /// 包裹信息
	        /// </summary>
	        [XmlElement("package_info")]
	        public PackageInfoDtoDomain PackageInfo { get; set; }
	
	        /// <summary>
	        /// 收件信息
	        /// </summary>
	        [XmlElement("recipient")]
	        public UserInfoDtoDomain Recipient { get; set; }
	
	        /// <summary>
	        /// 发件信息
	        /// </summary>
	        [XmlElement("sender")]
	        public UserInfoDtoDomain Sender { get; set; }
	
	        /// <summary>
	        /// 模板URL
	        /// </summary>
	        [XmlElement("template_url")]
	        public string TemplateUrl { get; set; }
	
	        /// <summary>
	        /// 面单号
	        /// </summary>
	        [XmlElement("waybill_code")]
	        public string WaybillCode { get; set; }
}

        #endregion
    }
}
