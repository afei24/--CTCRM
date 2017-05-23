using System;
using System.Collections.Generic;
using Top.Api.Util;

namespace Top.Api.Request
{
    /// <summary>
    /// TOP API: taobao.fenxiao.dealer.requisitionorder.remark.update
    /// </summary>
    public class FenxiaoDealerRequisitionorderRemarkUpdateRequest : BaseTopRequest<Top.Api.Response.FenxiaoDealerRequisitionorderRemarkUpdateResponse>
    {
        /// <summary>
        /// 经销采购单ID
        /// </summary>
        public Nullable<long> DealerOrderId { get; set; }

        /// <summary>
        /// 备注留言，可为空
        /// </summary>
        public string SupplierMemo { get; set; }

        /// <summary>
        /// 旗子的标记，必选。  1-5之间的数字。  非1-5之间，都采用1作为默认。  1:红色  2:黄色  3:绿色  4:蓝色  5:粉红色
        /// </summary>
        public Nullable<long> SupplierMemoFlag { get; set; }

        #region ITopRequest Members

        public override string GetApiName()
        {
            return "taobao.fenxiao.dealer.requisitionorder.remark.update";
        }

        public override IDictionary<string, string> GetParameters()
        {
            TopDictionary parameters = new TopDictionary();
            parameters.Add("dealer_order_id", this.DealerOrderId);
            parameters.Add("supplier_memo", this.SupplierMemo);
            parameters.Add("supplier_memo_flag", this.SupplierMemoFlag);
            if (this.otherParams != null)
            {
                parameters.AddAll(this.otherParams);
            }
            return parameters;
        }

        public override void Validate()
        {
            RequestValidator.ValidateRequired("dealer_order_id", this.DealerOrderId);
            RequestValidator.ValidateRequired("supplier_memo_flag", this.SupplierMemoFlag);
            RequestValidator.ValidateMaxValue("supplier_memo_flag", this.SupplierMemoFlag, 5);
            RequestValidator.ValidateMinValue("supplier_memo_flag", this.SupplierMemoFlag, 1);
        }

        #endregion
    }
}
