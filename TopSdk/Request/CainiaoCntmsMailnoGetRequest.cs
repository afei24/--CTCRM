using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using Top.Api.Util;

namespace Top.Api.Request
{
    /// <summary>
    /// TOP API: cainiao.cntms.mailno.get
    /// </summary>
    public class CainiaoCntmsMailnoGetRequest : BaseTopRequest<Top.Api.Response.CainiaoCntmsMailnoGetResponse>
    {
        /// <summary>
        /// 获取菜鸟配送电子面单请求参数
        /// </summary>
        public string Content { get; set; }

        public CnTmsMailnoGetContentDomain Content_ { set { this.Content = TopUtils.ObjectToJson(value); } } 

        #region ITopRequest Members

        public override string GetApiName()
        {
            return "cainiao.cntms.mailno.get";
        }

        public override IDictionary<string, string> GetParameters()
        {
            TopDictionary parameters = new TopDictionary();
            parameters.Add("content", this.Content);
            if (this.otherParams != null)
            {
                parameters.AddAll(this.otherParams);
            }
            return parameters;
        }

        public override void Validate()
        {
        }

	/// <summary>
/// CnTmsMailnoReceiverinfoDomain Data Structure.
/// </summary>
[Serializable]
public class CnTmsMailnoReceiverinfoDomain : TopObject
{
	        /// <summary>
	        /// 收件人地址
	        /// </summary>
	        [XmlElement("receiver_address")]
	        public string ReceiverAddress { get; set; }
	
	        /// <summary>
	        /// 收件人区县
	        /// </summary>
	        [XmlElement("receiver_area")]
	        public string ReceiverArea { get; set; }
	
	        /// <summary>
	        /// 收件人城市
	        /// </summary>
	        [XmlElement("receiver_city")]
	        public string ReceiverCity { get; set; }
	
	        /// <summary>
	        /// 收件人手机，手机与电话必须有一值不为空
	        /// </summary>
	        [XmlElement("receiver_mobile")]
	        public string ReceiverMobile { get; set; }
	
	        /// <summary>
	        /// 收件人姓名
	        /// </summary>
	        [XmlElement("receiver_name")]
	        public string ReceiverName { get; set; }
	
	        /// <summary>
	        /// 收件人昵称
	        /// </summary>
	        [XmlElement("receiver_nick")]
	        public string ReceiverNick { get; set; }
	
	        /// <summary>
	        /// 收件人电话，手机与电话必须有一值不为空
	        /// </summary>
	        [XmlElement("receiver_phone")]
	        public string ReceiverPhone { get; set; }
	
	        /// <summary>
	        /// 收件人省份
	        /// </summary>
	        [XmlElement("receiver_province")]
	        public string ReceiverProvince { get; set; }
	
	        /// <summary>
	        /// 收件方邮编
	        /// </summary>
	        [XmlElement("receiver_zip_code")]
	        public string ReceiverZipCode { get; set; }
}

	/// <summary>
/// CnTmsMailnoSenderinfoDomain Data Structure.
/// </summary>
[Serializable]
public class CnTmsMailnoSenderinfoDomain : TopObject
{
	        /// <summary>
	        /// 发件人地址
	        /// </summary>
	        [XmlElement("sender_address")]
	        public string SenderAddress { get; set; }
	
	        /// <summary>
	        /// 发件人区县
	        /// </summary>
	        [XmlElement("sender_area")]
	        public string SenderArea { get; set; }
	
	        /// <summary>
	        /// 发件人城市
	        /// </summary>
	        [XmlElement("sender_city")]
	        public string SenderCity { get; set; }
	
	        /// <summary>
	        /// 发件人手机，手机与电话必须有一值不为空
	        /// </summary>
	        [XmlElement("sender_mobile")]
	        public string SenderMobile { get; set; }
	
	        /// <summary>
	        /// 发件人姓名
	        /// </summary>
	        [XmlElement("sender_name")]
	        public string SenderName { get; set; }
	
	        /// <summary>
	        /// 发件人电话，手机与电话必须有一值不为空
	        /// </summary>
	        [XmlElement("sender_phone")]
	        public string SenderPhone { get; set; }
	
	        /// <summary>
	        /// 发件人省份
	        /// </summary>
	        [XmlElement("sender_province")]
	        public string SenderProvince { get; set; }
	
	        /// <summary>
	        /// 发件人邮编
	        /// </summary>
	        [XmlElement("sender_zip_code")]
	        public string SenderZipCode { get; set; }
}

	/// <summary>
/// CnTmsMailnoItemDomain Data Structure.
/// </summary>
[Serializable]
public class CnTmsMailnoItemDomain : TopObject
{
	        /// <summary>
	        /// 发货商品名称
	        /// </summary>
	        [XmlElement("item_name")]
	        public string ItemName { get; set; }
	
	        /// <summary>
	        /// 发货商品数量
	        /// </summary>
	        [XmlElement("item_qty")]
	        public Nullable<long> ItemQty { get; set; }
}

	/// <summary>
/// CnTmsMailnoGetContentDomain Data Structure.
/// </summary>
[Serializable]
public class CnTmsMailnoGetContentDomain : TopObject
{
	        /// <summary>
	        /// 拓展字段
	        /// </summary>
	        [XmlElement("extend_field")]
	        public string ExtendField { get; set; }
	
	        /// <summary>
	        /// 发货商品信息
	        /// </summary>
	        [XmlArray("items")]
	        [XmlArrayItem("cn_tms_mailno_item")]
	        public List<CnTmsMailnoItemDomain> Items { get; set; }
	
	        /// <summary>
	        /// ERP订单编码
	        /// </summary>
	        [XmlElement("order_code")]
	        public string OrderCode { get; set; }
	
	        /// <summary>
	        /// 来源渠道（TB 淘宝，JD 京东，TM 天猫，1688 1688（阿里中文站），YHD 1号店，DD 当当，VANCL 凡客，PP 拍拍，YX 易讯，EBAY 易贝ebay，AMAZON 亚马逊，SN 苏宁在线，GM 国美在线，WPH 唯品会，JM 聚美优品，LF 乐蜂网，MGJ 蘑菇街，JS 聚尚网，YG 优购，YT 银泰，YL 邮乐，PX 拍鞋网，POS POS门店，OTHERS 其他）
	        /// </summary>
	        [XmlElement("order_source")]
	        public string OrderSource { get; set; }
	
	        /// <summary>
	        /// 包裹序号,如果同一订单获取多个包裹时,需要标记当前请求为第几个包裹
	        /// </summary>
	        [XmlElement("package_no")]
	        public Nullable<long> PackageNo { get; set; }
	
	        /// <summary>
	        /// 收件人信息
	        /// </summary>
	        [XmlElement("receiver_info")]
	        public CnTmsMailnoReceiverinfoDomain ReceiverInfo { get; set; }
	
	        /// <summary>
	        /// 发件人信息
	        /// </summary>
	        [XmlElement("sender_info")]
	        public CnTmsMailnoSenderinfoDomain SenderInfo { get; set; }
	
	        /// <summary>
	        /// 店铺编码
	        /// </summary>
	        [XmlElement("shop_code")]
	        public string ShopCode { get; set; }
	
	        /// <summary>
	        /// 解决方案CODE，由菜鸟提供
	        /// </summary>
	        [XmlElement("solutions_code")]
	        public string SolutionsCode { get; set; }
	
	        /// <summary>
	        /// 交易单号
	        /// </summary>
	        [XmlElement("trade_id")]
	        public string TradeId { get; set; }
}

        #endregion
    }
}
