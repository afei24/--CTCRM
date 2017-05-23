using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.Data;
using System.Reflection;

namespace CTCRM.Common
{
  public  class Utility
    {
      public static Boolean CheckCanSendEmail()
      {
          ////如果当前时间在9:00-20:00之间，返回true。
          try
          {
              DateTime dtime = DateTime.Now;
              int hour = DateTime.Now.Hour;
              int min = DateTime.Now.Minute;

              List<int> lst = new List<int>();
              lst.Add(20);
              lst.Add(21);
              lst.Add(22);
              lst.Add(23);
              lst.Add(0);
              lst.Add(1);
              lst.Add(2);
              lst.Add(3);
              lst.Add(4);
              lst.Add(5);
              lst.Add(6);
              lst.Add(7);
              lst.Add(8);
              lst.Add(9);
              for (int i = 0; i < lst.Count; i++)
              {
                  if (hour.Equals(lst[i]))
                  {
                      if (hour.Equals(9))
                      {
                          if (min > 0)
                          {
                              return true;
                          }
                      }
                      return false;
                  }
              }
              return true;
          }
          catch (Exception ex)
          {
              return true;
          }
      }

       //邮件
        public static bool IsEmail(string itemValue)
        {
            return (IsRegEx("^(.)+@([a-zA-Z0-9_-])+((\\.[a-zA-Z0-9_-]{2,3}){1,2})$", itemValue));
        }

        //座机
        public static bool IsPhone(string itemValue)
        {
            return (IsRegEx("^((\\(\\d{3}\\))|(\\d{3}\\-))?(\\(0\\d{2,3}\\)|0\\d{2,3}-)?[1-9]\\d{6,7}$", itemValue));
        }

        //可带 字母 数字、“_”、“.”的字符串
        public static bool IsNumericAndSig(string itemValue)
        {
            return (IsRegEx("^[a-zA-Z]{1}([a-zA-Z0-9]|[._])+$", itemValue));
        }

        //只能为中文
        public static bool IsChinese(string itemValue)
        {
            return (IsRegEx("^[\u4e00-\u9fa5]+$", itemValue));
        }

        //不能包含英文以外的字符
        public static bool IsEN(string itemValue)
        {
            return (IsRegEx("^[a-zA-Z]+$", itemValue));
        }
        //验证银行卡：卡号必须为15位或16位或19位数字
        public static bool IsBankCardNo(string itemValue)
        {
            return (IsRegEx("^(\\d{15}|\\d{16}|\\d{19})$", itemValue));
        }
        //验证手机号码：13、15、18,17
        public static bool IsCellPhone(string itemValue)
        {
            return (IsRegEx("^1[3|5|8|7][0-9]{9}$", itemValue));
        }
        //身份证验证
        public static bool IsIdentifyNo(string itemValue)
        {
            return (IsRegEx("(^\\d{15}$)|(^\\d{17}([0-9]|X)$)", itemValue));
        }
        //邮编
        public static bool IsZIPCode(string itemValue)
        {
            return (IsRegEx("^[1-9][0-9]{5}$", itemValue));
        }
        //必须为整数
        public static bool IsPositiveINT(string itemValue)
        {
            return (IsRegEx("^([1-9]\\d*)$", itemValue));
        }
        /// <summary>
        /// 正整数判断
        /// </summary>
        /// <param name="itemValue"></param>
        /// <returns></returns>
        public static bool IsINT(string itemValue)
        {
            return (IsRegEx("^-?\\d+$", itemValue));
        }
       //必须为数字
        public static bool IsNumeric(string itemValue)
        {
            return (IsRegEx("^-?\\d+(\\.\\d+)?$", itemValue));
        }

        public static bool IsMoney(string itemValue)
        {
            return (IsRegEx("^(([1-9]\\d{0,9})|0)(\\.\\d{1,2})?$", itemValue));
        }

        public static bool IsDate(string itemValue)
        {
            return (IsRegEx("^(\\d{4})\\(\\d{2})\\-(\\d{2})$", itemValue));
        }
        private static bool IsRegEx(string regExValue, string itemValue)
        {
            try
            {
                Regex regex = new System.Text.RegularExpressions.Regex(regExValue);
                if (regex.IsMatch(itemValue)) return true;
                else return false;
            }
            catch (Exception)
            {
                return false;
            }
            finally
            {
            }
        }

