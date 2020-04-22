using System;
using System.Collections.Generic;
using AutoMapper;
using Google.Protobuf.Collections;
using Newtonsoft.Json.Converters;
using Compeng.PEQP.Model.Enums;
using Compeng.PEQP.Model.ExpressInferceModels.Request;
using Compeng.PEQP.Model.ExpressInferceModels.Response;

namespace Compeng.PEQP.GrpcService
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<string, ExpressCompanyCode>().ConvertUsing<StringToExpressCompanyCodeConverter>();
            CreateMap<string,decimal?>().ConvertUsing<StringToNullableDecimalConverter>();
            CreateMap<CancelOrderRequest, ExpressCancelOrderRequest>();
            CreateMap<CancelExpressBackResponse, ExpressBackResponse>();
            //创建电子面单
            CreateMap<CreateOrderRequest, ExpressGetElectronicsurfaceRequest>()
                .ForMember(des => des.Commodity, opt => opt.MapFrom<RepeatedFieldToListCommodityConverter>())
                .ForMember(des => des.AddService, opt => opt.MapFrom<RepeatedFieldToListAddServiceConverter>());
            CreateMap<ExpressReceiver, Model.ExpressInferceModels.Request.ExpressReceiver>();
            CreateMap<ExpressSender, Model.ExpressInferceModels.Request.ExpressSender>();
            CreateMap<ExpressAddService, Model.ExpressInferceModels.Request.ExpressAddService>();
            CreateMap<ExpressCommodity, Model.ExpressInferceModels.Request.ExpressCommodity>();
            CreateMap<ExpressGetElectronicsurfaceResponse, CreateOrderResponse>();
            CreateMap<GetChildOrderRequest, ExpressGetChildrenOrderLogisticsNoRequest>();
            CreateMap<ExpressGetChildrenOrderLogisticsNoResponse, GetChildOrderResponse>();
            CreateMap<ExpressQueryLogisticInfoResponse, GetLogisticsResponse>();
            CreateMap<GetLogisticsRequest, ExpressQueryLogisticInfoRequest>();
            CreateMap<Compeng.PEQP.Model.ExpressInferceModels.Response.ExpressTraceInfo, ExpressTraceInfo>();
        }
    }

    /// <summary>
    /// 增值服务映射gprc protobuf---->addservice-->list<service>
    /// </summary>
    public class RepeatedFieldToListAddServiceConverter : IValueResolver<CreateOrderRequest, ExpressGetElectronicsurfaceRequest, List<Model.ExpressInferceModels.Request.ExpressAddService>>
    {
        public List<Model.ExpressInferceModels.Request.ExpressAddService> Resolve(CreateOrderRequest source, ExpressGetElectronicsurfaceRequest destination, List<Model.ExpressInferceModels.Request.ExpressAddService> destMember,
            ResolutionContext context)
        {
            List<Model.ExpressInferceModels.Request.ExpressAddService> list = new List<Model.ExpressInferceModels.Request.ExpressAddService>();
            foreach (var item in source.AddService)
            {
                list.Add(new Model.ExpressInferceModels.Request.ExpressAddService()
                {
                    CustomerID = item.CustomerID,
                    Name = item.Name,
                    Value = item.Value
                  
                });
            }

            return list;
        }
    }
    /// <summary>
    /// gprc protobuf---->commiy
    /// </summary>
    public class RepeatedFieldToListCommodityConverter : IValueResolver<CreateOrderRequest, ExpressGetElectronicsurfaceRequest, List<Model.ExpressInferceModels.Request.ExpressCommodity>>
    {
       
        public List<Model.ExpressInferceModels.Request.ExpressCommodity> Resolve(CreateOrderRequest source, ExpressGetElectronicsurfaceRequest destination, List<Model.ExpressInferceModels.Request.ExpressCommodity> destMember,
            ResolutionContext context)
        {
            List<Model.ExpressInferceModels.Request.ExpressCommodity> list = new List<Model.ExpressInferceModels.Request.ExpressCommodity>();
            foreach (var item in source.Commodity)
            {
                list.Add(new Model.ExpressInferceModels.Request.ExpressCommodity()
                {
                    GoodsCode = item.GoodsCode,
                    GoodsDesc = item.GoodsDesc,
                    GoodsName = item.GoodsName,
                    GoodsPrice = context.Mapper.Map<string,decimal?>(item.GoodsPrice),
                    GoodsQuantity =item.GoodsQuantity,
                    GoodsVol = context.Mapper.Map<string,decimal?>(item.GoodsVol),
                    GoodsWeight = context.Mapper.Map<string,decimal?>(item.GoodsWeight)
                });
            }

            return list;
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