using System;
using System.Collections.Generic;
using Top.Api.Util;

namespace Top.Api.Request
{
    /// <summary>
    /// TOP API: taobao.ecloud.top.file.get
    /// </summary>
    public class EcloudTopFileGetRequest : BaseTopRequest<Top.Api.Response.EcloudTopFileGetResponse>
    {
        /// <summary>
        /// 系统自动生成
        /// </summary>
        public string ClientId { get; set; }

        /// <summary>
        /// 系统自动生成
        /// </summary>
        public Nullable<long> FileId { get; set; }

        /// <summary>
        /// 系统自动生成
        /// </summary>
        public string Path { get; set; }

        /// <summary>
        /// 系统自动生成
        /// </summary>
        public Nullable<long> Site { get; set; }

        /// <summary>
        /// 系统自动生成
        /// </summary>
        public Nullable<long> SpaceId { get; set; }

        #region ITopRequest Members

        public override string GetApiName()
        {
            return "taobao.ecloud.top.file.get";
        }

        public override IDictionary<string, string> GetParameters()
        {
            TopDictionary parameters = new TopDictionary();
            parameters.Add("client_id", this.ClientId);
            parameters.Add("file_id", this.FileId);
            parameters.Add("path", this.Path);
            parameters.Add("site", this.Site);
            parameters.Add("space_id", this.SpaceId);
            if (this.otherParams != null)
            {
                parameters.AddAll(this.otherParams);
            }
            return parameters;
        }

        public override void Validate()
        {
            RequestValidator.ValidateRequired("client_id", this.ClientId);
        }

        #endregion
    }
}
