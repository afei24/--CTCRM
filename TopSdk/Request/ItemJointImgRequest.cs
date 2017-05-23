using System;
using System.Collections.Generic;
using Top.Api.Util;

namespace Top.Api.Request
{
    /// <summary>
    /// TOP API: taobao.item.joint.img
    /// </summary>
    public class ItemJointImgRequest : BaseTopRequest<Top.Api.Response.ItemJointImgResponse>
    {
        /// <summary>
        /// 商品图片id(如果是更新图片，则需要传该参数)
        /// </summary>
        public Nullable<long> Id { get; set; }

        /// <summary>
        /// 上传的图片是否关联为商品主图
        /// </summary>
        public Nullable<bool> IsMajor { get; set; }

        /// <summary>
        /// 商品数字ID，必选
        /// </summary>
        public Nullable<long> NumIid { get; set; }

        /// <summary>
        /// 图片URL,图片空间图片的相对地址
        /// </summary>
        public string PicPath { get; set; }

        /// <summary>
        /// 图片序号
        /// </summary>
        public Nullable<long> Position { get; set; }

        #region ITopRequest Members

        public override string GetApiName()
        {
            return "taobao.item.joint.img";
        }

        public override IDictionary<string, string> GetParameters()
        {
            TopDictionary parameters = new TopDictionary();
            parameters.Add("id", this.Id);
            parameters.Add("is_major", this.IsMajor);
            parameters.Add("num_iid", this.NumIid);
            parameters.Add("pic_path", this.PicPath);
            parameters.Add("position", this.Position);
            if (this.otherParams != null)
            {
                parameters.AddAll(this.otherParams);
            }
            return parameters;
        }

        public override void Validate()
        {
            RequestValidator.ValidateRequired("num_iid", this.NumIid);
            RequestValidator.ValidateMinValue("num_iid", this.NumIid, 0);
            RequestValidator.ValidateRequired("pic_path", this.PicPath);
        }

        #endregion
    }
}
