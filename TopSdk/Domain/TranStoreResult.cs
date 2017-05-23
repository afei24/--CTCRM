using System;
using System.Xml.Serialization;

namespace Top.Api.Domain
{
    /// <summary>
    /// TranStoreResult Data Structure.
    /// </summary>
    [Serializable]
    public class TranStoreResult : TopObject
    {
        /// <summary>
        /// 中转仓地址
        /// </summary>
        [XmlElement("store_address")]
        public string StoreAddress { get; set; }

        /// <summary>
        /// 中转仓代码
        /// </summary>
        [XmlElement("store_code")]
        public string StoreCode { get; set; }

        /// <summary>
        /// 中转仓名字
        /// </summary>
        [XmlElement("store_name")]
        public string StoreName { get; set; }
    }
}
