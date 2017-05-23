using System;
using System.Collections.Generic;
using Top.Api.Response;
using Top.Api.Util;

namespace Top.Api.Request
{
    /// <summary>
    /// TOP API: taobao.item.propimg.upload
    /// </summary>
    public class ItemPropimgUploadRequest : BaseTopRequest<ItemPropimgUploadResponse>, ITopUploadRequest<ItemPropimgUploadResponse>
    {
        /// <summary>
        /// 属性图片ID。如果是新增不需要填写
        /// </summary>
        public Nullable<long> Id { get; set; }

        /// <summary>
        /// 属性图片内容。类型:JPG,GIF;图片大小不超过:3M
        /// </summary>
        public FileItem Image { get; set; }

        /// <summary>
        /// 商品数字ID，必选
        /// </summary>
        public Nullable<long> NumIid { get; set; }

        /// <summary>
        /// 图片位置
        /// </summary>
        public Nullable<long> Position { get; set; }

        /// <summary>
        /// 属性列表。调用taobao.itemprops.get获取类目属性，属性必须是颜色属性，再用taobao.itempropvalues.get取得vid。格式:pid:vid。
        /// </summary>
        public string Properties { get; set; }

        #region BaseTopRequest Members

        public override string GetApiName()
        {
            return "taobao.item.propimg.upload";
        }

        public override IDictionary<string, string> GetParameters()
        {
            TopDictionary parameters = new TopDictionary();
            parameters.Add("id", this.Id);
            parameters.Add("num_iid", this.NumIid);
            parameters.Add("position", this.Position);
            parameters.Add("properties", this.Properties);
            if (this.otherParams != null)
            {
                parameters.AddAll(this.otherParams);
            }
            return parameters;
        }

        public override void Validate()
        {
            RequestValidator.ValidateMaxLength("image", this.Image, 3145728);
            RequestValidator.ValidateRequired("num_iid", this.NumIid);
            RequestValidator.ValidateMinValue("num_iid", this.NumIid, 0);
            RequestValidator.ValidateRequired("properties", this.Properties);
        }

        #endregion

        #region ITopUploadRequest Members

        public IDictionary<string, FileItem> GetFileParameters()
        {
            IDictionary<string, FileItem> parameters = new Dictionary<string, FileItem>();
            parameters.Add("image", this.Image);
            return parameters;
        }

        #endregion
    }
}
