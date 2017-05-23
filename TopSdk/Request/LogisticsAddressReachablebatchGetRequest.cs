using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using Top.Api.Util;

namespace Top.Api.Request
{
    /// <summary>
    /// TOP API: taobao.logistics.address.reachablebatch.get
    /// </summary>
    public class LogisticsAddressReachablebatchGetRequest : BaseTopRequest<Top.Api.Response.LogisticsAddressReachablebatchGetResponse>
    {
        /// <summary>
        /// 筛单用户输入地址结构
        /// </summary>
        public string AddressList { get; set; }

        public List<AddressReachableDomain> AddressList_ { set { this.AddressList = TopUtils.ObjectToJson(value); } } 

        #region ITopRequest Members

        public override string GetApiName()
        {
            return "taobao.logistics.address.reachablebatch.get";
        }

        public override IDictionary<string, string> GetParameters()
        {
            TopDictionary parameters = new TopDictionary();
            parameters.Add("address_list", this.AddressList);
            if (this.otherParams != null)
            {
                parameters.AddAll(this.otherParams);
            }
            return parameters;
        }

        public override void Validate()
        {
            RequestValidator.ValidateObjectMaxListSize("address_list", this.AddressList, 20);
        }

	/// <summary>
/// AddressReachableDomain Data Structure.
/// </summary>
[Serializable]
public class AddressReachableDomain : TopObject
{
	        /// <summary>
	        /// 详细地址
	        /// </summary>
	        [XmlElement("address")]
	        public string Address { get; set; }
	
	        /// <summary>
	        /// 标准区域编码(三级行政区编码或是四级行政区)，可以通过taobao.areas.get获取，如北京市朝阳区为110105
	        /// </summary>
	        [XmlElement("area_code")]
	        public string AreaCode { get; set; }
	
	        /// <summary>
	        /// 物流公司编码ID，可以从这个接口获取所有物流公司的标准编码taobao.logistics.companies.get，可以传入多个值，以英文逗号分隔，如“1000000952,1000000953”
	        /// </summary>
	        [XmlElement("partner_id")]
	        public string PartnerId { get; set; }
	
	        /// <summary>
	        /// 服务对应的数字编码，如揽派范围对应88
	        /// </summary>
	        [XmlElement("service_type")]
	        public Nullable<long> ServiceType { get; set; }
	
	        /// <summary>
	        /// 发货地，标准区域编码(四级行政)，可以通过taobao.areas.get获取，如浙江省杭州市余杭区闲林街道为 330110011
	        /// </summary>
	        [XmlElement("source_area_code")]
	        public string SourceAreaCode { get; set; }
}

        #endregion
    }
}
