using System;
using System.Collections.Generic;

namespace MarkLogic.Client.DataService
{
    public class SingleParameter<T> : DataServiceParameter
    {
        private Marshal _marshalledValue;

        public SingleParameter(string name, bool allowNull, T value, Func<T, Marshal> marshalValue)
            : base(name, allowNull)
        {
            _marshalledValue = marshalValue(value);
            if (!allowNull && !_marshalledValue.HasValue)
            {
                throw new ArgumentNullException(name, "Parameter does not allow null values.");
            }
        }

        public override IEnumerable<Marshal> GetMarshals()
        {
            return new[] { _marshalledValue };
        }
    }
}