using System;
using System.Collections.Generic;
using Top.Api.Util;

namespace Top.Api.Request
{
    /// <summary>
    /// TOP API: taobao.qianniu.shopfeed.feed.add
    /// </summary>
    public class QianniuShopfeedFeedAddRequest : BaseTopRequest<Top.Api.Response.QianniuShopfeedFeedAddResponse>
    {
        /// <summary>
        /// 动态生效时间
        /// </summary>
        public Nullable<DateTime> ActiveDate { get; set; }

        /// <summary>
        /// 动态提醒时间
        /// </summary>
        public Nullable<DateTime> AlertTime { get; set; }

        /// <summary>
        /// 动态提醒跳转url
        /// </summary>
        public string AlertUrl { get; set; }

        /// <summary>
        /// 动态状态：1=草稿，2=编辑完成，3=审核通过，4=已发布，0=审核不通过
        /// </summary>
        public Nullable<long> EditStatus { get; set; }

        /// <summary>
        /// 动态内容
        /// </summary>
        public string FeedContent { get; set; }

        /// <summary>
        /// 动态类型：上新预告=1、上新=2、活动=3、调查=4、福利=5、爆款=6、无=0
        /// </summary>
        public Nullable<long> FeedTag { get; set; }

        /// <summary>
        /// 动态标题
        /// </summary>
        public string FeedTitle { get; set; }

        /// <summary>
        /// 动态扩展属性，jsonarray，如动态所关联的商品图片、购买链接等等
        /// </summary>
        public string ShopFeedExtInfo { get; set; }

        #region ITopRequest Members

        public override string GetApiName()
        {
            return "taobao.qianniu.shopfeed.feed.add";
        }

        public override IDictionary<string, string> GetParameters()
        {
            TopDictionary parameters = new TopDictionary();
            parameters.Add("active_date", this.ActiveDate);
            parameters.Add("alert_time", this.AlertTime);
            parameters.Add("alert_url", this.AlertUrl);
            parameters.Add("edit_status", this.EditStatus);
            parameters.Add("feed_content", this.FeedContent);
            parameters.Add("feed_tag", this.FeedTag);
            parameters.Add("feed_title", this.FeedTitle);
            parameters.Add("shop_feed_ext_info", this.ShopFeedExtInfo);
            if (this.otherParams != null)
            {
                parameters.AddAll(this.otherParams);
            }
            return parameters;
        }

        public override void Validate()
        {
            RequestValidator.ValidateRequired("edit_status", this.EditStatus);
            RequestValidator.ValidateRequired("feed_content", this.FeedContent);
            RequestValidator.ValidateRequired("feed_tag", this.FeedTag);
        }

        #endregion
    }
}
