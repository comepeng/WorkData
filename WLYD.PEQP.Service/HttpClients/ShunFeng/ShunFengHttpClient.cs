using Compeng.OMS.BusinessModel.InterfaceModels.SF.SFQiao;
using Compeng.PEQP.Model.ExpressInferceModels.Enums;
using Compeng.PEQP.Model.ExpressInferceModels.Response;
using Compeng.PEQP.Model.ExpressInferceModels.ShunFeng;
using Compeng.PEQP.Service.HttpClients.YuanTong;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;

namespace Compeng.PEQP.Service.HttpClients.ShunFeng
{
    public class ShunFengHttpClient
    {
        private readonly HttpClient _httpClient;
        private readonly ILogger<YuanTongHttpClient> _logger;
        private readonly ShunFengApiConfig _shunFengApiConfig;
        public ShunFengHttpClient(HttpClient httpClient, ILoggerFactory loggerFactory,ShunFengApiConfig shunFengApiConfig)
        {
            _httpClient = httpClient;
            _logger = loggerFactory.CreateLogger<YuanTongHttpClient>();
            _shunFengApiConfig = shunFengApiConfig;
        }

        internal async Task<ShunFengQiaoOrderResponse> CreateOrderAsync(string requestStr)
        {
            // SFQiaoContext.Instance.ApiUrl;
            var apiUrl =_shunFengApiConfig.ApiUrl;
            StringContent stringContent = CreateSignAndBuildRequesContent(requestStr);
            ShunFengQiaoOrderResponse sFQiaoOrderResponse = new ShunFengQiaoOrderResponse();
            try
            {
                var httpResponse = await _httpClient.PostAsync(apiUrl, stringContent);
                string responseStr = await httpResponse.Content.ReadAsStringAsync();
                return HandleCreateOrderResponseStr(responseStr);
            }
            catch (HttpRequestException ex)
            {
                sFQiaoOrderResponse.Success = false;
                sFQiaoOrderResponse.Reason = ex.Message;
                _logger.LogError($"调用{nameof(ShunFengHttpClient)}接口:{nameof(CreateOrderAsync)}失败，失败原因：{ex.Message},堆栈信息：{ex.StackTrace}");
            }
            return sFQiaoOrderResponse;
        }
        /// <summary>
        /// 获取子单号
        /// </summary>
        /// <param name="requestXml"></param>
        /// <returns></returns>
        internal async Task<ExpressGetChildrenOrderLogisticsNoResponse> GetChildrenOrderLogisticsNoAsync(string requestXml)
        {
            StringContent stringContent = CreateSignAndBuildRequesContent(requestXml);
            ExpressGetChildrenOrderLogisticsNoResponse re = new ExpressGetChildrenOrderLogisticsNoResponse();
            string apiUrl = _shunFengApiConfig.ApiUrl;
            try
            {
                var httpResponse = await _httpClient.PostAsync(apiUrl, stringContent);
                string responseStr = await httpResponse.Content.ReadAsStringAsync();
                return HandleChildrenOrderReponseStr(responseStr);
            }
            catch (HttpRequestException ex)
            {
                re.Success = false;
                re.Reason = ex.Message;
                re.ResultCode = ExpressInterfaceResponseStatusCode.Other;
                _logger.LogError($"调用{nameof(ShunFengHttpClient)}接口:{nameof(GetChildrenOrderLogisticsNoAsync)}失败，失败原因：{ex.Message},堆栈信息：{ex.StackTrace}");               
            }
            return re;
        }
        /// <summary>
        /// 解析子单响应xml
        /// </summary>
        /// <param name="result"></param>
        /// <returns></returns>
        private ExpressGetChildrenOrderLogisticsNoResponse HandleChildrenOrderReponseStr(string result)
        {
            ExpressGetChildrenOrderLogisticsNoResponse response = new ExpressGetChildrenOrderLogisticsNoResponse();
            try
            {
                if (GetNodeValue(result, "Head") == "ERR")
                {
                    result = XElement.Parse(result).Value;
                    response.Success = false;
                    response.Reason = result;
                    response.ResultCode = ExpressInterfaceResponseStatusCode.Other;
                }
                else
                {
                    XmlDocument doc = new XmlDocument();
                    doc.LoadXml(result);
                    XmlNodeList rls_infoNodeList = doc.SelectNodes("//OrderZDResponse");
                    foreach (XmlNode schoolNode in rls_infoNodeList)
                    {
                        var strValue = schoolNode.Attributes["mailno_zd"]?.Value;
                        if (!string.IsNullOrEmpty(strValue))
                        {
                            response.ZDLogisticCodes = strValue;
                        }
                    }
                    response.Success = true;
                    response.ResultCode = ExpressInterfaceResponseStatusCode.Success;
                }
            }
            catch (XmlException ex)
            {
                response.Success = false;
                response.Reason = ex.Message;
                _logger.LogError($"调用{nameof(ShunFengHttpClient)}接口:{nameof(HandleChildrenOrderReponseStr)}失败，失败原因：{ex.Message},堆栈信息：{ex.StackTrace}");
            }
            return response;
        }

