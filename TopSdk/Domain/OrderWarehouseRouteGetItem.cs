using System;
using System.Xml.Serialization;

namespace Top.Api.Domain
{
    /// <summary>
    /// OrderWarehouseRouteGetItem Data Structure.
    /// </summary>
    [Serializable]
    public class OrderWarehouseRouteGetItem : TopObject
    {
        /// <summary>
        /// 菜鸟订单编码 当订单路由到菜鸟仓发货时，生成此单号。等待路由仓或由商家仓发货的订单，此单号为空。格式LBX+数字
        /// </summary>
        [XmlElement("cn_order_code")]
        public string CnOrderCode { get; set; }

        /// <summary>
        /// 通知仓库此订单明细的商品应发数量
        /// </summary>
        [XmlElement("item_qty")]
        public long ItemQty { get; set; }

        /// <summary>
        /// ERP订单明细编码或者子交易单号
        /// </summary>
        [XmlElement("order_item_id")]
        public string OrderItemId { get; set; }

        /// <summary>
        /// 订单路由状态 状态值： WAIT_ROUTE 待路由仓 ROUTE_TO_CN 路由到菜鸟仓发货 ROUTE_TO_ERP 路由到商家仓发货。 STOP_ROUTE 终止分仓，如订单已取消时，不再发货。 注：待路由仓状态表示未做路由，不确定由哪个仓库发货，可与5分钟后再次查询
        /// </summary>
        [XmlElement("rout_status")]
        public string RoutStatus { get; set; }

        /// <summary>
        /// 仓库编码 当订单路由到菜鸟仓发货时输出菜鸟仓编码。等待路由仓或由商家仓发货的订单，此内容为空。
        /// </summary>
        [XmlElement("store_code")]
        public string StoreCode { get; set; }
    }
}
