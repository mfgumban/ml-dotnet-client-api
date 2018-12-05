using System;
using System.Collections.Generic;
using MarkLogic.Client.DataService;

namespace MarkLogic.Client
{
    public abstract class DataServiceParameter
    {
        protected DataServiceParameter(string name, bool allowNull)
        {
            Name = name;
            AllowNull = allowNull;
        }

        public string Name { get; }

        public bool AllowNull { get; }

        public abstract IEnumerable<Marshal> GetMarshals();
    }
}