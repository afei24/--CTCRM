using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;

namespace Magic.Common.CSVHelper.ImageHandler
{
    public class ImageHandlerClient
    {
        public static string Handler(string filePath, string userName, string gender, string imageHandler, ref Boolean isSuccess, ref int weight)
        {
            try
            {
                var stream = getImage(filePath);
                ImageRequest request = new ImageRequest();
                System.Drawing.Image image = Image.FromStream(stream);
                request.Width = image.Width;
                request.Heith = image.Height;
                request.gender = gender;
                request.imageHandler = imageHandler;
                request.fileStream = stream;
                request.Weight = stream.Length;
                weight = Convert.ToInt32(request.Weight);
                isSuccess = true;
                if (request.Weight < 1845) { isSuccess = false; return string.Empty; };
                ImageWeightHandler weightHandler = new ImageWeightHandler();
                ImageHeightHandler heightHandler = new ImageHeightHandler(weightHandler);
                ImageWidthHandler widthhandler = new ImageWidthHandler(heightHandler);
                List<string> fileList = new List<string>();
                request.IsSuccess = isSuccess;
                widthhandler.Handler(request, fileList);
                return fileList.FirstOrDefault() == null ? filePath : fileList.FirstOrDefault();
            }
            catch (Exception ex)
            {
                return string.Empty;
            }

        }
        private static Stream getImage(string URl)
        {

            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(URl);
            WebResponse response = request.GetResponse();
            Stream stream = response.GetResponseStream();
            byte[] buffer = new byte[1024];

            if (!response.ContentType.ToLower().StartsWith("text/"))
            {
                try
                {
                    Stream outStream = new MemoryStream();
                    Stream inStream = response.GetResponseStream();
                    int bufferLength;
                    do
                    {
                        bufferLength = inStream.Read(buffer, 0, buffer.Length);
                        if (bufferLength > 0)
                            outStream.Write(buffer, 0, bufferLength);
                    }
                    while (bufferLength > 0);

                    outStream.Flush();
                    outStream.Seek(0, SeekOrigin.Begin);
                    inStream.Close();
                    return outStream;
                }
                catch (Exception ex)
                {
                    return null;
                }
            }
            else
            {
                return null;
            }


        }
    }
}
