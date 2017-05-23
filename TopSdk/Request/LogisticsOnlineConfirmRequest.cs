using System;
using System.Collections.Generic;
using Top.Api.Util;

namespace Top.Api.Request
{
    /// <summary>
    /// TOP API: taobao.logistics.online.confirm
    /// </summary>
    public class LogisticsOnlineConfirmRequest : BaseTopRequest<Top.Api.Response.LogisticsOnlineConfirmResponse>
    {
        /// <summary>
        /// 表明是否是拆单，默认值0，1表示拆单
        /// </summary>
        public Nullable<long> IsSplit { get; set; }

        /// <summary>
        /// 运单号.具体一个物流公司的真实运单号码。淘宝官方物流会校验，请谨慎传入；
        /// </summary>
        public string OutSid { get; set; }

        /// <summary>
        /// 商家的IP地址
        /// </summary>
        public string SellerIp { get; set; }

        /// <summary>
        /// 拆单子订单列表，对应的数据是：子订单号的列表。可以不传，但是如果传了则必须符合传递的规则。子订单必须是操作的物流订单的子订单的真子集
        /// </summary>
        public string SubTid { get; set; }

        /// <summary>
        /// 淘宝交易ID
        /// </summary>
        public Nullable<long> Tid { get; set; }

        #region ITopRequest Members

        public override string GetApiName()
        {
            return "taobao.logistics.online.confirm";
        }

        public override IDictionary<string, string> GetParameters()
        {
            TopDictionary parameters = new TopDictionary();
            parameters.Add("is_split", this.IsSplit);
            parameters.Add("out_sid", this.OutSid);
            parameters.Add("seller_ip", this.SellerIp);
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
            RequestValidator.ValidateRequired("out_sid", this.OutSid);
            RequestValidator.ValidateMaxListSize("sub_tid", this.SubTid, 20);
            RequestValidator.ValidateRequired("tid", this.Tid);
        }

        #endregion
    }
}
