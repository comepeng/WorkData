using System.Collections.Generic;
using System.ComponentModel;

namespace Compeng.PEQP.Util.Extensions
{
   
    public static class CollectionExtension
    {
        public static bool IsNullOrEmpty<T>(this ICollection<T> collection)
        {
            return (collection == null) || (collection.Count == 0);
        }

        /// <summary>
        /// 集合不为null并且count>0
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="collection"></param>
        /// <returns></returns>
        public static bool IsSafed<T>(this ICollection<T> collection)
        {
            return !collection.IsNullOrEmpty();
        }

        public static TValue TryGetOrDefault<TKey, TValue>(this IDictionary<TKey, TValue> dic, TKey key)
        {
            return dic.ContainsKey(key) ? dic[key] : default(TValue);
        }

        public static TValue MapTo<TValue>(this IDictionary<string, object> dic)
            where TValue : class, new()
        {
            if (null == dic || 0 == dic.Count) return default(TValue);

            TValue obj = new TValue();

            var pdc= TypeDescriptor.GetProperties(obj);
            PropertyDescriptor property;
            dic.Keys.Each(key =>
            {
                property = pdc[key];
                if (null != property)
                    property.SetValue(obj, dic[key].GetType() == property.PropertyType ? dic[key] : dic[key].FromTo(property.PropertyType));
            });
            
            return obj;
        }
    }
}
