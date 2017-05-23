using System;
using System.Collections.Generic;
using Top.Api.Response;
using Top.Api.Util;

namespace Top.Api.Request
{
    /// <summary>
    /// TOP API: taobao.ma.qrcode.upload
    /// </summary>
    public class MaQrcodeUploadRequest : BaseTopRequest<MaQrcodeUploadResponse>, ITopUploadRequest<MaQrcodeUploadResponse>
    {
        /// <summary>
        /// 二维码的图片后辍,目前只支持png,jpg,jpeg,gif四种
        /// </summary>
        public string Ext { get; set; }

        /// <summary>
        /// 图片名
        /// </summary>
        public string ImageName { get; set; }

        /// <summary>
        /// 0000
        /// </summary>
        public FileItem Imge { get; set; }

        #region BaseTopRequest Members

        public override string GetApiName()
        {
            return "taobao.ma.qrcode.upload";
        }

        public override IDictionary<string, string> GetParameters()
        {
            TopDictionary parameters = new TopDictionary();
            parameters.Add("ext", this.Ext);
            parameters.Add("image_name", this.ImageName);
            if (this.otherParams != null)
            {
                parameters.AddAll(this.otherParams);
            }
            return parameters;
        }

        public override void Validate()
        {
            RequestValidator.ValidateRequired("ext", this.Ext);
            RequestValidator.ValidateMaxLength("ext", this.Ext, 5);
            RequestValidator.ValidateRequired("image_name", this.ImageName);
            RequestValidator.ValidateRequired("imge", this.Imge);
        }

        #endregion

        #region ITopUploadRequest Members

        public IDictionary<string, FileItem> GetFileParameters()
        {
            IDictionary<string, FileItem> parameters = new Dictionary<string, FileItem>();
            parameters.Add("imge", this.Imge);
            return parameters;
        }

        #endregion
    }
}
