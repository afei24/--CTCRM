using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Magic.Common.CSVHelper.ImageHandler
{
    public class ImageRequest
    {
        /// <summary>
        /// 文件流
        /// </summary>
        public System.IO.Stream fileStream;
        /// <summary>
        /// 用户名
        /// </summary>
        public string UserName { get; set; }
        /// <summary>
        /// 图片宽度
        /// </summary>
        public int Width { get; set; }
        /// <summary>
        /// 图片高度
        /// </summary>
        public int Heith { get; set; }
        /// <summary>
        /// 图片质量
        /// </summary>
        public Int64 Weight { get; set; }
        /// <summary>
        /// 是否处理
        /// </summary>
        public Boolean IsHandler;
        /// <summary>
        ///临时文件目录
        /// </summary>
        private string tempFilePath = "/TempImages/";
        /// <summary>
        /// 生成方式：1、跳过已经有手机详情的宝贝；2、重新生成已经有手机详情的宝贝
        /// </summary>
        public string gender;
        /// <summary>
        /// 图片处理方式：1、超长图片切割成两张。2、超长图片直接忽略
        /// </summary>
        public string imageHandler;
        /// <summary>
        ///临时文件路径
        /// </summary>
        public string TempFilePath { get { return this.tempFilePath; } }
        /// <summary>
        /// 是否成功
        /// </summary>
        public Boolean IsSuccess { get; set; }

        public string GenderTempFilePath()
        {
            var filePath = TempFilePath + System.Guid.NewGuid().ToString() + System.DateTime.Now.ToFileTime() + ".jpg";
            return System.Web.HttpContext.Current.Server.MapPath(filePath);
        }
    }
}
