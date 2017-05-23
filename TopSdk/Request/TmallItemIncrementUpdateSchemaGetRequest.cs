using System;
using System.Collections.Generic;
using Top.Api.Util;

namespace Top.Api.Request
{
    /// <summary>
    /// TOP API: tmall.item.increment.update.schema.get
    /// </summary>
    public class TmallItemIncrementUpdateSchemaGetRequest : BaseTopRequest<Top.Api.Response.TmallItemIncrementUpdateSchemaGetResponse>
    {
        /// <summary>
        /// 需要编辑的商品ID
        /// </summary>
        public Nullable<long> ItemId { get; set; }

        /// <summary>
        /// 如果入参xml_data指定了更新的字段，则只返回指定字段的规则（ISV如果功能性很强，如明确更新Title，请拼装好此字段以提升API整体性能）
        /// </summary>
        public string XmlData { get; set; }

        #region ITopRequest Members

        public override string GetApiName()
        {
            return "tmall.item.increment.update.schema.get";
        }

        public override IDictionary<string, string> GetParameters()
        {
            TopDictionary parameters = new TopDictionary();
            parameters.Add("item_id", this.ItemId);
            parameters.Add("xml_data", this.XmlData);
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
