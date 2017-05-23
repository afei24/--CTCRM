using System;
using System.Collections.Generic;
using Top.Api.Util;

namespace Top.Api.Request
{
    /// <summary>
    /// TOP API: taobao.inventory.initial
    /// </summary>
    public class InventoryInitialRequest : BaseTopRequest<Top.Api.Response.InventoryInitialResponse>
    {
        /// <summary>
        /// 商品初始库存信息： [{"scItemId":"商品后端ID，如果有传scItemCode,参数可以为0","scItemCode":"商品商家编码","inventoryType":"库存类型  1：正常,2：损坏,3：冻结,10：质押,11-20:用户自定义","quantity":"数量"}]
        /// </summary>
        public string Items { get; set; }

        /// <summary>
        /// 商家仓库编码
        /// </summary>
        public string StoreCode { get; set; }

        #region ITopRequest Members

        public override string GetApiName()
        {
            return "taobao.inventory.initial";
        }

        public override IDictionary<string, string> GetParameters()
        {
            TopDictionary parameters = new TopDictionary();
            parameters.Add("items", this.Items);
            parameters.Add("store_code", this.StoreCode);
            if (this.otherParams != null)
            {
                parameters.AddAll(this.otherParams);
            }
            return parameters;
        }

        public override void Validate()
        {
            RequestValidator.ValidateRequired("items", this.Items);
            RequestValidator.ValidateRequired("store_code", this.StoreCode);
        }

        #endregion
    }
}
