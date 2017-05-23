using System;
using System.Xml.Serialization;
using System.Collections.Generic;

namespace Top.Api.Response
{
    /// <summary>
    /// ItempropvaluesGetResponse.
    /// </summary>
    public class ItempropvaluesGetResponse : TopResponse
    {
        /// <summary>
        /// 最近修改时间。格式:yyyy-MM-dd HH:mm:ss
        /// </summary>
        [XmlElement("last_modified")]
        public string LastModified { get; set; }

        /// <summary>
        /// 属性值,根据fields传入的参数返回相应的结果
        /// </summary>
        [XmlArray("prop_values")]
        [XmlArrayItem("prop_value")]
        public List<Top.Api.Domain.PropValue> PropValues { get; set; }

    }
}
