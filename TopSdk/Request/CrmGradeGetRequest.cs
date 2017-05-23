using System;
using System.Collections.Generic;
using Top.Api.Util;

namespace Top.Api.Request
{
    /// <summary>
    /// TOP API: taobao.crm.grade.get
    /// </summary>
    public class CrmGradeGetRequest : BaseTopRequest<Top.Api.Response.CrmGradeGetResponse>
    {
        #region ITopRequest Members

        public override string GetApiName()
        {
            return "taobao.crm.grade.get";
        }

        public override IDictionary<string, string> GetParameters()
        {
            TopDictionary parameters = new TopDictionary();
            if (this.otherParams != null)
            {
                parameters.AddAll(this.otherParams);
            }
            return parameters;
        }

        public override void Validate()
        {
        }

        #endregion
    }
}