      /// <summary>
      /// 排除移动号码
      /// </summary>
      /// <param name="strMobile"></param>
      /// <returns></returns>
        public static bool IsYiDongCellPhoneNo(string strMobile)
        {
            List<string> lsPre = new List<string>();
            lsPre.Add("134");
            lsPre.Add("135");
            lsPre.Add("136");
            lsPre.Add("137");
            lsPre.Add("138");
            lsPre.Add("139");
            lsPre.Add("141");
            lsPre.Add("143");
            lsPre.Add("147");
            lsPre.Add("150");
            lsPre.Add("151");
            lsPre.Add("152");
            lsPre.Add("154");
            lsPre.Add("157");
            lsPre.Add("158");
            lsPre.Add("159");
            lsPre.Add("182");
            lsPre.Add("183");
            lsPre.Add("184");
            lsPre.Add("187");
            lsPre.Add("188");
            for (int n = 0; n < lsPre.Count; n++)
            {
                if (strMobile.StartsWith(lsPre[n]))
                    return true;
            }
            return false;
        }


      /// <summary>
        /// 排除联通号码130，131，132、155、156、185、186、145
      /// </summary>
      /// <param name="strMobile"></param>
      /// <returns></returns>
        public static bool IsLianTongCellPhoneNo(string strMobile)
        {
            List<string> lsPre = new List<string>();
            lsPre.Add("130");
            lsPre.Add("131");
            lsPre.Add("132");
            lsPre.Add("155");
            lsPre.Add("156");
            lsPre.Add("186");
            lsPre.Add("185");
            lsPre.Add("145");
           
            for (int n = 0; n < lsPre.Count; n++)
            {
                if (strMobile.StartsWith(lsPre[n]))
                    return true;
            }
            return false;
        }

        /// <summary>
        /// 获取文件大小的单位换算
        /// </summary>
        /// <param name="fileSize"></param>
        /// <returns></returns>
        public static String FormatFileSize(Int64 fileSize)
        {
            if (fileSize < 0)
            {
                throw new ArgumentOutOfRangeException("fileSize");
            }
            else if (fileSize >= 1024 * 1024 * 1024)
            {
                return string.Format("{0:########0.00} GB", ((Double)fileSize) / (1024 * 1024 * 1024));
            }
            else if (fileSize >= 1024 * 1024)
            {
                return string.Format("{0:####0.00} MB", ((Double)fileSize) / (1024 * 1024));
            }
            else if (fileSize >= 1024)
            {
                return string.Format("{0:####0.00} KB", ((Double)fileSize) / 1024);
            }
            else
            {
                return string.Format("{0} bytes", fileSize);
            }
        }

        /// <summary>
        /// 将一个列表转换成DataTable,如果列表为空将返回空的DataTable结构
        /// </summary>
        /// <typeparam name="T">要转换的数据类型</typeparam>
        /// <param name="entityList">实体对象列表</param> 
        public static DataTable EntityListToDataTable<T>(List<T> entityList)
        {
            DataTable dt = new DataTable();
            //取类型T所有Propertie
            Type entityType = typeof(T);
            PropertyInfo[] entityProperties = entityType.GetProperties();
            Type colType = null;
            foreach (PropertyInfo propInfo in entityProperties)
            {

                if (propInfo.PropertyType.IsGenericType)
                {
                    colType = Nullable.GetUnderlyingType(propInfo.PropertyType);
                }
                else
                {
                    colType = propInfo.PropertyType;
                }

                if (colType.FullName.StartsWith("System"))
                {
                    dt.Columns.Add(propInfo.Name, colType);
                }
            }
            if (entityList != null && entityList.Count > 0)
            {
                foreach (T entity in entityList)
                {
                    DataRow newRow = dt.NewRow();
                    foreach (PropertyInfo propInfo in entityProperties)
                    {
                        if (dt.Columns.Contains(propInfo.Name))
                        {
                            object objValue = propInfo.GetValue(entity, null);
                            newRow[propInfo.Name] = objValue == null ? DBNull.Value : objValue;
                        }
                    }
                    dt.Rows.Add(newRow);
                }
            }
            return dt;
        }


    }
}
