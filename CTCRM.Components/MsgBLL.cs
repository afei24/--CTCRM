using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CTCRM.Entity;
using CTCRM.DAL;
using System.Data;

namespace CTCRM.Components
{
  public  class MsgBLL
    {
      public static bool AddMsgPackage(MsgPackage obj)
      {
          return MsgDAL.AddMsgPackage(obj);
      }
      public static string GetFailedCount()
      {
          return MsgDAL.GetFailedCount();
      }
      public static DataTable GetMsgReminderHisBySellerNick(string sellerNick, string starteDate, string endDate)
      {
          return MsgDAL.GetMsgReminderHisBySellerNick(sellerNick, starteDate, endDate);
      }
      public static DataTable GetMsgReminderHisBySellerNick(string sellerNick, string starteDate, string endDate,string type)
      {
          return MsgDAL.GetMsgReminderHisBySellerNick(sellerNick, starteDate, endDate, type);
      }
      public static bool SellerSendPhoneYes(string sellerNick, string cellPhone)
      {
          return MsgDAL.SellerSendPhoneYes(sellerNick, cellPhone);
      }
      public static bool AddSellerYDNumber(string nick, string number)
      {
          return MsgDAL.AddSellerYDNumber(nick,number);
      }
      public static DataTable GetSellerYDNumbers(string sellerNick, string startDate, string endDate)
      {
          return MsgDAL.GetSellerYDNumbers(sellerNick, startDate,endDate);
      }
      public static DataTable GetMsgContentByTransID(string transNumber)
      {
          return MsgDAL.GetMsgContentByTransID(transNumber);
      }
      public static bool ClearMsgCountForCT()
      {
          return MsgDAL.ClearMsgCountForCT();
      }
      public static bool CountFailedMsgSend()
      {
          return MsgDAL.CountFailedMsgSend();
      }
      public static DataTable GetMsgHisByNick(string sellerNick)
      {
          return MsgDAL.GetMsgHisByNick(sellerNick);
      }
      public static String GetSellerSendMsgCusContent(string sellerNick)
      {
          return MsgDAL.GetSellerSendMsgCusContent(sellerNick);
      }
      public static bool UpdateSellerCusMsgContent(string sellerNick, string msgContent)
      {
          return MsgDAL.UpdateSellerCusMsgContent(sellerNick, msgContent);
      }
      public static string  CheckSellerMsgTransIsExit(string sellerNick)
      {
          return MsgDAL.CheckSellerMsgTransIsExit(sellerNick);
      }

      public static bool AddMsgTrans(MsgPackage obj)
      {
          return MsgDAL.AddMsgTrans(obj);
      }

      public static DataTable GetSellerMsgSendHis(string sellerNick, string startDate, string endDate, string sendType, string helpSellerNick, string buyerPhone, string sendStatus)
      {
          return MsgDAL.GetSellerMsgSendHis(sellerNick, startDate, endDate, sendType, helpSellerNick, buyerPhone, sendStatus);
      }
      public static bool DeleteMsgHisForReminder(string transNumber)
      {
          return MsgDAL.DeleteMsgHisForReminder(transNumber);
      }
      public static DataTable GetSellerMsgSendHisForReminder(string sellerNick, string startDate, string endDate, string sendType, string helpSellerNick, string buyerPhone)
      {
          return MsgDAL.GetSellerMsgSendHisForReminder(sellerNick, startDate, endDate, sendType, helpSellerNick, buyerPhone);
      }
      public static DataTable GetSellerMsgSendHis(string startDate, string endDate)
      {
          return MsgDAL.GetSellerMsgSendHis(startDate, endDate);
      }
      public static bool UpdateMsgTrans(MsgPackage o)
      {
          return MsgDAL.UpdateMsgTrans(o);
      }
      public static bool DeleteMsgHisForReminder(string sellerNick, string startDate, string endDate, string sendType)
      {
          DataTable dt = MsgDAL.GetSellerMsgSendHisForReminder(sellerNick, startDate, endDate, sendType, "", "");
          if (dt != null && dt.Rows.Count > 0)
          {
              for (int i = 0; i < dt.Rows.Count; i++)
              {
                  try
                  {
                      string transNumber = dt.Rows[i]["transNumber"].ToString();
                      MsgDAL.DeleteMsgHisForReminder(transNumber);
                  }
                  catch (Exception ex)
                  {
                      continue;
                  }
              }

          }
          return true;
      }
      public static bool DeleteMsgHis(string sellerNick, string startDate, string endDate, string sendType)
      {
          DataTable dt = MsgDAL.GetSellerMsgSendHis(sellerNick, startDate, endDate, sendType,"","","");
          if (dt != null && dt.Rows.Count > 0)
          {
              for (int i = 0; i < dt.Rows.Count; i++)
              {
                  try
                  {
                      string transNumber = dt.Rows[i]["transNumber"].ToString();
                      MsgDAL.DeleteMsgHis(transNumber);
                  }
                  catch (Exception ex) {
                      continue;
                  }
              }

          }
          return true;
      }

