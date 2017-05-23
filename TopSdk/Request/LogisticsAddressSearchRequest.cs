using System;
using System.Collections.Generic;
using Top.Api.Util;

namespace Top.Api.Request
{
    /// <summary>
    /// TOP API: taobao.logistics.address.search
    /// </summary>
    public class LogisticsAddressSearchRequest : BaseTopRequest<Top.Api.Response.LogisticsAddressSearchResponse>
    {
        /// <summary>
        /// 可选，参数列表如下：<br><font color='red'>no_def:查询非默认地址<br>get_def:查询默认取货地址，也即对应卖家后台地址库中发货地址（send_def暂不起作用）<br>cancel_def:查询默认退货地址<br>缺省此参数时，查询所有当前用户的地址库</font>
        /// </summary>
        public string Rdef { get; set; }

        #region ITopRequest Members

        public override string GetApiName()
        {
            return "taobao.logistics.address.search";
        }

        public override IDictionary<string, string> GetParameters()
        {
            TopDictionary parameters = new TopDictionary();
            parameters.Add("rdef", this.Rdef);
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
