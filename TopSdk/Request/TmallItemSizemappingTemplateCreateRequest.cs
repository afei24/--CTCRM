using System;
using System.Collections.Generic;
using Top.Api.Util;

namespace Top.Api.Request
{
    /// <summary>
    /// TOP API: tmall.item.sizemapping.template.create
    /// </summary>
    public class TmallItemSizemappingTemplateCreateRequest : BaseTopRequest<Top.Api.Response.TmallItemSizemappingTemplateCreateResponse>
    {
        /// <summary>
        /// 尺码表模板内容，格式为"尺码值:维度名称:数值,尺码值:维度名称:数值"。其中，数值的单位，长度单位为厘米（cm），体重单位为公斤（kg）。尺码值，维度数据不能包含数字，特殊字符。数值为0-999.9的数字，且最多一位小数。
        /// </summary>
        public string TemplateContent { get; set; }

        /// <summary>
        /// 尺码表模板名称
        /// </summary>
        public string TemplateName { get; set; }

        #region ITopRequest Members

        public override string GetApiName()
        {
            return "tmall.item.sizemapping.template.create";
        }

        public override IDictionary<string, string> GetParameters()
        {
            TopDictionary parameters = new TopDictionary();
            parameters.Add("template_content", this.TemplateContent);
            parameters.Add("template_name", this.TemplateName);
            if (this.otherParams != null)
            {
                parameters.AddAll(this.otherParams);
            }
            return parameters;
        }

        public override void Validate()
        {
            RequestValidator.ValidateRequired("template_content", this.TemplateContent);
            RequestValidator.ValidateMaxLength("template_content", this.TemplateContent, 8000);
            RequestValidator.ValidateRequired("template_name", this.TemplateName);
            RequestValidator.ValidateMaxLength("template_name", this.TemplateName, 20);
        }

        #endregion
    }
}
