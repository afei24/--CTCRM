using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Magic.Common.CSVHelper.ImageHandler
{
    public abstract class BaseImageHandler
    {
        public BaseImageHandler()
        {
        }
        protected BaseImageHandler nextImageHandler { get; set; }
        public BaseImageHandler(BaseImageHandler imageHandler)
        {
            this.nextImageHandler = imageHandler;
        }
        public abstract void Handler(ImageRequest request,List<string> handlerResult);
    }


}
