using System;
using System.Collections.Generic;
using Top.Api.Util;

namespace Top.Api.Request
{
    /// <summary>
    /// TOP API: taobao.item.img.delete
    /// </summary>
    public class ItemImgDeleteRequest : BaseTopRequest<Top.Api.Response.ItemImgDeleteResponse>
    {
        /// <summary>
        /// 商品图片ID
        /// </summary>
        public Nullable<long> Id { get; set; }

        /// <summary>
        /// 标记是否要删除第6张图，因为第6张图与普通商品图片不是存储在同一个位置的无图片ID，所以要通过一个标记来判断是否为第6张图，目前第6张图业务主要用在女装业务下
        /// </summary>
        public Nullable<bool> IsSixthPic { get; set; }

        /// <summary>
        /// 商品数字ID
        /// </summary>
        public Nullable<long> NumIid { get; set; }

        #region ITopRequest Members

        public override string GetApiName()
        {
            return "taobao.item.img.delete";
        }

        public override IDictionary<string, string> GetParameters()
        {
            TopDictionary parameters = new TopDictionary();
            parameters.Add("id", this.Id);
            parameters.Add("is_sixth_pic", this.IsSixthPic);
            parameters.Add("num_iid", this.NumIid);
            if (this.otherParams != null)
            {
                parameters.AddAll(this.otherParams);
            }
            return parameters;
        }

        public override void Validate()
        {
            RequestValidator.ValidateRequired("id", this.Id);
            RequestValidator.ValidateMinValue("id", this.Id, 1);
            RequestValidator.ValidateRequired("num_iid", this.NumIid);
            RequestValidator.ValidateMinValue("num_iid", this.NumIid, 1);
        }

        #endregion
    }
}
