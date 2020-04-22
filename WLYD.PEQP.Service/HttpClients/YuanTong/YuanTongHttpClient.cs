using Compeng.PEQP.Model.ExpressInferceModels.Enums;
using Compeng.PEQP.Model.ExpressInferceModels.YTO;
using Compeng.PEQP.Model.ExpressInferceModels.YTO.Response;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Xml;

namespace Compeng.PEQP.Service.HttpClients.YuanTong
{
    public class YuanTongHttpClient
    {
        private readonly HttpClient _httpClient;
        private readonly ILogger<YuanTongHttpClient> _logger;
        private readonly YuanTongApiConfig _yuanTongApiConfig;

        public YuanTongHttpClient(HttpClient httpClient, ILoggerFactory loggerFactory,
            YuanTongApiConfig yuanTongApiConfig)
        {
            _httpClient = httpClient;
            _logger = loggerFactory.CreateLogger<YuanTongHttpClient>();
            _yuanTongApiConfig = yuanTongApiConfig;
        }

        #region Interfaces

        /// <summary>
        ///  创建电子订单
        /// </summary>
        /// <param name="xmlDataStr">要发送的数据</param>
        /// <returns></returns>
        public async Task<YuanTongOrderResponse> CreateOrderAsync(string xmlDataStr, string clientId, string partnerId)
        {
            YuanTongOrderResponse xmlResonse = null;
            byte[] strMd5 = MD5Hashing.HashString2(Encoding.UTF8, xmlDataStr + partnerId);
            string data_digest = Base64Encode.EncodeToBase64(strMd5);
            string encodeXmlDataStr = HttpUtility.UrlEncode(xmlDataStr, Encoding.UTF8);
            string urlEncodeDataDgest = HttpUtility.UrlEncode(data_digest, Encoding.UTF8);
            var requestContent =
                $"logistics_interface={encodeXmlDataStr}&data_digest={urlEncodeDataDgest}&clientId={clientId}&type=offline";
            StringContent hp = new StringContent(requestContent, Encoding.UTF8);
            var headerType = new MediaTypeHeaderValue("application/x-www-form-urlencoded");
            headerType.CharSet = "UTF-8";
            hp.Headers.ContentType = headerType;
            try
            {
                string
                    createOrderUrl =
                        _yuanTongApiConfig
                            .CommonOrderApiUrl; // _apiInfo.ApiItemInfoList.FirstOrDefault(c =>ApiConstants.ElectronicSufaceApi.Equals(c.ApiCode,StringComparison.OrdinalIgnoreCase))?.ApiUrl;
                _logger.LogInformation($"请求地址：{createOrderUrl},请求报文：{xmlDataStr}");
                var response = await _httpClient.PostAsync(createOrderUrl, hp);
                var responseContent = await response.Content.ReadAsStringAsync();
                xmlResonse = XmlParser.Deserialize<YuanTongOrderResponse>(responseContent);
            }
            catch (HttpRequestException ex)
            {
                xmlResonse = new YuanTongOrderResponse();
                xmlResonse.Success = false;
                xmlResonse.Reason = ex.Message;
                _logger.LogError($"调用创建电子面单接口失败，失败原因：{ex.Message},堆栈信息：{ex.StackTrace}");
            }
            catch (XmlException ex)
            {
                xmlResonse = new YuanTongOrderResponse();
                xmlResonse.Success = false;
                xmlResonse.Reason = ex.Message;
                _logger.LogError($"调用创建电子面单接口失败，失败原因：{ex.Message},堆栈信息：{ex.StackTrace}");
            }

            return xmlResonse;
        }

        /// <summary>
        /// 获取物流信息
        /// </summary>
        /// <param name="xmlStr"></param>
        /// <param name="method"></param>
        /// <returns></returns>
        public async Task<YuanTongLogisticsResponse> GetLogisticInfoAsync(string xmlStr,
            string method = "yto.Marketing.WaybillTrace")
        {
            string
                url = _yuanTongApiConfig
                    .ApiUrl; //_apiInfo.ApiItemInfoList.FirstOrDefault(c=>ApiConstants.LogisticApi.Equals(c.ApiCode, StringComparison.OrdinalIgnoreCase))?.ApiUrl;//物流查询api
            string requestData = InitGetLogisticsParamterAndBuildRequest(xmlStr, method);
            _logger.LogInformation($"请求报文：{requestData}");
            StringContent
                request = new StringContent(requestData,
                    Encoding.UTF8); //SetRequestHeaders(requestData, byteData, _httpClient);
            var headerType = new MediaTypeHeaderValue("application/x-www-form-urlencoded");
            headerType.CharSet = "UTF-8";
            request.Headers.ContentType = headerType;
            YuanTongLogisticsResponse yuanTongLogisticsResponse = new YuanTongLogisticsResponse();
            try
            {
                var response = await _httpClient.PostAsync(url, request);
                var responseContent = await response.Content.ReadAsStringAsync();
                if (responseContent.Contains("<WaybillProcessInfo>"))
                {
                    yuanTongLogisticsResponse.Success = true;
                    var logisticsInfo = XmlParser.Deserialize<YuanTongQueryLogisticsResponse>(responseContent);
                    yuanTongLogisticsResponse.WaybillProcessInfos = logisticsInfo.WaybillProcessInfos;
                }
                else
                {
                    var errorResp = XmlParser.Deserialize<YuanTongErrorResponse>(responseContent);
                    yuanTongLogisticsResponse.Success = false;
                    yuanTongLogisticsResponse.Reason = errorResp.Reason;
                    yuanTongLogisticsResponse.ResultCode = ExpressInterfaceResponseStatusCode.Other;
                }
            }
            catch (HttpRequestException ex)
            {
                _logger.LogError(
                    $"调用{nameof(YuanTongHttpClient)}接口:{nameof(GetLogisticInfoAsync)}失败，失败原因：{ex.Message},堆栈信息：{ex.StackTrace}");
                throw;
            }

            return yuanTongLogisticsResponse;
        }

