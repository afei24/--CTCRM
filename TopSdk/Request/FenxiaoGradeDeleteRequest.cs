using System;
using System.Collections.Generic;
using Top.Api.Util;

namespace Top.Api.Request
{
    /// <summary>
    /// TOP API: taobao.fenxiao.grade.delete
    /// </summary>
    public class FenxiaoGradeDeleteRequest : BaseTopRequest<Top.Api.Response.FenxiaoGradeDeleteResponse>
    {
        /// <summary>
        /// 等级ID
        /// </summary>
        public Nullable<long> GradeId { get; set; }

        #region ITopRequest Members

        public override string GetApiName()
        {
            return "taobao.fenxiao.grade.delete";
        }

        public override IDictionary<string, string> GetParameters()
        {
            TopDictionary parameters = new TopDictionary();
            parameters.Add("grade_id", this.GradeId);
            if (this.otherParams != null)
            {
                parameters.AddAll(this.otherParams);
            }
            return parameters;
        }

        public override void Validate()
        {
            RequestValidator.ValidateRequired("grade_id", this.GradeId);
        }

        #endregion
    }
}
