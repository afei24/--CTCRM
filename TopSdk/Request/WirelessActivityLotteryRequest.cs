using System;
using System.Collections.Generic;
using Top.Api.Util;

namespace Top.Api.Request
{
    /// <summary>
    /// TOP API: taobao.wireless.activity.lottery
    /// </summary>
    public class WirelessActivityLotteryRequest : BaseTopRequest<Top.Api.Response.WirelessActivityLotteryResponse>
    {
        /// <summary>
        /// 活动参数
        /// </summary>
        public string BizParam { get; set; }

        /// <summary>
        /// 活动类型
        /// </summary>
        public string BizType { get; set; }

        /// <summary>
        /// ua
        /// </summary>
        public string Ua { get; set; }

        /// <summary>
        /// umid
        /// </summary>
        public string Umid { get; set; }

        #region ITopRequest Members

        public override string GetApiName()
        {
            return "taobao.wireless.activity.lottery";
        }

        public override IDictionary<string, string> GetParameters()
        {
            TopDictionary parameters = new TopDictionary();
            parameters.Add("biz_param", this.BizParam);
            parameters.Add("biz_type", this.BizType);
            parameters.Add("ua", this.Ua);
            parameters.Add("umid", this.Umid);
            if (this.otherParams != null)
            {
                parameters.AddAll(this.otherParams);
            }
            return parameters;
        }

        public override void Validate()
        {
            RequestValidator.ValidateRequired("biz_type", this.BizType);
        }

        #endregion
    }
}
