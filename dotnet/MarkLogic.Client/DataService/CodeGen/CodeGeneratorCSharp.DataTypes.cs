using System;
using System.Collections.Generic;
using System.Linq;

namespace MarkLogic.Client.DataService.CodeGen
{
    public sealed partial class CodeGeneratorCSharp
    {
        private class RawType
        {
            public RawType(string typeFullName, string marshalMethod, string unmarshalMethod)
            {
                var nameTokens = typeFullName.Split('.');
                TypeName = nameTokens.Last();
                Namespace = nameTokens.Length == 1 ? null : string.Join(".", nameTokens.Take(nameTokens.Length - 1));
                MarshalMethod = marshalMethod;
                UnmarshalMethod = unmarshalMethod;
            }

            public string TypeName { get; }

            public string Namespace { get; }

            public string MarshalMethod { get; }

            public string UnmarshalMethod { get; }
        }

        private class DataType
        {
            public DataType(string declaredType, bool isValueType, params RawType[] supportedTypes)
            {
                DeclaredType = declaredType;
                IsValueType = isValueType;
                SupportedTypes = supportedTypes;
            }

            public string DeclaredType { get; }

            public bool IsValueType { get; }

            public IEnumerable<RawType> SupportedTypes { get; }

            public RawType DefaultType => SupportedTypes.First();
        }

        private static Lazy<Dictionary<string, DataType>> _dataTypeMap = new Lazy<Dictionary<string, DataType>>(() =>
        {
            var mappings = new DataType[]
            {
                new DataType("string", false,
                    new RawType("string", "String", "String"),
                    new RawType("System.IO.Stream", "StreamAsText", "StreamAsText")),
                new DataType("boolean", true,
                    new RawType("bool", "Boolean", "Boolean"),
                    new RawType("string", "String", "String")),
                new DataType("date", true,
                    new RawType("DateTime", "Date", "Date"),
                    new RawType("string", "String", "String")),
                new DataType("time", true,
                    new RawType("DateTime", "Time", "Time"),
                    new RawType("string", "String", "String")),
                new DataType("dateTime", true,
                    new RawType("DateTime", "DateTime", "DateTime"),
                    new RawType("string", "String", "String")),
                new DataType("dayTimeDuration", true,
                    new RawType("TimeSpan", "TimeSpan", "TimeSpan"),
                    new RawType("string", "String", "String")),
                new DataType("decimal", true,
                    new RawType("decimal", "Decimal", "Decimal"),
                    new RawType("string", "String", "String")),
                new DataType("double", true,
                    new RawType("double", "Double", "Double"),
                    new RawType("string", "String", "String")),
                new DataType("float", true,
                    new RawType("float", "Float", "Float"),
                    new RawType("string", "String", "String")),
                new DataType("int", true,
                    new RawType("int", "Integer", "Integer"),
                    new RawType("string", "String", "String")),
                new DataType("unsignedInt", true,
                    new RawType("uint", "UnsignedInteger", "UnsignedInteger"),
                    new RawType("string", "String", "String")),
                new DataType("long", true,
                    new RawType("long", "Long", "Long"),
                    new RawType("string", "String", "String")),
                new DataType("ulong", true,
                    new RawType("double", "UnsignedLong", "UnsignedLong"),
                    new RawType("string", "String", "String")),
                new DataType("array", false,
                    new RawType("System.IO.Stream", "StreamAsJson", "StreamAsJson"),
                    new RawType("Newtonsoft.Json.Linq.JArray", "JsonArray", "JsonArray"),
                    new RawType("string", "String", "String")),
                new DataType("object", false,
                    new RawType("System.IO.Stream", "StreamAsJson", "StreamAsJson"),
                    new RawType("Newtonsoft.Json.Linq.JObject", "JsonObject", "JsonObject"),
                    new RawType("string", "String", "String")),
                new DataType("binaryDocument", false,
                    new RawType("System.IO.Stream", "Stream", "Stream")),
                new DataType("jsonDocument", false,
                    new RawType("System.IO.Stream", "StreamAsJson", "StreamAsJson"),
                    new RawType("Newtonsoft.Json.Linq.JObject", "JsonObject", "JsonObject"),
                    new RawType("string", "String", "String")),
                new DataType("textDocument", false,
                    new RawType("System.IO.Stream", "StreamAsText", "StreamAsText"),
                    new RawType("string", "String", "String")),
                new DataType("xmlDocument", false,
                    new RawType("System.IO.Stream", "StreamAsXml", "StreamAsXml"),
                    new RawType("string", "String", "String"))
            };

            var map = new Dictionary<string, DataType>();
            foreach(var mapping in mappings)
            {
                map.Add(mapping.DeclaredType, mapping);
            }
            return map;
        }, true);

        private static DataType MatchDataType(string declaredType)
        {
            DataType mapping;
            if (!_dataTypeMap.Value.TryGetValue(declaredType, out mapping))
            {
                throw new InvalidOperationException($"Data type {declaredType} is incorrect or unsupported.");
            }
            return mapping;
        }

        private static string GetDataType(string declaredType, bool isMultiple, bool isNullable)
        {
            var dt = MatchDataType(declaredType);
            return $"{(isMultiple ? "IEnumerable<" : "")}{dt.DefaultType.TypeName}{(isMultiple ? ">" : "")}";
        }
    }
}
