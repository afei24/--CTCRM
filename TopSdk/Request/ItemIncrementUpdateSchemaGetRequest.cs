using System;
using System.Collections.Generic;
using Top.Api.Util;

namespace Top.Api.Request
{
    /// <summary>
    /// TOP API: taobao.item.increment.update.schema.get
    /// </summary>
    public class ItemIncrementUpdateSchemaGetRequest : BaseTopRequest<Top.Api.Response.ItemIncrementUpdateSchemaGetResponse>
    {
        /// <summary>
        /// 宝贝类目id
        /// </summary>
        public Nullable<long> CategoryId { get; set; }

        /// <summary>
        /// 宝贝id
        /// </summary>
        public Nullable<long> ItemId { get; set; }

        /// <summary>
        /// 修改字段
        /// </summary>
        public string UpdateFields { get; set; }

        #region ITopRequest Members

        public override string GetApiName()
        {
            return "taobao.item.increment.update.schema.get";
        }

        public override IDictionary<string, string> GetParameters()
        {
            TopDictionary parameters = new TopDictionary();
            parameters.Add("category_id", this.CategoryId);
            parameters.Add("item_id", this.ItemId);
            parameters.Add("update_fields", this.UpdateFields);
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
