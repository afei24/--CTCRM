using CHENGTUAN.Components;
using CHENGTUAN.Entity;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using Top.Api;
using Top.Api.Request;
using Top.Api.Response;
using Top.Api.Util;

namespace CTCRM.Components.TopCRM
{
    /// <summary>
    /// 商品图片
    /// </summary>
    public class ItemImage
    {
        /// <summary>
        /// 商品图片上传
        /// </summary>
        /// <param name="numIid">商品数字ID</param>
        /// <param name="filePath">文件路径</param>
        /// <param name="isMagor">是否将图片设置为主图</param>
        public string ItemImgUpload(Int64 numIid, string filePath, Boolean isMagor, string sessionKey)
        {
            try
            {
                ITopClient client = TBManager.GetClient();
                PictureUploadRequest req = new PictureUploadRequest();
                //req.NumIid = numIid;
                req.ClientType = "client:phone";
                var fileInfo = new FileInfo(filePath);
                FileItem fItem = new FileItem(fileInfo);
                req.ImageInputTitle = fileInfo.Name;
                req.PictureCategoryId = 0;
                req.Img = fItem;
                //req.IsMajor = true;
                //req.Position = 6;
                PictureUploadResponse response = client.Execute(req, sessionKey);

                //#if DEBUG
                //                return filePath;
                //#else
                return response.Picture.PicturePath;
                //#endif
            }
            catch (Exception ex)
            {
                ExceptionReporter.WriteLog(ex, ExceptionPostion.TopApi);
                return null;
            }
        }
    }
}
