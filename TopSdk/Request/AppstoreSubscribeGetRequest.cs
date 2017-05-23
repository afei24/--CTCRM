using System;
using System.Collections.Generic;
using Top.Api.Util;

namespace Top.Api.Request
{
    /// <summary>
    /// TOP API: taobao.appstore.subscribe.get
    /// </summary>
    public class AppstoreSubscribeGetRequest : BaseTopRequest<Top.Api.Response.AppstoreSubscribeGetResponse>
    {
        /// <summary>
        /// 插件实例ID
        /// </summary>
        public Nullable<long> LeaseId { get; set; }

        /// <summary>
        /// 用户昵称
        /// </summary>
        public string Nick { get; set; }

        #region ITopRequest Members

        public override string GetApiName()
        {
            return "taobao.appstore.subscribe.get";
        }

        public override IDictionary<string, string> GetParameters()
        {
            TopDictionary parameters = new TopDictionary();
            parameters.Add("lease_id", this.LeaseId);
            parameters.Add("nick", this.Nick);
            if (this.otherParams != null)
            {
                parameters.AddAll(this.otherParams);
            }
            return parameters;
        }

        public override void Validate()
        {
            RequestValidator.ValidateRequired("nick", this.Nick);
        }

        #endregion
    }
}
