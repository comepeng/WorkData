using System;
using System.Reflection;
using AspectCore.Extensions.Reflection;

namespace Compeng.Rpc.Core.Util
{
    public static class GrpcUtil
    {
        /// <summary>
        /// 获取grpc服务的名字
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static string GetGrpcServiceName<T>() where T : class, new()
        {
            var memberInfo = typeof(T).BaseType;
            var fieldInfo = memberInfo.DeclaringType.GetTypeInfo()
                .GetField("__ServiceName", BindingFlags.Static | BindingFlags.NonPublic);
            var reflector = fieldInfo.GetReflector();
            var name = reflector.GetStaticValue() as string;
            return name;
        }

        /// <summary>
        /// 获取grpc服务的名字
        /// </summary>
        /// <param name="type">客户端或者服务端的类名</param>
        /// <returns></returns>
        public static string GetGrpcServiceName(Type type)
        {
            var memberInfo = type.BaseType;
            var fieldInfo = memberInfo.DeclaringType.GetTypeInfo()
                .GetField("__ServiceName", BindingFlags.Static | BindingFlags.NonPublic);
            var reflector = fieldInfo.GetReflector();
            var name = reflector.GetStaticValue() as string;
            return name;
        }
    }
}