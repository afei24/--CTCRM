using System;
using System.Xml.Serialization;
using System.Collections.Generic;

namespace Top.Api.Response
{
    /// <summary>
    /// MaQrcodeCommonCreateResponse.
    /// </summary>
    public class MaQrcodeCommonCreateResponse : TopResponse
    {
        /// <summary>
        /// 二维码对像
        /// </summary>
        [XmlArray("modules")]
        [XmlArrayItem("qrcode_d_o")]
        public List<Top.Api.Domain.QrcodeDO> Modules { get; set; }

        /// <summary>
        /// 执行是否成功
        /// </summary>
        [XmlElement("suc")]
        public bool Suc { get; set; }

    }
}
