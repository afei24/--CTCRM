using System;
using System.Collections.Generic;
using Top.Api.Util;

namespace Top.Api.Request
{
    /// <summary>
    /// TOP API: taobao.picture.isreferenced.get
    /// </summary>
    public class PictureIsreferencedGetRequest : BaseTopRequest<Top.Api.Response.PictureIsreferencedGetResponse>
    {
        /// <summary>
        /// 图片id
        /// </summary>
        public Nullable<long> PictureId { get; set; }

        #region ITopRequest Members

        public override string GetApiName()
        {
            return "taobao.picture.isreferenced.get";
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
            RequestValidator.ValidateRequired("picture_id", this.PictureId);
        }

        #endregion
    }
}
