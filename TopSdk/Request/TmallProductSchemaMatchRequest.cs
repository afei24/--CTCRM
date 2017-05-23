using System;
using System.Collections.Generic;
using Top.Api.Util;

namespace Top.Api.Request
{
    /// <summary>
    /// TOP API: tmall.product.schema.match
    /// </summary>
    public class TmallProductSchemaMatchRequest : BaseTopRequest<Top.Api.Response.TmallProductSchemaMatchResponse>
    {
        /// <summary>
        /// 商品发布的目标类目，必须是叶子类目
        /// </summary>
        public Nullable<long> CategoryId { get; set; }

        /// <summary>
        /// 根据tmall.product.match.schema.get获取到的模板，ISV将需要的字段填充好相应的值结果XML。
        /// </summary>
        public string Propvalues { get; set; }

        #region ITopRequest Members

        public override string GetApiName()
        {
            return "tmall.product.schema.match";
        }

        public override IDictionary<string, string> GetParameters()
        {
            TopDictionary parameters = new TopDictionary();
            parameters.Add("category_id", this.CategoryId);
            parameters.Add("propvalues", this.Propvalues);
            if (this.otherParams != null)
            {
                parameters.AddAll(this.otherParams);
            }
            return parameters;
        }

        public override void Validate()
        {
            RequestValidator.ValidateRequired("category_id", this.CategoryId);
            RequestValidator.ValidateRequired("propvalues", this.Propvalues);
        }

        #endregion
    }
}
