using System;
using System.Xml.Serialization;
using System.Collections.Generic;

namespace Top.Api.Response
{
    /// <summary>
    /// ShopGetbytitleResponse.
    /// </summary>
    public class ShopGetbytitleResponse : TopResponse
    {
        /// <summary>
        /// 错误码
        /// </summary>
        [XmlElement("err_code")]
        public string ErrCode { get; set; }

        /// <summary>
        /// 错误信息
        /// </summary>
        [XmlElement("err_msg")]
        public string ErrMsg { get; set; }

        /// <summary>
        /// 有无错误
        /// </summary>
        [XmlElement("is_error")]
        public bool IsError { get; set; }

        /// <summary>
        /// test
        /// </summary>
        [XmlElement("result_shop")]
        public string ResultShop { get; set; }

    }
}
