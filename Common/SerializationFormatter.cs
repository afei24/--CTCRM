using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Reflection;

namespace CTCRM.Common
{
   public class SerializationFormatter
    {
        public static DataTable SerializationDataTable<T>(List<T> lst)
        {
            if (lst != null && lst.Count > 0)
            {
                DataTable dt = new DataTable();
                System.Type objType = lst[0].GetType();
                PropertyInfo[] properties = objType.GetProperties();
                foreach (var item in properties)
                {
                    dt.Columns.Add(item.Name);
                }
                foreach (var item in lst)
                {
                    object[] objs = new object[properties.Length];
                    for (var i = 0; i < properties.Length; i++)
                    {
                        objs[i] = properties[i].GetValue(item, null);
                    }
                    dt.Rows.Add(objs);
                }
                return dt;
            }
            else
            {
                return null;
            }
        }
        public static DateTime GetDateTimeForLongTime(string longStr)
        {
            double douTime = 0;
            if (double.TryParse(longStr, out douTime))
            {
                System.DateTime date = System.DateTime.MinValue;
                return System.TimeZone.CurrentTimeZone.ToLocalTime(new System.DateTime(1970, 1, 1)).AddMilliseconds(Convert.ToDouble(longStr));
            }
            else
            {
                return System.DateTime.MaxValue;
            }
        }
    }
}
