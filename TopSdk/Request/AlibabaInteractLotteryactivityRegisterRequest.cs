using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using Top.Api.Util;

namespace Top.Api.Request
{
    /// <summary>
    /// TOP API: alibaba.interact.lotteryactivity.register
    /// </summary>
    public class AlibabaInteractLotteryactivityRegisterRequest : BaseTopRequest<Top.Api.Response.AlibabaInteractLotteryactivityRegisterResponse>
    {
        /// <summary>
        /// 入参
        /// </summary>
        public string ParamTopUpdateActivityLotteryInfoParam { get; set; }

        public TopUpdateActivityLotteryInfoParamDomain ParamTopUpdateActivityLotteryInfoParam_ { set { this.ParamTopUpdateActivityLotteryInfoParam = TopUtils.ObjectToJson(value); } } 

        #region ITopRequest Members

        public override string GetApiName()
        {
            return "alibaba.interact.lotteryactivity.register";
        }

        public override IDictionary<string, string> GetParameters()
        {
            TopDictionary parameters = new TopDictionary();
            parameters.Add("param_top_update_activity_lottery_info_param", this.ParamTopUpdateActivityLotteryInfoParam);
            if (this.otherParams != null)
            {
                parameters.AddAll(this.otherParams);
            }
            return parameters;
        }

        public override void Validate()
        {
            RequestValidator.ValidateRequired("param_top_update_activity_lottery_info_param", this.ParamTopUpdateActivityLotteryInfoParam);
        }

	/// <summary>
/// TopUpdateActivityLotteryInfoParamDomain Data Structure.
/// </summary>
[Serializable]
public class TopUpdateActivityLotteryInfoParamDomain : TopObject
{
	        /// <summary>
	        /// 商家通过isv创建的活动id
	        /// </summary>
	        [XmlElement("activity_biz_id")]
	        public string ActivityBizId { get; set; }
	
	        /// <summary>
	        /// isv的appkey
	        /// </summary>
	        [XmlElement("app_key")]
	        public string AppKey { get; set; }
	
	        /// <summary>
	        /// 可随意传，目前没有用到，扩展字段
	        /// </summary>
	        [XmlElement("banner_url")]
	        public string BannerUrl { get; set; }
	
	        /// <summary>
	        /// 商家创建的红包总额
	        /// </summary>
	        [XmlElement("benefit_amount")]
	        public string BenefitAmount { get; set; }
	
	        /// <summary>
	        /// 可随意传，目前没有用到，扩展字段
	        /// </summary>
	        [XmlElement("benefit_attribute")]
	        public string BenefitAttribute { get; set; }
	
	        /// <summary>
	        /// 商家创建的红包面额
	        /// </summary>
	        [XmlElement("benefit_denomination")]
	        public Nullable<long> BenefitDenomination { get; set; }
	
	        /// <summary>
	        /// 商家选择使用的红包权益id
	        /// </summary>
	        [XmlElement("benefit_id")]
	        public Nullable<long> BenefitId { get; set; }
	
	        /// <summary>
	        /// 目前填1，代表支付宝红包
	        /// </summary>
	        [XmlElement("benefit_type")]
	        public string BenefitType { get; set; }
	
	        /// <summary>
	        /// 目前必须填4，代表互动城
	        /// </summary>
	        [XmlElement("biz_type")]
	        public string BizType { get; set; }
	
	        /// <summary>
	        /// 商家创建的isv活动的结束时间
	        /// </summary>
	        [XmlElement("end_time")]
	        public Nullable<DateTime> EndTime { get; set; }
	
	        /// <summary>
	        /// 抽奖活动开始时间，long型
	        /// </summary>
	        [XmlElement("lottery_activity_end_date")]
	        public Nullable<long> LotteryActivityEndDate { get; set; }
	
	        /// <summary>
	        /// 抽奖活动结束时间
	        /// </summary>
	        [XmlElement("lottery_activity_start_date")]
	        public Nullable<long> LotteryActivityStartDate { get; set; }
	
	        /// <summary>
	        /// 抽奖活动名称
	        /// </summary>
	        [XmlElement("name")]
	        public string Name { get; set; }
	
	        /// <summary>
	        /// 奖品扩展字段
	        /// </summary>
	        [XmlElement("prize_ext_attribute")]
	        public string PrizeExtAttribute { get; set; }
	
	        /// <summary>
	        /// 1元红包
	        /// </summary>
	        [XmlElement("prize_name")]
	        public string PrizeName { get; set; }
	
	        /// <summary>
	        /// 奖品扩展字段
	        /// </summary>
	        [XmlElement("prize_param_attribute")]
	        public string PrizeParamAttribute { get; set; }
	
	        /// <summary>
	        /// 奖品总数
	        /// </summary>
	        [XmlElement("prize_quantity")]
	        public string PrizeQuantity { get; set; }
	
	        /// <summary>
	        /// 奖品总数
	        /// </summary>
	        [XmlElement("prize_remain_quantity")]
	        public string PrizeRemainQuantity { get; set; }
	
	        /// <summary>
	        /// 必须填1，代表红包
	        /// </summary>
	        [XmlElement("prize_type")]
	        public string PrizeType { get; set; }
	
	        /// <summary>
	        /// 0～1之间，代表奖池的概率
	        /// </summary>
	        [XmlElement("probability")]
	        public string Probability { get; set; }
	
	        /// <summary>
	        /// 商家创建的isv活动的开始时间
	        /// </summary>
	        [XmlElement("start_time")]
	        public Nullable<DateTime> StartTime { get; set; }
	
	        /// <summary>
	        /// 用户活动期间总共中奖次数限制
	        /// </summary>
	        [XmlElement("win_permission_activity_count")]
	        public Nullable<long> WinPermissionActivityCount { get; set; }
	
	        /// <summary>
	        /// 用户每天总共中奖次数限制
	        /// </summary>
	        [XmlElement("win_permission_day_count")]
	        public Nullable<long> WinPermissionDayCount { get; set; }
}

        #endregion
    }
}
