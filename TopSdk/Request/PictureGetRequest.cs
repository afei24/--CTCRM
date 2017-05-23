using System;
using System.Collections.Generic;
using Top.Api.Util;

namespace Top.Api.Request
{
    /// <summary>
    /// TOP API: taobao.picture.get
    /// </summary>
    public class PictureGetRequest : BaseTopRequest<Top.Api.Response.PictureGetResponse>
    {
        /// <summary>
        /// 图片使用，如果是pc宝贝detail使用，设置为client:computer，查询出来的图片是符合pc的宝贝detail显示的如果是手机宝贝detail使用，设置为client:phone，查询出来的图片是符合手机的宝贝detail显示的,默认值是全部
        /// </summary>
        public string ClientType { get; set; }

        /// <summary>
        /// 是否删除,unfroze代表没有删除
        /// </summary>
        public string Deleted { get; set; }

        /// <summary>
        /// 查询上传结束时间点,格式:yyyy-MM-dd HH:mm:ss
        /// </summary>
        public Nullable<DateTime> EndDate { get; set; }

        /// <summary>
        /// 是否获取https的链接
        /// </summary>
        public Nullable<bool> IsHttps { get; set; }

        /// <summary>
        /// 图片被修改的时间点，格式:yyyy-MM-dd HH:mm:ss。查询此修改时间点之后到目前的图片。
        /// </summary>
        public Nullable<DateTime> ModifiedTime { get; set; }

        /// <summary>
        /// 图片查询结果排序,time:desc按上传时间从晚到早(默认), time:asc按上传时间从早到晚,sizes:desc按图片从大到小，sizes:asc按图片从小到大,默认time:desc
        /// </summary>
        public string OrderBy { get; set; }

        /// <summary>
        /// 页码.传入值为1代表第一页,传入值为2代表第二页,依此类推,默认值为1
        /// </summary>
        public Nullable<long> PageNo { get; set; }

        /// <summary>
        /// 每页条数.每页返回最多返回100条,默认值40
        /// </summary>
        public Nullable<long> PageSize { get; set; }

        /// <summary>
        /// 图片分类ID
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
        /// 图片标题,最大长度50字符,中英文都算一字符
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// 图片url查询接口
        /// </summary>
        public string Urls { get; set; }

        #region ITopRequest Members

        public override string GetApiName()
        {
            return "taobao.picture.get";
        }

        public override IDictionary<string, string> GetParameters()
        {
            TopDictionary parameters = new TopDictionary();
            parameters.Add("client_type", this.ClientType);
            parameters.Add("deleted", this.Deleted);
            parameters.Add("end_date", this.EndDate);
            parameters.Add("is_https", this.IsHttps);
            parameters.Add("modified_time", this.ModifiedTime);
            parameters.Add("order_by", this.OrderBy);
            parameters.Add("page_no", this.PageNo);
            parameters.Add("page_size", this.PageSize);
            parameters.Add("picture_category_id", this.PictureCategoryId);
            parameters.Add("picture_id", this.PictureId);
            parameters.Add("start_date", this.StartDate);
            parameters.Add("title", this.Title);
            parameters.Add("urls", this.Urls);
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
