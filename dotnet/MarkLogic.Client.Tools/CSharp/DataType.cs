using System;
using System.Collections.Generic;
using System.Linq;

namespace MarkLogic.Client.Tools.CSharp
{
    public class DataType
    {
        internal DataType(string name, params TypeMapping[] supportedTypes)
        {
            Name = name;
            TypeMappings = supportedTypes;
        }

        public string Name { get; }

        public IEnumerable<TypeMapping> TypeMappings { get; }

        public TypeMapping DefaultMapping => TypeMappings.First();

        public TypeMapping GetMapping(string typeFullName)
        {
            if (string.IsNullOrWhiteSpace(typeFullName))
            {
                return DefaultMapping;
            }
            var mapping = TypeMappings.FirstOrDefault(t => t.TypeFullName == typeFullName);
            return mapping ?? throw new DataTypeException(Name, typeFullName);
        }

        public static IReadOnlyDictionary<string, DataType> All => _dataTypeMap.Value;

        private static Lazy<IReadOnlyDictionary<string, DataType>> _dataTypeMap = new Lazy<IReadOnlyDictionary<string, DataType>>(() =>
        {
            var mappings = new DataType[]
            {
                new DataType("string",
                    new RefTypeMapping("string", "String", "String"),
                    new RefTypeMapping("System.IO.Stream", "StreamAsText", "Stream")),
                new DataType("boolean",
                    new ValueTypeMapping("bool", "Boolean", "Boolean"),
                    new RefTypeMapping("string", "String", "String")),
                new DataType("date",
                    new ValueTypeMapping("System.DateTime", "Date", "Date"),
                    new RefTypeMapping("string", "String", "String")),
                new DataType("time",
                    new ValueTypeMapping("System.DateTime", "Time", "Time"),
                    new RefTypeMapping("string", "String", "String")),
                new DataType("dateTime",
                    new ValueTypeMapping("System.DateTime", "DateTime", "DateTime"),
                    new RefTypeMapping("string", "String", "String")),
                new DataType("dayTimeDuration",
                    new ValueTypeMapping("System.TimeSpan", "TimeSpan", "TimeSpan"),
                    new RefTypeMapping("string", "String", "String")),
                new DataType("decimal",
                    new ValueTypeMapping("decimal", "Decimal", "Decimal"),
                    new RefTypeMapping("string", "String", "String")),
                new DataType("double",
                    new ValueTypeMapping("double", "Double", "Double"),
                    new RefTypeMapping("string", "String", "String")),
                new DataType("float",
                    new ValueTypeMapping("float", "Float", "Float"),
                    new RefTypeMapping("string", "String", "String")),
                new DataType("int",
                    new ValueTypeMapping("int", "Integer", "Integer"),
                    new RefTypeMapping("string", "String", "String")),
                new DataType("unsignedInt",
                    new ValueTypeMapping("uint", "UnsignedInteger", "UnsignedInteger"),
                    new RefTypeMapping("string", "String", "String")),
                new DataType("long",
                    new ValueTypeMapping("long", "Long", "Long"),
                    new RefTypeMapping("string", "String", "String")),
                new DataType("unsignedLong",
                    new ValueTypeMapping("ulong", "UnsignedLong", "UnsignedLong"),
                    new RefTypeMapping("string", "String", "String")),
                new DataType("array",
                    new RefTypeMapping("System.IO.Stream", "StreamAsJson", "Stream"),
                    new RefTypeMapping("Newtonsoft.Json.Linq.JArray", "JsonArray", "JsonArray"),
                    new RefTypeMapping("string", "String", "String")),
                new DataType("object",
                    new RefTypeMapping("System.IO.Stream", "StreamAsJson", "Stream"),
                    new RefTypeMapping("Newtonsoft.Json.Linq.JObject", "JsonObject", "JsonObject"),
                    new RefTypeMapping("string", "String", "String")),
                new DataType("binaryDocument",
                    new RefTypeMapping("System.IO.Stream", "StreamAsBinary", "Stream")),
                new DataType("jsonDocument",
                    new RefTypeMapping("System.IO.Stream", "StreamAsJson", "Stream"),
                    new RefTypeMapping("Newtonsoft.Json.Linq.JObject", "JsonObject", "JsonObject"),
                    new RefTypeMapping("string", "String", "String")),
                new DataType("textDocument",
                    new RefTypeMapping("System.IO.Stream", "StreamAsText", "Stream"),
                    new RefTypeMapping("string", "String", "String")),
                new DataType("xmlDocument",
                    new RefTypeMapping("System.IO.Stream", "StreamAsXml", "Stream"),
                    new RefTypeMapping("System.Xml.XmlDocument", "XmlDocument", "XmlDocument"),
                    new RefTypeMapping("System.Xml.Linq.XDocument", "XDocument", "XDocument"),
                    new RefTypeMapping("string", "String", "String"))
            };

            var map = new Dictionary<string, DataType>();
            foreach(var mapping in mappings)
            {
                map.Add(mapping.Name, mapping);
            }
            return map;
        }, true);
    }
}
