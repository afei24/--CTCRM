using System;
using System.Xml.Serialization;

namespace Top.Api.Domain
{
    /// <summary>
    /// QrCodeStyle Data Structure.
    /// </summary>
    [Serializable]
    public class QrCodeStyle : TopObject
    {
        /// <summary>
        /// 可选参数，二维背景色颜色值，接入业务点配置为准，未配置，默认为白
        /// </summary>
        [XmlElement("bg_color")]
        public Nullable<long> BgColor { get; set; }

        /// <summary>
        /// 可选参数，二维码深色点颜色值，接入业务点配置为准，未配置，默认为黑
        /// </summary>
        [XmlElement("color")]
        public Nullable<long> Color { get; set; }

        /// <summary>
        /// 可选参数，二维码纠错级别 0=~7%,1=~15%,2=~25%,3=~30%
        /// </summary>
        [XmlElement("level")]
        public Nullable<long> Level { get; set; }

        /// <summary>
        /// 可选参数，logo的淘宝tfs地址，默认无
        /// </summary>
        [XmlElement("logo")]
        public string Logo { get; set; }

        /// <summary>
        /// 可选参数，二维码的边框，默认大小1个单位点，便于扫码
        /// </summary>
        [XmlElement("margin")]
        public Nullable<long> Margin { get; set; }

        /// <summary>
        /// 可选参数，二维码大小，值60～600，默认185pix
        /// </summary>
        [XmlElement("size")]
        public Nullable<long> Size { get; set; }
    }
}
