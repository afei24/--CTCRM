using System;
using System.Collections.Generic;
using Top.Api.Util;

namespace Top.Api.Request
{
    /// <summary>
    /// TOP API: cainiao.cboss.workplatform.biztype.queryall
    /// </summary>
    public class CainiaoCbossWorkplatformBiztypeQueryallRequest : BaseTopRequest<Top.Api.Response.CainiaoCbossWorkplatformBiztypeQueryallResponse>
    {
        /// <summary>
        /// level
        /// </summary>
        public Nullable<long> Level { get; set; }

        /// <summary>
        /// tradeId
        /// </summary>
        public string TradeId { get; set; }

        #region ITopRequest Members

        public override string GetApiName()
        {
            return "cainiao.cboss.workplatform.biztype.queryall";
        }

        public override IDictionary<string, string> GetParameters()
        {
            TopDictionary parameters = new TopDictionary();
            parameters.Add("level", this.Level);
            parameters.Add("trade_id", this.TradeId);
            if (this.otherParams != null)
            {
                parameters.AddAll(this.otherParams);
            }
            return parameters;
        }

        public override void Validate()
        {
            RequestValidator.ValidateRequired("trade_id", this.TradeId);
        }

        #endregion
    }
}
