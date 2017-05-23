using System;
using System.Collections.Generic;
using Top.Api.Util;

namespace Top.Api.Request
{
    /// <summary>
    /// TOP API: taobao.marketing.promotion.kfc
    /// </summary>
    public class MarketingPromotionKfcRequest : BaseTopRequest<Top.Api.Response.MarketingPromotionKfcResponse>
    {
        /// <summary>
        /// 活动描述
        /// </summary>
        public string PromotionDesc { get; set; }

        /// <summary>
        /// 活动名称
        /// </summary>
        public string PromotionTitle { get; set; }

        #region ITopRequest Members

        public override string GetApiName()
        {
            return "taobao.marketing.promotion.kfc";
        }

        public override IDictionary<string, string> GetParameters()
        {
            TopDictionary parameters = new TopDictionary();
            parameters.Add("promotion_desc", this.PromotionDesc);
            parameters.Add("promotion_title", this.PromotionTitle);
            if (this.otherParams != null)
            {
                parameters.AddAll(this.otherParams);
            }
            return parameters;
        }

        public override void Validate()
        {
            RequestValidator.ValidateRequired("promotion_desc", this.PromotionDesc);
            RequestValidator.ValidateRequired("promotion_title", this.PromotionTitle);
        }

        #endregion
    }
}
