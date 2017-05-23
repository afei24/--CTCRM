using System;
using System.Collections.Generic;
using Top.Api.Util;

namespace Top.Api.Request
{
    /// <summary>
    /// TOP API: taobao.wlb.item.consignment.query
    /// </summary>
    public class WlbItemConsignmentQueryRequest : BaseTopRequest<Top.Api.Response.WlbItemConsignmentQueryResponse>
    {
        /// <summary>
        /// 授权结束时间
        /// </summary>
        public Nullable<DateTime> AuthorizeEndTime { get; set; }

        /// <summary>
        /// 授权开始时间
        /// </summary>
        public Nullable<DateTime> AuthorizeStartTime { get; set; }

        /// <summary>
        /// 货主的用户昵称，未设置则查询全部
        /// </summary>
        public string OwnerUserNick { get; set; }

        /// <summary>
        /// 当前页
        /// </summary>
        public Nullable<long> PageNo { get; set; }

        /// <summary>
        /// 分页记录个数，如果用户输入的记录数大于50，则一页显示50条记录
        /// </summary>
        public Nullable<long> PageSize { get; set; }

        #region ITopRequest Members

        public override string GetApiName()
        {
            return "taobao.wlb.item.consignment.query";
        }

        public override IDictionary<string, string> GetParameters()
        {
            TopDictionary parameters = new TopDictionary();
            parameters.Add("authorize_end_time", this.AuthorizeEndTime);
            parameters.Add("authorize_start_time", this.AuthorizeStartTime);
            parameters.Add("owner_user_nick", this.OwnerUserNick);
            parameters.Add("page_no", this.PageNo);
            parameters.Add("page_size", this.PageSize);
            if (this.otherParams != null)
            {
                parameters.AddAll(this.otherParams);
            }
            return parameters;
        }

        public override void Validate()
        {
            RequestValidator.ValidateRequired("page_no", this.PageNo);
            RequestValidator.ValidateRequired("page_size", this.PageSize);
        }

        #endregion
    }
}
