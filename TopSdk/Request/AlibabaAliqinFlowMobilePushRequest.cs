using System;
using System.Collections.Generic;
using Top.Api.Response;
using Top.Api.Util;

namespace Top.Api.Request
{
    /// <summary>
    /// TOP API: alibaba.aliqin.flow.mobile.push
    /// </summary>
    public class AlibabaAliqinFlowMobilePushRequest : BaseTopRequest<AlibabaAliqinFlowMobilePushResponse>
    {
        /// <summary>
        /// 是否重试
        /// </summary>
        public string Always { get; set; }

        /// <summary>
        /// 流量
        /// </summary>
        public string Flow { get; set; }

        /// <summary>
        /// 手机号
        /// </summary>
        public string Mobile { get; set; }

        /// <summary>
        /// 原因
        /// </summary>
        public string Reason { get; set; }

        /// <summary>
        /// 流水号
        /// </summary>
        public string Serial { get; set; }

        #region ITopRequest Members

        public override string GetApiName()
        {
            return "alibaba.aliqin.flow.mobile.push";
        }

        public override IDictionary<string, string> GetParameters()
        {
            TopDictionary parameters = new TopDictionary();
            parameters.Add("always", this.Always);
            parameters.Add("flow", this.Flow);
            parameters.Add("mobile", this.Mobile);
            parameters.Add("reason", this.Reason);
            parameters.Add("serial", this.Serial);
            if (this.otherParams != null)
            {
                parameters.AddAll(this.otherParams);
            }
            return parameters;
        }

        public override void Validate()
        {
            RequestValidator.ValidateRequired("always", this.Always);
            RequestValidator.ValidateRequired("flow", this.Flow);
            RequestValidator.ValidateRequired("mobile", this.Mobile);
            RequestValidator.ValidateRequired("reason", this.Reason);
        }

        #endregion
    }
}
