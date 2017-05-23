using CHENGTUAN.Components;
using CHENGTUAN.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Top.Api;
using Top.Api.Domain;
using Top.Api.Request;
using Top.Api.Response;

namespace CTCRM.Components.TopCRM
{
   public class ClearTop
    {
        /// <summary>
        /// 查询用户的图片空间使用信息，包括：订购量，已使用容量，免费容量，总的可使用容量，订购有效期，剩余容量 
        /// </summary>
        /// <returns></returns>
        public static UserInfo GetPicInfo()
        {
            try
            {
                ITopClient client = TBManager.GetClient();
                PictureUserinfoGetRequest req = new PictureUserinfoGetRequest();
                PictureUserinfoGetResponse response = client.Execute(req, Users.SessionKey);
                return response.UserInfo;
            }
            catch (Exception ex)
            {
                ExceptionReporter.WriteLog(ex, ExceptionPostion.TopApi);
                return null;
            }
        }

        /// <summary>
        /// 获取图片分类信息
        /// </summary>
        /// <returns></returns>
        public static List<PictureCategory> GetPicCatalog()
        {
            try
            {
                ITopClient client = TBManager.GetClient();
                PictureCategoryGetRequest req = new PictureCategoryGetRequest();
                PictureCategoryGetResponse response = client.Execute(req, Users.SessionKey);
                return response.PictureCategories;
            }
            catch (Exception ex)
            {
                ExceptionReporter.WriteLog(ex, ExceptionPostion.TopApi);
                return null;
            }
        }


        /// <summary>
        /// 获取图片分类信息
        /// </summary>
        /// <param name="currentPage"></param>
        /// <param name="pageSize"></param>
        /// <param name="picture_category_id"></param>
        /// <param name="total"></param>
        /// <returns></returns>
        public static List<Picture> GetPicsBySeller(long currentPage, long pageSize, long picture_category_id, ref long total)
        {
            try
            {
                if (currentPage == 0)
                {
                    currentPage = 1L;
                }
                if (pageSize == 0)
                {
                    pageSize = 100;
                }
                ITopClient client = TBManager.GetClient();
                PictureGetRequest req = new PictureGetRequest();
                req.PageNo = currentPage;
                req.PageSize = pageSize;
                if (picture_category_id != 0)
                {
                    req.PictureCategoryId = picture_category_id;
                }
                req.Deleted = "unfroze";
                PictureGetResponse response = client.Execute(req, Users.SessionKey);
                total = response.TotalResults;
                return response.Pictures;
            }
            catch (Exception ex)
            {
                ExceptionReporter.WriteLog(ex, ExceptionPostion.TopApi);
                return null;
            }
        }

        /// <summary>
        /// 更具图片ID获取图片大小
        /// </summary>
        /// <param name="picID"></param>
        /// <returns></returns>
        public static List<Picture> GetPicsByPicID(long picID)
        {
            try
            {
                ITopClient client = TBManager.GetClient();
                PictureGetRequest req = new PictureGetRequest();
                req.PictureId = picID;
                PictureGetResponse response = client.Execute(req, Users.SessionKey);
                return response.Pictures;
            }
            catch (Exception ex)
            {
                ExceptionReporter.WriteLog(ex, ExceptionPostion.TopApi);
                return null;
            }
        }

        public static Boolean DeleleInvalidPic(string picIDs)
        {
            try
            {
                ITopClient client = TBManager.GetClient();
                PictureDeleteRequest req = new PictureDeleteRequest();
                req.PictureIds = picIDs;
                PictureDeleteResponse response = client.Execute(req, Users.SessionKey);
                return response.Success;
            }
            catch (Exception ex)
            {
                ExceptionReporter.WriteLog(ex, ExceptionPostion.TopApi);
                return false;
            }
        }
    }
}
