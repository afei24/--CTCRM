using System;
using System.Collections.Generic;
using Top.Api.Util;

namespace Top.Api.Request
{
    /// <summary>
    /// TOP API: taobao.mixnick.wetoplay
    /// </summary>
    public class MixnickWetoplayRequest : BaseTopRequest<Top.Api.Response.MixnickWetoplayResponse>
    {
        /// <summary>
        /// 排查问题id
        /// </summary>
        public string TraceId { get; set; }

        /// <summary>
        /// 微淘混淆nick
        /// </summary>
        public string WeMixnick { get; set; }

        #region ITopRequest Members

        public override string GetApiName()
        {
            return "taobao.mixnick.wetoplay";
        }

        public override IDictionary<string, string> GetParameters()
        {
            TopDictionary parameters = new TopDictionary();
            parameters.Add("trace_id", this.TraceId);
            parameters.Add("we_mixnick", this.WeMixnick);
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
