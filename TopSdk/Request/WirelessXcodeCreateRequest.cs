using System;
using System.Xml.Serialization;
using Top.Api.Domain;
using System.Collections.Generic;
using Top.Api.Util;

namespace Top.Api.Request
{
    /// <summary>
    /// TOP API: taobao.wireless.xcode.create
    /// </summary>
    public class WirelessXcodeCreateRequest : BaseTopRequest<Top.Api.Response.WirelessXcodeCreateResponse>
    {
        /// <summary>
        /// 码平台开放的业务code
        /// </summary>
        public string BizCode { get; set; }

        /// <summary>
        /// 原始内容/原始地址
        /// </summary>
        public string Content { get; set; }

        /// <summary>
        /// 普通二维码样式参数
        /// </summary>
        public string Style { get; set; }

        public QrCodeStyle Style_ { set { this.Style = TopUtils.ObjectToJson(value); } } 

        #region ITopRequest Members

        public override string GetApiName()
        {
            return "taobao.wireless.xcode.create";
        }

        public override IDictionary<string, string> GetParameters()
        {
            TopDictionary parameters = new TopDictionary();
            parameters.Add("biz_code", this.BizCode);
            parameters.Add("content", this.Content);
            parameters.Add("style", this.Style);
            if (this.otherParams != null)
            {
                parameters.AddAll(this.otherParams);
            }
            return parameters;
        }

        public override void Validate()
        {
            RequestValidator.ValidateRequired("content", this.Content);
        }

        #endregion
    }
}
