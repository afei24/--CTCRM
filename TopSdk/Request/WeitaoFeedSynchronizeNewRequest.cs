using System;
using System.Collections.Generic;
using Top.Api.Util;

namespace Top.Api.Request
{
    /// <summary>
    /// TOP API: taobao.weitao.feed.synchronize.new
    /// </summary>
    public class WeitaoFeedSynchronizeNewRequest : BaseTopRequest<Top.Api.Response.WeitaoFeedSynchronizeNewResponse>
    {
        /// <summary>
        /// feed点击跳转的活动地址
        /// </summary>
        public string DetailUrl { get; set; }

        /// <summary>
        /// feed展示结束时间
        /// </summary>
        public Nullable<long> EndTime { get; set; }

        /// <summary>
        /// 广播类型：粉丝猜价格461、投票有礼462、粉丝抢红包463、盖楼有礼464、加购有礼465
        /// </summary>
        public Nullable<long> FeedType { get; set; }

        /// <summary>
        /// 宝贝列表，用于card展示，0~2个宝贝ID
        /// </summary>
        public string ItemIds { get; set; }

        /// <summary>
        /// 活动ID
        /// </summary>
        public string SbizId { get; set; }

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
            return "taobao.weitao.feed.synchronize.new";
        }

        public override IDictionary<string, string> GetParameters()
        {
            TopDictionary parameters = new TopDictionary();
            parameters.Add("detail_url", this.DetailUrl);
            parameters.Add("end_time", this.EndTime);
            parameters.Add("feed_type", this.FeedType);
            parameters.Add("item_ids", this.ItemIds);
            parameters.Add("sbiz_id", this.SbizId);
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
            RequestValidator.ValidateRequired("detail_url", this.DetailUrl);
            RequestValidator.ValidateRequired("end_time", this.EndTime);
            RequestValidator.ValidateRequired("feed_type", this.FeedType);
            RequestValidator.ValidateMaxListSize("item_ids", this.ItemIds, 20);
            RequestValidator.ValidateRequired("sbiz_id", this.SbizId);
            RequestValidator.ValidateRequired("start_time", this.StartTime);
            RequestValidator.ValidateRequired("summary", this.Summary);
            RequestValidator.ValidateRequired("title", this.Title);
        }

        #endregion
    }
}
