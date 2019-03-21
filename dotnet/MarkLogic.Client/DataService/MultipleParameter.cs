using System;
using System.Collections.Generic;
using System.Linq;

namespace MarkLogic.Client.DataService
{
    public class MultipleParameter<T> : DataServiceParameter
    {
        private List<Marshal> _marshalledValues = new List<Marshal>();

        public MultipleParameter(string name, bool allowNull, IEnumerable<T> values, Func<T, Marshal> marshalValue)
            : base(name, allowNull)
        {
            var vs = values != null ? values.ToArray() : new T[0];
            if (!allowNull && vs.Length == 0)
            {
                throw new ArgumentNullException(name, "Parameter does not allow null values.");
            }

            foreach (var value in vs)
            {
                _marshalledValues.Add(marshalValue(value));
            }
        }

        public override IEnumerable<Marshal> GetMarshals()
        {
            return _marshalledValues;
        }
    }
}