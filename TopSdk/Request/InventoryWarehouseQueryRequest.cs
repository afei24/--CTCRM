using System;
using System.Collections.Generic;
using Top.Api.Util;

namespace Top.Api.Request
{
    /// <summary>
    /// TOP API: taobao.inventory.warehouse.query
    /// </summary>
    public class InventoryWarehouseQueryRequest : BaseTopRequest<Top.Api.Response.InventoryWarehouseQueryResponse>
    {
        /// <summary>
        /// 页码
        /// </summary>
        public Nullable<long> PageNo { get; set; }

        /// <summary>
        /// 页大小
        /// </summary>
        public Nullable<long> PageSize { get; set; }

        #region ITopRequest Members

        public override string GetApiName()
        {
            return "taobao.inventory.warehouse.query";
        }

        public override IDictionary<string, string> GetParameters()
        {
            TopDictionary parameters = new TopDictionary();
            parameters.Add("page_no", this.PageNo);
            parameters.Add("page_size", this.PageSize);
            if (this.otherParams != null)
            {
                parameters.AddAll(this.otherParams);
            }
            return parameters;
        }

        public override void Validate()
        {
            RequestValidator.ValidateRequired("page_no", this.PageNo);
            RequestValidator.ValidateRequired("page_size", this.PageSize);
        }

        #endregion
    }
}
