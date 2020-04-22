using System;
using System.Text.Json;
using Bogus;
using Compeng.PEQP.Model.ExpressInferceModels.YTO.Request;
using Compeng.PEQP.Util.Converter;
using Compeng.PEQP.Util.Json;
using Compeng.PEQP.WebAPI;
using Xunit;
using Xunit.Abstractions;

namespace Compeng.PEQP.Test
{
    public class UnitTest1
    {
        private readonly ITestOutputHelper _testOutputHelper;

        public UnitTest1(ITestOutputHelper testOutputHelper)
        {
            _testOutputHelper = testOutputHelper;
        }

        [Fact]
        public void TestMockData()
        {
            var faker = new Faker<YuanTongOrderRequest>("zh_CN")
                    .RuleFor(o => o.ClientID, f => f.Random.Uuid().ToString())
                    .RuleFor(o => o.LogisticProviderID, f => "YTO" + f.Random.String2(10))
                    .RuleFor(o => o.CustomerId, (f, u) => u.ClientID)
                    .RuleFor(o => o.TxLogisticID, f => f.Finance.Iban())
                    .RuleFor(o => o.TradeNo, f => f.Finance.Iban())
                    .RuleFor(o => o.MailNo, f => f.Random.AlphaNumeric(16))
                    .RuleFor(o => o.Type, f => f.Random.Int(0, 4))
                    .RuleFor(o => o.ServiceType, f => f.PickRandomParam(0, 1, 2, 4, 8))
                    .RuleFor(o => o.TotalValue, f => f.Finance.Amount())
                    .RuleFor(o => o.Remark, f => f.Lorem.Sentence(20))
                //.RuleFor(o=>o.SendEndTime,f=>DateTime.Now)
                ;
            var request = faker.Generate();
            Assert.InRange(request.Type, 0, 4);
            Assert.Contains(request.ServiceType, new int[] {0, 1, 2, 4, 8});
            _testOutputHelper.WriteLine(request.ToJson());


            object o = 1;
            _testOutputHelper.WriteLine(o.ToJson());
            o = null;
            _testOutputHelper.WriteLine(o.ToJson());
        }
    }
}