using System;
using System.Collections.Generic;
using Top.Api.Util;

namespace Top.Api.Request
{
    /// <summary>
    /// TOP API: taobao.jindoucloud.message.send
    /// </summary>
    public class JindoucloudMessageSendRequest : BaseTopRequest<Top.Api.Response.JindoucloudMessageSendResponse>
    {
        /// <summary>
        /// 发送的消息。参数说明： <div>nick：接收者，支持子账号 ，必填 <div>title：展示的标题，必填 <div>biz_id：业务id，同一个业务可以变化多次，即有多个状态的迁移。比如：交易消息的状态迁移。可选 <div>send_no：发送的消息编号，服务端会用appkey+user+send_no对消息做重复发送的控制，必填。 <div>msg_category：分配给isv的允许发送的一级类目。必填 <div>msg_type：分配给isv的允许发送的一级类目下的二级类目，必填。 <div>view_data：json数据，在客户端展示的数据，最多5个。可选。 <div>biz_data：消息跳转到插件，插件需要处理这条消息需要的参数，可选。
        /// </summary>
        public string Messages { get; set; }

        #region ITopRequest Members

        public override string GetApiName()
        {
            return "taobao.jindoucloud.message.send";
        }

        public override IDictionary<string, string> GetParameters()
        {
            TopDictionary parameters = new TopDictionary();
            parameters.Add("messages", this.Messages);
            if (this.otherParams != null)
            {
                parameters.AddAll(this.otherParams);
            }
            return parameters;
        }

        public override void Validate()
        {
            RequestValidator.ValidateRequired("messages", this.Messages);
        }

        #endregion
    }
}
