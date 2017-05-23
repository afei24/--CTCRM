using System;
using System.Collections.Generic;
using Top.Api.Util;

namespace Top.Api.Request
{
    /// <summary>
    /// TOP API: taobao.item.get
    /// </summary>
    public class ItemGetRequest : BaseTopRequest<Top.Api.Response.ItemGetResponse>
    {
        /// <summary>
        /// 需要返回的商品对象字段，如title,price,desc_modules等，。可选值：Item商品结构体中所有字段均可返回（除sold_quantity）；多个字段用“,”分隔。<br>新增返回字段：item_weight(商品的重量，格式为数字，包含小数)、item_size(商品的体积，格式为数字，包含小数)、change_prop（商品基础色数据）
        /// </summary>
        public string Fields { get; set; }

        /// <summary>
        /// 商品数字ID
        /// </summary>
        public Nullable<long> NumIid { get; set; }

        #region ITopRequest Members

        public override string GetApiName()
        {
            return "taobao.item.get";
        }

        public override IDictionary<string, string> GetParameters()
        {
            TopDictionary parameters = new TopDictionary();
            parameters.Add("fields", this.Fields);
            parameters.Add("num_iid", this.NumIid);
            if (this.otherParams != null)
            {
                parameters.AddAll(this.otherParams);
            }
            return parameters;
        }

        public override void Validate()
        {
            RequestValidator.ValidateRequired("fields", this.Fields);
            RequestValidator.ValidateMinValue("num_iid", this.NumIid, 1);
        }

        #endregion
    }
}
