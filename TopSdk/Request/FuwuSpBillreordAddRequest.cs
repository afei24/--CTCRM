using System;
using System.Xml.Serialization;
using Top.Api.Domain;
using System.Collections.Generic;
using Top.Api.Util;

namespace Top.Api.Request
{
    /// <summary>
    /// TOP API: taobao.fuwu.sp.billreord.add
    /// </summary>
    public class FuwuSpBillreordAddRequest : BaseTopRequest<Top.Api.Response.FuwuSpBillreordAddResponse>
    {
        /// <summary>
        /// 确认单的账单明细
        /// </summary>
        public string ParamBillRecordDTO { get; set; }

        public BillRecordDto ParamBillRecordDTO_ { set { this.ParamBillRecordDTO = TopUtils.ObjectToJson(value); } } 

        #region ITopRequest Members

        public override string GetApiName()
        {
            return "taobao.fuwu.sp.billreord.add";
        }

        public override IDictionary<string, string> GetParameters()
        {
            TopDictionary parameters = new TopDictionary();
            parameters.Add("param_bill_record_d_t_o", this.ParamBillRecordDTO);
            if (this.otherParams != null)
            {
                parameters.AddAll(this.otherParams);
            }
            return parameters;
        }

        public override void Validate()
        {
            RequestValidator.ValidateRequired("param_bill_record_d_t_o", this.ParamBillRecordDTO);
        }

        #endregion
    }
}
