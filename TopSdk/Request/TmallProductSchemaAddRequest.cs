using System;
using System.Collections.Generic;
using Top.Api.Util;

namespace Top.Api.Request
{
    /// <summary>
    /// TOP API: tmall.product.schema.add
    /// </summary>
    public class TmallProductSchemaAddRequest : BaseTopRequest<Top.Api.Response.TmallProductSchemaAddResponse>
    {
        /// <summary>
        /// 品牌ID
        /// </summary>
        public Nullable<long> BrandId { get; set; }

        /// <summary>
        /// 商品发布的目标类目，必须是叶子类目
        /// </summary>
        public Nullable<long> CategoryId { get; set; }

        /// <summary>
        /// 根据tmall.product.add.schema.get生成的产品发布规则入参数据
        /// </summary>
        public string XmlData { get; set; }

        #region ITopRequest Members

        public override string GetApiName()
        {
            return "tmall.product.schema.add";
        }

        public override IDictionary<string, string> GetParameters()
        {
            TopDictionary parameters = new TopDictionary();
            parameters.Add("brand_id", this.BrandId);
            parameters.Add("category_id", this.CategoryId);
            parameters.Add("xml_data", this.XmlData);
            if (this.otherParams != null)
            {
                parameters.AddAll(this.otherParams);
            }
            return parameters;
        }

        public override void Validate()
        {
            RequestValidator.ValidateRequired("category_id", this.CategoryId);
            RequestValidator.ValidateRequired("xml_data", this.XmlData);
        }

        #endregion
    }
}
