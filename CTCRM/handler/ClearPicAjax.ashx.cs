using CTCRM.Common;
using CTCRM.Components;
using CTCRM.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CTCRM.handler
{
    /// <summary>
    /// ClearPicAjax 的摘要说明
    /// </summary>
    public class ClearPicAjax : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            var command = context.Request.Form["command"];
            if (!string.IsNullOrEmpty(command))
            {
                switch (command)
                {
                    #region getPicInfo
                    case "getPicInfo":
                        {
                            string catalogId = context.Request.Form["cateID"];
                            PicBLL objDal = new PicBLL();
                            if (catalogId.Equals("全部分类"))
                            {
                                catalogId = "0";
                            }
                            var count = objDal.GetNeedClearPicCount(Convert.ToInt64(catalogId)).ToString();
                            context.Response.Write(count);
                            context.Response.End();
                        }
                        break;
                    #endregion

                    #region clearPics
                    case "clearPics":
                        {
                            Int64 canSavedSize = 0;
                            PicBLL objDal = new PicBLL();
                            if (objDal.DeleleUnusedPic(ref canSavedSize))
                            {
                                //lbCleardCount.Text = lbClearCount.Text;
                                //Tr1.Visible = true;
                                //Tr2.Visible = true;
                            }
                            SavedSpace space = new SavedSpace();
                            space.SellerNick = Users.Nick;
                            space.TotalSavedSpace = canSavedSize;
                            if (!PicBLL.CheckSpace(space))
                            {
                                PicBLL.AddSpace(space);
                            }
                            else
                            {
                                PicBLL.UpdateSpace(space);
                            }
                            //将节约的空间累计到DB
                            var count = Utility.FormatFileSize(canSavedSize);
                            context.Response.Write(count);
                            context.Response.End();
                        }
                        break;
                    #endregion
                }
            }
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}