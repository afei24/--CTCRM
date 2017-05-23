using CHENGTUAN.Components;
using CHENGTUAN.Entity;
using CTCRM.Components.TopCRM;
using CTCRM.DAL;
using CTCRM.Entity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using Top.Api.Domain;

namespace CTCRM.Components
{
  public  class tuiGuangBLL
    {
      public static bool AddIPProxy(string ip)
      {
          return tuiGuangDAL.AddIPProxy(ip);
      }
      public static bool ChekIPProxy(string ip)
      {
          return tuiGuangDAL.ChekIPProxy(ip);
      }
      public static DataTable GetAllOPENIDs()
      {
          return tuiGuangDAL.GetAllOPENIDs();
      }
      public static DataTable GetTuiGuangLog(string sellerNick, string startDate, string endDate)
      {
          return tuiGuangDAL.GetTuiGuangLog(sellerNick, startDate, endDate);
      }
      public static DataTable GetValidData()
      {
          return tuiGuangDAL.GetValidData();
      }
      public static DataTable GetAdLogBack(string sellerNick, string starteDate, string endDate)
      {
          return tuiGuangDAL.GetAdLogBack(sellerNick, starteDate, endDate);
      }
      public static String AddTuiGuangLogForS(string sellerNick)
      {
          DataTable tb = tuiGuangDAL.GetLogData(sellerNick);
          if (tb != null && tb.Rows.Count > 0)
          {
              int planCount = Convert.ToInt32(tb.Rows[0]["planCount"].ToString());
              return tuiGuangDAL.AddTuiGuangLog(sellerNick, "1", planCount);
          }
          else
          {
              Random rd = new Random();
              int planCount = rd.Next(20, 35);
              return tuiGuangDAL.AddTuiGuangLog(sellerNick, "1", planCount);
          }
      }
      public static DataTable GetLogData(string sellerNick)
      {
          return tuiGuangDAL.GetLogData(sellerNick);
      }
      public static bool DeleteTuiGuangHis(string startDate, string endDate)
      {
          DataTable tb = tuiGuangDAL.GetTuiGuangLog("", startDate, endDate);
          if (tb != null && tb.Rows.Count > 0)
          {
              for (int i = 0; i < tb.Rows.Count; i++)
              {
                  string transNo = tb.Rows[i]["transNo"].ToString();
                  tuiGuangDAL.DeleteTuiGuangHis(transNo);
              }
          }
          return true;
      }
      public static DataTable GetTuiGuangItemsForYMY(string openId)
      {
          return tuiGuangDAL.GetTuiGuangItemsForYMY(openId);
      }
      public static bool DeleteIPProxy(string ip)
      {
          return tuiGuangDAL.DeleteIPProxy(ip);
      }
      public static DataTable GetAdLog(string starteDate, string endDate)
      {
          return tuiGuangDAL.GetAdLog(Users.Nick, starteDate, endDate);
      }
      public static bool ChekTuiGuangMaxItems()
      {
          DataTable tb = tuiGuangDAL.ChekTuiGuangMaxItems(Users.Nick);
          if (tb != null && tb.Rows.Count > 0)
          {
              if (tb.Rows.Count >= 6)
              {
                  return true;
              }
          }
          return false;
      }
      public static DataTable GetSellerTuiGuangItems(string sellerNick, string startDate, string endDate, string tuiStatus)
      {
          return tuiGuangDAL.GetSellerTuiGuangItems(sellerNick, startDate, endDate, tuiStatus);
      }
      public static DataTable GetIPProxyList()
      {
          return tuiGuangDAL.GetIPProxyList();
      }
      public static bool ChekTuiGuangItem(string itemNo)
      {
          return tuiGuangDAL.ChekTuiGuangItem(itemNo);
      }
      public static DataTable GetTuiGuangItems()
      {
          return tuiGuangDAL.GetTuiGuangItems(Users.Nick);
      }
      public static bool AddTask(string itemNo)
      {
          Item itm = TBOnSalePro.GetItemByID(Users.SessionKey, itemNo);
          if(itm!=null)
          {
              TuiguangPro obj = new TuiguangPro();
              obj.ItemNo = itemNo;
              obj.SellerNick = Users.Nick;
              obj.ItemPicUrl = itm.PicUrl;
              obj.ItemTitle = itm.Title;
              obj.ItemUrl = itm.DetailUrl;
              obj.Price = itm.Price;
              obj.Inventory = itm.SoldQuantity.ToString();
              obj.TuiStatus = "1";// 1：推广中 0：下架中
              obj.EndUseTime = Users.Deadline == null ? "" : Users.Deadline;
              //分配或者获取Openid
              string openID = "";
              DataTable tbOpenid = tuiGuangDAL.GetTuiGuangOpenID(Users.Nick);
              if (tbOpenid != null && tbOpenid.Rows.Count == 1)
              {
                  openID = tbOpenid.Rows[0]["openId"].ToString();
              }
              else
              {
                  DataTable tbSytemOpenIds = tuiGuangDAL.GetSystemOpenIDs();
                  if (tbSytemOpenIds != null && tbSytemOpenIds.Rows.Count > 0)
                  {
                      for (int i = 0; i < tbSytemOpenIds.Rows.Count; i++)
                      {
                          string openId = tbSytemOpenIds.Rows[i]["openid"].ToString();
                          if (tuiGuangDAL.ChekOpenIDCanUsed(openId))
                          {
                              openID = openId;
                              //执行更新操作,将分配的OPENID占用
                              tuiGuangDAL.UpdateOpenStatus(openId);
                              break;
                          }
                      }
                  }
              }
              obj.OpenId = openID;
              if (!string.IsNullOrEmpty(openID))
              {
                  obj.TuiAddress = "http://youmuya.wx.jaeapp.com/index.php/Home/Choice/shareGoodsDetail/gid/" + openID + ".html";
                  if (tuiGuangDAL.AddTuiGuang(obj))
                  {
                      return true;
                  }
              }
              else
              {
                  return false;
              } 
          }
          return false;
      }

      public static bool ChekDianPu()
      {
          return tuiGuangDAL.ChekDianPu(Users.Nick);
      }
      public static bool AddDianPu(SellerShopForTuiGuang obj)
      {
          return tuiGuangDAL.AddDianPu(obj);
      }
      public static string GetTuiSataus(string itemNo)
      {
          return tuiGuangDAL.GetTuiSataus(itemNo);
      }
      public static bool AddOPENID(string openID)
      {
          return tuiGuangDAL.AddOPENID(openID);
      }
      public static bool UpdateTuiPro(string itemNo, string status)
      {
          try
          {
              TuiguangPro obj = new TuiguangPro();
              obj.SellerNick = System.Web.HttpUtility.UrlEncode(Users.Nick);
              obj.ItemNo = itemNo;
              obj.TuiStatus = status;
              return tuiGuangDAL.UpdateTuiPro(obj);
          }
          catch (Exception ex)
          {
              ExceptionReporter.WriteLog(ex, ExceptionPostion.TBApply_Data);
          }
          return false;
      }

      public static bool DeleteTuiPro(string itemNo)
      {
          return tuiGuangDAL.DeleteTuiPro(itemNo);
      }

      public static DataTable GetShopInfo(string sellerNick)
      {
          return tuiGuangDAL.GetShopInfo(sellerNick);
      }
      public static bool UpdateDianPu(SellerShopForTuiGuang obj)
      {
          return tuiGuangDAL.UpdateDianPu(obj);

      }
    }
}
