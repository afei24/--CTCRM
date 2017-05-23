using System;
using System.Collections.Generic;
using Top.Api.Util;

namespace Top.Api.Request
{
    /// <summary>
    /// TOP API: taobao.item.update.schema.get
    /// </summary>
    public class ItemUpdateSchemaGetRequest : BaseTopRequest<Top.Api.Response.ItemUpdateSchemaGetResponse>
    {
        /// <summary>
        /// 商品类目id
        /// </summary>
        public Nullable<long> CategoryId { get; set; }

        /// <summary>
        /// 商品id
        /// </summary>
        public Nullable<long> ItemId { get; set; }

        #region ITopRequest Members

        public override string GetApiName()
        {
            return "taobao.item.update.schema.get";
        }

        public override IDictionary<string, string> GetParameters()
        {
            TopDictionary parameters = new TopDictionary();
            parameters.Add("category_id", this.CategoryId);
            parameters.Add("item_id", this.ItemId);
            if (this.otherParams != null)
            {
                parameters.AddAll(this.otherParams);
            }
            return parameters;
        }

        public override void Validate()
        {
            RequestValidator.ValidateRequired("item_id", this.ItemId);
        }

        #endregion
    }
}
