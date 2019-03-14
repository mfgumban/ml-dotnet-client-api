using System.Linq;

namespace MarkLogic.Client.Tools.CSharp
{
    public class TypeMapping
    {
        internal TypeMapping(string typeFullName, bool isValueType, string marshalMethod, string unmarshalMethod)
        {
            TypeFullName = typeFullName;
            var nameTokens = typeFullName.Split('.');
            TypeName = nameTokens.Last();
            IsValueType = isValueType;
            Namespace = nameTokens.Length == 1 ? null : string.Join(".", nameTokens.Take(nameTokens.Length - 1));
            MarshalMethod = marshalMethod;
            UnmarshalMethod = unmarshalMethod;
        }

        public string TypeFullName { get; }

        public string TypeName { get; }

        public bool IsValueType { get; }

        public string Namespace { get; }

        public string MarshalMethod { get; }

        public string UnmarshalMethod { get; }
    }

    public class ValueTypeMapping : TypeMapping
    {
        internal ValueTypeMapping(string typeFullName, string marshalMethod, string unmarshalMethod)
            : base(typeFullName, true, marshalMethod, unmarshalMethod)
        {
        }
    }

    public class RefTypeMapping : TypeMapping
    {
        internal RefTypeMapping(string typeFullName, string marshalMethod, string unmarshalMethod)
            : base(typeFullName, false, marshalMethod, unmarshalMethod)
        {
        }
    }
}
