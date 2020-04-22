using System;
using System.Text.Json;
using System.Text.Json.Serialization;
using Compeng.PEQP.Util.Extensions;

namespace Compeng.PEQP.Util.Converter
{
    public class JsonDateTimeConverter : JsonConverter<DateTime>
    {
        public override DateTime Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            return DateTime.Parse(reader.GetString());
        }

        public override void Write(Utf8JsonWriter writer, DateTime value, JsonSerializerOptions options)
        {
            //格式化为本地时间
            writer.WriteStringValue(value.ToLocalTime().ToDisplayDateTime());
        }

        public override bool CanConvert(Type typeToConvert)
        {
            return typeToConvert==typeof(DateTime);
        }
    }
}