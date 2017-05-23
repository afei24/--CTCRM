using System;
using System.Collections.Generic;
using Top.Api.Util;

namespace Top.Api.Request
{
    /// <summary>
    /// TOP API: tmall.product.schema.update
    /// </summary>
    public class TmallProductSchemaUpdateRequest : BaseTopRequest<Top.Api.Response.TmallProductSchemaUpdateResponse>
    {
        /// <summary>
        /// 产品编号
        /// </summary>
        public Nullable<long> ProductId { get; set; }

        /// <summary>
        /// 根据tmall.product.update.schema.get生成的产品更新规则入参数据
        /// </summary>
        public string XmlData { get; set; }

        #region ITopRequest Members

        public override string GetApiName()
        {
            return "tmall.product.schema.update";
        }

        public override IDictionary<string, string> GetParameters()
        {
            TopDictionary parameters = new TopDictionary();
            parameters.Add("product_id", this.ProductId);
            parameters.Add("xml_data", this.XmlData);
            if (this.otherParams != null)
            {
                parameters.AddAll(this.otherParams);
            }
            return parameters;
        }

        public override void Validate()
        {
            RequestValidator.ValidateRequired("product_id", this.ProductId);
            RequestValidator.ValidateRequired("xml_data", this.XmlData);
        }

        #endregion
    }
}
