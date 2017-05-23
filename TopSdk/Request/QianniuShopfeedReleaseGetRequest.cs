using System;
using System.Collections.Generic;
using Top.Api.Util;

namespace Top.Api.Request
{
    /// <summary>
    /// TOP API: taobao.qianniu.shopfeed.release.get
    /// </summary>
    public class QianniuShopfeedReleaseGetRequest : BaseTopRequest<Top.Api.Response.QianniuShopfeedReleaseGetResponse>
    {
        /// <summary>
        /// 分页大小
        /// </summary>
        public Nullable<long> PageSize { get; set; }

        /// <summary>
        /// 本地最后一条动态的时间
        /// </summary>
        public Nullable<DateTime> StartDate { get; set; }

        #region ITopRequest Members

        public override string GetApiName()
        {
            return "taobao.qianniu.shopfeed.release.get";
        }

        public override IDictionary<string, string> GetParameters()
        {
            TopDictionary parameters = new TopDictionary();
            parameters.Add("page_size", this.PageSize);
            parameters.Add("start_date", this.StartDate);
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
