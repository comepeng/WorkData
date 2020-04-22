using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Compeng.PEQP.Dto.SfPartner;
using Compeng.PEQP.Model.ExpressInferceModels.SfPartner;
using Microsoft.Extensions.Logging;

namespace Compeng.PEQP.Service.HttpClients.SfPartner
{
    public class SfPartnerHttpClient
    {
        private readonly HttpClient _httpClient;
        private readonly ILogger<SfPartnerHttpClient> _logger;
        private readonly SfPartnerAPIConfig _config;

        public SfPartnerHttpClient(SfPartnerAPIConfig config, ILogger<SfPartnerHttpClient> logger,
            HttpClient httpClient)
        {
            _config = config;
            _logger = logger;
            _httpClient = httpClient;
        }

        /// <summary>
        /// 运单信息查询
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public async Task<WaybillInfoResponse> GetWaybillInfoAsync(WaybillInfoRequest request)
        {
            request.PartnerId = _config.PartnerId;
            var json = request.ToJson();
            var base64 = json.Encrypt();
            var keyValuePairs = new List<KeyValuePair<string, string>>
            {
                new KeyValuePair<string, string>("param", base64)
            };
            var content = new FormUrlEncodedContent(keyValuePairs);
            //默认为失败返回
            var waybillInfoResponse = new WaybillInfoResponse();
            try
            {
                var httpResponse = await _httpClient.PostAsync(_config.ApiUrl, content);
                string responseStr = await httpResponse.Content.ReadAsStringAsync();
                var decrypt = responseStr.Decrypt();
                waybillInfoResponse = decrypt.ToObj<WaybillInfoResponse>();
            }
            catch (Exception e)
            {
                if (waybillInfoResponse.ResultObject == null)
                {
                    waybillInfoResponse.ResultObject = new ResultObject();
                }

                waybillInfoResponse.ResultObject.Message = e.Message;
                _logger.LogError(
                    $"调用{nameof(SfPartnerHttpClient)}接口:{nameof(GetWaybillInfoAsync)}失败，失败原因：{e.Message},堆栈信息：{e.StackTrace}");
            }


            return await Task.FromResult(waybillInfoResponse);
        }
    }
}