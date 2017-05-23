using System;
using System.Xml.Serialization;

namespace Top.Api.Domain
{
    /// <summary>
    /// BugImg Data Structure.
    /// </summary>
    [Serializable]
    public class BugImg : TopObject
    {
        /// <summary>
        /// 添加时间.格式:yyyy-mm-dd hh:mm:ss
        /// </summary>
        [XmlElement("created_at")]
        public string CreatedAt { get; set; }

        /// <summary>
        /// 图片格式
        /// </summary>
        [XmlElement("format")]
        public string Format { get; set; }

        /// <summary>
        /// 缺陷图片ID
        /// </summary>
        [XmlElement("id")]
        public long Id { get; set; }

        /// <summary>
        /// 图片名称
        /// </summary>
        [XmlElement("name")]
        public string Name { get; set; }

        /// <summary>
        /// 图片序号。图片展示顺序，数据越小越靠前。要求是正整数。
        /// </summary>
        [XmlElement("position")]
        public long Position { get; set; }

        /// <summary>
        /// 图片地址.(绝对地址,格式:http://host/image_path)
        /// </summary>
        [XmlElement("url")]
        public string Url { get; set; }
    }
}
