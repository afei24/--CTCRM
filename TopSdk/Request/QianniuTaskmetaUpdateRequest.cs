using System;
using System.Collections.Generic;
using Top.Api.Util;

namespace Top.Api.Request
{
    /// <summary>
    /// TOP API: taobao.qianniu.taskmeta.update
    /// </summary>
    public class QianniuTaskmetaUpdateRequest : BaseTopRequest<Top.Api.Response.QianniuTaskmetaUpdateResponse>
    {
        /// <summary>
        /// 要更新的任务元数据，JSON格式，例如：  meta= {    "id" : 1,    "title" : "xxx",    "content" : "yyyy",    "biz_sys_Id" : 12232,    "biz_sys_task_type" : 1212,    "start_time" : 1380173565480,    "end_time" : 1380173565480,   "sender_uid" : 213123213,    "sender_nick" : "tbtest1063",    "reminder_flag" : 1,    "finish_strategy" : 1   }
        /// </summary>
        public string Meta { get; set; }

        #region ITopRequest Members

        public override string GetApiName()
        {
            return "taobao.qianniu.taskmeta.update";
        }

        public override IDictionary<string, string> GetParameters()
        {
            TopDictionary parameters = new TopDictionary();
            parameters.Add("meta", this.Meta);
            if (this.otherParams != null)
            {
                parameters.AddAll(this.otherParams);
            }
            return parameters;
        }

        public override void Validate()
        {
            RequestValidator.ValidateRequired("meta", this.Meta);
        }

        #endregion
    }
}
