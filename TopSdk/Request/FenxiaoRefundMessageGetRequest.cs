using System;
using System.Collections.Generic;
using Top.Api.Util;

namespace Top.Api.Request
{
    /// <summary>
    /// TOP API: taobao.fenxiao.refund.message.get
    /// </summary>
    public class FenxiaoRefundMessageGetRequest : BaseTopRequest<Top.Api.Response.FenxiaoRefundMessageGetResponse>
    {
        /// <summary>
        /// 页码。（大于0的整数。默认为1）
        /// </summary>
        public Nullable<long> PageNo { get; set; }

        /// <summary>
        /// 每页条数。（默认10）
        /// </summary>
        public Nullable<long> PageSize { get; set; }

        /// <summary>
        /// 子采购单id
        /// </summary>
        public Nullable<long> SubOrderId { get; set; }

        #region ITopRequest Members

        public override string GetApiName()
        {
            return "taobao.fenxiao.refund.message.get";
        }

        public override IDictionary<string, string> GetParameters()
        {
            TopDictionary parameters = new TopDictionary();
            parameters.Add("page_no", this.PageNo);
            parameters.Add("page_size", this.PageSize);
            parameters.Add("sub_order_id", this.SubOrderId);
            if (this.otherParams != null)
            {
                parameters.AddAll(this.otherParams);
            }
            return parameters;
        }

        public override void Validate()
        {
            RequestValidator.ValidateRequired("sub_order_id", this.SubOrderId);
        }

        #endregion
    }
}
