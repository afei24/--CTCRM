using System;
using System.Xml.Serialization;
using System.Collections.Generic;

namespace Top.Api.Domain
{
    /// <summary>
    /// ArticleViewResult Data Structure.
    /// </summary>
    [Serializable]
    public class ArticleViewResult : TopObject
    {
        /// <summary>
        /// 服务code
        /// </summary>
        [XmlElement("article_code")]
        public string ArticleCode { get; set; }

        /// <summary>
        /// 服务简介
        /// </summary>
        [XmlElement("article_commment")]
        public string ArticleCommment { get; set; }

        /// <summary>
        /// sku详情列表
        /// </summary>
        [XmlArray("article_item_view_units")]
        [XmlArrayItem("article_item_view_unit")]
        public List<Top.Api.Domain.ArticleItemViewUnit> ArticleItemViewUnits { get; set; }

        /// <summary>
        /// 服务名称
        /// </summary>
        [XmlElement("article_name")]
        public string ArticleName { get; set; }

        /// <summary>
        /// 错误码
        /// </summary>
        [XmlElement("error_code")]
        public string ErrorCode { get; set; }

        /// <summary>
        /// 错误消息
        /// </summary>
        [XmlElement("error_msg")]
        public string ErrorMsg { get; set; }

        /// <summary>
        /// 用户淘宝nick
        /// </summary>
        [XmlElement("nick")]
        public string Nick { get; set; }

        /// <summary>
        /// 服务图片地址
        /// </summary>
        [XmlElement("pict_url")]
        public string PictUrl { get; set; }
    }
}
