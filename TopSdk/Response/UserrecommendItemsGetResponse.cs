using System;
using System.Xml.Serialization;
using System.Collections.Generic;

namespace Top.Api.Response
{
    /// <summary>
    /// UserrecommendItemsGetResponse.
    /// </summary>
    public class UserrecommendItemsGetResponse : TopResponse
    {
        /// <summary>
        /// 返回用户相关的关联宝贝集合
        /// </summary>
        [XmlArray("favorite_items")]
        [XmlArrayItem("favorite_item")]
        public List<Top.Api.Domain.FavoriteItem> FavoriteItems { get; set; }

    }
}
