using System;
using System.Collections.Generic;
using Top.Api.Util;

namespace Top.Api.Request
{
    /// <summary>
    /// TOP API: taobao.tpn.authorize.query
    /// </summary>
    public class TpnAuthorizeQueryRequest : BaseTopRequest<Top.Api.Response.TpnAuthorizeQueryResponse>
    {
        /// <summary>
        /// 传递客户端的信息
        /// </summary>
        public string ClientInfo { get; set; }

        /// <summary>
        /// 用户子账号userId，如果是主账号，则为0
        /// </summary>
        public Nullable<long> SubUserId { get; set; }

        /// <summary>
        /// 账号的名称，如trade、item、qianniu等  多个账号以逗号分割
        /// </summary>
        public string Topics { get; set; }

        /// <summary>
        /// 用户主账号userId
        /// </summary>
        public Nullable<long> UserId { get; set; }

        /// <summary>
        /// 客户端使用的版本号
        /// </summary>
        public Nullable<long> Version { get; set; }

        #region ITopRequest Members

        public override string GetApiName()
        {
            return "taobao.tpn.authorize.query";
        }

        public override IDictionary<string, string> GetParameters()
        {
            TopDictionary parameters = new TopDictionary();
            parameters.Add("client_info", this.ClientInfo);
            parameters.Add("sub_user_id", this.SubUserId);
            parameters.Add("topics", this.Topics);
            parameters.Add("user_id", this.UserId);
            parameters.Add("version", this.Version);
            if (this.otherParams != null)
            {
                parameters.AddAll(this.otherParams);
            }
            return parameters;
        }

        public override void Validate()
        {
            RequestValidator.ValidateRequired("sub_user_id", this.SubUserId);
            RequestValidator.ValidateRequired("topics", this.Topics);
            RequestValidator.ValidateRequired("user_id", this.UserId);
        }

        #endregion
    }
}