      public static DataTable GetMsgTransBySellerNick(string sellerNick,string startDate,string endDate)
      {
          return MsgDAL.GetMsgTransBySellerNick(sellerNick,startDate,endDate);
      }

      public static bool UpdateMsgTransForSecond(MsgPackage o)
      {
          return MsgDAL.UpdateMsgTransForSecond(o);
      }

      public static bool AddMsgTemp(MsgTemp obj)
      {
          return MsgDAL.AddMsgTemp(obj);
      }

      public static DataTable GetSellerMsgStatus(string sellerNick)
      {
          return MsgDAL.GetSellerMsgStatus(sellerNick);
      }

      /// <summary>
      /// 检查卖家当前账户短信账户是否足够发送
      /// </summary>
      public static Boolean CheckSellerMsgStatus()
      {
          DataTable tbmsgCanUseCount = MsgDAL.GetSellerMsgStatus(Users.Nick);
          if (tbmsgCanUseCount != null && tbmsgCanUseCount.Rows.Count > 0)
          {
              var msgCanUseCount = tbmsgCanUseCount.Rows[0]["msgCanUseCount"].ToString();
              if (!string.IsNullOrEmpty(msgCanUseCount) && Convert.ToInt32(msgCanUseCount) > 0)
              {
                  return true;
              }
          }
          return false;
      }

      public static DataTable GetMsgTempByNick(string sellerNick)
      {
          return MsgDAL.GetMsgTempByNick(sellerNick);
      }
      public static bool DeleteMsgTemp(string tempId)
      {
          return MsgDAL.DeleteMsgTemp(tempId);
      }

      public static Boolean CheckSellerMsgTempIsExit(string title, string sellerNick)
      {
          return MsgDAL.CheckSellerMsgTempIsExit(title, sellerNick);
      }

      public static string GetMsgTempContentByID(string tempId)
      {
          return MsgDAL.GetMsgTempContentByID(tempId);
      }
      public static bool UpdateMsgTransServiceStatus(string sellerNick, Boolean serviceStatus)
      {
          return MsgDAL.UpdateMsgTransServiceStatus(sellerNick, serviceStatus);
      }
      /// <summary>
      /// 每条短信发送条数更新
      /// </summary>
      /// <param name="sellerNick"></param>
      /// <param name="perMsgCount">每条内容耗费短信条数</param>
      /// <returns></returns>
      public static bool UpdateMsgTransUseCount(string sellerNick, int perMsgCount)
      {
          return MsgDAL.UpdateMsgTransUseCount(sellerNick, perMsgCount);
      }

      public static DataTable GetAuditMessage(string sellerNick, string startDate, string endDate, string auditSatus)
      {
          return MsgDAL.GetAuditMessage(sellerNick, startDate, endDate, auditSatus);
      }
      public static bool DeleteMsgPakage(string tempId)
      {
          return MsgDAL.DeleteMsgPakage(tempId);
      }
      public static bool UpdateMsgPakage(string id)
      {
          return MsgDAL.UpdateMsgPakage(id); 
      }
      public static DataTable GetMsgPakageByID(string id)
      {
          return MsgDAL.GetMsgPakageByID(id);
      }
      public static DataTable GetMoreYiWanMsg()
      {
          return MsgDAL.GetMoreYiWanMsg();
      }
      /// <summary>
      /// 获得给卖家设置的发送百分之几
      /// </summary>
      /// <param name="sellerNick"></param>
      /// <returns></returns>
      public static DataTable GetSellerMsgSendPrecent(string sellerNick)
      {
          return MsgDAL.GetSellerMsgSendPrecent(sellerNick);
      }
      /// <summary>
      /// 获取卖家短信事务明细
      /// </summary>
      /// <param name="sellerNick"></param>
      /// <returns></returns>
      public static DataTable GetSellerMsgTrans(string sellerNick)
      {
          return MsgDAL.GetSellerMsgTrans(sellerNick);
      }

