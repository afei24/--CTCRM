using System;
using System.Collections.Generic;
using Top.Api.Util;

namespace Top.Api.Request
{
    /// <summary>
    /// TOP API: taobao.ecloud.top.file.getdownloadurl
    /// </summary>
    public class EcloudTopFileGetdownloadurlRequest : BaseTopRequest<Top.Api.Response.EcloudTopFileGetdownloadurlResponse>
    {
        /// <summary>
        /// 系统自动生成
        /// </summary>
        public string ClientId { get; set; }

        /// <summary>
        /// 系统自动生成
        /// </summary>
        public string FileIds { get; set; }

        /// <summary>
        /// 系统自动生成
        /// </summary>
        public string PackageName { get; set; }

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
            return "taobao.ecloud.top.file.getdownloadurl";
        }

        public override IDictionary<string, string> GetParameters()
        {
            TopDictionary parameters = new TopDictionary();
            parameters.Add("client_id", this.ClientId);
            parameters.Add("file_ids", this.FileIds);
            parameters.Add("package_name", this.PackageName);
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
            RequestValidator.ValidateRequired("file_ids", this.FileIds);
            RequestValidator.ValidateRequired("space_id", this.SpaceId);
        }

        #endregion
    }
}
