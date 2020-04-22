using System;
using System.Collections.Generic;
using System.Linq;

namespace Compeng.PEQP.Util.Extensions
{
  
    public static class IEnumerableExtension
    {
        /// <summary>
        /// 根据给定的表达式排除重复项
        /// </summary>
        /// <typeparam name="TSource"></typeparam>
        /// <typeparam name="TKey"></typeparam>
        /// <param name="source"></param>
        /// <param name="keySelector"></param>
        /// <returns></returns>
        public static IEnumerable<TSource> DistinctBy<TSource, TKey>(this IEnumerable<TSource> source, Func<TSource, TKey> keySelector)
        {
            HashSet<TKey> seenKeys = new HashSet<TKey>();
            foreach (TSource element in source)
            {
                if (element != null)
                {
                    if (seenKeys.Add(keySelector(element)))
                    {
                        yield return element;
                    }
                }

            }
        }
        /// <summary>
        /// 删除掉集合为null的项
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="source"></param>
        public static IEnumerable<T> DropNullItem<T>(this IEnumerable<T> source) 
        {
           return source.Where(p => p != null).ToList();
           
        }

        /// <summary>
        /// 循环操作
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="enumerable"></param>
        /// <param name="action"></param>
        public static void ForEach<T>(this IEnumerable<T> enumerable, Action<T> action)
        {
            foreach (T item in enumerable)
            {
                action(item);
            }
        }

        /// <summary>
        /// 循环操作
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="enumerable"></param>
        /// <param name="action"></param>
        public static void Each<T>(this IEnumerable<T> enumerable, Action<T> action)
        {
            foreach (var item in enumerable)
                if (null != action) action(item);
        }

        public static IEnumerable<T> EachFor<K, T>(this IEnumerable<K> enumerable, Func<K,T> func)
        {
            foreach (var item in enumerable)
                if (null != func) yield return func(item);
        }

        public static string JoinString<T>(this IEnumerable<T> obj, String separator,Func<IEnumerable<T>, IEnumerable<string>> source)
        {
            return String.Join(separator, source(obj));
        }

        public static Dictionary<string, (Guid Key,string Value)> ToDictionary<T>(this IEnumerable<T> obj, Func<T, (Guid uid,string Key, string Value)> getKeyValue)
        {
            Dictionary<string, (Guid Key, string Value)> result = new Dictionary<string, (Guid Key, string Value)>();

            obj.ForEach(o =>
            {
                var dic = getKeyValue(o);
                if (!result.ContainsKey(dic.Key))
                    result.Add(dic.Key, (dic.uid, dic.Value));
            });

            return result;
        }

    }
}
