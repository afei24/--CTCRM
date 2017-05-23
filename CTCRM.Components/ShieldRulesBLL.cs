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
   public class ShieldRulesBLL
    {   
       public  static Boolean CheckCloseOrderConfigIsExit(string sellerNick)
       {
           ShieldRulesDAL obj = new ShieldRulesDAL();
           return obj.CheckCloseOrderConfigIsExit(sellerNick);
       }
       public static Boolean DeleteDefenseLog(string startDate, string endDate)
       {
           ShieldRulesDAL obj = new ShieldRulesDAL();
           return obj.DeleteDefenseLog(startDate, endDate);

       }
       public static DataTable GeCloseOrderConfigByNick(string sellerNick)
       {
           ShieldRulesDAL obj = new ShieldRulesDAL();
           return obj.GeCloseOrderConfigByNick(sellerNick);
       }

       public static Boolean UpdateAutoCloseOrderStatus(string sellerNick, int openStatus)
       {
           ShieldRulesDAL obj = new ShieldRulesDAL();
           return obj.UpdateAutoCloseOrderStatus(sellerNick, openStatus);
       }

       public static Boolean CheckIsMiaoPingAuto(string sellerNick)
       {
           ShieldRulesDAL obj = new ShieldRulesDAL();
           return obj.CheckIsMiaoPingAuto(sellerNick);
       }

       public  static bool AddCloseOrderConfig(CloseOrderConfig obj)
       {
           ShieldRulesDAL obj2 = new ShieldRulesDAL();
           return obj2.AddCloseOrderConfig(obj);
       }

       public static bool UpdateCloseOrderConfig(CloseOrderConfig obj3)
       {
           ShieldRulesDAL objDal = new ShieldRulesDAL();
           return objDal.UpdateCloseOrderConfig(obj3);
       }
       public static Boolean UpdateCloseDate(string sellerNick)
       {
           ShieldRulesDAL objDal = new ShieldRulesDAL();
           return objDal.UpdateCloseDate(sellerNick);

       }
       public static DataTable GetCloseOrderConfig(string sellerNick)
       {
           ShieldRulesDAL objDal = new ShieldRulesDAL();
           return objDal.GetCloseOrderConfig(sellerNick);
       }
       public static DataTable GetAddressCloseConfig(string sellerNick)
       {
           ShieldRulesDAL objDal = new ShieldRulesDAL();
           return objDal.GetAddressCloseConfig(sellerNick);
       }
       public static bool DeleteCloseAddressConfig(CloseAddressConfig obj)
       {
           ShieldRulesDAL objDal = new ShieldRulesDAL();
           return objDal.DeleteCloseAddressConfig(obj);
       }
       public static DataTable GetOrderDenfenseListByNick(string sellerNick, string startDate, string endRateDate)
       {
           ShieldRulesDAL objDal = new ShieldRulesDAL();
           return objDal.GetOrderDenfenseListByNick(sellerNick, startDate, endRateDate);
       }

       public static Boolean CheckCloseAddressConfigIsExit(string sellerNick, string buyerName,string buyerPhone)
       {
           ShieldRulesDAL objDal = new ShieldRulesDAL();
           return objDal.CheckCloseAddressConfigIsExit(sellerNick,buyerName,buyerPhone);
       }
        public static bool AddCloseAddressConfig(CloseAddressConfig obj)
        {
             ShieldRulesDAL objDal = new ShieldRulesDAL();
           return objDal.AddCloseAddressConfig(obj);
        }

        public static DataTable GetCloseOrderBlakListByNick(string sellerNick)
        {
              ShieldRulesDAL objDal = new ShieldRulesDAL();
           return objDal.GetCloseOrderBlakListByNick(sellerNick);
        }

        public static int GetBlakListCloseOrderCount(string sellerNick)
        {
            ShieldRulesDAL objDal = new ShieldRulesDAL();
            return objDal.GetBlakListCloseOrderCount(sellerNick);
        }
        public static bool DeleteAllCloseOrderBlaklist(string sellerNick)
        {
            ShieldRulesDAL objDal = new ShieldRulesDAL();
            return objDal.DeleteAllCloseOrderBlaklist(sellerNick);
        }
        public static bool DeleteCloseOrderBlaklist(string blakListID)
        {
            ShieldRulesDAL objDal = new ShieldRulesDAL();
            return objDal.DeleteCloseOrderBlaklist(blakListID);
        }
        public static DataTable GetSellerDenfensRateConfig(string sellerNick, string startDate, string endRateDate)
        {
            ShieldRulesDAL objDal = new ShieldRulesDAL();
            return objDal.GetSellerDenfensRateConfig(sellerNick, startDate, endRateDate);
        }

    }
}
