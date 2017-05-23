using System;
using System.Collections.Generic;
using Top.Api.Util;

namespace Top.Api.Request
{
    /// <summary>
    /// TOP API: taobao.logistics.trace.search
    /// </summary>
    public class LogisticsTraceSearchRequest : BaseTopRequest<Top.Api.Response.LogisticsTraceSearchResponse>
    {
        /// <summary>
        /// 表明是否是拆单，默认值0，1表示拆单
        /// </summary>
        public Nullable<long> IsSplit { get; set; }

        /// <summary>
        /// 卖家昵称
        /// </summary>
        public string SellerNick { get; set; }

        /// <summary>
        /// 拆单子订单列表，当is_split=1时，需要传人；对应的数据是：子订单号的列表。
        /// </summary>
        public string SubTid { get; set; }

        /// <summary>
        /// 淘宝交易号，请勿传非淘宝交易号
        /// </summary>
        public Nullable<long> Tid { get; set; }

        #region ITopRequest Members

        public override string GetApiName()
        {
            return "taobao.logistics.trace.search";
        }

        public override IDictionary<string, string> GetParameters()
        {
            TopDictionary parameters = new TopDictionary();
            parameters.Add("is_split", this.IsSplit);
            parameters.Add("seller_nick", this.SellerNick);
            parameters.Add("sub_tid", this.SubTid);
            parameters.Add("tid", this.Tid);
            if (this.otherParams != null)
            {
                parameters.AddAll(this.otherParams);
            }
            return parameters;
        }

        public override void Validate()
        {
            RequestValidator.ValidateRequired("seller_nick", this.SellerNick);
            RequestValidator.ValidateMaxListSize("sub_tid", this.SubTid, 50);
            RequestValidator.ValidateRequired("tid", this.Tid);
        }

        #endregion
    }
}
