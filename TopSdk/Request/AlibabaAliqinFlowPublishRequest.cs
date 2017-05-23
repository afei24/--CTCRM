using System;
using System.Collections.Generic;
using Top.Api.Util;

namespace Top.Api.Request
{
    /// <summary>
    /// TOP API: alibaba.aliqin.flow.publish
    /// </summary>
    public class AlibabaAliqinFlowPublishRequest : BaseTopRequest<Top.Api.Response.AlibabaAliqinFlowPublishResponse>
    {
        /// <summary>
        /// 设置true为始终发送成功
        /// </summary>
        public string Always { get; set; }

        /// <summary>
        /// 流量
        /// </summary>
        public string Flow { get; set; }

        /// <summary>
        /// 原因
        /// </summary>
        public string Reason { get; set; }

        /// <summary>
        /// 唯一流水号（字母+数字）
        /// </summary>
        public string Serial { get; set; }

        /// <summary>
        /// 用户id
        /// </summary>
        public string UserId { get; set; }

        #region ITopRequest Members

        public override string GetApiName()
        {
            return "alibaba.aliqin.flow.publish";
        }

        public override IDictionary<string, string> GetParameters()
        {
            TopDictionary parameters = new TopDictionary();
            parameters.Add("always", this.Always);
            parameters.Add("flow", this.Flow);
            parameters.Add("reason", this.Reason);
            parameters.Add("serial", this.Serial);
            parameters.Add("user_id", this.UserId);
            if (this.otherParams != null)
            {
                parameters.AddAll(this.otherParams);
            }
            return parameters;
        }

        public override void Validate()
        {
            RequestValidator.ValidateRequired("flow", this.Flow);
            RequestValidator.ValidateRequired("reason", this.Reason);
            RequestValidator.ValidateRequired("serial", this.Serial);
            RequestValidator.ValidateRequired("user_id", this.UserId);
        }

        #endregion
    }
}
