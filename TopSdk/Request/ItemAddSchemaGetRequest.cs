using System;
using System.Collections.Generic;
using Top.Api.Util;

namespace Top.Api.Request
{
    /// <summary>
    /// TOP API: taobao.item.add.schema.get
    /// </summary>
    public class ItemAddSchemaGetRequest : BaseTopRequest<Top.Api.Response.ItemAddSchemaGetResponse>
    {
        /// <summary>
        /// 发布宝贝的叶子类目id
        /// </summary>
        public Nullable<long> CategoryId { get; set; }

        #region ITopRequest Members

        public override string GetApiName()
        {
            return "taobao.item.add.schema.get";
        }

        public override IDictionary<string, string> GetParameters()
        {
            TopDictionary parameters = new TopDictionary();
            parameters.Add("category_id", this.CategoryId);
            if (this.otherParams != null)
            {
                parameters.AddAll(this.otherParams);
            }
            return parameters;
        }

        public override void Validate()
        {
            RequestValidator.ValidateRequired("category_id", this.CategoryId);
        }

        #endregion
    }
}
