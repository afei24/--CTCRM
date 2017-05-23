using System;

using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Magic.Common.CSVHelper.ImageHandler
{
    public class ImageHeightHandler : BaseImageHandler
    {
        public ImageHeightHandler()
        { }
        public ImageHeightHandler(BaseImageHandler imageHandler)
            : base(imageHandler)
        {

        }
        public override void Handler(ImageRequest request, List<string> handlerResult)
        {
            if (request.Heith > 960)
            {
                var filePath = request.GenderTempFilePath();
                if (handlerResult.Count > 0)
                {
                    using (Stream stream = new System.IO.FileStream(handlerResult.FirstOrDefault(), FileMode.Open))
                    {

                        ImageClass.MyImage.CutForCustom(stream, filePath, 620, 960, 100);
                    }
                }
                else
                {
                    ImageClass.MyImage.CutForCustom(request.fileStream, filePath, 620, 960, 100);
                }
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
