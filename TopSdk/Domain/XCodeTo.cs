using System;
using System.Xml.Serialization;

namespace Top.Api.Domain
{
    /// <summary>
    /// XCodeTo Data Structure.
    /// </summary>
    [Serializable]
    public class XCodeTo : TopObject
    {
        /// <summary>
        /// 创建时间
        /// </summary>
        [XmlElement("gmt_create")]
        public string GmtCreate { get; set; }

        /// <summary>
        /// 最后修改时间
        /// </summary>
        [XmlElement("gmt_modified")]
        public string GmtModified { get; set; }

        /// <summary>
        /// 记录ID
        /// </summary>
        [XmlElement("id")]
        public long Id { get; set; }

        /// <summary>
        /// 二维码图片地址
        /// </summary>
        [XmlElement("img_url")]
        public string ImgUrl { get; set; }

        /// <summary>
        /// 有效期结束时间，使用短链接跳转的，结束后不再可以访问
        /// </summary>
        [XmlElement("life_end")]
        public string LifeEnd { get; set; }

        /// <summary>
        /// 有效期开始时间
        /// </summary>
        [XmlElement("life_start")]
        public string LifeStart { get; set; }

        /// <summary>
        /// 短连接关键字符
        /// </summary>
        [XmlElement("short_name")]
        public string ShortName { get; set; }

        /// <summary>
        /// 短连接
        /// </summary>
        [XmlElement("short_url")]
        public string ShortUrl { get; set; }

        /// <summary>
        /// 码的状态，1-生效，0-未生效，-1-逻辑删除。
        /// </summary>
        [XmlElement("status")]
        public long Status { get; set; }

        /// <summary>
        /// 所属用户ID，如果入参没有用户登录信息，则随机生成
        /// </summary>
        [XmlElement("user_id")]
        public long UserId { get; set; }
    }
}
