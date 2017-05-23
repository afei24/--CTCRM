using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using Top.Api.Util;

namespace Top.Api.Request
{
    /// <summary>
    /// TOP API: cainiao.waybill.ii.query.by.tradecode
    /// </summary>
    public class CainiaoWaybillIiQueryByTradecodeRequest : BaseTopRequest<Top.Api.Response.CainiaoWaybillIiQueryByTradecodeResponse>
    {
        /// <summary>
        /// 订单号列表
        /// </summary>
        public string ParamList { get; set; }

        public List<WaybillDetailQueryByBizSubCodeRequestDomain> ParamList_ { set { this.ParamList = TopUtils.ObjectToJson(value); } } 

        #region ITopRequest Members

        public override string GetApiName()
        {
            return "cainiao.waybill.ii.query.by.tradecode";
        }

        public override IDictionary<string, string> GetParameters()
        {
            TopDictionary parameters = new TopDictionary();
            parameters.Add("param_list", this.ParamList);
            if (this.otherParams != null)
            {
                parameters.AddAll(this.otherParams);
            }
            return parameters;
        }

        public override void Validate()
        {
            RequestValidator.ValidateObjectMaxListSize("param_list", this.ParamList, 10);
        }

	/// <summary>
/// WaybillDetailQueryByBizSubCodeRequestDomain Data Structure.
/// </summary>
[Serializable]
public class WaybillDetailQueryByBizSubCodeRequestDomain : TopObject
{
	        /// <summary>
	        /// 订单号
	        /// </summary>
	        [XmlElement("biz_sub_code")]
	        public string BizSubCode { get; set; }
	
	        /// <summary>
	        /// 请求id
	        /// </summary>
	        [XmlElement("object_id")]
	        public string ObjectId { get; set; }
}

        #endregion
    }
}
