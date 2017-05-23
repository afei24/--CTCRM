using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using Top.Api.Util;

namespace Top.Api.Request
{
    /// <summary>
    /// TOP API: alibaba.interact.aopdata.register
    /// </summary>
    public class AlibabaInteractAopdataRegisterRequest : BaseTopRequest<Top.Api.Response.AlibabaInteractAopdataRegisterResponse>
    {
        /// <summary>
        /// 入参
        /// </summary>
        public string ParamTopIsvDecorateParam { get; set; }

        public TopIsvDecorateParamDomain ParamTopIsvDecorateParam_ { set { this.ParamTopIsvDecorateParam = TopUtils.ObjectToJson(value); } } 

        #region ITopRequest Members

        public override string GetApiName()
        {
            return "alibaba.interact.aopdata.register";
        }

        public override IDictionary<string, string> GetParameters()
        {
            TopDictionary parameters = new TopDictionary();
            parameters.Add("param_top_isv_decorate_param", this.ParamTopIsvDecorateParam);
            if (this.otherParams != null)
            {
                parameters.AddAll(this.otherParams);
            }
            return parameters;
        }

        public override void Validate()
        {
            RequestValidator.ValidateRequired("param_top_isv_decorate_param", this.ParamTopIsvDecorateParam);
        }

	/// <summary>
/// TopIsvDecorateParamDomain Data Structure.
/// </summary>
[Serializable]
public class TopIsvDecorateParamDomain : TopObject
{
	        /// <summary>
	        /// 活动id，调用alibaba.interact.activity.register传入的bizid
	        /// </summary>
	        [XmlElement("biz_id")]
	        public string BizId { get; set; }
	
	        /// <summary>
	        /// 目前必须填0，代表店铺
	        /// </summary>
	        [XmlElement("biz_type")]
	        public string BizType { get; set; }
	
	        /// <summary>
	        /// {"action":"update","image_url":"http://xx.cdn","click_url":"http://xxx.play.m.jaeapp.com"}，action为update，代表新增(image_url以及click_url必传)。action=get，代表获得商家设置的活动，image_url以及click_url不用填写。action＝del,代表将活动从资源位撤下
	        /// </summary>
	        [XmlElement("business_params")]
	        public string BusinessParams { get; set; }
	
	        /// <summary>
	        /// 不用传
	        /// </summary>
	        [XmlElement("position")]
	        public string Position { get; set; }
	
	        /// <summary>
	        /// 目前必须填0，代表店铺中宝箱资源位
	        /// </summary>
	        [XmlElement("sub_biz_type")]
	        public string SubBizType { get; set; }
}

        #endregion
    }
}
