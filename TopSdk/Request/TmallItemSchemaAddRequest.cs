using System;
using System.Collections.Generic;
using Top.Api.Util;

namespace Top.Api.Request
{
    /// <summary>
    /// TOP API: tmall.item.schema.add
    /// </summary>
    public class TmallItemSchemaAddRequest : BaseTopRequest<Top.Api.Response.TmallItemSchemaAddResponse>
    {
        /// <summary>
        /// 商品发布的目标类目，必须是叶子类目
        /// </summary>
        public Nullable<long> CategoryId { get; set; }

        /// <summary>
        /// 发布商品的productId，如果tmall.product.match.schema.get获取到得字段为空，这个参数传入0，否则需要通过tmall.product.schema.match查询到得可用productId
        /// </summary>
        public Nullable<long> ProductId { get; set; }

        /// <summary>
        /// 根据tmall.item.add.schema.get生成的商品发布规则入参数据
        /// </summary>
        public string XmlData { get; set; }

        #region ITopRequest Members

        public override string GetApiName()
        {
            return "tmall.item.schema.add";
        }

        public override IDictionary<string, string> GetParameters()
        {
            TopDictionary parameters = new TopDictionary();
            parameters.Add("category_id", this.CategoryId);
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
            RequestValidator.ValidateRequired("category_id", this.CategoryId);
            RequestValidator.ValidateRequired("product_id", this.ProductId);
            RequestValidator.ValidateRequired("xml_data", this.XmlData);
        }

        #endregion
    }
}
