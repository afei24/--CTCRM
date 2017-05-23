using System;
using System.Collections.Generic;
using Top.Api.Util;

namespace Top.Api.Request
{
    /// <summary>
    /// TOP API: tmall.product.specs.ticket.get
    /// </summary>
    public class TmallProductSpecsTicketGetRequest : BaseTopRequest<Top.Api.Response.TmallProductSpecsTicketGetResponse>
    {
        /// <summary>
        /// 产品规格ID，多个用逗号分隔
        /// </summary>
        public string SpecIds { get; set; }

        #region ITopRequest Members

        public override string GetApiName()
        {
            return "tmall.product.specs.ticket.get";
        }

        public override IDictionary<string, string> GetParameters()
        {
            TopDictionary parameters = new TopDictionary();
            parameters.Add("spec_ids", this.SpecIds);
            if (this.otherParams != null)
            {
                parameters.AddAll(this.otherParams);
            }
            return parameters;
        }

        public override void Validate()
        {
            RequestValidator.ValidateRequired("spec_ids", this.SpecIds);
        }

        #endregion
    }
}
