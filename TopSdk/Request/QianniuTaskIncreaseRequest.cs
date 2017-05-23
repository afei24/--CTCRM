using System;
using System.Collections.Generic;
using Top.Api.Util;

namespace Top.Api.Request
{
    /// <summary>
    /// TOP API: taobao.qianniu.task.increase
    /// </summary>
    public class QianniuTaskIncreaseRequest : BaseTopRequest<Top.Api.Response.QianniuTaskIncreaseResponse>
    {
        /// <summary>
        /// 任务元id
        /// </summary>
        public Nullable<long> MetadataId { get; set; }

        /// <summary>
        /// 任务列表，JSON格式，例如： tasks =[{ "receiver_uid" : 123, "receiver_nick" : "nick"}, { "receiver_uid" : 456, "receiver_nick" : "nick2"} ]
        /// </summary>
        public string Tasks { get; set; }

        #region ITopRequest Members

        public override string GetApiName()
        {
            return "taobao.qianniu.task.increase";
        }

        public override IDictionary<string, string> GetParameters()
        {
            TopDictionary parameters = new TopDictionary();
            parameters.Add("metadata_id", this.MetadataId);
            parameters.Add("tasks", this.Tasks);
            if (this.otherParams != null)
            {
                parameters.AddAll(this.otherParams);
            }
            return parameters;
        }

        public override void Validate()
        {
            RequestValidator.ValidateRequired("metadata_id", this.MetadataId);
            RequestValidator.ValidateRequired("tasks", this.Tasks);
        }

        #endregion
    }
}
