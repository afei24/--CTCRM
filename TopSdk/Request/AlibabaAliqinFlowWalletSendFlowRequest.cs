using System;
using System.Collections.Generic;
using Top.Api.Util;

namespace Top.Api.Request
{
    /// <summary>
    /// TOP API: alibaba.aliqin.flow.wallet.send.flow
    /// </summary>
    public class AlibabaAliqinFlowWalletSendFlowRequest : BaseTopRequest<Top.Api.Response.AlibabaAliqinFlowWalletSendFlowResponse>
    {
        /// <summary>
        /// 设置true为始终发送成功
        /// </summary>
        public string Always { get; set; }

        /// <summary>
        /// 混淆用户名
        /// </summary>
        public string BuyerNick { get; set; }

        /// <summary>
        /// 流量
        /// </summary>
        public string Flow { get; set; }

        /// <summary>
        /// 真实用户名称，如果填写这个字段，buyer_nick失效
        /// </summary>
        public string RealNick { get; set; }

        /// <summary>
        /// 购物送
        /// </summary>
        public string Reason { get; set; }

        /// <summary>
        /// 唯一流水号，字母+数字组合
        /// </summary>
        public string Serial { get; set; }

        #region ITopRequest Members

        public override string GetApiName()
        {
            return "alibaba.aliqin.flow.wallet.send.flow";
        }

        public override IDictionary<string, string> GetParameters()
        {
            TopDictionary parameters = new TopDictionary();
            parameters.Add("always", this.Always);
            parameters.Add("buyer_nick", this.BuyerNick);
            parameters.Add("flow", this.Flow);
            parameters.Add("real_nick", this.RealNick);
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
            RequestValidator.ValidateRequired("flow", this.Flow);
            RequestValidator.ValidateRequired("reason", this.Reason);
            RequestValidator.ValidateRequired("serial", this.Serial);
        }

        #endregion
    }
}
