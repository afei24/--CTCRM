using System;
using System.Collections.Generic;
using Top.Api.Response;
using Top.Api.Util;

namespace Top.Api.Request
{
    /// <summary>
    /// TOP API: taobao.rp.returngoods.refuse
    /// </summary>
    public class RpReturngoodsRefuseRequest : BaseTopRequest<RpReturngoodsRefuseResponse>, ITopUploadRequest<RpReturngoodsRefuseResponse>
    {
        /// <summary>
        /// 退款编号
        /// </summary>
        public Nullable<long> RefundId { get; set; }

        /// <summary>
        /// 退款服务状态，售后或者售中
        /// </summary>
        public string RefundPhase { get; set; }

        /// <summary>
        /// 退款版本号
        /// </summary>
        public Nullable<long> RefundVersion { get; set; }

        /// <summary>
        /// 拒绝退货凭证图片，必须图片格式，大小不能超过5M
        /// </summary>
        public FileItem RefuseProof { get; set; }

        /// <summary>
        /// 拒绝原因编号，会提供拒绝原因列表供选择
        /// </summary>
        public Nullable<long> RefuseReasonId { get; set; }

        #region BaseTopRequest Members

        public override string GetApiName()
        {
            return "taobao.rp.returngoods.refuse";
        }

        public override IDictionary<string, string> GetParameters()
        {
            TopDictionary parameters = new TopDictionary();
            parameters.Add("refund_id", this.RefundId);
            parameters.Add("refund_phase", this.RefundPhase);
            parameters.Add("refund_version", this.RefundVersion);
            parameters.Add("refuse_reason_id", this.RefuseReasonId);
            if (this.otherParams != null)
            {
                parameters.AddAll(this.otherParams);
            }
            return parameters;
        }

        public override void Validate()
        {
            RequestValidator.ValidateRequired("refund_id", this.RefundId);
            RequestValidator.ValidateRequired("refund_phase", this.RefundPhase);
            RequestValidator.ValidateRequired("refund_version", this.RefundVersion);
            RequestValidator.ValidateRequired("refuse_proof", this.RefuseProof);
        }

        #endregion

        #region ITopUploadRequest Members

        public IDictionary<string, FileItem> GetFileParameters()
        {
            IDictionary<string, FileItem> parameters = new Dictionary<string, FileItem>();
            parameters.Add("refuse_proof", this.RefuseProof);
            return parameters;
        }

        #endregion
    }
}
