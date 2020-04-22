using AutoMapper;
using Google.Protobuf.Collections;
using System;
using System.Collections.Generic;
using Compeng.PEQP.Dto.Express.Request;
using Compeng.PEQP.Model.Enums;

namespace Compeng.PEQP.WebAPI
{
    /// <summary>
    /// dto--->grpc 对象映射
    /// </summary>
    public class MappingProfile:Profile
    {
        public MappingProfile()
        {
            CreateMap<string, ExpressCompanyCode>().ConvertUsing<StringToExpressCompanyCodeConverter>();
            CreateMap<List<ExpressAddServiceDto>,RepeatedField<ExpressAddService>>().ConvertUsing<ListToRepetedConverter>();
            CreateMap<string,decimal?>().ConvertUsing<StringToNullableDecimalConverter>();
            CreateMap<decimal?,string>().ConvertUsing<NullableDecimalToStringConverter>();
            CreateMap<CancelOrderRequestDto, CancelOrderRequest>().ForAllMembers(opt=>opt.NullSubstitute(string.Empty));//只针对string
            CreateMap<ChildrenOrderLogisticsNoRequestDto, GetChildOrderRequest>().ConvertUsing<ChildrenOrderLogisticsNoRequestDtoToChildrenOrderRequest>();
            CreateMap<ExpressReceiverDto, ExpressReceiver>();
            CreateMap<ExpressSenderDto, ExpressSender>();
            CreateMap<ExpressAddServiceDto, ExpressAddService>();
            CreateMap<ExpressCommodityDto, ExpressCommodity>();
            //创建电子面单
            CreateMap<ElectronicsurfaceRequestDto, CreateOrderRequest>();
            CreateMap<LogisticInfoRequestDto, GetLogisticsRequest>().ForAllMembers(opt => opt.NullSubstitute(string.Empty));
        }
    }
    public class ChildrenOrderLogisticsNoRequestDtoToChildrenOrderRequest : ITypeConverter<ChildrenOrderLogisticsNoRequestDto, GetChildOrderRequest>
    {
        public GetChildOrderRequest Convert(ChildrenOrderLogisticsNoRequestDto source, GetChildOrderRequest destination, ResolutionContext context)
        {
            GetChildOrderRequest getChildOrderRequest = new GetChildOrderRequest();
            getChildOrderRequest.OrderCode = source.OrderCode ?? string.Empty;
            getChildOrderRequest.ParcelQuantity = source.ParcelQuantity;
            getChildOrderRequest.ShipperCode = source.ShipperCode ?? string.Empty;
          
            return getChildOrderRequest;
        }
    }
    /// <summary>
    /// list -----> repeted
    /// </summary>
    public class ListToRepetedConverter : ITypeConverter<List<ExpressAddServiceDto>, RepeatedField<ExpressAddService>>
    {
        public RepeatedField<ExpressAddService> Convert(List<ExpressAddServiceDto> source, RepeatedField<ExpressAddService> destination, ResolutionContext context)
        {
            var a = context.Mapper.Map<List<ExpressAddServiceDto>, List<ExpressAddService>>(source);
            destination.AddRange(a);
            return destination;
        }
    }
    /// <summary>
    /// 可空decimal--->string converter
    /// </summary>
    public class NullableDecimalToStringConverter : ITypeConverter<decimal?, string>
    {
        public string Convert(decimal? source, string destination, ResolutionContext context)
        {
            if (source.HasValue)
            {
                return source.Value.ToString();
            }
            return string.Empty;
        }
    }
    /// <summary>
    /// 字符串转可空decimal
    /// </summary>
    public class StringToNullableDecimalConverter : ITypeConverter<string, decimal?>
    {
        public decimal? Convert(string source, decimal? destination, ResolutionContext context)
        {
            if (Decimal.TryParse(source, out var v))
            {
                return v;
            }

            return null;
        }
    }
    /// <summary>
    /// 字符串转快递公司编码枚举
    /// </summary>
    public class StringToExpressCompanyCodeConverter : ITypeConverter<string, ExpressCompanyCode>
    {
        public ExpressCompanyCode Convert(string source, ExpressCompanyCode destination, ResolutionContext context)
        {
            if (Enum.TryParse<ExpressCompanyCode>(source, out var code))
            {
                return code;
            }
            throw new ArgumentException("快递公司编码填写错误,请对照文档更正！");
        }
    }
}