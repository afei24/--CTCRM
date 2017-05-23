using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Magic.Common.CSVHelper.ImageHandler
{
    public class ImageWeightHandler : BaseImageHandler
    {
        public ImageWeightHandler()
        { }
        public ImageWeightHandler(BaseImageHandler imageHandler)
            : base(imageHandler)
        {
        }
        public override void Handler(ImageRequest request, List<string> handlerResult)
        {
            var handler = handlerResult.FirstOrDefault();
            var filePath = request.GenderTempFilePath();
            var isExcute = false;

            if (handler != null && File.Exists(handler))
            {
                using (var fileInfo = new FileStream(handler, FileMode.Open))
                {
                    if (fileInfo.Length > 819200)
                    {
                        isExcute = true;
                        ImageClass.MyImage.CutForCustom(fileInfo, filePath, request.Width, request.Heith, 80);
                    }
                    else
                    {
                        isExcute = true;
                        ImageClass.MyImage.CutForCustom(fileInfo, filePath, request.Width, request.Heith, 100);
                    }
                    //while (fileInfo.Length > 819200)
                    //{
                    //    isExcute = true;
                    //    using (var fileStream = new FileStream(handler, FileMode.Open))
                    //    {
                    //        ImageClass.MyImage.CutForCustom(fileStream, filePath, 620, 960, Convert.ToInt32(--curr));
                    //    }
                    //    fileInfo = new FileInfo(handler);
                    //}
                }
            }
            else
            {
                if (request.fileStream.Length > 819200)
                {
                    isExcute = true;
                    ImageClass.MyImage.CutForCustom(request.fileStream, filePath, request.Width, request.Heith, 80);

                }
                else
                {
                    isExcute = true;
                    ImageClass.MyImage.CutForCustom(request.fileStream, filePath, request.Width, request.Heith, 100);
                }
            }
            if (isExcute)
            {
                if (File.Exists(handlerResult.FirstOrDefault()))
                    File.Delete(handlerResult.FirstOrDefault());
                handlerResult.Clear();
                handlerResult.Add(filePath);
            }
            if (nextImageHandler != null)
            {
                nextImageHandler.Handler(request, handlerResult);
            }
        }
    }
}
