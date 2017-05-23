using System;
using System.Collections.Generic;
using Top.Api.Util;

namespace Top.Api.Request
{
    /// <summary>
    /// TOP API: taobao.region.warehouse.manage
    /// </summary>
    public class RegionWarehouseManageRequest : BaseTopRequest<Top.Api.Response.RegionWarehouseManageResponse>
    {
        /// <summary>
        /// 可映射三级地址,例: 广东省
        /// </summary>
        public string Regions { get; set; }

        /// <summary>
        /// 仓库编码
        /// </summary>
        public string StoreCode { get; set; }

        #region ITopRequest Members

        public override string GetApiName()
        {
            return "taobao.region.warehouse.manage";
        }

        public override IDictionary<string, string> GetParameters()
        {
            TopDictionary parameters = new TopDictionary();
            parameters.Add("regions", this.Regions);
            parameters.Add("store_code", this.StoreCode);
            if (this.otherParams != null)
            {
                parameters.AddAll(this.otherParams);
            }
            return parameters;
        }

        public override void Validate()
        {
            RequestValidator.ValidateRequired("regions", this.Regions);
            RequestValidator.ValidateMaxListSize("regions", this.Regions, 20);
            RequestValidator.ValidateRequired("store_code", this.StoreCode);
        }

        #endregion
    }
}
