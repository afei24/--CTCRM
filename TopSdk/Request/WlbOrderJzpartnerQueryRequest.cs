using System;
using System.Collections.Generic;
using Top.Api.Util;

namespace Top.Api.Request
{
    /// <summary>
    /// TOP API: taobao.wlb.order.jzpartner.query
    /// </summary>
    public class WlbOrderJzpartnerQueryRequest : BaseTopRequest<Top.Api.Response.WlbOrderJzpartnerQueryResponse>
    {
        /// <summary>
        /// serviceType表示查询所有的支持服务类型的服务商。 家装干线服务     11 家装干支服务     12 家装干支装服务   13 卫浴大件干线     14 卫浴大件干支     15 卫浴大件安装     16 地板干线         17 地板干支         18 地板安装         19 灯具安装         20 卫浴小件安装     21 （注：同一个服务商针对不同类型的serviceType是具有不同的tpCode的）
        /// </summary>
        public Nullable<long> ServiceType { get; set; }

        /// <summary>
        /// 淘宝交易订单号，如果不填写Tid则必须填写serviceType。如果填写Tid，则表明只需要查询对应订单的服务商。
        /// </summary>
        public Nullable<long> TaobaoTradeId { get; set; }

        #region ITopRequest Members

        public override string GetApiName()
        {
            return "taobao.wlb.order.jzpartner.query";
        }

        public override IDictionary<string, string> GetParameters()
        {
            TopDictionary parameters = new TopDictionary();
            parameters.Add("service_type", this.ServiceType);
            parameters.Add("taobao_trade_id", this.TaobaoTradeId);
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
