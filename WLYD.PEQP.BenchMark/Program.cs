using System;
using BenchmarkDotNet.Running;

namespace Compeng.PEQP.BenchMark
{
    class Program
    {
        static void Main(string[] args)
        {
            //所有代码需使用release编译
            BenchmarkRunner.Run<Rr>();
            //BenchmarkRunner.Run<Ch>();
        }
    }
}