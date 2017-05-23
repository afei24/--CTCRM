using System;
using System.Collections.Generic;
using Top.Api.Util;

namespace Top.Api.Request
{
    /// <summary>
    /// TOP API: taobao.wlb.orderitem.page.get
    /// </summary>
    public class WlbOrderitemPageGetRequest : BaseTopRequest<Top.Api.Response.WlbOrderitemPageGetResponse>
    {
        /// <summary>
        /// 物流宝订单编码
        /// </summary>
        public string OrderCode { get; set; }

        /// <summary>
        /// 分页查询参数，指定查询页数，默认为1
        /// </summary>
        public Nullable<long> PageNo { get; set; }

        /// <summary>
        /// 分页查询参数，每页查询数量，默认20，最大值50,大于50时按照50条查询
        /// </summary>
        public Nullable<long> PageSize { get; set; }

        #region ITopRequest Members

        public override string GetApiName()
        {
            return "taobao.wlb.orderitem.page.get";
        }

        public override IDictionary<string, string> GetParameters()
        {
            TopDictionary parameters = new TopDictionary();
            parameters.Add("order_code", this.OrderCode);
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
            RequestValidator.ValidateRequired("order_code", this.OrderCode);
        }

        #endregion
    }
}
