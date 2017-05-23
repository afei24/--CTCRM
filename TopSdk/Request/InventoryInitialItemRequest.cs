using System;
using System.Collections.Generic;
using Top.Api.Util;

namespace Top.Api.Request
{
    /// <summary>
    /// TOP API: taobao.inventory.initial.item
    /// </summary>
    public class InventoryInitialItemRequest : BaseTopRequest<Top.Api.Response.InventoryInitialItemResponse>
    {
        /// <summary>
        /// 后端商品id
        /// </summary>
        public Nullable<long> ScItemId { get; set; }

        /// <summary>
        /// 商品初始库存信息： [{"storeCode":"必选,商家仓库编号","inventoryType":"可选，库存类型 1：正常,2：损坏,3：冻结,10：质押,11-20:用户自定义,默认为1","quantity":"必选,数量"}]
        /// </summary>
        public string StoreInventorys { get; set; }

        #region ITopRequest Members

        public override string GetApiName()
        {
            return "taobao.inventory.initial.item";
        }

        public override IDictionary<string, string> GetParameters()
        {
            TopDictionary parameters = new TopDictionary();
            parameters.Add("sc_item_id", this.ScItemId);
            parameters.Add("store_inventorys", this.StoreInventorys);
            if (this.otherParams != null)
            {
                parameters.AddAll(this.otherParams);
            }
            return parameters;
        }

        public override void Validate()
        {
            RequestValidator.ValidateRequired("sc_item_id", this.ScItemId);
            RequestValidator.ValidateRequired("store_inventorys", this.StoreInventorys);
        }

        #endregion
    }
}
