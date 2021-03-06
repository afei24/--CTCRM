using System;
using System.Xml.Serialization;
using System.Collections.Generic;

namespace Top.Api.Response
{
    /// <summary>
    /// ItemcatsAuthorizeGetResponse.
    /// </summary>
    public class ItemcatsAuthorizeGetResponse : TopResponse
    {
        /// <summary>
        /// 里面有3个数组：  Brand[]品牌列表,  ItemCat[] 类目列表  XinpinItemCat[] 针对于C卖家新品类目列表
        /// </summary>
        [XmlElement("seller_authorize")]
        public Top.Api.Domain.SellerAuthorize SellerAuthorize { get; set; }

    }
}
