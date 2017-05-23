using System;
using System.Collections.Generic;
using Top.Api.Util;

namespace Top.Api.Request
{
    /// <summary>
    /// TOP API: taobao.mixnick.change
    /// </summary>
    public class MixnickChangeRequest : BaseTopRequest<Top.Api.Response.MixnickChangeResponse>
    {
        /// <summary>
        /// 输入的appkey
        /// </summary>
        public string SrcAppkey { get; set; }

        /// <summary>
        /// 输入的混淆nick
        /// </summary>
        public string SrcMixNick { get; set; }

        #region ITopRequest Members

        public override string GetApiName()
        {
            return "taobao.mixnick.change";
        }

        public override IDictionary<string, string> GetParameters()
        {
            TopDictionary parameters = new TopDictionary();
            parameters.Add("src_appkey", this.SrcAppkey);
            parameters.Add("src_mix_nick", this.SrcMixNick);
            if (this.otherParams != null)
            {
                parameters.AddAll(this.otherParams);
            }
            return parameters;
        }

        public override void Validate()
        {
            RequestValidator.ValidateRequired("src_appkey", this.SrcAppkey);
            RequestValidator.ValidateRequired("src_mix_nick", this.SrcMixNick);
        }

        #endregion
    }
}
