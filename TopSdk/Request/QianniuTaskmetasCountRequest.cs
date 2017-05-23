using System;
using System.Collections.Generic;
using Top.Api.Util;

namespace Top.Api.Request
{
    /// <summary>
    /// TOP API: taobao.qianniu.taskmetas.count
    /// </summary>
    public class QianniuTaskmetasCountRequest : BaseTopRequest<Top.Api.Response.QianniuTaskmetasCountResponse>
    {
        /// <summary>
        /// 业务类型
        /// </summary>
        public string BizType { get; set; }

        /// <summary>
        /// 关键词搜索。只对任务内容进行模糊匹配
        /// </summary>
        public string KeyWord { get; set; }

        /// <summary>
        /// 发起任务人的uid
        /// </summary>
        public Nullable<long> SenderUid { get; set; }

        /// <summary>
        /// 0未完成，2完成，4取消。不填为所有
        /// </summary>
        public Nullable<long> Status { get; set; }

        #region ITopRequest Members

        public override string GetApiName()
        {
            return "taobao.qianniu.taskmetas.count";
        }

        public override IDictionary<string, string> GetParameters()
        {
            TopDictionary parameters = new TopDictionary();
            parameters.Add("biz_type", this.BizType);
            parameters.Add("key_word", this.KeyWord);
            parameters.Add("sender_uid", this.SenderUid);
            parameters.Add("status", this.Status);
            if (this.otherParams != null)
            {
                parameters.AddAll(this.otherParams);
            }
            return parameters;
        }

        public override void Validate()
        {
        }

        #endregion
    }
}
