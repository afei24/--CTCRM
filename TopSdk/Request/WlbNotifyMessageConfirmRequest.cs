using System;
using System.Collections.Generic;
using Top.Api.Util;

namespace Top.Api.Request
{
    /// <summary>
    /// TOP API: taobao.wlb.notify.message.confirm
    /// </summary>
    public class WlbNotifyMessageConfirmRequest : BaseTopRequest<Top.Api.Response.WlbNotifyMessageConfirmResponse>
    {
        /// <summary>
        /// 物流宝通知消息的id，通过taobao.wlb.notify.message.page.get接口得到的WlbMessage数据结构中的id字段
        /// </summary>
        public string MessageId { get; set; }

        #region ITopRequest Members

        public override string GetApiName()
        {
            return "taobao.wlb.notify.message.confirm";
        }

        public override IDictionary<string, string> GetParameters()
        {
            TopDictionary parameters = new TopDictionary();
            parameters.Add("message_id", this.MessageId);
            if (this.otherParams != null)
            {
                parameters.AddAll(this.otherParams);
            }
            return parameters;
        }

        public override void Validate()
        {
            RequestValidator.ValidateRequired("message_id", this.MessageId);
        }

        #endregion
    }
}
