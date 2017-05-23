using System;
using System.Xml.Serialization;

namespace Top.Api.Domain
{
    /// <summary>
    /// WlbInventory Data Structure.
    /// </summary>
    [Serializable]
    public class WlbInventory : TopObject
    {
        /// <summary>
        /// 商品ID
        /// </summary>
        [XmlElement("item_id")]
        public long ItemId { get; set; }

        /// <summary>
        /// 冻结(锁定)数量，用来跟踪库存的中间状态，比如前台销售了1件商品，这时lock加1，当商品出库的时候lock再减回去
        /// </summary>
        [XmlElement("lock_quantity")]
        public long LockQuantity { get; set; }

        /// <summary>
        /// 库存占用数，两部分组成：  1.交易占用  买家付款后在仓库发货出库前会占用库存。  2.非交易出库占用  出库单创建仍未出库时会将库存占用
        /// </summary>
        [XmlElement("occupy_quantity")]
        public long OccupyQuantity { get; set; }

        /// <summary>
        /// 可销库存数量(库存总数-拍下预扣数-占用数)
        /// </summary>
        [XmlElement("quantity")]
        public long Quantity { get; set; }

        /// <summary>
        /// 买家拍下但是没有付款的预扣数量，超过一定时间没有付款会自动释放。为防止超卖，这部分库存不可售，也暂不能出库。
        /// </summary>
        [XmlElement("reserve_quantity")]
        public long ReserveQuantity { get; set; }

        /// <summary>
        /// 仓库编码，关联到仓库类型服务的编码非托管库存(卖家自己管理的库存，物流宝不可见又称自有库存)的所在仓库编码: STORE_SYS_PRIVATE
        /// </summary>
        [XmlElement("store_code")]
        public string StoreCode { get; set; }

        /// <summary>
        /// VENDIBLE--可销售库存  FREEZE--冻结库存  ONWAY--在途库存  DEFECT--残次品库存
        /// </summary>
        [XmlElement("type")]
        public string Type { get; set; }

        /// <summary>
        /// 货主ID
        /// </summary>
        [XmlElement("user_id")]
        public long UserId { get; set; }
    }
}
