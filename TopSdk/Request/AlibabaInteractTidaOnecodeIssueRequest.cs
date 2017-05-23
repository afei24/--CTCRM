using System;
using System.Collections.Generic;
using Top.Api.Util;

namespace Top.Api.Request
{
    /// <summary>
    /// TOP API: alibaba.interact.tida.onecode.issue
    /// </summary>
    public class AlibabaInteractTidaOnecodeIssueRequest : BaseTopRequest<Top.Api.Response.AlibabaInteractTidaOnecodeIssueResponse>
    {
        /// <summary>
        /// 支持onecode的接口，令牌对应接口
        /// </summary>
        public string Api { get; set; }

        /// <summary>
        /// 透传参数
        /// </summary>
        public string BizExtString { get; set; }

        /// <summary>
        /// 手淘登陆用户混淆nick
        /// </summary>
        public string MixUserNick { get; set; }

        /// <summary>
        /// 安全过滤结果，是否安全。
        /// </summary>
        public string Safety { get; set; }

        /// <summary>
        /// 支持onecode的接口单次调用令牌
        /// </summary>
        public string Ticket { get; set; }

        /// <summary>
        /// 唯一。单次请求调试信息，可作为请求记录ID
        /// </summary>
        public string TraceId { get; set; }

        #region ITopRequest Members

        public override string GetApiName()
        {
            return "alibaba.interact.tida.onecode.issue";
        }

        public override IDictionary<string, string> GetParameters()
        {
            TopDictionary parameters = new TopDictionary();
            parameters.Add("api", this.Api);
            parameters.Add("biz_ext_string", this.BizExtString);
            parameters.Add("mix_user_nick", this.MixUserNick);
            parameters.Add("safety", this.Safety);
            parameters.Add("ticket", this.Ticket);
            parameters.Add("trace_id", this.TraceId);
            if (this.otherParams != null)
            {
                parameters.AddAll(this.otherParams);
            }
            return parameters;
        }

        public override void Validate()
        {
            RequestValidator.ValidateRequired("api", this.Api);
            RequestValidator.ValidateRequired("mix_user_nick", this.MixUserNick);
            RequestValidator.ValidateRequired("ticket", this.Ticket);
            RequestValidator.ValidateRequired("trace_id", this.TraceId);
        }

        #endregion
    }
}
