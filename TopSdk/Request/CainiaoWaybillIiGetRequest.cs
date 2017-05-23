using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using Top.Api.Util;

namespace Top.Api.Request
{
    /// <summary>
    /// TOP API: cainiao.waybill.ii.get
    /// </summary>
    public class CainiaoWaybillIiGetRequest : BaseTopRequest<Top.Api.Response.CainiaoWaybillIiGetResponse>
    {
        /// <summary>
        /// 入参信息
        /// </summary>
        public string ParamWaybillCloudPrintApplyNewRequest { get; set; }

        public WaybillCloudPrintApplyNewRequestDomain ParamWaybillCloudPrintApplyNewRequest_ { set { this.ParamWaybillCloudPrintApplyNewRequest = TopUtils.ObjectToJson(value); } } 

        #region ITopRequest Members

        public override string GetApiName()
        {
            return "cainiao.waybill.ii.get";
        }

        public override IDictionary<string, string> GetParameters()
        {
            TopDictionary parameters = new TopDictionary();
            parameters.Add("param_waybill_cloud_print_apply_new_request", this.ParamWaybillCloudPrintApplyNewRequest);
            if (this.otherParams != null)
            {
                parameters.AddAll(this.otherParams);
            }
            return parameters;
        }

        public override void Validate()
        {
            RequestValidator.ValidateRequired("param_waybill_cloud_print_apply_new_request", this.ParamWaybillCloudPrintApplyNewRequest);
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
	        /// 区
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
	        /// 发货地址需要通过<a href="http://open.taobao.com/doc2/detail.htm?spm=a219a.7629140.0.0.3OFCPk&treeId=17&articleId=104860&docType=1">search接口</a>
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
/// OrderInfoDtoDomain Data Structure.
/// </summary>
[Serializable]
public class OrderInfoDtoDomain : TopObject
{
	        /// <summary>
	        /// <a href="http://open.taobao.com/doc2/detail.htm?spm=a219a.7629140.0.0.8cf9Nj&treeId=17&articleId=105085&docType=1#2">订单渠道平台编码</a>
	        /// </summary>
	        [XmlElement("order_channels_type")]
	        public string OrderChannelsType { get; set; }
	
	        /// <summary>
	        /// 订单号,数量限制100
	        /// </summary>
	        [XmlArray("trade_order_list")]
	        [XmlArrayItem("string")]
	        public List<string> TradeOrderList { get; set; }
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
	        /// 包裹id,拆合单使用，<a href="http://open.taobao.com/doc2/detail.htm?spm=a219a.7629140.0.0.8cf9Nj&treeId=17&articleId=105085&docType=1#10">使用方式</a>
	        /// </summary>
	        [XmlElement("id")]
	        public string Id { get; set; }
	
	        /// <summary>
	        /// 商品信息,数量限制为100
	        /// </summary>
	        [XmlArray("items")]
	        [XmlArrayItem("item")]
	        public List<ItemDomain> Items { get; set; }
	
	        /// <summary>
	        /// 体积, 单位 ml
	        /// </summary>
	        [XmlElement("volume")]
	        public Nullable<long> Volume { get; set; }
	
	        /// <summary>
	        /// 重量,单位 g
	        /// </summary>
	        [XmlElement("weight")]
	        public Nullable<long> Weight { get; set; }
}

	/// <summary>
/// TradeOrderInfoDtoDomain Data Structure.
/// </summary>
[Serializable]
public class TradeOrderInfoDtoDomain : TopObject
{
	        /// <summary>
	        /// 服务值,传值方式见<a href="http://open.taobao.com/doc2/detail.htm?spm=a219a.7629140.0.0.haIJwt&treeId=17&articleId=105050&docType=1">链接</a>
	        /// </summary>
	        [XmlElement("logistics_services")]
	        public string LogisticsServices { get; set; }
	
	        /// <summary>
	        /// <a href="http://open.taobao.com/docs/doc.htm?docType=1&articleId=105086&treeId=17&platformId=17#6">请求ID</a>
	        /// </summary>
	        [XmlElement("object_id")]
	        public string ObjectId { get; set; }
	
	        /// <summary>
	        /// 订单信息
	        /// </summary>
	        [XmlElement("order_info")]
	        public OrderInfoDtoDomain OrderInfo { get; set; }
	
	        /// <summary>
	        /// 包裹信息
	        /// </summary>
	        [XmlElement("package_info")]
	        public PackageInfoDtoDomain PackageInfo { get; set; }
	
	        /// <summary>
	        /// 收件人信息
	        /// </summary>
	        [XmlElement("recipient")]
	        public UserInfoDtoDomain Recipient { get; set; }
	
	        /// <summary>
	        /// 标准模板模板URL<a href="http://open.taobao.com/doc2/apiDetail.htm?apiId=26756">获取方式</a>,<a href="http://open.taobao.com/doc2/detail.htm?spm=a219a.7629140.0.0.Wl5ToC&treeId=17&articleId=105049&docType=1">打印组件使用文档</a>
	        /// </summary>
	        [XmlElement("template_url")]
	        public string TemplateUrl { get; set; }
	
	        /// <summary>
	        /// 使用者ID<a href="http://open.taobao.com/support/hotProblemDetail.htm?spm=a219a.7386793.0.0.4mwx9s&id=244622&tagId=">获取方式</a>
	        /// </summary>
	        [XmlElement("user_id")]
	        public Nullable<long> UserId { get; set; }
}

	/// <summary>
/// WaybillCloudPrintApplyNewRequestDomain Data Structure.
/// </summary>
[Serializable]
public class WaybillCloudPrintApplyNewRequestDomain : TopObject
{
	        /// <summary>
	        /// <a href="http://open.taobao.com/doc2/detail.htm?spm=a219a.7629140.0.0.8cf9Nj&treeId=17&articleId=105085&docType=1#1">物流公司Code</a>
	        /// </summary>
	        [XmlElement("cp_code")]
	        public string CpCode { get; set; }
	
	        /// <summary>
	        /// 产品类型编码,<a href="http://open.taobao.com/doc2/detail.htm?spm=a219a.7629140.0.0.haIJwt&treeId=17&articleId=105050&docType=1">链接</a>
	        /// </summary>
	        [XmlElement("product_code")]
	        public string ProductCode { get; set; }
	
	        /// <summary>
	        /// 发货人信息
	        /// </summary>
	        [XmlElement("sender")]
	        public UserInfoDtoDomain Sender { get; set; }
	
	        /// <summary>
	        /// 请求面单信息，数量限制为10
	        /// </summary>
	        [XmlArray("trade_order_info_dtos")]
	        [XmlArrayItem("trade_order_info_dto")]
	        public List<TradeOrderInfoDtoDomain> TradeOrderInfoDtos { get; set; }
}

        #endregion
    }
}