        /// <summary>
        /// 取消订单
        /// </summary>
        /// <param name="requestStr"></param>
        /// <returns></returns>
        internal async Task<ExpressBackResponse> CancelOrderAsync(string requestStr)
        {
            var apiUrl = _shunFengApiConfig.ApiUrl;
            var response = new ExpressBackResponse();
            StringContent stringContent = CreateSignAndBuildRequesContent(requestStr);
            try
            {
                var httpResponse = await _httpClient.PostAsync(apiUrl, stringContent);
                string responseStr = await httpResponse.Content.ReadAsStringAsync();
                return HandleCancelOrderResponse(responseStr);
            }
            catch (HttpRequestException ex)
            {
                response.Success = false;
                response.Reason = ex.Message;
                _logger.LogError($"调用{nameof(ShunFengHttpClient)}接口:{nameof(CancelOrderAsync)}失败，失败原因：{ex.Message},堆栈信息：{ex.StackTrace}");
            }
            return response;
        }
        /// <summary>
        /// 处理取消订单接口返回的内容
        /// </summary>
        /// <param name="rsponseStr"></param>
        /// <returns></returns>
        private ExpressBackResponse HandleCancelOrderResponse(string result)
        {
            var response = new ExpressBackResponse();
            try
            {
                if ("ERR".Equals(GetNodeValue(result, "Head")))
                {
                    response.Success = false;
                    response.Reason = XElement.Parse(result).Value;
                    response.ResultCode = ExpressInterfaceResponseStatusCode.Other;
                }
                else
                {
                    if (GetXmlNodeValue(result, "OrderConfirmResponse", "res_status") == "1")
                    {
                        response.Reason = "客户订单号与顺丰运单不匹配";
                        response.Success = false;
                        response.ResultCode = ExpressInterfaceResponseStatusCode.Other;
                        return response;
                    }
                    response.Success = true;
                    response.ResultCode = ExpressInterfaceResponseStatusCode.Success;
                }
            }
            catch (XmlException ex)
            {

                response.Success = false;
                response.Reason = ex.Message;
                response.ResultCode = ExpressInterfaceResponseStatusCode.Other;
            }
            return response;
        }

        private StringContent CreateSignAndBuildRequesContent(string requestStr)
        {
            //SFQiaoContext.Instance.CheckWord;
            var checkWord = _shunFengApiConfig.CheckWord;//string.Empty;
            string verifyCode = MD5ToBase64String(requestStr + checkWord);
            //ServicePointManager.ServerCertificateValidationCallback = new RemoteCertificateValidationCallback(CheckValidationResult);
            string postData = string.Format("xml={0}&verifyCode={1}", requestStr, verifyCode);
            StringContent stringContent = new StringContent(postData, Encoding.UTF8);
            var headerType = new MediaTypeHeaderValue("application/x-www-form-urlencoded");
            headerType.CharSet = "UTF-8";
            stringContent.Headers.ContentType = headerType;
            return stringContent;
        }

