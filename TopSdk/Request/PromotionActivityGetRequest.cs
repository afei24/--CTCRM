using System;
using System.Collections.Generic;
using Top.Api.Util;

namespace Top.Api.Request
{
    /// <summary>
    /// TOP API: taobao.promotion.activity.get
    /// </summary>
    public class PromotionActivityGetRequest : BaseTopRequest<Top.Api.Response.PromotionActivityGetResponse>
    {
        /// <summary>
        /// 活动的id
        /// </summary>
        public Nullable<long> ActivityId { get; set; }

        #region ITopRequest Members

        public override string GetApiName()
        {
            return "taobao.promotion.activity.get";
        }

        public override IDictionary<string, string> GetParameters()
        {
            TopDictionary parameters = new TopDictionary();
            parameters.Add("activity_id", this.ActivityId);
            if (this.otherParams != null)
            {
                parameters.AddAll(this.otherParams);
            }
            return parameters;
        }

        public override void Validate()
        {
        }

        #endregion
    }
}
