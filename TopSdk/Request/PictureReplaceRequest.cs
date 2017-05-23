using System;
using System.Collections.Generic;
using Top.Api.Response;
using Top.Api.Util;

namespace Top.Api.Request
{
    /// <summary>
    /// TOP API: taobao.picture.replace
    /// </summary>
    public class PictureReplaceRequest : BaseTopRequest<PictureReplaceResponse>, ITopUploadRequest<PictureReplaceResponse>
    {
        /// <summary>
        /// 图片二进制文件流,不能为空,允许png、jpg、gif图片格式
        /// </summary>
        public FileItem ImageData { get; set; }

        /// <summary>
        /// 要替换的图片的id，必须大于0
        /// </summary>
        public Nullable<long> PictureId { get; set; }

        #region BaseTopRequest Members

        public override string GetApiName()
        {
            return "taobao.picture.replace";
        }

        public override IDictionary<string, string> GetParameters()
        {
            TopDictionary parameters = new TopDictionary();
            parameters.Add("picture_id", this.PictureId);
            if (this.otherParams != null)
            {
                parameters.AddAll(this.otherParams);
            }
            return parameters;
        }

        public override void Validate()
        {
            RequestValidator.ValidateRequired("image_data", this.ImageData);
            RequestValidator.ValidateRequired("picture_id", this.PictureId);
        }

        #endregion

        #region ITopUploadRequest Members

        public IDictionary<string, FileItem> GetFileParameters()
        {
            IDictionary<string, FileItem> parameters = new Dictionary<string, FileItem>();
            parameters.Add("image_data", this.ImageData);
            return parameters;
        }

        #endregion
    }
}
