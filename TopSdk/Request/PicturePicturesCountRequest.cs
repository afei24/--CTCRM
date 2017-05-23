using System;
using System.Collections.Generic;
using Top.Api.Util;

namespace Top.Api.Request
{
    /// <summary>
    /// TOP API: taobao.picture.pictures.count
    /// </summary>
    public class PicturePicturesCountRequest : BaseTopRequest<Top.Api.Response.PicturePicturesCountResponse>
    {
        /// <summary>
        /// 图片使用，如果是pc宝贝detail使用，设置为client:computer，查询出来的图片是符合pc的宝贝detail显示的如果是手机宝贝detail使用，设置为client:phone，查询出来的图片是符合手机的宝贝detail显示的,默认值是全部
        /// </summary>
        public string ClientType { get; set; }

        /// <summary>
        /// 是否删除,undeleted代表没有删除,deleted表示删除
        /// </summary>
        public string Deleted { get; set; }

        /// <summary>
        /// 查询上传结束时间点,格式:yyyy-MM-dd HH:mm:ss
        /// </summary>
        public Nullable<DateTime> EndDate { get; set; }

        /// <summary>
        /// 图片分类
        /// </summary>
        public Nullable<long> PictureCategoryId { get; set; }

        /// <summary>
        /// 图片ID
        /// </summary>
        public Nullable<long> PictureId { get; set; }

        /// <summary>
        /// 查询上传开始时间点,格式:yyyy-MM-dd HH:mm:ss
        /// </summary>
        public Nullable<DateTime> StartDate { get; set; }

        /// <summary>
        /// 图片被修改的时间点，格式:yyyy-MM-dd HH:mm:ss。查询此修改时间点之后到目前的图片。
        /// </summary>
        public Nullable<DateTime> StartModifiedDate { get; set; }

        /// <summary>
        /// 文件名
        /// </summary>
        public string Title { get; set; }

        #region ITopRequest Members

        public override string GetApiName()
        {
            return "taobao.picture.pictures.count";
        }

        public override IDictionary<string, string> GetParameters()
        {
            TopDictionary parameters = new TopDictionary();
            parameters.Add("client_type", this.ClientType);
            parameters.Add("deleted", this.Deleted);
            parameters.Add("end_date", this.EndDate);
            parameters.Add("picture_category_id", this.PictureCategoryId);
            parameters.Add("picture_id", this.PictureId);
            parameters.Add("start_date", this.StartDate);
            parameters.Add("start_modified_date", this.StartModifiedDate);
            parameters.Add("title", this.Title);
            if (this.otherParams != null)
            {
                parameters.AddAll(this.otherParams);
            }
            return parameters;
        }

        public override void Validate()
        {
        }

        #endregion
    }
}
