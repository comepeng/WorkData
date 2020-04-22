using Grpc.Core;

namespace Compeng.Rpc.Client
{
    /// <summary>
    /// rpc请求代理类
    /// </summary>
    internal class RpcCallInvoker : CallInvoker
    {
        private readonly ChannelManager _channelManager;

        public RpcCallInvoker(ChannelManager channelManager)
        {
            _channelManager = channelManager;
        }

        public override TResponse BlockingUnaryCall<TRequest, TResponse>(Method<TRequest, TResponse> method,
            string host, CallOptions options, TRequest request)
        {
            var call = CreateCall(method, host, options);
            return Calls.BlockingUnaryCall(call, request);
        }

        public override AsyncUnaryCall<TResponse> AsyncUnaryCall<TRequest, TResponse>(
            Method<TRequest, TResponse> method, string host, CallOptions options, TRequest request)
        {
            var call = CreateCall(method, host, options);
            return Calls.AsyncUnaryCall(call, request);
        }

        public override AsyncServerStreamingCall<TResponse> AsyncServerStreamingCall<TRequest, TResponse>(
            Method<TRequest, TResponse> method, string host, CallOptions options,
            TRequest request)
        {
            var call = CreateCall(method, host, options);
            return Calls.AsyncServerStreamingCall(call, request);
        }

        public override AsyncClientStreamingCall<TRequest, TResponse> AsyncClientStreamingCall<TRequest, TResponse>(
            Method<TRequest, TResponse> method, string host, CallOptions options)
        {
            var call = CreateCall(method, host, options);
            return Calls.AsyncClientStreamingCall(call);
        }

        public override AsyncDuplexStreamingCall<TRequest, TResponse> AsyncDuplexStreamingCall<TRequest, TResponse>(
            Method<TRequest, TResponse> method, string host, CallOptions options)
        {
            var call = CreateCall(method, host, options);
            return Calls.AsyncDuplexStreamingCall(call);
        }

        private CallInvocationDetails<TRequest, TResponse> CreateCall<TRequest, TResponse>(
            Method<TRequest, TResponse> method, string host, CallOptions options)
            where TRequest : class
            where TResponse : class
        {
            // var methodFullName = method.FullName;  //格式为/全类名/rpc方法，例如 /helloWorld.Greeter/SayHello
            //todo: 后续实现粒度到接口的负载均衡。要点：1、注册到接口粒度。2、此处支持接口粒度负载
            var channel = _channelManager.GetChannel(method.ServiceName);
            return new CallInvocationDetails<TRequest, TResponse>(channel, method, host, options);
        }
    }
}