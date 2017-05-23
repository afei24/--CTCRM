using System;
using System.Collections.Generic;
using Top.Api.Util;

namespace Top.Api.Request
{
    /// <summary>
    /// TOP API: alibaba.interact.activity.unregister
    /// </summary>
    public class AlibabaInteractActivityUnregisterRequest : BaseTopRequest<Top.Api.Response.AlibabaInteractActivityUnregisterResponse>
    {
        /// <summary>
        /// 互动活动ID
        /// </summary>
        public string BizId { get; set; }

        #region ITopRequest Members

        public override string GetApiName()
        {
            return "alibaba.interact.activity.unregister";
        }

        public override IDictionary<string, string> GetParameters()
        {
            TopDictionary parameters = new TopDictionary();
            parameters.Add("biz_id", this.BizId);
            if (this.otherParams != null)
            {
                parameters.AddAll(this.otherParams);
            }
            return parameters;
        }

        public override void Validate()
        {
            RequestValidator.ValidateRequired("biz_id", this.BizId);
        }

        #endregion
    }
}
