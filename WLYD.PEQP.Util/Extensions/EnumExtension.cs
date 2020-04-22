using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;

namespace Compeng.PEQP.Util.Extensions
{

    /// <summary>
    /// 键值对DTO
    /// </summary>
    public class KeyValueDto
    {
        public int Key { get; set; }
        public string Value { get; set; }
    }

    /// <summary>
    /// 枚举扩展
    /// </summary>
    public static class EnumExtension
    {
        public static IEnumerable<Type> EnumTypes { get; set; }

        /// <summary>
        /// 转化为集合
        /// </summary>
        /// <param name="implementAssemblyFile">枚举程序集名称的长格式</param>
        /// <param name="enumName">枚举名称</param>
        /// <returns>对象集合</returns>
        public static List<KeyValueDto> GetKeyValues(string assemblyString, string enumName)
        {
            if (EnumTypes == null)
            {
                AssemblyName an = new AssemblyName(assemblyString);
                EnumTypes = from t in Assembly.Load(an).GetTypes()
                            where (t.IsAssignableFrom(t) )
                            select t;
            }
            var list = new List<KeyValueDto>();
            if (null != EnumTypes && EnumTypes.Any())
            {
                var e = EnumTypes.SingleOrDefault(m => string.Compare(m.Name, enumName, true) == 0);
                if (null != e)
                {
                    list = GetKeyValues(e);
                }
            }
            return list;
        }

        /// <summary>
        /// 转化为集合
        /// </summary>
        /// <param name="enumType">枚举Type</param>
        /// <returns>对象集合</returns>
        public static List<KeyValueDto> GetKeyValues(Type enumType)
        {
            var list = new List<KeyValueDto>();
            foreach (int i in Enum.GetValues(enumType))
            {
                list.Add(new KeyValueDto()
                {
                    Key = i,
                    Value = Enum.GetName(enumType, i)
                });
            }
            return list;
        }

        /// <summary>
        /// 转化为集合
        /// </summary>
        /// <param name="e">枚举类</param>
        /// <returns>对象集合</returns>
        public static List<KeyValueDto> GetKeyValues(Enum e)
        {
            var list = new List<KeyValueDto>();
            foreach (int i in Enum.GetValues(e.GetType()))
            {
                list.Add(new KeyValueDto()
                {
                    Key = i,
                    Value = Enum.GetName(e.GetType(), i)
                });
            }
            return list;
        }

        /// <summary>
        /// 转化为键值对集合
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns>键值对集合</returns>
        public static Dictionary<int, string> GetDictionary<T>() where T : IComparable
        {
            Dictionary<int, string> dics = new Dictionary<int, string>();
            foreach (int s in Enum.GetValues(typeof(T)))
            {
                dics.Add(s, Enum.GetName(typeof(T), s));
            }
            return dics;
        }
        
        /// <summary>
        /// 转换为枚举集合
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static IList<T> GetEnumKeys<T>() where T : IComparable
        {
            IList<T> list = new List<T>();
            foreach (T key in Enum.GetValues(typeof(T)))
            {
                list.Add(key);
            }
            return list;
        }

        /// <summary>
        /// 获取枚举属性上的描述特性内容
        /// </summary>
        /// <param name="value"></param>
        /// <returns>描述内容</returns>
        public static string GetEnumDescriptionAttribute(this Enum value)
        {
            try
            {
                FieldInfo fi = value.GetType().GetField(value.ToString());
                if(fi!=null)
                { 
                var attribute = fi.GetCustomAttributes(
                      typeof(System.ComponentModel.DescriptionAttribute), false)
                       .Cast<System.ComponentModel.DescriptionAttribute>()
                       .FirstOrDefault();
                if (attribute != null)
                    return attribute.Description;
                }
                return value.ToString();
            }
            catch
            {
                return "";
            }
        }


        /// <summary>
        /// 获取枚举值上的Description特性的说明
        /// </summary>
        /// <typeparam name="T">枚举类型</typeparam>
        /// <param name="obj">枚举值</param>
        /// <returns>特性的说明</returns>
        public static string GetEnumDescription<T>(T obj)
        {
            var type = obj.GetType();
            FieldInfo field = type.GetField(Enum.GetName(type, obj));
            DescriptionAttribute descAttr = Attribute.GetCustomAttribute(field, typeof(DescriptionAttribute)) as DescriptionAttribute;
            if (descAttr == null)
            {
                return string.Empty;
            }

            return descAttr.Description;
        }


        /// <summary>
        /// MethodOne获取枚举的Name,Value,Description
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static List<EnumModel> MethodOne_GetEnumModel<T>()
        {
            List<EnumModel> listEnumModel = new List<EnumModel>();
            Type type = typeof(T);
            FieldInfo[] fieldInfos = type.GetFields();
            foreach (FieldInfo fieldInfo in fieldInfos)
            {
                EnumModel enumModel = new EnumModel();
                if (!fieldInfo.IsSpecialName)
                {
                    enumModel.Name = fieldInfo.Name;
                    enumModel.Value = ((T)Enum.Parse(type, fieldInfo.Name)).GetHashCode();

                    DescriptionAttribute[] enumAttributeList = (DescriptionAttribute[])fieldInfo.GetCustomAttributes(typeof(DescriptionAttribute), false);
                    if (enumAttributeList != null && enumAttributeList.Length > 0)
                    {
                        enumModel.Description = enumAttributeList[0].Description;
                    }
                    else
                    {
                        enumModel.Description = fieldInfo.Name;
                    }
                    /*
                     * 下面的方法也可以获得枚举的描述
                         dynamic dy = fieldInfo.GetCustomAttributes(typeof(DescriptionAttribute), false);
                         if (dy != null && dy.Length>0)
                         {
                             enumModel.Description = dy[0].Description;
                         }
                         else
                         {
                             enumModel.Description = fieldInfo.Name;
                         }
                    */
                    listEnumModel.Add(enumModel);
                }
            }
            return listEnumModel;
        }

        /// <summary>
        /// 判断传的数据存在于枚举的Description中否
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static bool IsExistence<T>(string description)
        {
            var list = MethodOne_GetEnumModel<T>();
            if (list != null && list.Any())
            {
                if (list.Any(o => o.Description == description))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            return false;
        }


        /// <summary>
        /// 根据枚举描述获取枚举
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="description"></param>
        /// <returns></returns>
        public static T GetEnumName<T>(string description)
        {
            try
            {
                var list = MethodOne_GetEnumModel<T>();
                if (list != null && list.Any())
                {
                    var em = list.FirstOrDefault(o => o.Description == description);
                    return (T)Enum.Parse(typeof(T), em.Name);
                }
                else
                {
                    throw new ArgumentException(string.Format("{0} 未能找到对应的枚举.", description), "Description");
                }
            }
            catch (Exception)
            {
                throw new ArgumentException(string.Format("{0} 获取枚举出错.", description), "Description");
            }
        }
    }

    /// <summary>
    /// 用于保存枚举值Name,Value,Description的类
    /// </summary>
    public class EnumModel
    {
        public string Description { get; set; }
        public string Name { get; set; }
        public int Value { get; set; }
    }
}
