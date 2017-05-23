using System;
using System.Collections.Generic;
using Top.Api.Util;

namespace Top.Api.Request
{
    /// <summary>
    /// TOP API: taobao.items.custom.get
    /// </summary>
    public class ItemsCustomGetRequest : BaseTopRequest<Top.Api.Response.ItemsCustomGetResponse>
    {
        /// <summary>
        /// 需返回的字段列表，参考：Item商品结构体说明，其中barcode、sku.barcode等条形码字段暂不支持；多个字段之间用“,”分隔。
        /// </summary>
        public string Fields { get; set; }

        /// <summary>
        /// 商品的外部商品ID，支持批量，最多不超过40个。
        /// </summary>
        public string OuterId { get; set; }

        #region ITopRequest Members

        public override string GetApiName()
        {
            return "taobao.items.custom.get";
        }

        public override IDictionary<string, string> GetParameters()
        {
            TopDictionary parameters = new TopDictionary();
            parameters.Add("fields", this.Fields);
            parameters.Add("outer_id", this.OuterId);
            if (this.otherParams != null)
            {
                parameters.AddAll(this.otherParams);
            }
            return parameters;
        }

        public override void Validate()
        {
            RequestValidator.ValidateRequired("fields", this.Fields);
            RequestValidator.ValidateRequired("outer_id", this.OuterId);
        }

        #endregion
    }
}
