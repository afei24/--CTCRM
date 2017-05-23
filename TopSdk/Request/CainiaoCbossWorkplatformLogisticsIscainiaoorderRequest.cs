using System;
using System.Collections.Generic;
using Top.Api.Util;

namespace Top.Api.Request
{
    /// <summary>
    /// TOP API: cainiao.cboss.workplatform.logistics.iscainiaoorder
    /// </summary>
    public class CainiaoCbossWorkplatformLogisticsIscainiaoorderRequest : BaseTopRequest<Top.Api.Response.CainiaoCbossWorkplatformLogisticsIscainiaoorderResponse>
    {
        /// <summary>
        /// 交易单号
        /// </summary>
        public string TradeId { get; set; }

        #region ITopRequest Members

        public override string GetApiName()
        {
            return "cainiao.cboss.workplatform.logistics.iscainiaoorder";
        }

        public override IDictionary<string, string> GetParameters()
        {
            TopDictionary parameters = new TopDictionary();
            parameters.Add("trade_id", this.TradeId);
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
