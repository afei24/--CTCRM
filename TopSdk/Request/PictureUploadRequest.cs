using System;
using System.Collections.Generic;
using Top.Api.Response;
using Top.Api.Util;

namespace Top.Api.Request
{
    /// <summary>
    /// TOP API: taobao.picture.upload
    /// </summary>
    public class PictureUploadRequest : BaseTopRequest<PictureUploadResponse>, ITopUploadRequest<PictureUploadResponse>
    {
        /// <summary>
        /// 图片上传的来源，有电脑版本宝贝发布，手机版本宝贝发布client:computer电脑版本宝贝使用，client:phone手机版本宝贝使用。注意：当client:phone时，图片限制为宽度在480-620之间，长度不能超过960，否则会报错。
        /// </summary>
        public string ClientType { get; set; }

        /// <summary>
        /// 包括后缀名的图片标题,不能为空，如Bule.jpg,有些卖家希望图片上传后取图片文件的默认名
        /// </summary>
        public string ImageInputTitle { get; set; }

        /// <summary>
        /// 图片二进制文件流,不能为空,允许png、jpg、gif图片格式,3M以内。
        /// </summary>
        public FileItem Img { get; set; }

        /// <summary>
        /// 是否获取https连接
        /// </summary>
        public Nullable<bool> IsHttps { get; set; }

        /// <summary>
        /// 图片分类ID，设置具体某个分类ID或设置0上传到默认分类，只能传入一个分类
        /// </summary>
        public Nullable<long> PictureCategoryId { get; set; }

        /// <summary>
        /// 如果此参数大于0，而且在后台能查到对应的图片，则此次上传为原图替换
        /// </summary>
        public Nullable<long> PictureId { get; set; }

        /// <summary>
        /// 图片标题,如果为空,传的图片标题就取去掉后缀名的image_input_title,超过50字符长度会截取50字符,重名会在标题末尾加"(1)";标题末尾已经有"(数字)"了，则数字加1
        /// </summary>
        public string Title { get; set; }

        #region BaseTopRequest Members

        public override string GetApiName()
        {
            return "taobao.picture.upload";
        }

        public override IDictionary<string, string> GetParameters()
        {
            TopDictionary parameters = new TopDictionary();
            parameters.Add("client_type", this.ClientType);
            parameters.Add("image_input_title", this.ImageInputTitle);
            parameters.Add("is_https", this.IsHttps);
            parameters.Add("picture_category_id", this.PictureCategoryId);
            parameters.Add("picture_id", this.PictureId);
            parameters.Add("title", this.Title);
            if (this.otherParams != null)
            {
                parameters.AddAll(this.otherParams);
            }
            return parameters;
        }

        public override void Validate()
        {
            RequestValidator.ValidateRequired("image_input_title", this.ImageInputTitle);
            RequestValidator.ValidateRequired("img", this.Img);
            RequestValidator.ValidateRequired("picture_category_id", this.PictureCategoryId);
            RequestValidator.ValidateMaxValue("picture_category_id", this.PictureCategoryId, 9223372036854775807);
            RequestValidator.ValidateMinValue("picture_category_id", this.PictureCategoryId, 0);
            RequestValidator.ValidateMaxValue("picture_id", this.PictureId, 9223372036854775807);
            RequestValidator.ValidateMinValue("picture_id", this.PictureId, 0);
        }

        #endregion

        #region ITopUploadRequest Members

        public IDictionary<string, FileItem> GetFileParameters()
        {
            IDictionary<string, FileItem> parameters = new Dictionary<string, FileItem>();
            parameters.Add("img", this.Img);
            return parameters;
        }

        #endregion
    }
}
