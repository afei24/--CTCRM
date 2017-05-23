using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CTCRM.Entity
{
   public class PrintTradeOrder
    {
        /// <summary>
        /// 商家外部编码(可与商家外部系统对接)
        /// </summary>
        public string outer_iid { get; set; }
        /// <summary>
        /// 子订单级订单优惠金额。精确到2位小数;单位:元。如:200.07，表示:200元7分
        /// </summary>
        public string discount_fee { get; set; }
        /// <summary>
        /// 子订单实付金额。精确到2位小数，单位:元。如:200.07，表示:200元7分。对于多子订单的交易，计算公式如下：payment = price * num + adjust_fee - discount_fee ；单子订单交易，payment与主订单的payment一致，对于退款成功的子订单，由于主订单的优惠分摊金额，会造成该字段可能不为0.00元。建议 使用退款前的实付金额减去退款单中的实际退款金额计算
        /// </summary>
        public string payment { get; set; }
        /// <summary>
        /// 订单状态：平台定义
        /// </summary>
        public string status { get; set; }
        /// <summary>
        /// 商品图片的绝对路径
        /// </summary>
        public string pic_path { get; set; }
        /// <summary>
        /// SKU的值。如：机身颜色:黑色;手机套餐:官方标配
        /// </summary>
        public string sku_properties_name { get; set; }
        /// <summary>
        /// 手工调整金额.格式为:1.01;单位:元;精确到小数点后两位.
        /// </summary>
        public string adjust_fee { get; set; }
        /// <summary>
        /// 外部网店自己定义的Sku编号
        /// </summary>
        public string outer_sku_id { get; set; }
        /// <summary>
        /// 交易商品对应的类目ID
        /// </summary>
        public string cid { get; set; }

        /// <summary>
        /// 套餐的值。如：M8原装电池:便携支架:M8专用座充:莫凡保护袋
        /// </summary>
        public string item_meal_name { get; set; }
        /// <summary>
        /// 购买数量。取值范围:大于零的整数
        /// </summary>
        public string num { get; set; }
        /// <summary>
        /// 商品标题
        /// </summary>
        public string title { get; set; }
        /// <summary>
        /// 商品价格。精确到2位小数;单位:元。如:200.07
        /// </summary>
        public string price { get; set; }
        /// <summary>
        /// 子订单编号（唯一）
        /// </summary>
        public string oid { get; set; }
        /// <summary>
        /// 应付金额（商品价格 * 商品数量 + 手工调整金额 - 子订单级订单优惠金额）
        /// </summary>
        public string total_fee { get; set; }
        /// <summary>
        /// 商品数字ID
        /// </summary>
        public string num_iid { get; set; }
        /// <summary>
        /// 商品的最小库存单位Sku的id
        /// </summary>
        public string sku_id { get; set; }
        /// <summary>
        /// 卖家类型，可选值为：B（商城商家），C（普通卖家）
        /// </summary>
        public string seller_type { get; set; }

        /// <summary>
        /// 退款单ID
        /// </summary>
        public string refund_id { get; set; }

        /// <summary>
        /// 退款状态，取值范围：waitselleragree(等待卖家同意),refundsuccess(退款成功),refundclose(退款关闭),waitbuyermodify(待买家修改),waitbuyersend(等待买家退货),waitsellerreceive(等待卖家确认收货)
        /// </summary>
        public string refund_status { get; set; }
    }
}
