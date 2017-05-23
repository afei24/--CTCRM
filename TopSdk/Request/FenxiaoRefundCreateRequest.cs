using System;
using System.Collections.Generic;
using Top.Api.Util;

namespace Top.Api.Request
{
    /// <summary>
    /// TOP API: taobao.fenxiao.refund.create
    /// </summary>
    public class FenxiaoRefundCreateRequest : BaseTopRequest<Top.Api.Response.FenxiaoRefundCreateResponse>
    {
        /// <summary>
        /// 是否退货，只有子采购单发货后，才能申请退货
        /// </summary>
        public Nullable<bool> IsReturnGoods { get; set; }

        /// <summary>
        /// 此条子采购单是否退邮费，邮费要记在最后一笔申请退款的子单上面
        /// </summary>
        public Nullable<bool> IsReturnPostFee { get; set; }

        /// <summary>
        /// 退款说明,2-200字
        /// </summary>
        public string RefundDesc { get; set; }

        /// <summary>
        /// 发货前：  1、缺货，2、拍错商品，3、商品缺少所需样式，4、协商一致退款，5、未及时发货，0、其它  发货后：  经销：  1、商品质量问题，2、收到的商品不符，3、协商一致退款，4、一直未收到货，5、退还多付邮费，6、折扣、赠品、发票等问题，0、其它  代销：  1、商品质量问题，2、收到的商品不符，3、协商一致退款，4、买家一直未收到货，5、退还多付邮费，6、折扣、赠品、发票等问题，0、其它
        /// </summary>
        public Nullable<long> RefundReasonId { get; set; }

        /// <summary>
        /// 需要退款的金额，单位为分
        /// </summary>
        public Nullable<long> ReturnFee { get; set; }

        /// <summary>
        /// 需要创建退款的子采购单id
        /// </summary>
        public Nullable<long> SubOrderId { get; set; }

        #region ITopRequest Members

        public override string GetApiName()
        {
            return "taobao.fenxiao.refund.create";
        }

        public override IDictionary<string, string> GetParameters()
        {
            TopDictionary parameters = new TopDictionary();
            parameters.Add("is_return_goods", this.IsReturnGoods);
            parameters.Add("is_return_post_fee", this.IsReturnPostFee);
            parameters.Add("refund_desc", this.RefundDesc);
            parameters.Add("refund_reason_id", this.RefundReasonId);
            parameters.Add("return_fee", this.ReturnFee);
            parameters.Add("sub_order_id", this.SubOrderId);
            if (this.otherParams != null)
            {
                parameters.AddAll(this.otherParams);
            }
            return parameters;
        }

        public override void Validate()
        {
            RequestValidator.ValidateRequired("is_return_goods", this.IsReturnGoods);
            RequestValidator.ValidateRequired("is_return_post_fee", this.IsReturnPostFee);
            RequestValidator.ValidateRequired("refund_desc", this.RefundDesc);
            RequestValidator.ValidateRequired("refund_reason_id", this.RefundReasonId);
            RequestValidator.ValidateRequired("return_fee", this.ReturnFee);
            RequestValidator.ValidateRequired("sub_order_id", this.SubOrderId);
        }

        #endregion
    }
}
