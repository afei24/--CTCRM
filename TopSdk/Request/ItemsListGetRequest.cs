using System;
using System.Collections.Generic;
using Top.Api.Util;

namespace Top.Api.Request
{
    /// <summary>
    /// TOP API: taobao.items.list.get
    /// </summary>
    public class ItemsListGetRequest : BaseTopRequest<Top.Api.Response.ItemsListGetResponse>
    {
        /// <summary>
        /// 需要返回的商品对象字段。可选值：Item商品结构体中字段均可返回(其中item_weight,item_size,sold_quantity暂未返回)；多个字段用“,”分隔。如果想返回整个子对象，fields设置相应字段，如itemimg；如果想返回子对象里面的某个字段，那字段设为某个值，如itemimg.url。
        /// </summary>
        public string Fields { get; set; }

        /// <summary>
        /// 商品数字id列表，多个num_iid用逗号隔开，一次不超过20个。
        /// </summary>
        public string NumIids { get; set; }

        #region ITopRequest Members

        public override string GetApiName()
        {
            return "taobao.items.list.get";
        }

        public override IDictionary<string, string> GetParameters()
        {
            TopDictionary parameters = new TopDictionary();
            parameters.Add("fields", this.Fields);
            parameters.Add("num_iids", this.NumIids);
            if (this.otherParams != null)
            {
                parameters.AddAll(this.otherParams);
            }
            return parameters;
        }

        public override void Validate()
        {
            RequestValidator.ValidateRequired("fields", this.Fields);
            RequestValidator.ValidateMaxListSize("fields", this.Fields, 1000);
            RequestValidator.ValidateMaxListSize("num_iids", this.NumIids, 1000);
        }

        #endregion
    }
}
