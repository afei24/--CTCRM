﻿using Jayrock.Json;
using System;
using System.Collections;
using System.Collections.Generic;

namespace Top.Api.Parser
{
    public class TopJsonSimplifyReader : ITopReader
    {
        private IDictionary json;

        public TopJsonSimplifyReader(IDictionary json)
        {
            this.json = json;
        }

        public bool HasReturnField(object name)
        {
            return json.Contains(name);
        }

        public object GetPrimitiveObject(object name)
        {
            return json[name];
        }

        public object GetReferenceObject(object name, Type type, DTopConvert convert)
        {
            IDictionary dict = json[name] as IDictionary;
            if (dict != null && dict.Count > 0)
            {
                return convert(new TopJsonReader(dict), type);
            }
            else
            {
                return null;
            }
        }

        public IList GetListObjects(string listName, string itemName, Type type, DTopConvert convert)
        {
            IList listObjs = null;

            IList jsonList = json[listName] as IList;
            if (jsonList != null && jsonList.Count > 0)
            {
                Type listType = typeof(List<>).MakeGenericType(new Type[] { type });
                listObjs = Activator.CreateInstance(listType) as IList;
                foreach (object item in jsonList)
                {
                    if (typeof(IDictionary).IsAssignableFrom(item.GetType())) // object
                    {
                        IDictionary subMap = item as IDictionary;
                        object subObj = convert(new TopJsonSimplifyReader(subMap), type);
                        if (subObj != null)
                        {
                            listObjs.Add(subObj);
                        }
                    }
                    else if (typeof(IList).IsAssignableFrom(item.GetType())) // list or array
                    {
                        // TODO not support yet
                    }
                    else if (typeof(JsonNumber).IsAssignableFrom(item.GetType())) // long
                    {
                        listObjs.Add(((JsonNumber)item).ToInt64());
                    }
                    else // string, bool, other
                    {
                        listObjs.Add(item);
                    }
                }
            }

            return listObjs;
        }
    }
}
