using System;
using System.Collections.Generic;
using Top.Api.Util;

namespace Top.Api.Request
{
    /// <summary>
    /// TOP API: alibaba.interact.activity.register
    /// </summary>
    public class AlibabaInteractActivityRegisterRequest : BaseTopRequest<Top.Api.Response.AlibabaInteractActivityRegisterResponse>
    {
        /// <summary>
        /// 活动ID
        /// </summary>
        public string BizId { get; set; }

        /// <summary>
        /// 活动描述文字
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// 活动结束时间
        /// </summary>
        public Nullable<DateTime> EndTime { get; set; }

        /// <summary>
        /// 页面内容链接，仅允许ascii字符
        /// </summary>
        public string EntryUrl { get; set; }

        /// <summary>
        /// 是否有有效时间，若为真开始时间和结束时间必填，默认为真
        /// </summary>
        public Nullable<bool> HasValidTime { get; set; }

        /// <summary>
        /// 活动名称
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 活动封面图片（非必填）
        /// </summary>
        public string Picture { get; set; }

        /// <summary>
        /// 活动开始时间
        /// </summary>
        public Nullable<DateTime> StartTime { get; set; }

        #region ITopRequest Members

        public override string GetApiName()
        {
            return "alibaba.interact.activity.register";
        }

        public override IDictionary<string, string> GetParameters()
        {
            TopDictionary parameters = new TopDictionary();
            parameters.Add("biz_id", this.BizId);
            parameters.Add("description", this.Description);
            parameters.Add("end_time", this.EndTime);
            parameters.Add("entry_url", this.EntryUrl);
            parameters.Add("has_valid_time", this.HasValidTime);
            parameters.Add("name", this.Name);
            parameters.Add("picture", this.Picture);
            parameters.Add("start_time", this.StartTime);
            if (this.otherParams != null)
            {
                parameters.AddAll(this.otherParams);
            }
            return parameters;
        }

        public override void Validate()
        {
            RequestValidator.ValidateRequired("biz_id", this.BizId);
            RequestValidator.ValidateRequired("entry_url", this.EntryUrl);
            RequestValidator.ValidateRequired("has_valid_time", this.HasValidTime);
            RequestValidator.ValidateRequired("name", this.Name);
        }

        #endregion
    }
}
