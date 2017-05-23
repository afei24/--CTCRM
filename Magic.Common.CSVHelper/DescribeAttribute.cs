using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Magic.Common.CSVHelper
{
    [System.AttributeUsage(AttributeTargets.Property | AttributeTargets.Field, AllowMultiple = false, Inherited = true)]
    public class DescribeAttribute : Attribute
    {
        public string Filed
        {
            get;
            set;
        }
        public string EnName
        {
            get;
            set;
        }
        public int Index
        {
            get;
            set;
        }
        public object CurrValue { get; set; }

    }
}
