using System;
using System.Collections.Generic;
using Top.Api.Util;

namespace Top.Api.Request
{
    /// <summary>
    /// TOP API: taobao.rp.refunds.agree
    /// </summary>
    public class RpRefundsAgreeRequest : BaseTopRequest<Top.Api.Response.RpRefundsAgreeResponse>
    {
        /// <summary>
        /// 短信验证码，如果退款金额达到一定的数量，后端会返回调用失败，并同时往卖家的手机发送一条短信验证码。接下来用收到的短信验证码再次发起API调用即可完成退款操作。
        /// </summary>
        public string Code { get; set; }

        /// <summary>
        /// 退款信息，格式：refund_id|amount|version|phase，其中refund_id为退款编号，amount为退款金额（以分为单位），version为退款最后更新时间（时间戳格式），phase为退款阶段（可选值为：onsale, aftersale，天猫退款必值，淘宝退款不需要传），多个退款以半角逗号分隔。
        /// </summary>
        public string RefundInfos { get; set; }

        #region ITopRequest Members

        public override string GetApiName()
        {
            return "taobao.rp.refunds.agree";
        }

        public override IDictionary<string, string> GetParameters()
        {
            TopDictionary parameters = new TopDictionary();
            parameters.Add("code", this.Code);
            parameters.Add("refund_infos", this.RefundInfos);
            if (this.otherParams != null)
            {
                parameters.AddAll(this.otherParams);
            }
            return parameters;
        }

        public override void Validate()
        {
            RequestValidator.ValidateRequired("refund_infos", this.RefundInfos);
        }

        #endregion
    }
}
