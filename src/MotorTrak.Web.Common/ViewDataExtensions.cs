using System;
using System.Collections.Generic;
using System.Web.Mvc;

namespace MotoTrak.Web
{
    public static class ViewDataExtensions
    {
        public static T Get<T>(this ViewDataDictionary bag, string key)
        {
            if (!bag.ContainsKey(key))
            {
                throw new ArgumentException(string.Format("No object exists with key '{0}'.", key));
            }

            return (T)bag[key];
        }

        public static T GetOrDefault<T>(this ViewDataDictionary bag, string key, T defaultValue)
        {
            if (bag.ContainsKey(key))
            {
                return (T)bag[key];
            }
            else
            {
                return defaultValue;
            }
        }
    }
}