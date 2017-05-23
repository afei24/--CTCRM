using System;
using System.Collections.Generic;
using Top.Api.Util;

namespace Top.Api.Request
{
    /// <summary>
    /// TOP API: taobao.fenxiao.grade.update
    /// </summary>
    public class FenxiaoGradeUpdateRequest : BaseTopRequest<Top.Api.Response.FenxiaoGradeUpdateResponse>
    {
        /// <summary>
        /// 等级ID
        /// </summary>
        public Nullable<long> GradeId { get; set; }

        /// <summary>
        /// 等级名称，等级名称不可重复
        /// </summary>
        public string Name { get; set; }

        #region ITopRequest Members

        public override string GetApiName()
        {
            return "taobao.fenxiao.grade.update";
        }

        public override IDictionary<string, string> GetParameters()
        {
            TopDictionary parameters = new TopDictionary();
            parameters.Add("grade_id", this.GradeId);
            parameters.Add("name", this.Name);
            if (this.otherParams != null)
            {
                parameters.AddAll(this.otherParams);
            }
            return parameters;
        }

        public override void Validate()
        {
            RequestValidator.ValidateRequired("grade_id", this.GradeId);
            RequestValidator.ValidateRequired("name", this.Name);
            RequestValidator.ValidateMaxLength("name", this.Name, 20);
        }

        #endregion
    }
}
