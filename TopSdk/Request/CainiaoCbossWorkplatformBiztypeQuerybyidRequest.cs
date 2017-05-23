using System;
using System.Collections.Generic;
using Top.Api.Util;

namespace Top.Api.Request
{
    /// <summary>
    /// TOP API: cainiao.cboss.workplatform.biztype.querybyid
    /// </summary>
    public class CainiaoCbossWorkplatformBiztypeQuerybyidRequest : BaseTopRequest<Top.Api.Response.CainiaoCbossWorkplatformBiztypeQuerybyidResponse>
    {
        /// <summary>
        /// 业务类型id
        /// </summary>
        public string BizTypeId { get; set; }

        #region ITopRequest Members

        public override string GetApiName()
        {
            return "cainiao.cboss.workplatform.biztype.querybyid";
        }

        public override IDictionary<string, string> GetParameters()
        {
            TopDictionary parameters = new TopDictionary();
            parameters.Add("biz_type_id", this.BizTypeId);
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