      /// <summary>
      /// 统计物流发送的条数
      /// </summary>
      /// <param name="sellerNick"></param>
      /// <returns></returns>
      public static DataTable GetMsgSendHisForReminderCount(string seller)
      {
          return MsgDAL.GetMsgSendHisForReminderCount(seller);
      }

      /// <summary>
      /// 统计营销发送的条数
      /// </summary>
      /// <param name="sellerNick"></param>
      /// <returns></returns>
      public static DataTable GetMsgSendHisCount(string seller)
      {
          return MsgDAL.GetMsgSendHisCount(seller);
      }

      /// <summary>
      /// 统计发送的计费情况
      /// </summary>
      /// <param name="sellerNick"></param>
      /// <returns></returns>
      public static DataTable GetMsgSendJifen(string startTime, string endTime)
      {
          DataTable dtTwo = MsgDAL.GetTwo();
          DataTable dt =  MsgDAL.GetMsgSendCount( startTime,  endTime);
          MsgDAL.DeleteMsgRecords();
          for (int i = 0; i < dt.Rows.Count; i++)
          {
              int j =0;
              if (CheckTwo(dtTwo, dt.Rows[i]["sellernick"].ToString(), ref j))
              {
                  //获取卖家购买的短信包
                  DataTable dt1 = MsgDAL.GetMsgHisByNick(dt.Rows[i]["sellernick"].ToString());
                  if (dt1.Rows.Count >= 2)
                  {
                      if (dt1.Rows[1]["packageName"].ToString() == "店铺管家短信套餐(淘宝)200000条")
                      {
                          bool re = MsgDAL.InsertMsgRecords(dt.Rows[i]["sellernick"].ToString(), dt.Rows[i]["msgCount"].ToString(), (Convert.ToInt32(dt.Rows[i]["msgCount"]) * 0.034).ToString(), "3.4分/条");
                      }
                  }
                  else
                  {
                      if (((Convert.ToInt32(dt.Rows[i]["msgCount"])) + Convert.ToInt32(dtTwo.Rows[j]["msgCanUseCount"])) > 200000)
                      {
                          int price_35 = (((Convert.ToInt32(dt.Rows[i]["msgCount"])) + Convert.ToInt32(dtTwo.Rows[j]["msgCanUseCount"])) - 200000);
                          int price_34 = (Convert.ToInt32(dt.Rows[i]["msgCount"])) - price_35;
                          bool re = MsgDAL.InsertMsgRecords(dt.Rows[i]["sellernick"].ToString(), dt.Rows[i]["msgCount"].ToString(), (price_34 * 0.034 + price_35 * 0.035).ToString(), price_34 + "条 3.4分/条，" + price_35 + "条 3.5分/条，");
                      }
                      else
                      {
                          bool re = MsgDAL.InsertMsgRecords(dt.Rows[i]["sellernick"].ToString(), dt.Rows[i]["msgCount"].ToString(), (Convert.ToInt32(dt.Rows[i]["msgCount"]) * 0.034).ToString(), "3.4分/条");
                      }
                  }
              }
              else 
              {
                 bool re =  MsgDAL.InsertMsgRecords(dt.Rows[i]["sellernick"].ToString(), dt.Rows[i]["msgCount"].ToString(), (Convert.ToInt32(dt.Rows[i]["msgCount"]) * 0.035).ToString(), "3.5分/条");
              }
          }
              //MsgDAL.InsertMsgRecords();
          return MsgDAL.GetMsgRecords("");
      }

      public static bool CheckTwo(DataTable dtTwo, string sellernick,ref int i)
      {
          bool re = false;
          if (dtTwo == null || dtTwo.Rows.Count == 0)
          {
              return false;
          }
          for (int j = 0; j < dtTwo.Rows.Count; j++)
          {
              if (sellernick == dtTwo.Rows[j]["sellernick"].ToString())
              {
                  re = true;
                  i = j;
                  break;

              }
          }

          return re;
      }

      public static DataTable GetMsgRecords(string nick)
      {
          return MsgDAL.GetMsgRecords(nick);
      }

      public static DataTable GetMsgRecordsSum()
      {
          return MsgDAL.GetMsgRecordsSum();
      }

      public static DataTable GetMsgHis(string sellerNick, string satrtOrderDate, string endOrderDate, string rank)
      {
          return MsgDAL.GetMsgHis(sellerNick,  satrtOrderDate,  endOrderDate,  rank);
      }
    }
}
