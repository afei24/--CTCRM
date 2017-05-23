using System;
using System.Xml.Serialization;
using Top.Api.Domain;
using System.Collections.Generic;
using Top.Api.Util;

namespace Top.Api.Request
{
    /// <summary>
    /// TOP API: taobao.fuwu.sp.confirm.apply
    /// </summary>
    public class FuwuSpConfirmApplyRequest : BaseTopRequest<Top.Api.Response.FuwuSpConfirmApplyResponse>
    {
        /// <summary>
        /// 确认单申请
        /// </summary>
        public string ParamIncomeConfirmDTO { get; set; }

        public IncomeConfirmDto ParamIncomeConfirmDTO_ { set { this.ParamIncomeConfirmDTO = TopUtils.ObjectToJson(value); } } 

        #region ITopRequest Members

        public override string GetApiName()
        {
            return "taobao.fuwu.sp.confirm.apply";
        }

        public override IDictionary<string, string> GetParameters()
        {
            TopDictionary parameters = new TopDictionary();
            parameters.Add("param_income_confirm_d_t_o", this.ParamIncomeConfirmDTO);
            if (this.otherParams != null)
            {
                parameters.AddAll(this.otherParams);
            }
            return parameters;
        }

        public override void Validate()
        {
            RequestValidator.ValidateRequired("param_income_confirm_d_t_o", this.ParamIncomeConfirmDTO);
        }

        #endregion
    }
}
