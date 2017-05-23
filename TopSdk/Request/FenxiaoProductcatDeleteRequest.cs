using System;
using System.Collections.Generic;
using Top.Api.Util;

namespace Top.Api.Request
{
    /// <summary>
    /// TOP API: taobao.fenxiao.productcat.delete
    /// </summary>
    public class FenxiaoProductcatDeleteRequest : BaseTopRequest<Top.Api.Response.FenxiaoProductcatDeleteResponse>
    {
        /// <summary>
        /// 产品线ID
        /// </summary>
        public Nullable<long> ProductLineId { get; set; }

        #region ITopRequest Members

        public override string GetApiName()
        {
            return "taobao.fenxiao.productcat.delete";
        }

        public override IDictionary<string, string> GetParameters()
        {
            TopDictionary parameters = new TopDictionary();
            parameters.Add("product_line_id", this.ProductLineId);
            if (this.otherParams != null)
            {
                parameters.AddAll(this.otherParams);
            }
            return parameters;
        }

        public override void Validate()
        {
            RequestValidator.ValidateRequired("product_line_id", this.ProductLineId);
        }

        #endregion
    }
}
