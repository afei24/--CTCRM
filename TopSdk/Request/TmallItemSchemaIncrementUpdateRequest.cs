using System;
using System.Collections.Generic;
using Top.Api.Util;

namespace Top.Api.Request
{
    /// <summary>
    /// TOP API: tmall.item.schema.increment.update
    /// </summary>
    public class TmallItemSchemaIncrementUpdateRequest : BaseTopRequest<Top.Api.Response.TmallItemSchemaIncrementUpdateResponse>
    {
        /// <summary>
        /// 需要编辑的商品ID
        /// </summary>
        public Nullable<long> ItemId { get; set; }

        /// <summary>
        /// 根据tmall.item.increment.update.schema.get生成的商品增量编辑规则入参数据。需要更新的字段，一定要在入参的XML重点update_fields字段中明确指明
        /// </summary>
        public string XmlData { get; set; }

        #region ITopRequest Members

        public override string GetApiName()
        {
            return "tmall.item.schema.increment.update";
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
            RequestValidator.ValidateRequired("xml_data", this.XmlData);
        }

        #endregion
    }
}
