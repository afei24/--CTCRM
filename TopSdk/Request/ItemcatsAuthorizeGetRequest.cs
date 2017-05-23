using System;
using System.Collections.Generic;
using Top.Api.Util;

namespace Top.Api.Request
{
    /// <summary>
    /// TOP API: taobao.itemcats.authorize.get
    /// </summary>
    public class ItemcatsAuthorizeGetRequest : BaseTopRequest<Top.Api.Response.ItemcatsAuthorizeGetResponse>
    {
        /// <summary>
        /// 需要返回的字段。目前支持有：  brand.vid, brand.name,   item_cat.cid, item_cat.name, item_cat.status,item_cat.sort_order,item_cat.parent_cid,item_cat.is_parent,  xinpin_item_cat.cid,   xinpin_item_cat.name,   xinpin_item_cat.status,  xinpin_item_cat.sort_order,  xinpin_item_cat.parent_cid,  xinpin_item_cat.is_parent
        /// </summary>
        public string Fields { get; set; }

        #region ITopRequest Members

        public override string GetApiName()
        {
            return "taobao.itemcats.authorize.get";
        }

        public override IDictionary<string, string> GetParameters()
        {
            TopDictionary parameters = new TopDictionary();
            parameters.Add("fields", this.Fields);
            if (this.otherParams != null)
            {
                parameters.AddAll(this.otherParams);
            }
            return parameters;
        }

        public override void Validate()
        {
            RequestValidator.ValidateRequired("fields", this.Fields);
            RequestValidator.ValidateMaxListSize("fields", this.Fields, 20);
        }

        #endregion
    }
}
