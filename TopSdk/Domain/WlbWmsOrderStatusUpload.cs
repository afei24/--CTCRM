using System;
using System.Xml.Serialization;

namespace Top.Api.Domain
{
    /// <summary>
    /// WlbWmsOrderStatusUpload Data Structure.
    /// </summary>
    [Serializable]
    public class WlbWmsOrderStatusUpload : TopObject
    {
        /// <summary>
        /// 操作内容：物流详情显示
        /// </summary>
        [XmlElement("content")]
        public string Content { get; set; }

        /// <summary>
        /// 扩展属性
        /// </summary>
        [XmlElement("features")]
        public string Features { get; set; }

        /// <summary>
        /// 操作时间
        /// </summary>
        [XmlElement("operate_date")]
        public string OperateDate { get; set; }

        /// <summary>
        /// 操作人
        /// </summary>
        [XmlElement("operator")]
        public string Operator { get; set; }

        /// <summary>
        /// 操作人联系方式
        /// </summary>
        [XmlElement("operator_contact")]
        public string OperatorContact { get; set; }

        /// <summary>
        /// 仓库订单编码
        /// </summary>
        [XmlElement("order_code")]
        public string OrderCode { get; set; }

        /// <summary>
        /// 仓库订单类型：201 交易出库单（销售出库） 502 换货出库单 503 补发出库单 302 调拨入库单 501退货入库单 （销退入库单 ） 504换货入库 601 采购入库单 901 退供出库单 301 调拨出库单
        /// </summary>
        [XmlElement("order_type")]
        public string OrderType { get; set; }

        /// <summary>
        /// 备注
        /// </summary>
        [XmlElement("remark")]
        public string Remark { get; set; }

        /// <summary>
        /// 单据状态（WMS_ACCEPT 接单成功，WMS_REJECT 接单失败，WMS_CONFIRMED 仓库生产完成, WMS_CANCEL 取消仓库发货，WMS_ ARRIVALREGISTER 到货登记, WMS_ONSALE 上架完成,WMS_RECEIVED 收货完成, WMS_PICKED 拣货完成, WMS_CHECKED 复核完成, WMS_PACKAGED 打包完成,TMS_SIGN 买家签收，TMS_REJECT 买家拒签）
        /// </summary>
        [XmlElement("status")]
        public string Status { get; set; }

        /// <summary>
        /// 仓库订单编码
        /// </summary>
        [XmlElement("store_order_code")]
        public string StoreOrderCode { get; set; }
    }
}
