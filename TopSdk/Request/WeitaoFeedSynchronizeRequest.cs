using System;
using System.Collections.Generic;
using Top.Api.Util;

namespace Top.Api.Request
{
    /// <summary>
    /// TOP API: taobao.weitao.feed.synchronize
    /// </summary>
    public class WeitaoFeedSynchronizeRequest : BaseTopRequest<Top.Api.Response.WeitaoFeedSynchronizeResponse>
    {
        /// <summary>
        /// 活动id
        /// </summary>
        public Nullable<long> BizId { get; set; }

        /// <summary>
        /// feed封面图片url
        /// </summary>
        public string CoverPath { get; set; }

        /// <summary>
        /// feed点击跳转的活动地址
        /// </summary>
        public string DetailUrl { get; set; }

        /// <summary>
        /// feed展示结束时间
        /// </summary>
        public Nullable<long> EndTime { get; set; }

        /// <summary>
        /// feed展示开始时间
        /// </summary>
        public Nullable<long> StartTime { get; set; }

        /// <summary>
        /// feed描述
        /// </summary>
        public string Summary { get; set; }

        /// <summary>
        /// feed标题
        /// </summary>
        public string Title { get; set; }

        #region ITopRequest Members

        public override string GetApiName()
        {
            return "taobao.weitao.feed.synchronize";
        }

        public override IDictionary<string, string> GetParameters()
        {
            TopDictionary parameters = new TopDictionary();
            parameters.Add("biz_id", this.BizId);
            parameters.Add("cover_path", this.CoverPath);
            parameters.Add("detail_url", this.DetailUrl);
            parameters.Add("end_time", this.EndTime);
            parameters.Add("start_time", this.StartTime);
            parameters.Add("summary", this.Summary);
            parameters.Add("title", this.Title);
            if (this.otherParams != null)
            {
                parameters.AddAll(this.otherParams);
            }
            return parameters;
        }

        public override void Validate()
        {
            RequestValidator.ValidateRequired("biz_id", this.BizId);
            RequestValidator.ValidateRequired("cover_path", this.CoverPath);
            RequestValidator.ValidateRequired("detail_url", this.DetailUrl);
            RequestValidator.ValidateRequired("end_time", this.EndTime);
            RequestValidator.ValidateRequired("start_time", this.StartTime);
            RequestValidator.ValidateRequired("summary", this.Summary);
            RequestValidator.ValidateRequired("title", this.Title);
        }

        #endregion
    }
}
