using System;
using System.Collections.Generic;
using Top.Api.Util;

namespace Top.Api.Request
{
    /// <summary>
    /// TOP API: taobao.wlb.wms.sku.get
    /// </summary>
    public class WlbWmsSkuGetRequest : BaseTopRequest<Top.Api.Response.WlbWmsSkuGetResponse>
    {
        /// <summary>
        /// 菜鸟商品ID,与itemcode必须有一个值不为空
        /// </summary>
        public string ItemCode { get; set; }

        /// <summary>
        /// 商家商品编码,与itemid必须有一个值不为空
        /// </summary>
        public string ItemId { get; set; }

        /// <summary>
        /// 货主ID
        /// </summary>
        public string OwnerUserId { get; set; }

        #region ITopRequest Members

        public override string GetApiName()
        {
            return "taobao.wlb.wms.sku.get";
        }

        public override IDictionary<string, string> GetParameters()
        {
            TopDictionary parameters = new TopDictionary();
            parameters.Add("item_code", this.ItemCode);
            parameters.Add("item_id", this.ItemId);
            parameters.Add("owner_user_id", this.OwnerUserId);
            if (this.otherParams != null)
            {
                parameters.AddAll(this.otherParams);
            }
            return parameters;
        }

        public override void Validate()
        {
        }

        #endregion
    }
}