        #endregion

        #region help methods

        /// <summary>
        /// 拼装请求数据
        /// </summary>
        /// <param name="parameters"></param>
        /// <returns></returns>
        public string buildRequestData(IDictionary<string, string> parameters)
        {
            if (parameters == null || parameters.Count == 0)
            {
                return null;
            }

            StringBuilder query = new StringBuilder();
            bool hasParam = false;

            foreach (KeyValuePair<string, string> kv in parameters)
            {
                string name = kv.Key;
                string value = kv.Value;
                if (!string.IsNullOrEmpty(name) && !string.IsNullOrEmpty(value))
                {
                    if (hasParam)
                    {
                        query.Append("&");
                    }

                    query.Append(name);
                    query.Append("=");
                    query.Append(value);
                    hasParam = true;
                }
            }

            return query.ToString();
        }

        /// <summary>
        /// 生成签名
        /// </summary>
        private string SignTopRequest(IDictionary<string, string> parameters, string secret)
        {
            // 按Key的字母顺序排序
            IDictionary<string, string> sortedParams =
                new SortedDictionary<string, string>(parameters, StringComparer.Ordinal);
            StringBuilder query = new StringBuilder();
            query.Append(secret); //将密钥放在字符串A的最前面
            foreach (KeyValuePair<string, string> kv in sortedParams)
            {
                if (!string.IsNullOrEmpty(kv.Key) && !string.IsNullOrEmpty(kv.Value))
                {
                    query.Append(kv.Key).Append(kv.Value);
                }
            }

            return GetMD5(query.ToString());
        }

        /// <summary>
        /// MD5 32位加密
        /// </summary>
        /// <param name="myString"></param>
        /// <returns></returns>
        public string GetMD5(string myString)
        {
            MD5 md5 = new MD5CryptoServiceProvider();
            byte[] fromData = Encoding.UTF8.GetBytes(myString); //
            byte[] targetData = md5.ComputeHash(fromData);
            StringBuilder stringBuilder = new StringBuilder();

            for (int i = 0; i < targetData.Length; i++)
            {
                //字节转换成字符串的时候要保证是2位宽度啊，某个字节为0转换成字符串的时候必须是00的，否则就会丢失位数啊。不仅是0，1～9也一样。
                //byte2String += targetData[i].ToString("x");//这个会丢失
                // byte2String = byte2String + targetData[i].ToString("x2");
                stringBuilder.Append(targetData[i].ToString("x2"));
            }

            return stringBuilder.ToString();
        }


        /// <summary>
        /// 设置请求头
        /// </summary>
        /// <param name="requestData"></param>
        /// <param name="byteData"></param>
        /// <param name="client"></param>
        /// <returns></returns>
        private StringContent SetRequestHeaders(string requestData, byte[] byteData, HttpClient client)
        {
            client.DefaultRequestHeaders.Clear();
            StringContent request = new StringContent(requestData, Encoding.UTF8);
            client.DefaultRequestHeaders.Add("Accept", "*/*");
            client.Timeout = TimeSpan.FromSeconds(30);
            client.DefaultRequestHeaders.Add("UserAgent",
                "Mozilla/4.0 (compatible; MSIE 6.0; Windows NT 5.1; SV1; .NET CLR 2.0.50727; .NET CLR 3.0.04506.648; .NET CLR 3.0.4506.2152; .NET CLR 3.5.30729)");
            client.DefaultRequestHeaders.Add("ContentLength", byteData.Length.ToString());
            client.DefaultRequestHeaders.Add("ContentType", "application/x-www-form-urlencoded;charset=UTF-8");
            return request;
        }

        /// <summary>
        /// 物流接口初始化参数
        /// </summary>
        /// <param name="xmlStr"></param>
        /// <param name="method"></param>
        /// <returns></returns>
        private string InitGetLogisticsParamterAndBuildRequest(string xmlStr, string method)
        {
            var parameters = new Dictionary<string, string>();
            var appKey = _yuanTongApiConfig.AppKey; //_apiInfo.AppKey;
            var userId = _yuanTongApiConfig.UserID; //_apiInfo.UserId;
            var secretKey = _yuanTongApiConfig.SecretKey; //_apiInfo.SecretKey;
            var version =
                _yuanTongApiConfig
                    .Version; //_apiInfo.ApiItemInfoList.FirstOrDefault(c=>ApiConstants.LogisticApi.Equals(c.ApiCode,StringComparison.OrdinalIgnoreCase))?.ApiVersion;
            parameters.Add("app_key", appKey);
            parameters.Add("method", method);
            parameters.Add("user_id", userId);
            parameters.Add("format", "XML");
            parameters.Add("timestamp", DateTime.Now.ToDisplayDateTime());
            parameters.Add("v", version);
            var sign = SignTopRequest(parameters, secretKey);
            parameters.Add("sign", sign.ToUpper()); //将字符串中的小写字母转成大写字母
            parameters.Add("param", xmlStr);
            var requestData = buildRequestData(parameters);
            return requestData;
        }

        #endregion
    }
}