        internal async Task<ExpressQueryLogisticInfoResponse> GetQueryLogisticInfoAsync(string requestDataStr)
        {
            var apiUrl = _shunFengApiConfig.ApiUrl; //string.Empty;// SFQiaoContext.Instance.ApiUrl;
            StringContent stringContent = CreateSignAndBuildRequesContent(requestDataStr);
            var queryResponse = new ExpressQueryLogisticInfoResponse()
            {
                Success = true,                
                ResultCode = ExpressInterfaceResponseStatusCode.Success
            };
            try
            {
                var httpResponse = await _httpClient.PostAsync(apiUrl, stringContent);
                string result = await httpResponse.Content.ReadAsStringAsync();
                if (GetNodeValue(result, "Head") == "ERR")
                {
                   
                    queryResponse.Success = false;
                    queryResponse.Reason = XElement.Parse(result).Value;
                    queryResponse.ResultCode =  ExpressInterfaceResponseStatusCode.Other;
                    return queryResponse;
                }
                XmlDocument doc = new XmlDocument();
                doc.LoadXml(result);
                XmlNodeList rls_infoNodeList = doc.SelectNodes("//Route");
                queryResponse.Traces = new List<ExpressTraceInfo>();
                foreach (XmlNode schoolNode in rls_infoNodeList)
                {
                    // var strValue = schoolNode.Attributes["mailno_zd"]?.Value;
                    var opCode = schoolNode.Attributes["opcode"]?.Value;
                    //var status = MapSFRouteStatus(opCode);
                    var newTrace = new ExpressTraceInfo()
                    {
                        AcceptTime = schoolNode.Attributes["accept_time"]?.Value,
                        AcceptStation = schoolNode.Attributes["remark"]?.Value,
                        Location = schoolNode.Attributes["accept_address"]?.Value,
                        Status = ((int)MapSFRouteStatus(opCode)).ToString(),
                    };
                    queryResponse.Traces.Add(newTrace);
                }
            }
            catch (HttpRequestException ex)
            {
                queryResponse.Success = false;
                queryResponse.Reason = ex.Message;
                queryResponse.ResultCode = ExpressInterfaceResponseStatusCode.Other;
                _logger.LogError($"调用{nameof(ShunFengHttpClient)}接口:{nameof(GetQueryLogisticInfoAsync)}失败，失败原因：{ex.Message},堆栈信息：{ex.StackTrace}");
            }
            catch (XmlException ex)
            {
                queryResponse.Success = false;
                queryResponse.Reason = ex.Message;
                queryResponse.ResultCode = ExpressInterfaceResponseStatusCode.Other;
                _logger.LogError($"调用{nameof(ShunFengHttpClient)}接口:{nameof(GetQueryLogisticInfoAsync)}失败，失败原因：{ex.Message},堆栈信息：{ex.StackTrace}");
            }
            return queryResponse;

        }
        /// <summary>
        /// 处理顺丰路由状态码
        /// </summary>
        /// <param name="status"></param>
        /// <returns></returns>
        private OrderTrackStatuCode MapSFRouteStatus(string status)
        {
            var recieptStatus = "50";
            if (recieptStatus.Contains(status))
            {
                return OrderTrackStatuCode.HadLanShou;
            }
            var signStatus = "80,8000";
            if (signStatus.Contains(status))
            {
                return OrderTrackStatuCode.Sign;
            }
            var assignStatus = "44";
            if (assignStatus.Contains(status))
            {
                return OrderTrackStatuCode.Delivery;
            }
            var exStatus = "33";
            if (exStatus.Contains(status))
            {
                return OrderTrackStatuCode.ProblemShipment;
            }
            return OrderTrackStatuCode.OnWay;
        }
        private string GetXmlNodeValue(string strXml, string strNodeName, string strValueName)
        {
            try
            {
                var xmlDoc = new XmlDocument();
                xmlDoc.LoadXml(strXml);
                var xNode = xmlDoc.SelectSingleNode("//" + strNodeName + "");
                var strValue = xNode.Attributes[strValueName]?.Value;
                return strValue;
            }
            catch (XmlException ex)
            {
                return ex.Message;
            }
        }
        /// <summary>
        /// 读取XML资源中的指定节点内容
        /// </summary>
        /// <param name="source">XML资源</param>
        /// <param name="nodeName">节点名称</param>
        /// <returns>节点内容</returns>
        public  string GetNodeValue(string source, string nodeName)
        {
            if (source == null || nodeName == null || source == "" || nodeName == "" ||
                source.Length < nodeName.Length * 2) return null;

            var start = source.IndexOf("<" + nodeName + ">") + nodeName.Length + 2;
            var end = source.IndexOf("</" + nodeName + ">");
            if (start == -1 || end == -1)
                return null;
            if (start >= end)
                return null;
            return source.Substring(start, end - start);
        }
        private ShunFengQiaoOrderResponse HandleCreateOrderResponseStr(string result)
        {
            ShunFengQiaoOrderResponse sfQiaoResponse = new ShunFengQiaoOrderResponse();
            try
            {
                if (GetNodeValue(result, "Head") == "ERR")
                {

                    sfQiaoResponse.Result = XElement.Parse(result).Value;
                    sfQiaoResponse.Success = false;
                    sfQiaoResponse.Reason = result;
                    sfQiaoResponse.ResultCode = "105";

                    return sfQiaoResponse;
                }

                sfQiaoResponse = new ShunFengQiaoOrderResponse()
                {
                    //获取xml中orderid、mailno、destcode等节点值
                    Orderid = GetXmlNodeValue(result, "OrderResponse", "orderid"),
                    Mailno = GetXmlNodeValue(result, "OrderResponse", "mailno"),
                    Return_tracking_no = GetXmlNodeValue(result, "OrderResponse", "return_tracking_no"),
                    Filter_result = GetXmlNodeValue(result, "OrderResponse", "filter_result"),
                    Origincode = GetXmlNodeValue(result, "OrderResponse", "origincode"),
                    Destcode = GetXmlNodeValue(result, "OrderResponse", "destcode"),
                    AgentMailno = GetXmlNodeValue(result, "OrderResponse", "agentMailno"),
                    Mapping_mark = GetXmlNodeValue(result, "OrderResponse", "mapping_mark"),
                    Remark = GetXmlNodeValue(result, "OrderResponse", "remark")
                };
                sfQiaoResponse.Success = true;
                if (sfQiaoResponse.Filter_result == "3")
                {
                    sfQiaoResponse.Success = false;
                    sfQiaoResponse.Reason = "不可以指派";
                    switch (sfQiaoResponse.Remark)
                    {
                        case "1":
                            sfQiaoResponse.Reason += "，收方超范围";
                            break;
                        case "2":
                            sfQiaoResponse.Reason += "，派方超范围";
                            break;
                        default:
                            sfQiaoResponse.Reason += "，其它原因";
                            break;
                    }
                    sfQiaoResponse.ResultCode = "105";
                    return sfQiaoResponse;
                }
                if (result.Contains("rls_detail"))
                {
                    sfQiaoResponse.HasDetail = true;
                    sfQiaoResponse.Success = true;
                    sfQiaoResponse.LogisticCode = GetXmlNodeValue(result, "rls_detail", "waybillNo");
                    sfQiaoResponse.OriginTransferCode = GetXmlNodeValue(result, "rls_detail", "sourceTransferCode");
                    sfQiaoResponse.OriginCityCode = GetXmlNodeValue(result, "rls_detail", "sourceCityCode");
                    sfQiaoResponse.OriginDeptCode = GetXmlNodeValue(result, "rls_detail", "sourceDeptCode");
                    sfQiaoResponse.OriginTeamCode = GetXmlNodeValue(result, "rls_detail", "sourceTeamCode");
                    sfQiaoResponse.DestCityCode = GetXmlNodeValue(result, "rls_detail", "destCityCode");
                    sfQiaoResponse.DestDeptCode = GetXmlNodeValue(result, "rls_detail", "destDeptCode");
                    sfQiaoResponse.DestDeptCodeMapping = GetXmlNodeValue(result, "rls_detail", "destDeptCodeMapping");
                    sfQiaoResponse.DestTeamCode = GetXmlNodeValue(result, "rls_detail", "destTeamCode");
                    sfQiaoResponse.DestTeamCodeMapping = GetXmlNodeValue(result, "rls_detail", "destTeamCodeMapping");
                    sfQiaoResponse.DestTransferCode = GetXmlNodeValue(result, "rls_detail", "destTransferCode");
                    sfQiaoResponse.DestRouteLabel = GetXmlNodeValue(result, "rls_detail", "destRouteLabel");
                    sfQiaoResponse.CodingMapping = GetXmlNodeValue(result, "rls_detail", "codingMapping");
                    sfQiaoResponse.CodingMappingOut = GetXmlNodeValue(result, "rls_detail", "codingMappingOut");
                    sfQiaoResponse.XbFlag = GetXmlNodeValue(result, "rls_detail", "xbFlag");
                    sfQiaoResponse.PrintFlag = GetXmlNodeValue(result, "rls_detail", "printFlag");
                    sfQiaoResponse.TwoDimensionCode = GetXmlNodeValue(result, "rls_detail", "twoDimensionCode");
                    sfQiaoResponse.ProCode = GetXmlNodeValue(result, "rls_detail", "proCode");
                    sfQiaoResponse.PrintIcon = GetXmlNodeValue(result, "rls_detail", "printIcon");
                    sfQiaoResponse.AbFlag = GetXmlNodeValue(result, "rls_detail", "abFlag");

                }
            }
            catch (XmlException ex)
            {
                _logger.LogError($"调用{nameof(ShunFengHttpClient)}方法:{nameof(HandleCreateOrderResponseStr)}失败，失败原因：{ex.Message},堆栈信息：{ex.StackTrace}");
            }
            return sfQiaoResponse;

        }

        public static string MD5ToBase64String(string str)
        {
            MD5 md5 = new MD5CryptoServiceProvider();
            //MD5(注意UTF8编码) 
            byte[] MD5 = md5.ComputeHash(Encoding.UTF8.GetBytes(str));
            string result = Convert.ToBase64String(MD5);
            return result;
        }
    }
}
