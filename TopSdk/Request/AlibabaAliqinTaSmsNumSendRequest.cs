using System;
using System.Collections.Generic;
using Top.Api.Util;

namespace Top.Api.Request
{
    /// <summary>
    /// TOP API: alibaba.aliqin.ta.sms.num.send
    /// </summary>
    public class AlibabaAliqinTaSmsNumSendRequest : BaseTopRequest<Top.Api.Response.AlibabaAliqinTaSmsNumSendResponse>
    {
        /// <summary>
        /// 公共回传参数
        /// </summary>
        public string Extend { get; set; }

        /// <summary>
        /// 商家自定义扩展码
        /// </summary>
        public string ExtendCode { get; set; }

        /// <summary>
        /// 商家自定义扩展名,例如店铺nick
        /// </summary>
        public string ExtendName { get; set; }

        /// <summary>
        /// 接收号码
        /// </summary>
        public string RecNum { get; set; }

        /// <summary>
        /// 短信签名
        /// </summary>
        public string SmsFreeSignName { get; set; }

        /// <summary>
        /// 短信模板变量，AckNum是变量参数
        /// </summary>
        public string SmsParam { get; set; }

        /// <summary>
        /// 短信模板CODE
        /// </summary>
        public string SmsTemplateCode { get; set; }

        /// <summary>
        /// 类型，normal：短信
        /// </summary>
        public string SmsType { get; set; }

        #region ITopRequest Members

        public override string GetApiName()
        {
            return "alibaba.aliqin.ta.sms.num.send";
        }

        public override IDictionary<string, string> GetParameters()
        {
            TopDictionary parameters = new TopDictionary();
            parameters.Add("extend", this.Extend);
            parameters.Add("extend_code", this.ExtendCode);
            parameters.Add("extend_name", this.ExtendName);
            parameters.Add("rec_num", this.RecNum);
            parameters.Add("sms_free_sign_name", this.SmsFreeSignName);
            parameters.Add("sms_param", this.SmsParam);
            parameters.Add("sms_template_code", this.SmsTemplateCode);
            parameters.Add("sms_type", this.SmsType);
            if (this.otherParams != null)
            {
                parameters.AddAll(this.otherParams);
            }
            return parameters;
        }

        public override void Validate()
        {
            RequestValidator.ValidateRequired("rec_num", this.RecNum);
            RequestValidator.ValidateRequired("sms_free_sign_name", this.SmsFreeSignName);
            RequestValidator.ValidateRequired("sms_template_code", this.SmsTemplateCode);
            RequestValidator.ValidateRequired("sms_type", this.SmsType);
        }

        #endregion
    }
}
