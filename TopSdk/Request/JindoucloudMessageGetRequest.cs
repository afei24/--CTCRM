using System;
using System.Collections.Generic;
using Top.Api.Util;

namespace Top.Api.Request
{
    /// <summary>
    /// TOP API: taobao.jindoucloud.message.get
    /// </summary>
    public class JindoucloudMessageGetRequest : BaseTopRequest<Top.Api.Response.JindoucloudMessageGetResponse>
    {
        /// <summary>
        /// 传递客户端的信息
        /// </summary>
        public string ClientInfo { get; set; }

        /// <summary>
        /// 结束时间
        /// </summary>
        public Nullable<DateTime> EndModified { get; set; }

        /// <summary>
        /// 一次性获取多少条数据
        /// </summary>
        public Nullable<long> Number { get; set; }

        /// <summary>
        /// 取消息的开始时间，如果不传的话默认是调用api时的系统当前时间。
        /// </summary>
        public Nullable<DateTime> StartModified { get; set; }

        /// <summary>
        /// 消息的类型，比如：商品类型为item
        /// </summary>
        public string Topic { get; set; }

        /// <summary>
        /// 客户端使用的版本号
        /// </summary>
        public Nullable<long> Version { get; set; }

        #region ITopRequest Members

        public override string GetApiName()
        {
            return "taobao.jindoucloud.message.get";
        }

        public override IDictionary<string, string> GetParameters()
        {
            TopDictionary parameters = new TopDictionary();
            parameters.Add("client_info", this.ClientInfo);
            parameters.Add("end_modified", this.EndModified);
            parameters.Add("number", this.Number);
            parameters.Add("start_modified", this.StartModified);
            parameters.Add("topic", this.Topic);
            parameters.Add("version", this.Version);
            if (this.otherParams != null)
            {
                parameters.AddAll(this.otherParams);
            }
            return parameters;
        }

        public override void Validate()
        {
            RequestValidator.ValidateRequired("topic", this.Topic);
        }

        #endregion
    }
}
