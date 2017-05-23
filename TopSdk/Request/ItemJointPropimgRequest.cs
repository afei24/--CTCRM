using System;
using System.Collections.Generic;
using Top.Api.Util;

namespace Top.Api.Request
{
    /// <summary>
    /// TOP API: taobao.item.joint.propimg
    /// </summary>
    public class ItemJointPropimgRequest : BaseTopRequest<Top.Api.Response.ItemJointPropimgResponse>
    {
        /// <summary>
        /// 属性图片ID。如果是新增不需要填写
        /// </summary>
        public Nullable<long> Id { get; set; }

        /// <summary>
        /// 商品数字ID，必选
        /// </summary>
        public Nullable<long> NumIid { get; set; }

        /// <summary>
        /// 图片地址(传入图片相对地址即可,即不需包含 http://img02.taobao.net/bao/uploaded )
        /// </summary>
        public string PicPath { get; set; }

        /// <summary>
        /// 图片序号
        /// </summary>
        public Nullable<long> Position { get; set; }

        /// <summary>
        /// 属性列表。调用taobao.itemprops.get获取，属性必须是颜色属性，格式:pid:vid。
        /// </summary>
        public string Properties { get; set; }

        #region ITopRequest Members

        public override string GetApiName()
        {
            return "taobao.item.joint.propimg";
        }

        public override IDictionary<string, string> GetParameters()
        {
            TopDictionary parameters = new TopDictionary();
            parameters.Add("id", this.Id);
            parameters.Add("num_iid", this.NumIid);
            parameters.Add("pic_path", this.PicPath);
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
            RequestValidator.ValidateRequired("num_iid", this.NumIid);
            RequestValidator.ValidateMinValue("num_iid", this.NumIid, 0);
            RequestValidator.ValidateRequired("pic_path", this.PicPath);
            RequestValidator.ValidateRequired("properties", this.Properties);
        }

        #endregion
    }
}
