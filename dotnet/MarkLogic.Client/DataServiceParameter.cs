using System;
using System.Collections.Generic;
using MarkLogic.Client.DataService;

namespace MarkLogic.Client
{
    public abstract class DataServiceParameter
    {
        protected DataServiceParameter(string name, bool allowNull)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentNullException("name");
            }
            Name = name;
            AllowNull = allowNull;
        }

        public string Name { get; }

        public bool AllowNull { get; }

        public abstract IEnumerable<Marshal> GetMarshals();
    }
}