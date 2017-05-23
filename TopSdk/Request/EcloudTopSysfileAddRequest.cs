using System;
using System.Collections.Generic;
using Top.Api.Util;

namespace Top.Api.Request
{
    /// <summary>
    /// TOP API: taobao.ecloud.top.sysfile.add
    /// </summary>
    public class EcloudTopSysfileAddRequest : BaseTopRequest<Top.Api.Response.EcloudTopSysfileAddResponse>
    {
        /// <summary>
        /// 客户端id
        /// </summary>
        public string ClientId { get; set; }

        /// <summary>
        /// 被添加文件信息，json格式 [{"fileId":1234,"spaceId":4567},{"fileId":478763,"spaceId":16002}]
        /// </summary>
        public string FileInfos { get; set; }

        /// <summary>
        /// 存储在系统空间制定目录名
        /// </summary>
        public string KeyName { get; set; }

        /// <summary>
        /// 若已经存在同名同类型文件，TRUE:文件增量文件版本，目录资源返回当前目录；FLASE：返回同名异常
        /// </summary>
        public Nullable<bool> Overwrite { get; set; }

        /// <summary>
        /// 用户site
        /// </summary>
        public Nullable<long> Site { get; set; }

        #region ITopRequest Members

        public override string GetApiName()
        {
            return "taobao.ecloud.top.sysfile.add";
        }

        public override IDictionary<string, string> GetParameters()
        {
            TopDictionary parameters = new TopDictionary();
            parameters.Add("client_id", this.ClientId);
            parameters.Add("file_infos", this.FileInfos);
            parameters.Add("key_name", this.KeyName);
            parameters.Add("overwrite", this.Overwrite);
            parameters.Add("site", this.Site);
            if (this.otherParams != null)
            {
                parameters.AddAll(this.otherParams);
            }
            return parameters;
        }

        public override void Validate()
        {
            RequestValidator.ValidateRequired("client_id", this.ClientId);
            RequestValidator.ValidateRequired("file_infos", this.FileInfos);
            RequestValidator.ValidateRequired("key_name", this.KeyName);
        }

        #endregion
    }
}
