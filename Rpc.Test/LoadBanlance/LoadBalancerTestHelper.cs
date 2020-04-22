using System.Collections.Generic;
using Compeng.Rpc.Client.Model;

namespace Rpc.Test.LoadBanlance
{
   public static class LoadBalancerTestHelper
       {
           public static List<HostAndPort> BuildList(int size)
           {
               var list = new List<HostAndPort>(size);
               for (int i = 0; i < size; i++)
               {
                   list.Add(new HostAndPort
                   {
                       Ip = "127.0.0.1",
                       Port = 9000 + i
                   });
               }
   
               return list;
           }
   
   //        todo: 带权重
   //        protected List<ProviderInfo> buildDiffWeightProviderList(int size) {
   //            List<ProviderInfo> aliveConnections = new ArrayList<ProviderInfo>();
   //            for (int i = 0; i < size; i++) {
   //                ProviderInfo provider = new ProviderInfo();
   //                provider.setHost("127.0.0.2");
   //                provider.setPort(9000 + i);
   //                provider.setWeight(i * 100); // 权重异常乘以100
   //
   //                aliveConnections.add(provider);
   //            }
   //
   //            return aliveConnections;
   //        }
       }
}