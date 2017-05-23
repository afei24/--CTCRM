using System;
using System.Collections.Generic;
using Top.Api.Util;

namespace Top.Api.Request
{
    /// <summary>
    /// TOP API: taobao.tmc.msg.sendrecord
    /// </summary>
    public class TmcMsgSendrecordRequest : BaseTopRequest<Top.Api.Response.TmcMsgSendrecordResponse>
    {
        /// <summary>
        /// 消息主键ID
        /// </summary>
        public string DataId { get; set; }

        /// <summary>
        /// 消息分组名
        /// </summary>
        public string GroupName { get; set; }

        /// <summary>
        /// TOPIC名称
        /// </summary>
        public string TopicName { get; set; }

        #region ITopRequest Members

        public override string GetApiName()
        {
            return "taobao.tmc.msg.sendrecord";
        }

        public override IDictionary<string, string> GetParameters()
        {
            TopDictionary parameters = new TopDictionary();
            parameters.Add("data_id", this.DataId);
            parameters.Add("group_name", this.GroupName);
            parameters.Add("topic_name", this.TopicName);
            if (this.otherParams != null)
            {
                parameters.AddAll(this.otherParams);
            }
            return parameters;
        }

        public override void Validate()
        {
            RequestValidator.ValidateRequired("data_id", this.DataId);
            RequestValidator.ValidateRequired("group_name", this.GroupName);
            RequestValidator.ValidateRequired("topic_name", this.TopicName);
        }

        #endregion
    }
}
