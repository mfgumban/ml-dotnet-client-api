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
            foreach(var value in values)
            {
                _marshalledValues.Add(marshalValue(value));
            }
            
            if (!allowNull && _marshalledValues.Count == 0)
            {
                throw new InvalidOperationException("Parameter does not allow null values."); // TODO: replace exception
            } 
        }

        public override IEnumerable<Marshal> GetMarshals()
        {
            return _marshalledValues;
        }
    }
}