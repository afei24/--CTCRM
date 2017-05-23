using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Magic.Common.CSVHelper.ImageHandler
{
    public class ImageWidthHandler : BaseImageHandler
    {
        public ImageWidthHandler()
        {
        }
        public ImageWidthHandler(BaseImageHandler imageHandler) :
            base(imageHandler) { }
        public override void Handler(ImageRequest request, List<string> handlerResult)
        {
            var filePath = request.GenderTempFilePath();
            Magic.Common.CSVHelper.ImageClass.MyImage.CutForCustom(request.fileStream, filePath, 620, request.Heith, 100);
            handlerResult.Add(filePath);
            if (this.nextImageHandler != null)
                this.nextImageHandler.Handler(request, handlerResult);

        }
    }
}
