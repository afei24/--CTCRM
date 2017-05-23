using CTCRM.Common;
using CTCRM.Components.TopCRM;
using CTCRM.DAL;
using CTCRM.Entity;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using Top.Api.Domain;

namespace CTCRM.Components
{
   public class PicBLL
    {

       public PicBLL()
        {
            ArrayList CanDeleteClearPic = null;//拼装所选分类下面能给删除的图片ID集合
            PageNo = 0;
            CurrentPage = 1;
            PageSize = 100;
        }
        Int64 CurrentPage
        {
            get { return Convert.ToInt64(System.Web.HttpContext.Current.Session["CurrentPage"]); }
            set { System.Web.HttpContext.Current.Session["CurrentPage"] = value; }
        }

        Int64 PageNo
        {
            get { return Convert.ToInt64(System.Web.HttpContext.Current.Session["PageNo"]); }
            set { System.Web.HttpContext.Current.Session["PageNo"] = value; }
        }
        Int64 PageSize
        {
            get { return Convert.ToInt64(System.Web.HttpContext.Current.Session["PageSize"]); }
            set { System.Web.HttpContext.Current.Session["PageSize"] = value; }
        }
        ArrayList CanDeleteClearPic
        {
            get { return (ArrayList)System.Web.HttpContext.Current.Session["CanDeleteClearPic"]; }
            set { System.Web.HttpContext.Current.Session["CanDeleteClearPic"] = value; }
        }
       
        Int64 total = 0;
        Int64 totalCanClearPic = 0;
        public Int64 GetNeedClearPicCount(long picture_category_id ) 
        {
            List<Picture> lstPic = ClearTop.GetPicsBySeller(CurrentPage, PageSize, picture_category_id, ref total);
            if (lstPic != null && lstPic.Count > 0) {
                DataTable tb = Utility.EntityListToDataTable<Picture>(lstPic);
                DataRow[] rwCanDelete = tb.Select("Referenced = False");
                totalCanClearPic += rwCanDelete.Length;
                foreach (DataRow r in rwCanDelete) {

                    if (CanDeleteClearPic == null) {
                        CanDeleteClearPic = new ArrayList();
                    }

                    if (!CanDeleteClearPic.Contains(r["PictureId"].ToString()))
                    {
                        CanDeleteClearPic.Add(r["PictureId"].ToString());  
                    }
                }
            }
            PageNo = PageNo + PageSize;
            if (PageNo < total)
            {
                CurrentPage = CurrentPage + 1;
                GetNeedClearPicCount(picture_category_id);
            }
            PageNo = 0;
            CurrentPage = 1;
            PageSize = 100;
             return totalCanClearPic;
        }

        public bool DeleleUnusedPic(ref Int64 canSavedSpace)
        {
            string picIDs = "";
            if (CanDeleteClearPic != null && CanDeleteClearPic.Count > 0)
            {
                for (int i = 0; i < CanDeleteClearPic.Count; i++)
                {
                    picIDs += CanDeleteClearPic[i].ToString() + ",";
                    List<Picture> lst = ClearTop.GetPicsByPicID(Convert.ToInt64(CanDeleteClearPic[i].ToString()));
                    if (lst != null && lst.Count == 1)
                    {
                        canSavedSpace += lst[0].Sizes;
                    }
                }
            }
            if (!string.IsNullOrEmpty(picIDs))
            { //有删除的垃圾图片
                picIDs = picIDs.Substring(0, picIDs.Length - 1);
                bool falg = ClearTop.DeleleInvalidPic(picIDs);
                if (falg)
                {
                    System.Web.HttpContext.Current.Session["CanDeleteClearPic"] = null;
                }
                return falg;
            }
            return false;
        }

 
       public static Int64 GetToalSavedSpace(string sellerNick)
       {
           return PicDAL.GetToalSavedSpace(sellerNick);
       }
       public static Boolean CheckSpace(SavedSpace entity)
       {
           return PicDAL.CheckSpace(entity);
       }
       public static bool AddSpace(SavedSpace entity)
       {
           return PicDAL.AddSpace(entity);
       }
       public static bool UpdateSpace(SavedSpace entity)
       {
           return PicDAL.UpdateSpace(entity);
       }
    }
}
