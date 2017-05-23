using System;
using System.Collections.Generic;
using Top.Api.Util;

namespace Top.Api.Request
{
    /// <summary>
    /// TOP API: alibaba.interact.allsparkisv.draw
    /// </summary>
    public class AlibabaInteractAllsparkisvDrawRequest : BaseTopRequest<Top.Api.Response.AlibabaInteractAllsparkisvDrawResponse>
    {
        /// <summary>
        /// dd
        /// </summary>
        public string Ddd { get; set; }

        /// <summary>
        /// ddd
        /// </summary>
        public string Test { get; set; }

        #region ITopRequest Members

        public override string GetApiName()
        {
            return "alibaba.interact.allsparkisv.draw";
        }

        public override IDictionary<string, string> GetParameters()
        {
            TopDictionary parameters = new TopDictionary();
            parameters.Add("ddd", this.Ddd);
            parameters.Add("test", this.Test);
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
