using System;
using System.Collections.Generic;
using Top.Api.Util;

namespace Top.Api.Request
{
    /// <summary>
    /// TOP API: cainiao.bim.tradeorder.consign
    /// </summary>
    public class CainiaoBimTradeorderConsignRequest : BaseTopRequest<Top.Api.Response.CainiaoBimTradeorderConsignResponse>
    {
        /// <summary>
        /// 仓储编码，ERP指定仓库发货时需要传值，编码由菜鸟提供
        /// </summary>
        public string StoreCode { get; set; }

        /// <summary>
        /// 交易单号
        /// </summary>
        public string TradeId { get; set; }

        #region ITopRequest Members

        public override string GetApiName()
        {
            return "cainiao.bim.tradeorder.consign";
        }

        public override IDictionary<string, string> GetParameters()
        {
            TopDictionary parameters = new TopDictionary();
            parameters.Add("store_code", this.StoreCode);
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
