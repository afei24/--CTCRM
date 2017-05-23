using System;
using System.Collections.Generic;
using Top.Api.Util;

namespace Top.Api.Request
{
    /// <summary>
    /// TOP API: taobao.wlb.wms.return.bill.get
    /// </summary>
    public class WlbWmsReturnBillGetRequest : BaseTopRequest<Top.Api.Response.WlbWmsReturnBillGetResponse>
    {
        /// <summary>
        /// 菜鸟订单编码，查询单个订单时orderCode与cnOrderCode必须有一个参数值不为空，两个参数都赋值时，以cnOrderCode值检索数据
        /// </summary>
        public string CnOrderCode { get; set; }

        /// <summary>
        /// ERP订单编码，查询单个订单时orderCode与cnOrderCode必须有一个参数值不为空，两个参数都赋值时，以cnOrderCode值检索数据
        /// </summary>
        public string OrderCode { get; set; }

        #region ITopRequest Members

        public override string GetApiName()
        {
            return "taobao.wlb.wms.return.bill.get";
        }

        public override IDictionary<string, string> GetParameters()
        {
            TopDictionary parameters = new TopDictionary();
            parameters.Add("cn_order_code", this.CnOrderCode);
            parameters.Add("order_code", this.OrderCode);
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
