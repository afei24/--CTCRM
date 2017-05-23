using System;
using System.Collections.Generic;
using Top.Api.Util;

namespace Top.Api.Request
{
    /// <summary>
    /// TOP API: taobao.ecloud.top.sysfile.list
    /// </summary>
    public class EcloudTopSysfileListRequest : BaseTopRequest<Top.Api.Response.EcloudTopSysfileListResponse>
    {
        /// <summary>
        /// 客户端id
        /// </summary>
        public string ClientId { get; set; }

        /// <summary>
        /// ALL(0),   IMG(1),   DOC(2),   TXT(3),   MUSIC(4),   VIDEO(5),   ZIP(6);
        /// </summary>
        public Nullable<long> FileType { get; set; }

        /// <summary>
        /// 存储在系统空间制定目录名
        /// </summary>
        public string KeyName { get; set; }

        /// <summary>
        /// 每次返回记录记录数0~200
        /// </summary>
        public Nullable<long> Length { get; set; }

        /// <summary>
        /// 当前索引位置，首次请求为0
        /// </summary>
        public Nullable<long> Offset { get; set; }

        /// <summary>
        /// 用户site
        /// </summary>
        public Nullable<long> Site { get; set; }

        /// <summary>
        /// 0：按照更新时间升序 ，1：按照更新时间降序,   2：按照文件类型升序,  3：按照文件类型降序,   4：按照文件名升序,  5：按照文件名降序,   6：按照文件大小升序,  7：按照文件大小降序
        /// </summary>
        public Nullable<long> SortType { get; set; }

        #region ITopRequest Members

        public override string GetApiName()
        {
            return "taobao.ecloud.top.sysfile.list";
        }

        public override IDictionary<string, string> GetParameters()
        {
            TopDictionary parameters = new TopDictionary();
            parameters.Add("client_id", this.ClientId);
            parameters.Add("file_type", this.FileType);
            parameters.Add("key_name", this.KeyName);
            parameters.Add("length", this.Length);
            parameters.Add("offset", this.Offset);
            parameters.Add("site", this.Site);
            parameters.Add("sort_type", this.SortType);
            if (this.otherParams != null)
            {
                parameters.AddAll(this.otherParams);
            }
            return parameters;
        }

        public override void Validate()
        {
            RequestValidator.ValidateRequired("client_id", this.ClientId);
            RequestValidator.ValidateRequired("key_name", this.KeyName);
        }

        #endregion
    }
}
