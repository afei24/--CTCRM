using System;
using System.Collections.Generic;
using Top.Api.Response;
using Top.Api.Util;

namespace Top.Api.Request
{
    /// <summary>
    /// TOP API: tmall.product.spec.pic.upload
    /// </summary>
    public class TmallProductSpecPicUploadRequest : BaseTopRequest<TmallProductSpecPicUploadResponse>, ITopUploadRequest<TmallProductSpecPicUploadResponse>
    {
        /// <summary>
        /// 上传的认证图片文件
        /// </summary>
        public FileItem CertifyPic { get; set; }

        /// <summary>
        /// 上传的认证图片的认证类型<br> 1：代表产品包装正面图<br> 2：代表完整产品资质<br> 3：代表产品包装反面图<br> 4：代表产品包装侧面图<br> 5：代表产品包装条形码特写<br> 6：代表特殊用途化妆品批准文号<br> 7：代表3C认证图标<br>
        /// </summary>
        public Nullable<long> CertifyType { get; set; }

        #region BaseTopRequest Members

        public override string GetApiName()
        {
            return "tmall.product.spec.pic.upload";
        }

        public override IDictionary<string, string> GetParameters()
        {
            TopDictionary parameters = new TopDictionary();
            parameters.Add("certify_type", this.CertifyType);
            if (this.otherParams != null)
            {
                parameters.AddAll(this.otherParams);
            }
            return parameters;
        }

        public override void Validate()
        {
            RequestValidator.ValidateRequired("certify_pic", this.CertifyPic);
            RequestValidator.ValidateRequired("certify_type", this.CertifyType);
        }

        #endregion

        #region ITopUploadRequest Members

        public IDictionary<string, FileItem> GetFileParameters()
        {
            IDictionary<string, FileItem> parameters = new Dictionary<string, FileItem>();
            parameters.Add("certify_pic", this.CertifyPic);
            return parameters;
        }

        #endregion
    }
}
