using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using ZHSoft.Json.Collections;
using ZHSoft.Json.Values;
using System.Collections;

namespace ZHSoft.Json
{
    /// <summary>
    /// JSONReflector provides a convenient way to convert value and reference type objects
    /// to JSON format through reflection.
    /// 
    /// This implementation build JSON around reflected public properties of type int, float,
    /// double, decimal, byte, string, bool, enum or array.  (Generics and other types may be
    /// supported at a later time.)
    /// </summary>
    public class JSONReflector : JSONValue
    {
        private JSONObjectCollection _jsonObjectCollection;

        private JSONValue GetJSONValue(object objValue)
        {
            if (objValue != null)
            {
                Type thisType = objValue.GetType();
                JSONValue jsonValue = null;

                if (thisType == typeof(System.Int32))
                {
                    jsonValue = new JSONNumberValue(Convert.ToInt32(objValue));
                }
                else if (thisType == typeof(System.Int16))
                {
                    jsonValue = new JSONNumberValue(Convert.ToInt16(objValue));
                }
                else if (thisType == typeof(System.Int64))
                {
                    jsonValue = new JSONNumberValue(Convert.ToInt64(objValue));
                }
                else if (thisType == typeof(System.Single))
                {
                    jsonValue = new JSONNumberValue(Convert.ToSingle(objValue));
                }
                else if (thisType == typeof(System.DateTime))
                {
                    jsonValue = new JSONStringValue(Convert.ToDateTime(objValue).ToString("yyyy-MM-dd HH:mm"));
                }
                else if (thisType == typeof(System.Double))
                {
                    jsonValue = new JSONNumberValue(Convert.ToDouble(objValue));
                }
                else if (thisType == typeof(System.Decimal))
                {
                    jsonValue = new JSONNumberValue(Convert.ToDecimal(objValue));
                }
                else if (thisType == typeof(System.Byte))
                {
                    jsonValue = new JSONNumberValue(Convert.ToByte(objValue));
                }
                else if (thisType == typeof(System.String))
                {
                    jsonValue = new JSONStringValue(Convert.ToString(objValue));

                }
                else if (thisType == typeof(System.Boolean))
                {
                    jsonValue = new JSONBoolValue(Convert.ToBoolean(objValue));
                }
                else if (thisType.BaseType == typeof(System.Enum))
                {
                    jsonValue = new JSONStringValue(Enum.GetName(thisType, objValue));
                }
                else if (thisType.IsArray)
                {
                   
                    List<JSONValue> jsonValues = new List<JSONValue>();
                    Array arrValue = (Array)objValue;
                    for (int x = 0; x < arrValue.Length; x++)
                    {
                        JSONValue jsValue = this.GetJSONValue(arrValue.GetValue(x));
                        jsonValues.Add(jsValue);
                    }
                    jsonValue = new JSONArrayCollection(jsonValues);
                }
                else if(objValue is IList)
                {
                    
                    List<JSONValue> jsonValues = new List<JSONValue>();
                    IList list = (IList)objValue;
                   
                    JSONArrayCollection tColl = new JSONArrayCollection();
                    foreach (object value in list)
                    {
                        Dictionary<JSONStringValue, JSONValue> objs = new Dictionary<JSONStringValue, JSONValue>();
                        Type vType = value.GetType();

                        if (vType == typeof(System.String)) 
                        {
                            tColl.Add(new JSONStringValue(Convert.ToString(value)));
                            continue;
                        }

                        PropertyInfo[] pis = vType.GetProperties(System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.Public);
                        foreach (PropertyInfo p in pis)
                        {
                            JSONStringValue jsonParameterName = new JSONStringValue(p.Name);
                            JSONValue jsonParameterValue = this.GetJSONValue(p.GetValue(value, null));
                            if (jsonParameterValue != null)
                            {
                                if (jsonParameterValue != null)
                                {
                                    objs.Add(jsonParameterName, jsonParameterValue);
                                }
                            }
                        }
                        tColl.Add(new JSONObjectCollection(objs));

                    }
                    //jsonValue = new JSONObjectCollection(objs);
                    return tColl;
                }
                
                else if (objValue.GetType().IsClass)
                {
                    Dictionary<JSONStringValue, JSONValue> jsonNameValuePairs = new Dictionary<JSONStringValue, JSONValue>();
                    PropertyInfo[] properties = thisType.GetProperties();
                    foreach (PropertyInfo pi in properties)
                    {
                        JSONStringValue jsonParameterName = new JSONStringValue(pi.Name);
                        JSONValue jsonParameterValue = this.GetJSONValue(pi.GetValue(objValue, null));


                        if (jsonParameterValue != null)
                        {
                            if (jsonParameterValue != null)
                            {
                                jsonNameValuePairs.Add(jsonParameterName, jsonParameterValue);
                            }
                        }

                    }
                    JSONObjectCollection resJson = new JSONObjectCollection(jsonNameValuePairs);
                    return resJson;

                }
                return jsonValue;
            }
            return null;
        }
        private JSONValue GetJSONValue<T>(object objValue) 
        {
            if (objValue != null)
            {
                Type thisType = objValue.GetType();
                List<JSONValue> jsonValues = new List<JSONValue>();
                List<T> list = (List<T>)objValue;
                JSONArrayCollection tColl = new JSONArrayCollection();
                foreach (T value in list)
                {
                    Dictionary<JSONStringValue, JSONValue> objs = new Dictionary<JSONStringValue, JSONValue>();
                    Type vType = value.GetType();
                    PropertyInfo[] pis = vType.GetProperties(System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.Public);
                    foreach (PropertyInfo p in pis)
                    {
                        objs.Add(new JSONStringValue(p.Name), GetJSONValue(p.GetValue(value, null)));
                    }
                    tColl.Add(new JSONObjectCollection(objs));

                }
                //jsonValue = new JSONObjectCollection(objs);
                return tColl;
            }
            return null;
        }
        /// <summary>
        /// Public constructor that accepts any object
        /// </summary>
        /// <param name="objValue">object to be reflected/evaluated for JSON conversion</param>
        public JSONReflector(object objValue)
        {
            Dictionary<JSONStringValue, JSONValue> jsonNameValuePairs = new Dictionary<JSONStringValue, JSONValue>();

            Type type = objValue.GetType();
            PropertyInfo[] properties = type.GetProperties(BindingFlags.Instance | BindingFlags.Public);
            foreach (PropertyInfo pi in properties)
            {
                JSONStringValue jsonParameterName = new JSONStringValue(pi.Name);
                JSONValue jsonParameterValue = this.GetJSONValue(pi.GetValue(objValue, null));

                
                if (jsonParameterValue != null)
                {
                    jsonNameValuePairs.Add(jsonParameterName, jsonParameterValue);
                }
                
            }

            this._jsonObjectCollection = new JSONObjectCollection(jsonNameValuePairs);
        }

        
        /// <summary>
        /// Required override of the ToString() method.
        /// </summary>
        /// <returns>returns the internal JSONObjectCollection ToString() method</returns>
        public override string ToString()
        {
            return this._jsonObjectCollection.ToString();
        }

        /// <summary>
        /// Required override of the PrettyPrint() method.
        /// </summary>
        /// <returns>returns the internal JSONObjectCollection PrettyPrint() method</returns>
        public override string PrettyPrint()
        {
            return this._jsonObjectCollection.PrettyPrint();
        }
    }
    
}
