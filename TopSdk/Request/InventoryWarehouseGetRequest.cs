using System;
using System.Collections.Generic;
using Top.Api.Util;

namespace Top.Api.Request
{
    /// <summary>
    /// TOP API: taobao.inventory.warehouse.get
    /// </summary>
    public class InventoryWarehouseGetRequest : BaseTopRequest<Top.Api.Response.InventoryWarehouseGetResponse>
    {
        /// <summary>
        /// 仓库编码
        /// </summary>
        public string StoreCode { get; set; }

        #region ITopRequest Members

        public override string GetApiName()
        {
            return "taobao.inventory.warehouse.get";
        }

        public override IDictionary<string, string> GetParameters()
        {
            TopDictionary parameters = new TopDictionary();
            parameters.Add("store_code", this.StoreCode);
            if (this.otherParams != null)
            {
                parameters.AddAll(this.otherParams);
            }
            return parameters;
        }

        public override void Validate()
        {
            RequestValidator.ValidateRequired("store_code", this.StoreCode);
        }

        #endregion
    }
}
