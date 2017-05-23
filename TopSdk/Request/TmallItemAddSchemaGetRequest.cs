using System;
using System.Collections.Generic;
using Top.Api.Util;

namespace Top.Api.Request
{
    /// <summary>
    /// TOP API: tmall.item.add.schema.get
    /// </summary>
    public class TmallItemAddSchemaGetRequest : BaseTopRequest<Top.Api.Response.TmallItemAddSchemaGetResponse>
    {
        /// <summary>
        /// 商品发布的目标类目，必须是叶子类目
        /// </summary>
        public Nullable<long> CategoryId { get; set; }

        /// <summary>
        /// 正常接口调用时，请忽略这个参数或者填FALSE。这个参数提供给ISV对接Schema时，如果想先获取了解所有字段和规则，可以将此字段设置为true，product_id也就不需要提供了，设置为0即可
        /// </summary>
        public Nullable<bool> IsvInit { get; set; }

        /// <summary>
        /// 商品发布的目标product_id
        /// </summary>
        public Nullable<long> ProductId { get; set; }

        /// <summary>
        /// 发布商品类型，一口价填“b”，拍卖填"a"
        /// </summary>
        public string Type { get; set; }

        #region ITopRequest Members

        public override string GetApiName()
        {
            return "tmall.item.add.schema.get";
        }

        public override IDictionary<string, string> GetParameters()
        {
            TopDictionary parameters = new TopDictionary();
            parameters.Add("category_id", this.CategoryId);
            parameters.Add("isv_init", this.IsvInit);
            parameters.Add("product_id", this.ProductId);
            parameters.Add("type", this.Type);
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
        }

        #endregion
    }
}
