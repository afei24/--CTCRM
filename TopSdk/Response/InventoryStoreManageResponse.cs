using System;
using System.Xml.Serialization;
using System.Collections.Generic;

namespace Top.Api.Response
{
    /// <summary>
    /// InventoryStoreManageResponse.
    /// </summary>
    public class InventoryStoreManageResponse : TopResponse
    {
        /// <summary>
        /// 返回结果
        /// </summary>
        [XmlArray("store_list")]
        [XmlArrayItem("store")]
        public List<Top.Api.Domain.Store> StoreList { get; set; }

    }
}
