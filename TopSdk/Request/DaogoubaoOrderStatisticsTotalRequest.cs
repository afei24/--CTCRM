using System;
using System.Collections.Generic;
using Top.Api.Util;

namespace Top.Api.Request
{
    /// <summary>
    /// TOP API: taobao.daogoubao.order.statistics.total
    /// </summary>
    public class DaogoubaoOrderStatisticsTotalRequest : BaseTopRequest<Top.Api.Response.DaogoubaoOrderStatisticsTotalResponse>
    {
        /// <summary>
        /// 调试时用的传入id
        /// </summary>
        public string DebugId { get; set; }

        /// <summary>
        /// 需要的字段名
        /// </summary>
        public string Field { get; set; }

        #region ITopRequest Members

        public override string GetApiName()
        {
            return "taobao.daogoubao.order.statistics.total";
        }

        public override IDictionary<string, string> GetParameters()
        {
            TopDictionary parameters = new TopDictionary();
            parameters.Add("debug_id", this.DebugId);
            parameters.Add("field", this.Field);
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
