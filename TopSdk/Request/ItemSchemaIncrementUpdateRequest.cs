using System;
using System.Collections.Generic;
using Top.Api.Util;

namespace Top.Api.Request
{
    /// <summary>
    /// TOP API: taobao.item.schema.increment.update
    /// </summary>
    public class ItemSchemaIncrementUpdateRequest : BaseTopRequest<Top.Api.Response.ItemSchemaIncrementUpdateResponse>
    {
        /// <summary>
        /// 商品类目id
        /// </summary>
        public Nullable<long> CategoryId { get; set; }

        /// <summary>
        /// 商品id
        /// </summary>
        public Nullable<long> ItemId { get; set; }

        /// <summary>
        /// 修改字段
        /// </summary>
        public string Parameters { get; set; }

        #region ITopRequest Members

        public override string GetApiName()
        {
            return "taobao.item.schema.increment.update";
        }

        public override IDictionary<string, string> GetParameters()
        {
            TopDictionary parameters = new TopDictionary();
            parameters.Add("category_id", this.CategoryId);
            parameters.Add("item_id", this.ItemId);
            parameters.Add("parameters", this.Parameters);
            if (this.otherParams != null)
            {
                parameters.AddAll(this.otherParams);
            }
            return parameters;
        }

        public override void Validate()
        {
            RequestValidator.ValidateRequired("item_id", this.ItemId);
            RequestValidator.ValidateRequired("parameters", this.Parameters);
        }

        #endregion
    }
}
