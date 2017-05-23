using System;
using System.Collections.Generic;
using Top.Api.Util;

namespace Top.Api.Request
{
    /// <summary>
    /// TOP API: taobao.jindoucloud.messagecount.get
    /// </summary>
    public class JindoucloudMessagecountGetRequest : BaseTopRequest<Top.Api.Response.JindoucloudMessagecountGetResponse>
    {
        /// <summary>
        /// 客户端的版本信息
        /// </summary>
        public string ClientInfo { get; set; }

        /// <summary>
        /// 需要的字段
        /// </summary>
        public string Fields { get; set; }

        /// <summary>
        /// 是否需要详细的数字和最后一条消息
        /// </summary>
        public Nullable<bool> NeedDetail { get; set; }

        /// <summary>
        /// 查询的计数器的类型，比如：item，表示商品类型，可以传递多个类型，多个类型之间用英文逗号分隔
        /// </summary>
        public string Topic { get; set; }

        /// <summary>
        /// 用于区分是要获取服务号的未读数还是系统消息的未读数。4表示系统消息，5表示服务号
        /// </summary>
        public Nullable<long> Type { get; set; }

        /// <summary>
        /// 如果是子账号，则用:拼接，第一位是主账号，第二位是子账号，如果是主账号，则没有:
        /// </summary>
        public string UserIds { get; set; }

        #region ITopRequest Members

        public override string GetApiName()
        {
            return "taobao.jindoucloud.messagecount.get";
        }

        public override IDictionary<string, string> GetParameters()
        {
            TopDictionary parameters = new TopDictionary();
            parameters.Add("client_info", this.ClientInfo);
            parameters.Add("fields", this.Fields);
            parameters.Add("need_detail", this.NeedDetail);
            parameters.Add("topic", this.Topic);
            parameters.Add("type", this.Type);
            parameters.Add("user_ids", this.UserIds);
            if (this.otherParams != null)
            {
                parameters.AddAll(this.otherParams);
            }
            return parameters;
        }

        public override void Validate()
        {
            RequestValidator.ValidateRequired("fields", this.Fields);
        }

        #endregion
    }
}
