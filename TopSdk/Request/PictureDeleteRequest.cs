using System;
using System.Collections.Generic;
using Top.Api.Util;

namespace Top.Api.Request
{
    /// <summary>
    /// TOP API: taobao.picture.delete
    /// </summary>
    public class PictureDeleteRequest : BaseTopRequest<Top.Api.Response.PictureDeleteResponse>
    {
        /// <summary>
        /// 图片ID字符串,可以一个也可以一组,用英文逗号间隔,如450,120,155.限制数量是100
        /// </summary>
        public string PictureIds { get; set; }

        #region ITopRequest Members

        public override string GetApiName()
        {
            return "taobao.picture.delete";
        }

        public override IDictionary<string, string> GetParameters()
        {
            TopDictionary parameters = new TopDictionary();
            parameters.Add("picture_ids", this.PictureIds);
            if (this.otherParams != null)
            {
                parameters.AddAll(this.otherParams);
            }
            return parameters;
        }

        public override void Validate()
        {
            RequestValidator.ValidateRequired("picture_ids", this.PictureIds);
            RequestValidator.ValidateMaxListSize("picture_ids", this.PictureIds, 100);
        }

        #endregion
    }
}
