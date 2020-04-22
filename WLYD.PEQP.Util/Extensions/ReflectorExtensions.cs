using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Reflection;

namespace Compeng.PEQP.Util.Extensions
{
    public static class ReflectorExtensions
    {
        /// <summary>
        /// 通过反射获取累属性值
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="obj"></param>
        /// <param name="propertyName"></param>
        /// <returns></returns>
        public static object GetReflectPropertyValue<T>(this T obj, string propertyName) where T : class, new()
        {
            object result = null;

            PropertyInfo[] p1 = obj.GetType().GetProperties();

            PropertyInfo pi = null;

            for (int i = 0; i < p1.Length; i++)
            {
                pi = p1[i];

                if (pi.Name.ToLower() == propertyName.ToLower())
                {
                    result = pi.GetValue(obj);

                    break;
                }
            }

            return result;
        }

        /// <summary>
        /// 通过反射获取累属性值
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="obj"></param>
        /// <param name="propertyName"></param>
        /// <returns></returns>
        public static object GetReflectPropertyValue<T>(this T obj, string FieldName, out Type type) where T : class, new()
        {
            try
            {
                Type Ts = obj.GetType();
                PropertyInfo pi = Ts.GetProperty(FieldName);
                type = pi.PropertyType;
                object o = pi.GetValue(obj, null);
                string Value = Convert.ToString(o);
                if (string.IsNullOrEmpty(Value)) return null;
                return Value;
            }
            catch
            {
                type = null;
                return null;
            }
        }

        public static object GetPropertyValue(this PropertyInfo pi, object obj)
        {
            try
            {
                object o = pi.GetValue(obj, null);
                string Value = Convert.ToString(o);
                if (string.IsNullOrEmpty(Value)) return null;
                return Value;
            }
            catch
            {
                return null;
            }
        }

        public static bool IsNullableType(this Type theType)
        {
            return (theType.IsGenericType && theType.
              GetGenericTypeDefinition().Equals
              (typeof(Nullable<>)));
        }


        /// <summary>
        /// 通过反射设置对象属性值
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="obj"></param>
        /// <param name="propertyName"></param>
        /// <returns></returns>
        public static bool SetReflectPropertyValue<T>(this T obj, string FieldName, object Value) where T : class, new()
        {
            try
            {
                Type Ts = obj.GetType();

                var pi = Ts.GetProperty(FieldName);

                var fieldType = pi.PropertyType;

                if (fieldType == typeof(bool) || fieldType == typeof(bool?))
                {
                    if (Value == null)
                        Value = false;
                    else
                    {
                        var val = Value.ToString().ToLower().Trim();
                        if (val == "1")
                            Value = true;
                        else if (val == "是")
                            Value = true;
                        else if (val == "true")
                            Value = true;
                        else
                            Value = false;
                    }

                    pi.SetValue(obj, Value, null);
                }
                else if (IsNullableType(fieldType))
                {

                    NullableConverter nullableConverter = new NullableConverter(fieldType);
                    //将convertsionType转换为nullable对的基础基元类型
                    fieldType = nullableConverter.UnderlyingType;

                    var v = Convert.ChangeType(Value, fieldType);

                    pi.SetValue(obj, v, null);
                }
                else
                {
                    object v = Convert.ChangeType(Value, fieldType);

                    pi.SetValue(obj, v, null);
                }

                return true;
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// 通过反射设置对象属性值
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="obj"></param>
        /// <param name="propertyName"></param>
        /// <returns></returns>
        public static bool SetPropertyValue(this PropertyInfo pi, object obj, object Value)
        {
            try
            {
                var fieldType = pi.PropertyType;

                if (fieldType == typeof(bool) || fieldType == typeof(bool?))
                {
                    if (Value == null)
                        Value = false;
                    else
                    {
                        var val = Value.ToString().ToLower().Trim();
                        if (val == "1")
                            Value = true;
                        else if (val == "是")
                            Value = true;
                        else if (val == "true")
                            Value = true;
                        else
                            Value = false;
                    }

                    pi.SetValue(obj, Value, null);
                }
                else if (IsNullableType(fieldType))
                {

                    NullableConverter nullableConverter = new NullableConverter(fieldType);
                    //将convertsionType转换为nullable对的基础基元类型
                    fieldType = nullableConverter.UnderlyingType;

                    var v = Convert.ChangeType(Value, fieldType);

                    pi.SetValue(obj, v, null);
                }
                else
                {
                    object v = Convert.ChangeType(Value, fieldType);

                    pi.SetValue(obj, v, null);
                }

                return true;
            }
            catch
            {
                return false;
            }
        }

        public static bool IsEmptyValueType<T>(this T obj) => obj?.GetType().BaseType == typeof(ValueType) && EqualityComparer<T>.Default.Equals(obj, default(T));

        public static bool IsNotEmptyValueType<T>(this T obj) => obj?.GetType().BaseType == typeof(ValueType) && !EqualityComparer<T>.Default.Equals(obj, default(T));

        /// <summary>
        /// 利用反射来判断对象是否包含某个属性
        /// </summary>
        /// <param name="instance">object</param>
        /// <param name="propertyName">需要判断的属性</param>
        /// <returns>是否包含</returns>
        public static bool ContainProperty(this object instance, string propertyName)
        {
            if (instance != null && !string.IsNullOrEmpty(propertyName))
            {
                PropertyInfo _findedPropertyInfo = instance.GetType().GetProperty(propertyName);
                return (_findedPropertyInfo != null);
            }
            return false;
        }
    }
}
