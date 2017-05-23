using System;
using System.Collections.Generic;
using Top.Api.Util;

namespace Top.Api.Request
{
    /// <summary>
    /// TOP API: alibaba.interact.activity.apply
    /// </summary>
    public class AlibabaInteractActivityApplyRequest : BaseTopRequest<Top.Api.Response.AlibabaInteractActivityApplyResponse>
    {
        /// <summary>
        /// 报名参加中心化流量活动的活动id
        /// </summary>
        public string ActivityBizId { get; set; }

        /// <summary>
        /// 报名参加的中心化流量活动的banner 地址
        /// </summary>
        public string BannerUrl { get; set; }

        /// <summary>
        /// 权益总额
        /// </summary>
        public string BenefitAmount { get; set; }

        /// <summary>
        /// 权益属性(如红包，则为relationid)
        /// </summary>
        public string BenefitAttribute { get; set; }

        /// <summary>
        /// 权益对应的面额
        /// </summary>
        public string BenefitDenomination { get; set; }

        /// <summary>
        /// 活动发放的权益类型，1:支付宝红包2:流量包3:淘金币4:集分宝5:优惠卷
        /// </summary>
        public string BenefitType { get; set; }

        /// <summary>
        /// 该活动参与的中心化流量活动。1:代表每日赢宝箱2:微淘广场
        /// </summary>
        public string BizType { get; set; }

        #region ITopRequest Members

        public override string GetApiName()
        {
            return "alibaba.interact.activity.apply";
        }

        public override IDictionary<string, string> GetParameters()
        {
            TopDictionary parameters = new TopDictionary();
            parameters.Add("activity_biz_id", this.ActivityBizId);
            parameters.Add("banner_url", this.BannerUrl);
            parameters.Add("benefit_amount", this.BenefitAmount);
            parameters.Add("benefit_attribute", this.BenefitAttribute);
            parameters.Add("benefit_denomination", this.BenefitDenomination);
            parameters.Add("benefit_type", this.BenefitType);
            parameters.Add("biz_type", this.BizType);
            if (this.otherParams != null)
            {
                parameters.AddAll(this.otherParams);
            }
            return parameters;
        }

        public override void Validate()
        {
            RequestValidator.ValidateRequired("activity_biz_id", this.ActivityBizId);
            RequestValidator.ValidateRequired("banner_url", this.BannerUrl);
            RequestValidator.ValidateRequired("benefit_attribute", this.BenefitAttribute);
            RequestValidator.ValidateRequired("benefit_type", this.BenefitType);
            RequestValidator.ValidateRequired("biz_type", this.BizType);
        }

        #endregion
    }
}
