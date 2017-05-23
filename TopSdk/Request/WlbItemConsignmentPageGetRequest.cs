using System;
using System.Collections.Generic;
using Top.Api.Util;

namespace Top.Api.Request
{
    /// <summary>
    /// TOP API: taobao.wlb.item.consignment.page.get
    /// </summary>
    public class WlbItemConsignmentPageGetRequest : BaseTopRequest<Top.Api.Response.WlbItemConsignmentPageGetResponse>
    {
        /// <summary>
        /// 代销商宝贝id
        /// </summary>
        public Nullable<long> IcItemId { get; set; }

        /// <summary>
        /// 供应商商品id
        /// </summary>
        public Nullable<long> OwnerItemId { get; set; }

        /// <summary>
        /// 供应商用户昵称
        /// </summary>
        public string OwnerUserNick { get; set; }

        #region ITopRequest Members

        public override string GetApiName()
        {
            return "taobao.wlb.item.consignment.page.get";
        }

        public override IDictionary<string, string> GetParameters()
        {
            TopDictionary parameters = new TopDictionary();
            parameters.Add("ic_item_id", this.IcItemId);
            parameters.Add("owner_item_id", this.OwnerItemId);
            parameters.Add("owner_user_nick", this.OwnerUserNick);
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
