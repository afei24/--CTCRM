using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using Top.Api.Util;

namespace Top.Api.Request
{
    /// <summary>
    /// TOP API: taobao.logistics.address.reachable.feedback
    /// </summary>
    public class LogisticsAddressReachableFeedbackRequest : BaseTopRequest<Top.Api.Response.LogisticsAddressReachableFeedbackResponse>
    {
        /// <summary>
        /// 地址可达性反馈数据对象
        /// </summary>
        public string ParamAddressReachableFeedbackTopRequest { get; set; }

        public AddressReachableFeedbackTopRequestDomain ParamAddressReachableFeedbackTopRequest_ { set { this.ParamAddressReachableFeedbackTopRequest = TopUtils.ObjectToJson(value); } } 

        #region ITopRequest Members

        public override string GetApiName()
        {
            return "taobao.logistics.address.reachable.feedback";
        }

        public override IDictionary<string, string> GetParameters()
        {
            TopDictionary parameters = new TopDictionary();
            parameters.Add("param_address_reachable_feedback_top_request", this.ParamAddressReachableFeedbackTopRequest);
            if (this.otherParams != null)
            {
                parameters.AddAll(this.otherParams);
            }
            return parameters;
        }

        public override void Validate()
        {
            RequestValidator.ValidateRequired("param_address_reachable_feedback_top_request", this.ParamAddressReachableFeedbackTopRequest);
        }

	/// <summary>
/// AddressReachableFeedbackTopRequestDomain Data Structure.
/// </summary>
[Serializable]
public class AddressReachableFeedbackTopRequestDomain : TopObject
{
	        /// <summary>
	        /// 收货地址，请填写详细的收货地址，包括省、市、区、街道或镇
	        /// </summary>
	        [XmlElement("address")]
	        public string Address { get; set; }
	
	        /// <summary>
	        /// 物流商编码code
	        /// </summary>
	        [XmlElement("cp_code")]
	        public string CpCode { get; set; }
	
	        /// <summary>
	        /// 物流商ID
	        /// </summary>
	        [XmlElement("cp_id")]
	        public Nullable<long> CpId { get; set; }
	
	        /// <summary>
	        /// 地址是否可达：0-不可达；1-可达
	        /// </summary>
	        [XmlElement("reachable")]
	        public Nullable<long> Reachable { get; set; }
	
	        /// <summary>
	        /// 商家ID，淘宝卖家sellerId
	        /// </summary>
	        [XmlElement("seller_id")]
	        public Nullable<long> SellerId { get; set; }
	
	        /// <summary>
	        /// 商家昵称
	        /// </summary>
	        [XmlElement("seller_nick_name")]
	        public string SellerNickName { get; set; }
}

        #endregion
    }
}
