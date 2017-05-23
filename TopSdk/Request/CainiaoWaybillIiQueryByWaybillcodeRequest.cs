using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using Top.Api.Util;

namespace Top.Api.Request
{
    /// <summary>
    /// TOP API: cainiao.waybill.ii.query.by.waybillcode
    /// </summary>
    public class CainiaoWaybillIiQueryByWaybillcodeRequest : BaseTopRequest<Top.Api.Response.CainiaoWaybillIiQueryByWaybillcodeResponse>
    {
        /// <summary>
        /// 系统自动生成
        /// </summary>
        public string ParamList { get; set; }

        public List<WaybillDetailQueryByWaybillCodeRequestDomain> ParamList_ { set { this.ParamList = TopUtils.ObjectToJson(value); } } 

        #region ITopRequest Members

        public override string GetApiName()
        {
            return "cainiao.waybill.ii.query.by.waybillcode";
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
            RequestValidator.ValidateObjectMaxListSize("param_list", this.ParamList, 20);
        }

	/// <summary>
/// WaybillDetailQueryByWaybillCodeRequestDomain Data Structure.
/// </summary>
[Serializable]
public class WaybillDetailQueryByWaybillCodeRequestDomain : TopObject
{
	        /// <summary>
	        /// 快递公司code
	        /// </summary>
	        [XmlElement("cp_code")]
	        public string CpCode { get; set; }
	
	        /// <summary>
	        /// 请求id
	        /// </summary>
	        [XmlElement("object_id")]
	        public string ObjectId { get; set; }
	
	        /// <summary>
	        /// 电子面单号
	        /// </summary>
	        [XmlElement("waybill_code")]
	        public string WaybillCode { get; set; }
}

        #endregion
    }
}
