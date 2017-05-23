using System;
using System.Collections.Generic;
using Top.Api.Util;

namespace Top.Api.Request
{
    /// <summary>
    /// TOP API: taobao.rp.returngoods.agree
    /// </summary>
    public class RpReturngoodsAgreeRequest : BaseTopRequest<Top.Api.Response.RpReturngoodsAgreeResponse>
    {
        /// <summary>
        /// 卖家提供的退货地址，淘宝退款为必填项。
        /// </summary>
        public string Address { get; set; }

        /// <summary>
        /// 卖家手机，淘宝退款为必填项。
        /// </summary>
        public string Mobile { get; set; }

        /// <summary>
        /// 卖家姓名，淘宝退款为必填项。
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 卖家提供的退货地址的邮编，淘宝退款为必填项。
        /// </summary>
        public string Post { get; set; }

        /// <summary>
        /// 退款编号
        /// </summary>
        public Nullable<long> RefundId { get; set; }

        /// <summary>
        /// 售中：onsale，售后：aftersale，天猫退款为必填项。
        /// </summary>
        public string RefundPhase { get; set; }

        /// <summary>
        /// 退款版本号，天猫退款为必填项。
        /// </summary>
        public Nullable<long> RefundVersion { get; set; }

        /// <summary>
        /// 卖家退货留言，天猫退款为必填项。
        /// </summary>
        public string Remark { get; set; }

        /// <summary>
        /// 卖家收货地址编号，天猫退款为必填项。
        /// </summary>
        public Nullable<long> SellerAddressId { get; set; }

        /// <summary>
        /// 卖家座机，淘宝退款为必填项。
        /// </summary>
        public string Tel { get; set; }

        #region ITopRequest Members

        public override string GetApiName()
        {
            return "taobao.rp.returngoods.agree";
        }

        public override IDictionary<string, string> GetParameters()
        {
            TopDictionary parameters = new TopDictionary();
            parameters.Add("address", this.Address);
            parameters.Add("mobile", this.Mobile);
            parameters.Add("name", this.Name);
            parameters.Add("post", this.Post);
            parameters.Add("refund_id", this.RefundId);
            parameters.Add("refund_phase", this.RefundPhase);
            parameters.Add("refund_version", this.RefundVersion);
            parameters.Add("remark", this.Remark);
            parameters.Add("seller_address_id", this.SellerAddressId);
            parameters.Add("tel", this.Tel);
            if (this.otherParams != null)
            {
                parameters.AddAll(this.otherParams);
            }
            return parameters;
        }

        public override void Validate()
        {
            RequestValidator.ValidateRequired("refund_id", this.RefundId);
        }

        #endregion
    }
}
