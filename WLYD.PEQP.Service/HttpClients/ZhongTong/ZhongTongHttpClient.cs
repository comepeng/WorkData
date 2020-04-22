using Compeng.PEQP.Model.ExpressInferceModels.ZTO;
using Compeng.PEQP.Model.ExpressInferceModels.ZTO.Request;
using Compeng.PEQP.Model.ExpressInferceModels.ZTO.Response;
using Compeng.PEQP.Service.HttpClients.YuanTong;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Compeng.PEQP.Service.HttpClients.ZhongTong
{
    public class ZhongTongHttpClient
    {

        private readonly ILogger<ZhongTongHttpClient> _logger;
        private readonly ZhongTongApiConfig _zhongTongApiConfig;
        private readonly HttpClient _httpClient;      
        public ZhongTongHttpClient(HttpClient httpClient, ILoggerFactory loggerFactory,ZhongTongApiConfig zhongTongApiConfig)
        {
            _httpClient = httpClient;
            _logger = loggerFactory.CreateLogger<ZhongTongHttpClient>();
            _zhongTongApiConfig = zhongTongApiConfig;
        }
        /// <summary>
        ///  创建电子订单
        /// </summary>
        /// <param name="requestStr">要发送的数据</param>
        /// <returns></returns>     
        internal async Task<ZhonTongResultStatusReponse> CreateExpressOrderAsync(ZhongTongWayBillVasRequest zhongtongRequest, string msgType = "GetWayBillVasService")
        {
            zhongtongRequest.PartnerId = _zhongTongApiConfig?.CompanyID;//必要
            var requestStr = JsonConvert.SerializeObject(zhongtongRequest);
            StringContent stringContent = GetRequestContent(requestStr, msgType);
            string url = _zhongTongApiConfig?.ApiUrl + "/GetWayBillVasService";
            ZhonTongResultStatusReponse response = new ZhonTongResultStatusReponse();
            try
            {
                _logger.LogInformation($"请求地址：{url}；请求报文{requestStr}");
                var responseContent = await _httpClient.PostAsync(url, stringContent);
                var responseContentStr = await responseContent.Content.ReadAsStringAsync();
                var jSetting = new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore };
                return JsonConvert.DeserializeObject<ZhonTongResultStatusReponse>(responseContentStr, jSetting);

            }
            catch (HttpRequestException ex)
            {
                _logger.LogError($"调用{nameof(YuanTongHttpClient)}接口:{nameof(CreateExpressOrderAsync)}失败，失败原因：{ex.Message},堆栈信息：{ex.StackTrace}");
                response.Message = ex.Message;
            }
            catch (JsonSerializationException ex)
            {
                _logger.LogError($"调用{nameof(YuanTongHttpClient)}接口:{nameof(CreateExpressOrderAsync)}失败，失败原因：{ex.Message},堆栈信息：{ex.StackTrace}");
                response.Message = ex.Message;
            }
            response.Status = false;
            return response;

        }

        private StringContent GetRequestContent(string requestStr, string msgType)
        {
            string trueAppKey = _zhongTongApiConfig.AppKey;//"711c9ddcc422";// _apiInfo.AppKey;
            string trueCompanyID = _zhongTongApiConfig.CompanyID;// "d758a25c895c4845a973f5663e4b8134";//_apiInfo.UserId;
            var postDic = new Dictionary<string, string>{
                {
                    "data", requestStr
                },
                {
                    "msg_type", msgType
                },
                {
                    "company_id", trueCompanyID
                }
             };

            string dataString = GetQueryString(postDic);
            byte[] validation = GetMd5HashBytes(dataString + trueAppKey, Encoding.UTF8);
            string digest = Convert.ToBase64String(validation);
            var dec = new Dictionary<string, string>();
            dec.Add("x-companyId", trueCompanyID);
            dec.Add("x-dataDigest", digest);
            StringContent stringContent = new StringContent(dataString, Encoding.UTF8);
            stringContent.Headers.Add("x-companyId", trueCompanyID);
            stringContent.Headers.Add("x-dataDigest", digest);
            var headerType = new MediaTypeHeaderValue("application/x-www-form-urlencoded");
            headerType.CharSet = "UTF-8";
            stringContent.Headers.ContentType = headerType;
            return stringContent;
        }

        /// <summary>
        /// 获取物流信息
        /// </summary>
        /// <returns></returns>
        internal async Task<ZhonTongResultStatusReponse> GetLogisticsInfoAsync(string data, string msgType = "TRACEINTERFACE_NEW_TRACES")
        {
            StringContent stringContent = GetRequestContent(data, msgType);
            ZhonTongResultStatusReponse response = new ZhonTongResultStatusReponse();
            try
            {
                string url = _zhongTongApiConfig.ApiUrl + "/traceInterfaceNewTraces";
                var responseContent = await _httpClient.PostAsync(url, stringContent);
                var responseContentStr = await responseContent.Content.ReadAsStringAsync();
                var jSetting = new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore };
                return JsonConvert.DeserializeObject<ZhonTongResultStatusReponse>(responseContentStr, jSetting);

            }
            catch (HttpRequestException ex)
            {
                _logger.LogError($"调用{nameof(YuanTongHttpClient)}接口:{nameof(GetLogisticsInfoAsync)}失败，失败原因：{ex.Message},堆栈信息：{ex.StackTrace}");
                response.Message = ex.Message;
            }
            catch (JsonSerializationException ex)
            {
                _logger.LogError($"调用{nameof(YuanTongHttpClient)}接口:{nameof(GetLogisticsInfoAsync)}失败，失败原因：{ex.Message},堆栈信息：{ex.StackTrace}");
                response.Message = ex.Message;
            }
            response.Status = false;
            return response;
        }

        /// <summary>
        /// 开放平台签名[MD5 + BASE64]
        /// </summary>
        /// <param name="encryptStr">加密的字符串(请求数据[data] + 消息密钥[key])</param>
        /// <param name="charset">编码方式, 默认UTF-8</param>
        /// <returns></returns>
        public  byte[] GetMd5HashBytes(string input, Encoding encodeType)
        {
            MD5 md5Hash = MD5.Create();
            return md5Hash.ComputeHash(encodeType.GetBytes(input));
        }
        /// <summary>
        /// 组装QueryString的方法
        /// 参数之间用&连接，首位没有符号，如：&=1&b=2&c=3
        /// <summary>
        /// <param name="formData"></param>
        /// <returns></returns>
        public string GetQueryString(Dictionary<string, string> formData)

        {
            if (formData == null || formData.Count == 0)
            {
                return "";
            }
            StringBuilder sb = new StringBuilder();
            int i = 0;
            foreach (var kv in formData)
            {
                i++;
                sb.AppendFormat("{0}={1}", kv.Key, kv.Value);
                if (i < formData.Count)
                {
                    sb.Append("&");
                }
            }
            return sb.ToString();
        }
    }
}
