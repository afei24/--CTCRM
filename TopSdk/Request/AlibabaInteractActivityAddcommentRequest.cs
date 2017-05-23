using System;
using System.Collections.Generic;
using Top.Api.Util;

namespace Top.Api.Request
{
    /// <summary>
    /// TOP API: alibaba.interact.activity.addcomment
    /// </summary>
    public class AlibabaInteractActivityAddcommentRequest : BaseTopRequest<Top.Api.Response.AlibabaInteractActivityAddcommentResponse>
    {
        /// <summary>
        /// 发评论的业务id
        /// </summary>
        public string BizId { get; set; }

        /// <summary>
        /// 该字段为评论内容
        /// </summary>
        public string Content { get; set; }

        /// <summary>
        /// 评论feedid
        /// </summary>
        public Nullable<long> FeedId { get; set; }

        #region ITopRequest Members

        public override string GetApiName()
        {
            return "alibaba.interact.activity.addcomment";
        }

        public override IDictionary<string, string> GetParameters()
        {
            TopDictionary parameters = new TopDictionary();
            parameters.Add("biz_id", this.BizId);
            parameters.Add("content", this.Content);
            parameters.Add("feed_id", this.FeedId);
            if (this.otherParams != null)
            {
                parameters.AddAll(this.otherParams);
            }
            return parameters;
        }

        public override void Validate()
        {
            RequestValidator.ValidateRequired("biz_id", this.BizId);
            RequestValidator.ValidateRequired("content", this.Content);
            RequestValidator.ValidateRequired("feed_id", this.FeedId);
        }

        #endregion
    }
}
